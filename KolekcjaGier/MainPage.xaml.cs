using KolekcjaGier.ViewModels;

namespace KolekcjaGier
{
    public partial class MainPage : ContentPage
    {
        private readonly GryViewModel _viewModel;

        public MainPage(GryViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.WczytajCommand.ExecuteAsync(null);
        }
    }
}