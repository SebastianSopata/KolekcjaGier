using KolekcjaGier.ViewModels;

namespace KolekcjaGier;

public partial class FormularzPage : ContentPage
{
    public FormularzPage(FormularzViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}