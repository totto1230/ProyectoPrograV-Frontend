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
            // Establecer el contexto de enlace para la página
            BindingContext = new DesechablesViewModel();
        }

        // Método que se ejecuta cuando se hace clic en el botón "Agregar al carrito"
        private void AgregarAlCarrito_Clicked(object sender, EventArgs e)
        {
            // Obtener el producto asociado al botón
            var button = (Button)sender;
            var product = (Product)button.CommandParameter;

            // Obtener el ViewModel de la página
            var viewModel = (DesechablesViewModel)BindingContext;

            // Ejecutar el comando para agregar el producto al carrito
            viewModel.AgregarProductoCarritoCommand.Execute(product);
        }

        // Otros métodos para navegar a otras páginas (si los tienes)
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
