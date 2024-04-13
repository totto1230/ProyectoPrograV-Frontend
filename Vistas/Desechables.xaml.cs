using Login1.ViewModels;

namespace Login1.Vistas;

public partial class Desechables : ContentPage
{
	public Desechables()
	{
		InitializeComponent();
        BindingContext = new DesechablesViewModel();
    }

    protected override async void OnAppearing()
    {
        
    }

    private void AgregarCarrito_Clicked(object sender, EventArgs e)
    {

    }
}