using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KolekcjaGier.Models;
using KolekcjaGier.Services;

namespace KolekcjaGier.ViewModels
{
    public partial class SzczegolyViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Gra? _gra;

        private readonly GryBaza _baza;

        public SzczegolyViewModel(GryBaza baza)
        {
            _baza = baza;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("WybranaGra", out var value) && value is Gra gra)
            {
                Gra = gra;
            }
        }

        [RelayCommand]
        private async Task Edytuj()
        {
            if (Gra is null) return;
            await Shell.Current.GoToAsync(nameof(FormularzPage), new ShellNavigationQueryParameters { ["EdytowanaGra"] = Gra });
        }

        [RelayCommand]
        private async Task Wroc()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task Usun()
        {
            if (Gra is null) return;

            bool tak = await Shell.Current.DisplayAlert("Usunąć?", Gra.Tytul, "Tak", "Nie");
            if (!tak) return;

            await _baza.UsunAsync(Gra);
            await Shell.Current.GoToAsync("..");
        }
    }
}