namespace SistemaAcademico.Views.Periodo;

public partial class EditPeriodo : ContentPage
{
	public EditPeriodo()
	{
		InitializeComponent();
	}

    private async void VoltarPeriodo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new periodos());
    }
}