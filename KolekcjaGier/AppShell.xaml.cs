namespace KolekcjaGier
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Rejestracja trasy dla strony szczegółów
            Routing.RegisterRoute(nameof(SzczegolyPage), typeof(SzczegolyPage));
            Routing.RegisterRoute(nameof(FormularzPage), typeof(FormularzPage));
        }
    }
}