using Login1.Utilidades;

namespace Login1.Vistas;

public partial class MainPageAdmin : ContentPage
{
 
	public MainPageAdmin()
	{
		InitializeComponent();
	}

    private async void Status_Clicked(object sender, EventArgs e)
    {
            await Navigation.PushAsync(new Status());
    }

    private async void Inventory_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Inventario());
    }

    private async void RequestFeature_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RequestFeature());
    }

    private async void LogOut_Clicked(object sender, EventArgs e)
    {
        Session.name = null;
        Session.typeU = null;
        Session.email = null;
        await Navigation.PushAsync(new Login());
    }
}