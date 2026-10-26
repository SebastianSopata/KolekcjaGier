using System.Collections.ObjectModel;
using KolekcjaGier.Models;

namespace KolekcjaGier
{
    public partial class MainPage : ContentPage
    {
        // Kolekcja naszych gier
        public ObservableCollection<Gra> Gry { get; } = new()
        {
            new Gra { Tytul = "Wiedźmin 3: Dziki Gon", Platforma = "PS4", RokWydania = 2015, WersjaPudelkowa = true, Ocena = 10.0, DataDodania = new DateTime(2021, 5, 10), Zdjecie = "wiedzmin3.jpg" },
            new Gra { Tytul = "Minecraft", Platforma = "PC", RokWydania = 2011, WersjaPudelkowa = false, Ocena = 9.0, DataDodania = new DateTime(2018, 8, 15), Zdjecie = "minecraft.jpg" },
            new Gra { Tytul = "Cyberpunk 2077", Platforma = "PS5", RokWydania = 2020, WersjaPudelkowa = true, Ocena = 8.5, DataDodania = new DateTime(2023, 1, 5), Zdjecie = "cyberpunk.jpg" },
            new Gra { Tytul = "Red Dead Redemption 2", Platforma = "Xbox One", RokWydania = 2018, WersjaPudelkowa = true, Ocena = 9.5, DataDodania = new DateTime(2021, 11, 20), Zdjecie = "rdr2xbox.jpg" },
      
        };

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this; // Wiązania na stronie szukają danych w tym pliku
        }

        // Obsługa kliknięcia (dotknięcia) w konkretną grę
        private async void OnGraWybrana(object? sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is not Gra wybranaGra)
                return;

            // Przejście do szczegółów z przekazaniem całego obiektu gry
            await Shell.Current.GoToAsync(nameof(SzczegolyPage), new ShellNavigationQueryParameters { ["WybranaGra"] = wybranaGra });

            // Wyzerowanie zaznaczenia
            ((CollectionView)sender!).SelectedItem = null;
        }

        // Przycisk dodawania nowej gry do kolekcji
        private void OnDodajClicked(object? sender, EventArgs e)
        {
            Gry.Add(new Gra
            {
                Tytul = "Hades",
                Platforma = "PC",
                RokWydania = 2020,
                WersjaPudelkowa = false,
                Ocena = 9.5,
                DataDodania = DateTime.Now,
                Zdjecie = "dotnet_bot.png"
            });
        }
    }
}