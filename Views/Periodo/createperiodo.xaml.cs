namespace SistemaAcademico;

public partial class createperiodo : ContentPage
{
	public createperiodo()
	{
		InitializeComponent();
	}

    private async void VoltarPeriodo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new periodos());
    }
}