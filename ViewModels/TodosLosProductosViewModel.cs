using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Login1.Models;
using Login1.Models.Entidades;
using Login1.Utilidades;
using System.Collections.ObjectModel;


namespace Login1.ViewModels
{
    public partial class TodosLosProductosViewModel : ObservableObject
    {
        [ObservableProperty]
        bool mostrarProductoAgregadoText;
        public ObservableCollection<Product> Productos { get; } = new ObservableCollection<Product>();

        public TodosLosProductosViewModel() 
        {
            MostrarProductoAgregadoText = false;
            Task.Run(async () => await GetProductos());
        }

        [RelayCommand]
        public async void AgregarProductoCarrito(Product product)
        {
            MostrarProductoAgregadoText = true;
            if (CarritoCompra.ProductosCarrito.Exists(x => x.IdProducto.Equals(product.IdProducto)))
            {
                CarritoCompra.ProductosCarrito.First(x => x.IdProducto.Equals(product.IdProducto)).CantidadEnCarrito += 1;
            }
            else
            {
                CarritoCompra.ProductosCarrito.Add(new ProductoCarrito
                {
                    Cantidad = product.Cantidad,
                    CantidadEnCarrito = 1,
                    Categoria = product.Categoria,
                    IdProducto = product.IdProducto,
                    Name = product.Name,
                    Precio = product.Precio,
                    UrlImage = product.UrlImage,
                });
            }
            await Task.Delay(2000);
            MostrarProductoAgregadoText = false;
        }


        [RelayCommand]
        public async Task GetProductos()
        {
            try
            {
                int cantidadProductos = ProductosDisponibles.productos.Cantidad.Length, i = 0;
                var listaProductos = new List<Product>();
                string categoria = " ";
                while (i < cantidadProductos)
                {
                    switch (ProductosDisponibles.productos.Categoria[i])
                    {
                        case 'B':
                            categoria = "BOBBA";
                            break;
                        case 'D':
                            categoria = "DESECHABLE";
                            break;
                        case 'O':
                            categoria = "OTHER";
                            break;
                        default:
                            await Shell.Current.DisplayAlert("UNEXPECTED ERROR! ", " INVALID CATEGORY" , "OK!");
                            break;
                    }
                    listaProductos.Add(new Product
                    {
                        IdProducto = ProductosDisponibles.productos.IdProducto[i],
                        Name = ProductosDisponibles.productos.Name[i],
                        Cantidad = ProductosDisponibles.productos.Cantidad[i],
                        Precio = ProductosDisponibles.productos.Precio[i],
                        Categoria = categoria,
                        UrlImage = Images.url[i]
                    });
                    i++;
                }

                foreach (var product in listaProductos)
                {
                    Productos.Add(product);
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("UNEXPECTED ERROR! ", ex.ToString(), "OK!");
                throw;
            }
        }
    }
}
