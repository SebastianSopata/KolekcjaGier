namespace KolekcjaGier
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Kolekcja Gier", "Już wkrótce!", "OK");
        }
    }
}