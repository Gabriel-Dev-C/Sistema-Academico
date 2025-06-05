using SistemaAcademico.Models;

namespace SistemaAcademico;

public partial class CreateCursos : ContentPage
{
	public CreateCursos()
	{
		InitializeComponent();
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

    private async void VoltarCursos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new cursos());
    }
}