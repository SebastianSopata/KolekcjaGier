namespace KolekcjaGier
{
    [QueryProperty(nameof(GraId), "id")]
    public partial class SzczegolyPage : ContentPage
    {
        public string GraId
        {
            set => NumerWyswietlacz.Text = $"Wybrano grê o numerze ID: {value}";
        }

        public SzczegolyPage()
        {
            InitializeComponent();
        }

        private async void OnWrocClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}