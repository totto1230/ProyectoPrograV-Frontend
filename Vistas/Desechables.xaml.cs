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

        // M�todo que se ejecuta cuando se hace clic en el bot�n "Agregar al carrito"
        private void AgregarAlCarrito_Clicked(object sender, EventArgs e)
        {
            // Obtener el producto asociado al bot�n
            var button = (Button)sender;
            var product = (Product)button.CommandParameter;

            // Obtener el ViewModel de la p�gina
            var viewModel = (DesechablesViewModel)BindingContext;

            // Ejecutar el comando para agregar el producto al carrito
            viewModel.AgregarProductoCarritoCommand.Execute(product);
        }

        // Otros m�todos para navegar a otras p�ginas (si los tienes)
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
