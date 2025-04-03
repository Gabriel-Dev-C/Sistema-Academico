namespace SistemaAcademico.Views.Curso;

public partial class EditCursos : ContentPage
{
	public EditCursos()
	{
		InitializeComponent();
	}

    private async void VoltarCursos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new cursos());
    }
}