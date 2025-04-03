namespace SistemaAcademico;

public partial class cursos : ContentPage
{
	public cursos()
	{
		InitializeComponent();
	}

    private async void CreateCursos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateCursos());
    }
}