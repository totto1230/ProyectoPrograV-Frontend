using Login1.ViewModels;

namespace Login1.Vistas;

public partial class OtrosProductos : ContentPage
{
	public OtrosProductos()
	{
		InitializeComponent();
        BindingContext = new OtrosProductosViewModel();
    }

    private async void IrACarrito_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Carrito());
    }
    private async void IrAMainPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
    private async void IrAPerfil_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Perfil());
    }
}