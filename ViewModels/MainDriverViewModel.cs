using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Login1.Models;
using Login1.Models.Entidades;
using Login1.Models.Request;
using Login1.Models.Response;
using Login1.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace Login1.ViewModels
{
    public partial class MainDriverViewModel : ObservableObject
    {
        [ObservableProperty]
        bool mostrarSpinner;
        [ObservableProperty]
        bool mostrarBuscarOrden;
        [ObservableProperty]
        bool mostrarAceptarOrden;
        [ObservableProperty]
        bool mostrarOrdenAceptada;
        [ObservableProperty]
        string cantidadProductosText;
        public ObservableCollection<OrdenA> Orden { get; } = new ObservableCollection<OrdenA>();
        public ObservableCollection<OrdenA> OrdenActual { get; set; } = new ObservableCollection<OrdenA>();

        int idOrdenn = 0;

        string url = Url.url;
        public MainDriverViewModel()
        {
            MostrarSpinner = false;
            MostrarBuscarOrden = true;
            MostrarAceptarOrden = false;
            MostrarOrdenAceptada = false;
            GetOrden();
        }

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
                    idOrdenn = i + 1;
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

        [RelayCommand]
        public async Task BuscarOrden()
        {
            MostrarBuscarOrden = false;
            MostrarSpinner = true;
            await Task.Delay(2000);
            MostrarSpinner = false;
            var r = new Random();
            var rInt = r.Next(0, Orden.Count + 1);
            if (OrdenActual.Count == 0)
            {
                OrdenActual.Add(Orden.ElementAt(rInt));
            }
            else
            {
                OrdenActual.Clear();
                OrdenActual.Add(Orden.ElementAt(rInt));
            }
            
            MostrarAceptarOrden = true;
        }

        [RelayCommand]
        public async Task AceptarOrden()
        {
            MostrarAceptarOrden = false;
            MostrarSpinner = true;
            await Task.Delay(2000);
            MostrarSpinner = false;
            MostrarOrdenAceptada = true;
        }

        [RelayCommand]
        public async Task CancelarOrden()
        {
            MostrarAceptarOrden = false;
            MostrarBuscarOrden = true;
        }

        [RelayCommand]
        public async Task TerminarViaje()
        {
            MostrarSpinner = true;
            MostrarOrdenAceptada = false;
            await Task.Delay(2000);
            MostrarSpinner = false;
            MostrarBuscarOrden = true;

            try
            {
                RequestOrdenActivaCompletar req = new RequestOrdenActivaCompletar();
                req.completar.completada = true;
                req.completar.numDriver = Session.number;
                req.completar.idOrden = idOrdenn;
                req.completar.fecha = DateTime.Now;

                var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();

                var response = await httpClient.PostAsync(url + "api/OrdenActiva/completar", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    ResponseOrdenActivaCompletar res = new ResponseOrdenActivaCompletar();
                    var responseOrdenCompletar = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<ResponseOrdenActivaCompletar>(responseOrdenCompletar);
                     res.Errors = new List<string>();

                    if (res.Result)
                    {
                        //All good!
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await Application.Current.MainPage.DisplayAlert(" ", res.Message, "OK!");
                        });
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await Application.Current.MainPage.DisplayAlert("UNEXPECTED ERROR! ", res.Message, "OK!");
                        });
                    }

                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("UNEXPECTED ERROR! ", " Error ", "OK!");
                    });
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
    }
}

