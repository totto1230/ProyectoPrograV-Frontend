using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Login1.Models;
using Login1.Models.Entidades;
using Login1.Models.Response;
using Login1.Utilidades;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text;

namespace Login1.ViewModels
{
    public partial class MainDriverViewModel : ObservableObject
    {
        //[ObservableProperty]
        //bool mostrarSpinner;
        //[ObservableProperty]
        //bool mostrarBuscarOrden;
        //[ObservableProperty]
        //bool mostrarAceptarOrden;
        //[ObservableProperty]
        //bool mostrarOrdenAceptada;
        //[ObservableProperty]
        //string cantidadProductosText;
        public ObservableCollection<OrdenA> Orden { get; } = new ObservableCollection<OrdenA>();

        public MainDriverViewModel()
        {
            //MostrarSpinner = false;
            //MostrarBuscarOrden = true;
            //MostrarAceptarOrden = false;
            //MostrarOrdenAceptada = false;
            GetOrden();
        }

        [RelayCommand]
        public void GetOrden()
        {
            try
            {
                int cantidadOrdenes = (OrdenesActivas.ordenes.CantidadProductosxOrden.Length), i = 0;
    

                var listaOrdenes = new List<OrdenA>();
                while (i < cantidadOrdenes)
                {
                    
                    listaOrdenes.Add(new OrdenA
                    {
                        NumeroCliente = OrdenesActivas.ordenes.NumeroCliente[i],
                        NombreProductos = setName(OrdenesActivas.ordenes.CantidadProductosxOrden[i]),
                        Cantidad = OrdenesActivas.ordenes.Cantidad[i],
                        Coordenadas = OrdenesActivas.ordenes.Cantidad[i],
                        TotalComprarOrden = OrdenesActivas.ordenes.TotalComprarOrden[i],
                        CostoViaje = OrdenesActivas.ordenes.CostoViaje[i],
                        NumOrder= i + 1
                    });
                    i++;
                }
                foreach (var x in listaOrdenes)
                {
                    Orden.Add(x);
                }
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("UNEXPECTED ERROR! ", ex.ToString(), "OK!");
                });
                throw;
            }
        }


        public string setName(int cantidadXOrden)
        {
            // Ensure cantidadXOrden does not exceed the length of the array
            cantidadXOrden = Math.Min(cantidadXOrden, OrdenesActivas.ordenes.NombreProductos.Length);

            // Extract the first cantidadXOrden elements from the array
            string[] productos = OrdenesActivas.ordenes.NombreProductos.Take(cantidadXOrden).ToArray();

            // Join the elements into a single string separated by commas
            return string.Join(", ", productos);
        }

        //public string setCantidad(int cantidadXOrden)
        //{
        //    cantidadXOrden = Math.Min(cantidadXOrden, OrdenesActivas.ordenes.Cantidad.Length);

        //    // Extract the first cantidadXOrden elements from the array
        //    string[] cantidad = OrdenesActivas.ordenes.Cantidad.Take(cantidadXOrden).ToArray();

        //    // Join the elements into a single string separated by commas
        //    return string.Join(", ", cantidad);
        //}




        //    [RelayCommand]
        //public async Task ToggleMostrarSpinner()
        //{
        //    MostrarBuscarOrden = false;
        //    MostrarSpinner = true;
        //    LlenarProductosOrden();
        //    await Task.Delay(2000);
        //    // Llamar API para buscar orden...
        //    //try
        //    //{
        //    //    HttpClient httpClient = new HttpClient();

        //    //    MostrarSpinner = true;
        //    //    var response = await httpClient.GetAsync(Url.url + "api/OrdenActiva/obtener");

        //    //    if (response.IsSuccessStatusCode)
        //    //    {
        //    //        var res = new ResponseOrdenActiva();
        //    //        var responseLogin = await response.Content.ReadAsStringAsync();
        //    //        res = JsonConvert.DeserializeObject<ResponseOrdenActiva>(responseLogin);

        //    //        if (res.Result)
        //    //        {
        //    //            foreach(var producto in res.Productos)
        //    //            {
        //    //                Productos.Add(producto);
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            // False desde el API
        //    //            MostrarBuscarOrden = true;
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        // Hubo un error en el API...
        //    //        MostrarBuscarOrden = true;
        //    //    }

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    // Hubo un error en el API...
        //    //    throw;
        //    //}
        //    //finally
        //    //{
        //    //    MostrarSpinner = false;
        //    //}
        //    MostrarAceptarOrden = false;
        //    MostrarSpinner = false;
        //}

        //[RelayCommand]
        //public async Task AceptarOrden()
        //{
        //    MostrarAceptarOrden = false;
        //    MostrarSpinner = true;
        //    await Task.Delay(2000);
        //    MostrarSpinner = false;
        //    MostrarOrdenAceptada = true;
        //}

        //[RelayCommand]
        //public async Task CancelarOrden()
        //{
        //    Productos.Clear();
        //    MostrarAceptarOrden = false;
        //    MostrarBuscarOrden = true;
        //}

        //[RelayCommand]
        //public async Task TerminarViaje()
        //{
        //    Productos.Clear();
        //    MostrarSpinner = true;
        //    MostrarOrdenAceptada = false;
        //    await Task.Delay(2000);
        //    MostrarSpinner = false;
        //    MostrarBuscarOrden = true;
        //}

        //private void LlenarProductosOrden()
        //{
        //    Productos.Clear();
        //    Productos.Add(new Product
        //    {
        //        Name = "Rose Milk Tea",
        //        Cantidad = 2,
        //    });
        //    Productos.Add(new Product
        //    {
        //        Name = "Lavender Milk",
        //        Cantidad = 1,
        //    });
        //    Productos.Add(new Product
        //    {
        //        Name = "Almond Milk",
        //        Cantidad = 2,
        //    });
        //    Productos.Add(new Product
        //    {
        //        Name = "Honey Lemonade",
        //        Cantidad = 3,
        //    });
        //    Productos.Add(new Product
        //    {
        //        Name = "Jasmine Tea",
        //        Cantidad = 1,
        //    });

        //    int? cantidadProductos = 0;

        //    foreach(var product in Productos)
        //    {
        //        cantidadProductos += product.Cantidad;
        //    }

        //    CantidadProductosText = "Cantidad de productos: " + cantidadProductos;
        //}
    }
}

