using SistemaAcademico.Views;
using SistemaAcademico.Models;
using System.Collections.ObjectModel;

namespace SistemaAcademico.Views.CursoPages
{
    public partial class Cursos : ContentPage
    {
        ObservableCollection<Curso> lista = new ObservableCollection<Curso>();

        public Cursos()
        {
            InitializeComponent();

            lstcursos.ItemsSource = lista;
        }

        protected override void OnAppearing()
        {
            carregarLista();
        }

        private async void carregarLista()
        {
            List<Curso> tmp = await App.Db.GetAll();

            lista.Clear();

            foreach (Curso curso in tmp)
            {
                lista.Add(curso);
            }
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new CreateCursos());
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
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

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuItem selecionado = sender as MenuItem;
                Curso p = selecionado.BindingContext as Curso;
                bool confirmacao = await DisplayAlert(
                "Confirmação", "Confirma a remoção?", "Sim", "Não");
                if (confirmacao == true)
                {
                    await App.Db.Delete(p.Codigo);
                    lista.Remove(p);

                    await DisplayAlert("Sucesso", "Registro removido com sucesso!", "OK");

                    OnAppearing();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void lstcursos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                Curso p = e.SelectedItem as Curso;
                txtCodigo.Text = p.Codigo.ToString();
                txtNome.Text = p.Nome.ToString();
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void btnLimpar_Clicked(object sender, EventArgs e)
        {
            txtCodigo.Text = String.Empty;
            txtNome.Text = String.Empty;
        }

        private async Task btnAlterar_Clicked(object sender, EventArgs e)
        {
            if (txtCodigo.Text == String.Empty)
            {
                DisplayAlert("Atenção", "Campo código obrigatório", "OK");
            }

            Curso p = new Curso();
            p.Codigo = int.Parse(txtCodigo.Text);
            p.Nome = txtNome.Text;
            p.Sigla = txtSigla.Text;

            await App.Db.Update(p);
            await DisplayAlert("Sucesso", "Registro alterado com sucesso!", "OK");

            OnAppearing();
        }
    }
}