namespace SistemaAcademico;

public partial class Cadastrar : ContentPage
{
	public Cadastrar()
	{
		InitializeComponent();
	}

    private async void Voltar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}