using KolekcjaGier.ViewModels;

namespace KolekcjaGier
{
    public partial class MainPage : ContentPage
    {
        public MainPage(GryViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}