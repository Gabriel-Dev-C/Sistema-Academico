using SistemaAcademico.Views;

namespace SistemaAcademico.Views.DisciplinaPages
{
    public partial class Disciplinas : ContentPage
    {
        public Disciplinas()
        {
            InitializeComponent();
        }

        private async void CreateDisc(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateDisciplina());
        }
    }
}