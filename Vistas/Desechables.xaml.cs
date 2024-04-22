using Login1.Models;
using Login1.ViewModels;
using System.Windows.Input;

namespace Login1.Vistas
{
    public partial class Desechables : ContentPage
    {
        public Desechables()
        {
            InitializeComponent();
            // Establecer el contexto de enlace para la p�gina
            BindingContext = new DesechablesViewModel();
        }

        // Otros m�todos para navegar a otras p�ginas 
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
}
