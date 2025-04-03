using SistemaAcademico.Views.Curso;

namespace SistemaAcademico;

public partial class cursos : ContentPage
{
	public cursos()
	{
		InitializeComponent();
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
}