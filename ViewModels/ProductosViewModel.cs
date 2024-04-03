using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Login1.Models;
using Login1.Models.Response;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Text;


namespace Login1.ViewModels
{
    public partial class ProductosViewModel : ObservableObject
    {
        string url = "https://proyectov-api20240325195643.azurewebsites.net/";
        public ObservableCollection<Product> Productos { get; } = new ObservableCollection<Product>();

        public ProductosViewModel() 
        {
            Task.Run(async () => await GetProductos());
        }

        [RelayCommand]
        public async Task GetProductos()
        {
            try
            {

                //HttpClient httpClient = new HttpClient();

                //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                //var response = await httpClient.GetAsync(url + "api/Productos/obtener");

                //var request = new HttpRequestMessage
                //{
                //    Method = HttpMethod.Get,
                //    RequestUri = new Uri(url + "api/Productos/obtener"),
                //    Content = new StringContent(
                //        "{}",
                //        Encoding.UTF8,
                //        MediaTypeNames.Application.Json
                //    ),
                //};

                //if (response.IsSuccessStatusCode)
                //{
                //    var responseString = await response.Content.ReadAsStringAsync();
                //    var listaProductosApi = JsonConvert.DeserializeObject<ResponseProductos>(responseString);
                //    if (listaProductosApi != null)
                //    {
                //        for (var i = 0; i < listaProductosApi.productos.IdProducto.Length; i++)
                //        {
                //            var producto = new Product
                //            {
                //                Cantidad = listaProductosApi.productos.Cantidad[i],
                //                Name = listaProductosApi.productos.Name[i],
                //                Precio = listaProductosApi.productos.Precio[i]
                //            };

                //            Productos.Add(producto);
                //        }
                //    }
                //}

                var listaProductos = new List<Product>
                {
                    new Product
                    {
                        Name = "Producto 1",
                        Cantidad = 10,
                        Precio = 25
                    },
                    new Product
                    {
                        Name = "Producto 2",
                        Cantidad = 20,
                        Precio = 35
                    },
                    new Product
                    {
                        Name = "Producto 3",
                        Cantidad = 15,
                        Precio = 42
                    },
                    new Product
                    {
                        Name = "Producto 4",
                        Cantidad = 8,
                        Precio = 18
                    },
                    new Product
                    {
                        Name = "Producto 5",
                        Cantidad = 10,
                        Precio = 27
                    },
                    new Product
                    {
                        Name = "Producto 6",
                        Cantidad = 10,
                        Precio = 10
                    },
                    new Product
                    {
                        Name = "Producto 7",
                        Cantidad = 10,
                        Precio = 8
                    },
                    new Product
                    {
                        Name = "Producto 8",
                        Cantidad = 10,
                        Precio = 12
                    },
                    new Product
                    {
                        Name = "Producto 9",
                        Cantidad = 10,
                        Precio = 25
                    },
                    new Product
                    {
                        Name = "Producto 10",
                        Cantidad = 10,
                        Precio = 6
                    },
                    new Product
                    {
                        Name = "Producto 11",
                        Cantidad = 10,
                        Precio = 11
                    },
                };

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
