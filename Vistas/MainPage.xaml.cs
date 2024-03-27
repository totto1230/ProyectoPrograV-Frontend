namespace Login1.Vistas;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
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
    private async void IrADesechables_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Desechables());
    }
    private async void IrAOtrosProductos_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OtrosProductos());
    }
}    