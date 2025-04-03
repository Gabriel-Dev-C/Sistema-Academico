namespace SistemaAcademico.Views.Disciplina;

public partial class EditDisciplina : ContentPage
{
	public EditDisciplina()
	{
		InitializeComponent();
	}
    private async void VoltarDisciplina(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new disciplinas());
    }
}