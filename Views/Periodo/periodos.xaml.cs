namespace SistemaAcademico;

public partial class periodos : ContentPage
{
	public periodos()
	{
		InitializeComponent();
	}

	private async void CreatePeriodo(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new createperiodo());
    }
}