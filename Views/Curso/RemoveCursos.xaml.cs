namespace SistemaAcademico.Views.Curso;

public partial class RemoveCursos : ContentPage
{
	public RemoveCursos()
	{
		InitializeComponent();
	}

    private async void VoltarCursos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new cursos());
    }
}