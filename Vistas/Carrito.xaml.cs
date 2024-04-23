using Login1.Models.Entidades;
using Login1.Utilidades;
using Login1.ViewModels;
using System.Text;

namespace Login1.Vistas;

public partial class Carrito : ContentPage
{
	public Carrito()
	{
		InitializeComponent();
        BindingContext = new CarritoViewModel();
    }
    private async void IrAMainPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
   
    private async void IrAPerfil_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Perfil());
    }
    private async void IrACarrito_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Carrito());
    }

    private async void IrAPaginaPago_Clicked(object sender, EventArgs e)
    {
        // Navegar a la página PaginaPago
        await Navigation.PushAsync(new PaginaPago());
    }

}