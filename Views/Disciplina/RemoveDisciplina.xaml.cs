namespace SistemaAcademico.Views.Disciplina;

public partial class RemoveDisciplina : ContentPage
{
	public RemoveDisciplina()
	{
		InitializeComponent();
	}

    private async void VoltarDisciplina(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new disciplinas());
    }
}