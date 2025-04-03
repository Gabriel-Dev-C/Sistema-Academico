using SistemaAcademico.Views.Periodo;

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

    private async void EditPeriodo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditPeriodo());
    }

    private async void RemovePeriodo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RemovePeriodo());
    }
}
