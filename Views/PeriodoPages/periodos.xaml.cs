using SistemaAcademico.Views;

namespace SistemaAcademico.Views.PeriodoPages
{
    public partial class Periodos : ContentPage
    {
        public Periodos()
        {
            InitializeComponent();
        }

        private async void CreatePeriodo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new createperiodo());
        }
    }
}
