using SistemaAcademico.Views.DisciplinaPages;

namespace SistemaAcademico;

public partial class CreateDisciplina : ContentPage
{
	public CreateDisciplina()
	{
		InitializeComponent();
	}

    private async void VoltarDisc(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Disciplinas());
    }
}