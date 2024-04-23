using Login1.Utilidades;


namespace Login1.Vistas;

public partial class Perfil : ContentPage
{
	public Perfil()
	{
		InitializeComponent();
        Name.Text = Session.name;
        Email.Text = Session.email;
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

    private async void CerrarSesion_Clicked(object sender, EventArgs e)
    {
     
        Session.name = null; 
        Session.typeU = null;
        Session.email = null;

        await Navigation.PushAsync(new Login());
    }

}