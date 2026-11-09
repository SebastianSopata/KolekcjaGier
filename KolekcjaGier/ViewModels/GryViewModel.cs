using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KolekcjaGier.Models;

namespace KolekcjaGier.ViewModels
{
    public partial class GryViewModel : ObservableObject
    {
        public ObservableCollection<Gra> Gry { get; } = new()
        {
            new Gra { Tytul = "Wiedźmin 3: Dziki Gon", Platforma = "PS4", RokWydania = 2015, WersjaPudelkowa = true, Ocena = 10.0, DataDodania = new DateTime(2021, 5, 10), Zdjecie = "wiedzmin3.jpg" },
            new Gra { Tytul = "Minecraft", Platforma = "PC", RokWydania = 2011, WersjaPudelkowa = false, Ocena = 9.0, DataDodania = new DateTime(2018, 8, 15), Zdjecie = "minecraft.jpg" },
            new Gra { Tytul = "Cyberpunk 2077", Platforma = "PS5", RokWydania = 2020, WersjaPudelkowa = true, Ocena = 8.5, DataDodania = new DateTime(2023, 1, 5), Zdjecie = "cyberpunk.jpg" },
            new Gra { Tytul = "Red Dead Redemption 2", Platforma = "Xbox One", RokWydania = 2018, WersjaPudelkowa = true, Ocena = 9.5, DataDodania = new DateTime(2021, 11, 20), Zdjecie = "rdr2xbox.jpg" },
            new Gra { Tytul = "Stardew Valley", Platforma = "Switch", RokWydania = 2016, WersjaPudelkowa = false, Ocena = 9.0, DataDodania = new DateTime(2023, 3, 12), Zdjecie = "dotnet_bot.png" }
        };

        [ObservableProperty]
        private int _liczbaGier;

        public GryViewModel()
        {
            LiczbaGier = Gry.Count;
        }

        [RelayCommand]
        private void Dodaj()
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

            LiczbaGier = Gry.Count;
        }

        [RelayCommand]
        private async Task PokazSzczegoly(Gra gra)
        {
            if (gra == null) return;

            await Shell.Current.GoToAsync(nameof(SzczegolyPage), new ShellNavigationQueryParameters { ["WybranaGra"] = gra });
        }
    }
}