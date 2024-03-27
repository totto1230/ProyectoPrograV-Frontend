using Login1.ViewModels;

namespace Login1.Vistas;

public partial class Desechables : ContentPage
{
	public Desechables()
	{
		InitializeComponent();
        BindingContext = new ProductosViewModel();
    }

    protected override async void OnAppearing()
    {
        
    }
}