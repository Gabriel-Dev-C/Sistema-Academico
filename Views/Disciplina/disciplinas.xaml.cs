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
}