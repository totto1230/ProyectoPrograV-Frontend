using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Login1.Models.Entidades;

namespace Login1.ViewModels
{
    public class CarritoViewModel
    {
        public ICommand MostrarCarritoCommand { get; }

        public CarritoViewModel()
        {
            MostrarCarritoCommand = new RelayCommand(MostrarCarrito);
        }

        private void MostrarCarrito()
        {
            // Lógica para mostrar los productos en el carrito
            foreach (var producto in CarritoCompra.ProductosCarrito)
            {
                Console.WriteLine($"Producto: {producto.Name}, Precio: {producto.Precio}");
            }
        }
    }
}
