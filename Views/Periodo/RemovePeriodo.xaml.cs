namespace SistemaAcademico.Views.Periodo;

public partial class RemovePeriodo : ContentPage
{
	public RemovePeriodo()
	{
		InitializeComponent();
	}

    private async void VoltarPeriodo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new periodos());
    }
}