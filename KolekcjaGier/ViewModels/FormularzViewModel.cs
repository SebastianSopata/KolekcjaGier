using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KolekcjaGier.Models;
using KolekcjaGier.Services;

namespace KolekcjaGier.ViewModels
{
    public partial class FormularzViewModel : ObservableObject, IQueryAttributable
    {
        private readonly GryBaza _baza;
        private int _id = 0;

        [ObservableProperty]
        private string _naglowekStrony = "Nowa gra";

        // Lista opcji do kontrolki Picker
        public List<string> Platformy { get; } = new() { "PC", "PS4", "PS5", "Xbox One", "Xbox Series X", "Switch" };
        public List<string> Zdjecia { get; } = new() { "wiedzmin3.jpg", "minecraft.jpg", "dotnet_bot.png" , "rdr2xbox.jpg " , "cyberpunk.jpg" };

        // Pola formularza
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ZapiszCommand))]
        private string _tytul = "";

        [ObservableProperty]
        private string _platforma = "PC";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ZapiszCommand))]
        private string _rokTekst = "";

        [ObservableProperty]
        private bool _wersjaPudelkowa = true;

        [ObservableProperty]
        private double _ocena = 8.0;

        [ObservableProperty]
        private DateTime _dataDodania = DateTime.Today;

        [ObservableProperty]
        private string _zdjecie = "dotnet_bot.png";

        // Komunikaty błędów walidacji
        [ObservableProperty]
        private string _bladTytulu = "";

        [ObservableProperty]
        private string _bladRoku = "";

        public FormularzViewModel(GryBaza baza)
        {
            _baza = baza;
            Sprawdz(); // Walidacja początkowa (pusty formularz pokaże błędy)
        }

        // Wywoływane automatycznie po zmianie Tytul lub RokTekst
        partial void OnTytulChanged(string value) => Sprawdz();
        partial void OnRokTekstChanged(string value) => Sprawdz();

        private void Sprawdz()
        {
            BladTytulu = string.IsNullOrWhiteSpace(Tytul) ? "Podaj tytuł gry" : "";

            if (!int.TryParse(RokTekst, out int rok))
                BladRoku = "Wpisz rok cyframi (np. 2015)";
            else if (rok < 1970 || rok > 2030)
                BladRoku = "Rok musi być z przedziału 1970–2030";
            else
                BladRoku = "";
        }

        private bool MoznaZapisac() =>
            string.IsNullOrEmpty(BladTytulu) && string.IsNullOrEmpty(BladRoku);

        // Odbiór gry w trybie edycji
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("EdytowanaGra", out var obiekt) && obiekt is Gra gra)
            {
                _id = gra.Id;
                NaglowekStrony = "Edycja gry";
                Tytul = gra.Tytul;
                Platforma = Platformy.Contains(gra.Platforma) ? gra.Platforma : "PC";
                RokTekst = gra.RokWydania.ToString();
                WersjaPudelkowa = gra.WersjaPudelkowa;
                Ocena = gra.Ocena;
                DataDodania = gra.DataDodania;
                Zdjecie = Zdjecia.Contains(gra.Zdjecie) ? gra.Zdjecie : "dotnet_bot.png";
            }
        }

        [RelayCommand(CanExecute = nameof(MoznaZapisac))]
        private async Task Zapisz()
        {
            var gra = new Gra
            {
                Id = _id, // 0 = wstaw nową, inne = aktualizuj istniejącą
                Tytul = Tytul.Trim(),
                Platforma = Platforma,
                RokWydania = int.Parse(RokTekst),
                WersjaPudelkowa = WersjaPudelkowa,
                Ocena = Ocena,
                DataDodania = DataDodania,
                Zdjecie = Zdjecie
            };

            await _baza.ZapiszAsync(gra);

            // Przy edycji wracamy o 2 strony (prosto na listę), przy dodawaniu o 1
            if (_id != 0)
                await Shell.Current.GoToAsync("../..");
            else
                await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task Anuluj()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}