using KolekcjaGier.Models;

namespace KolekcjaGier
{
    [QueryProperty(nameof(Gra), "WybranaGra")]
    public partial class SzczegolyPage : ContentPage
    {
        public Gra Gra { set => BindingContext = value; }

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