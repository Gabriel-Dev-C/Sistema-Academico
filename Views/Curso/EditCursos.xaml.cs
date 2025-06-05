using System.Collections.ObjectModel;
using SistemaAcademico.Models;
using SistemaAcademico.Views;

namespace SistemaAcademico.Views.Curso.EditCursos
{
    public partial class EditCursos : ContentPage
    {
        ObservableCollection<Curso> listaCursos = new ObservableCollection<Curso>();
        public EditCursos()
        {
            InitializeComponent();

            picCursos.ItemsSource = listaCursos;
            picCursos.ItemDisplayBinding = new Binding("Nome");
        }

        protected override void OnAppearing()
        {
            carregarCursos();

            //Posiciona no item desejado
            var curso = this.BindingContext as Curso;
            picCursos.SelectedItem = curso;
        }
        private async void carregarCursos()
        {
            List<Curso> tmp = await App.Db.GetAll();
            listaCursos.Clear();
            foreach (Curso curso in tmp)
            {
                listaCursos.Add(curso);
            }
        }
        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private async void btnAlterar_Clicked(object sender, EventArgs e)
        {
            if (picCursos.SelectedIndex == -1)
            {
                await DisplayAlert("Atenção!", "Selecione um curso", "OK");
            }
            else
            {
                // Obtém o curso selecionado
                var cursoSelecionado = (Curso)picCursos.SelectedItem;

                // Atualiza as propriedades desejadas
                cursoSelecionado.Nome = txtNome.Text

                await App.Db.Update(cursoSelecionado);
                await DisplayAlert("Sucesso!", "Registro alterado", "OK");
            }
        }

        private async void VoltarCursos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new cursos());
        }
    }
}