namespace Login1.Vistas;


public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();

       
    }

    private async void CreateAccount_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearNuevo());
    }
}




