namespace KolekcjaGier
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnRzeczTapped(object sender, TappedEventArgs e)
        {
            string numer = e.Parameter?.ToString() ?? "0";
            await Shell.Current.GoToAsync($"{nameof(SzczegolyPage)}?id={numer}");
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Kolekcja Gier", "Już wkrótce!", "OK");
        }
    }
}