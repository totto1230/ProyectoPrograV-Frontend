using Login1.Models;
using Login1.Models.Entidades;
using Login1.Utilidades;
using Login1.ViewModels;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Text;

namespace Login1.Vistas;

public partial class MainPageDriver : ContentPage
{
	public MainPageDriver()
	{
		InitializeComponent();
        BindingContext = new MainDriverViewModel();
    }

    private async void PerfilDriver_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PerfilDriver());
    }

    private async void LogOut_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }

    private async void IrAPerfil_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PerfilDriver());
    }
}