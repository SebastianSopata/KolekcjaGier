using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KolekcjaGier.Models;

namespace KolekcjaGier.ViewModels
{
    public partial class SzczegolyViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Gra? _gra;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("WybranaGra", out var value) && value is Gra gra)
            {
                Gra = gra;
            }
        }

        [RelayCommand]
        private async Task Wroc()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}