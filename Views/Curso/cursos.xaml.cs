using SistemaAcademico.Views;
using SistemaAcademico.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SistemaAcademico;

public partial class cursos : ContentPage
{
    ObservableCollection<Curso> lista = new ObservableCollection<Curso>();

    public cursos()
    {
        InitializeComponent();

        lstcursos.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {
        List<Curso> tmp = await App.Db.GetAll();
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

                await carregarListaCursos();
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

        await carregarListaCursos();
    }

    /*
    private void MenuItem_Clicked(object sender, EventArgs e)
    {
    }
    private async void CreateCurso(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateCursos());
    }

    private async void EditCurso(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditCursos());
    }

    private async void RemoveCurso(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RemoveCursos());
    }
    */
}