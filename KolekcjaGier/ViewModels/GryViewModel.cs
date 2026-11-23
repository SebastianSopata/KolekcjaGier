using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KolekcjaGier.Models;
using KolekcjaGier.Services;

namespace KolekcjaGier.ViewModels
{
    public partial class GryViewModel : ObservableObject
    {
        public ObservableCollection<Gra> Gry { get; } = new();

        [ObservableProperty]
        private int _liczbaGier;

        private readonly GryBaza _baza;

        public GryViewModel(GryBaza baza)
        {
            _baza = baza;
        }

        [RelayCommand]
        private async Task Wczytaj()
        {
            var lista = await _baza.PobierzWszystkieAsync();
            Gry.Clear();
            foreach (var g in lista)
                Gry.Add(g);

            LiczbaGier = Gry.Count;
        }

        [RelayCommand]
        private async Task Dodaj()
        {
            await Shell.Current.GoToAsync(nameof(FormularzPage));
        }

        [RelayCommand]
        private async Task PokazSzczegoly(Gra gra)
        {
            if (gra == null) return;

            await Shell.Current.GoToAsync(nameof(SzczegolyPage), new ShellNavigationQueryParameters { ["WybranaGra"] = gra });
        }
    }
}