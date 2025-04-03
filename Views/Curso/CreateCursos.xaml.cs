namespace SistemaAcademico;

public partial class CreateCursos : ContentPage
{
	public CreateCursos()
	{
		InitializeComponent();
	}

    private async void VoltarCursos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new cursos());
    }
}