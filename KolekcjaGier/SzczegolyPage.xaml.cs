using KolekcjaGier.ViewModels;

namespace KolekcjaGier
{
    public partial class SzczegolyPage : ContentPage
    {
        public SzczegolyPage(SzczegolyViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}