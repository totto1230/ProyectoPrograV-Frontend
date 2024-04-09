using Login1.Utilidades;
using System.Xml.Linq;

namespace Login1.Vistas;

public partial class PerfilDriver : ContentPage
{
    public PerfilDriver()
    {
        InitializeComponent();
        Name.Text = Session.name;
        Email.Text = Session.email;
    }
    private async void IrAMainPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPageDriver());
    }

    private async void CerrarSesion_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new Login());
    }
}