using SistemaAcademico.Models;
using SistemaAcademico.Views;
using System.Collections.ObjectModel;

namespace SistemaAcademico.Views.CursoPages
{
    public partial class CreateCursos : ContentPage
    {
        ObservableCollection<Curso> lista = new ObservableCollection<Curso>();

        public CreateCursos()
        {
            InitializeComponent();

            lstcursos.ItemsSource = lista;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Curso p = new Curso
                {
                    Nome = etrNomeCur.Text,
                    Sigla = etrSiglaCur.Text,
                    Obs = etrObsCur.Text
                };
                await App.Db.Insert(p);
                await DisplayAlert("Sucesso!", "Registro inserido", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops...", ex.Message, "OK");
            }
        }

        private async void txtsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string q = e.NewTextValue;
            lista.Clear();
            List<Curso> tmp = await App.Db.Search(q);
            foreach (Curso curso in tmp)
            {
                lista.Add(curso);
            }
        }

        private async void VoltarCursos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cursos());
        }
    }
}