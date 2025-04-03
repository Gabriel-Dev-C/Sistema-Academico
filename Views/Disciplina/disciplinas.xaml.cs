using SistemaAcademico.Views.Disciplina;

namespace SistemaAcademico;

public partial class disciplinas : ContentPage
{
	public disciplinas()
	{
		InitializeComponent();
	}

    private async void CreateDisc(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateDisciplina());
    }

    private async void EditDisciplina(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditDisciplina());
    }

    private async void RemoveDisciplina(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RemoveDisciplina());
    }
}