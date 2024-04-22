using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Login1.Models;
using Login1.Models.Entidades;
using System.Collections.ObjectModel;

namespace Login1.ViewModels
{
    public partial class CarritoViewModel : ObservableObject
    {
        public ObservableCollection<ProductoCarrito> ProductosCarrito { get; } = new ObservableCollection<ProductoCarrito>();

        public CarritoViewModel()
        {
            ArmarObjetosCarrito();
        }

        private void ArmarObjetosCarrito()
        {
            foreach(var productoCarrito in CarritoCompra.ProductosCarrito)
            {
                ProductosCarrito.Add(productoCarrito);
            }
        }

        [RelayCommand]
        public void EliminarProductoCarrito(ProductoCarrito productoCarrito)
        {
            CarritoCompra.ProductosCarrito.Remove(productoCarrito);
            ProductosCarrito.Remove(productoCarrito);
        }
    }
}
