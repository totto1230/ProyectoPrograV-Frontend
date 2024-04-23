using Login1.Models;
using Login1.Models.Entidades;
using Login1.Models.Request;
using Login1.Models.Response;
using Login1.Utilidades;
using Newtonsoft.Json;
using System.Text;

namespace Login1.Vistas;

public partial class PaginaPago : ContentPage
{
    string url = Url.url;

    public PaginaPago()
	{
		InitializeComponent();
	}

    private async void Pagar_Clicked(object sender, EventArgs e)
    {
        // Obtener los valores de los campos de entrada
        string nombreTarjeta = nombreEntry.Text;
        string numeroTarjeta = numeroEntry.Text;

        string fechaExpiracionn = anoEntry.Text + "-" + monthEntry.Text + "-" + dayEntry.Text;
        DateTime fechaExpiration = DateTime.Parse(fechaExpiracionn).Date;
        string cvc = cvcEntry.Text;

        // Verificar si alguno de los campos est� vac�o
        if (string.IsNullOrWhiteSpace(nombreTarjeta) ||
            string.IsNullOrWhiteSpace(numeroTarjeta) ||
            string.IsNullOrWhiteSpace(fechaExpiracionn) ||
            string.IsNullOrWhiteSpace(cvc))
        {
            // Mostrar mensaje de error si alg�n campo est� vac�o
            await DisplayAlert("Error", "Por favor, completa todos los campos", "OK");
            return; // Salir del m�todo sin procesar el pago
        }
        else
        {
            RequestOrden req = new RequestOrden();
            req.order = new Orden();
            req.order.Numero = Session.number;
            req.order.IdProducto = IdsCarrito.ids;
            req.order.Cantidad = llenarCantidad();
            req.order.coordenadas = [2.0, 3.0];
            req.order.NumeroTar = numeroTarjeta;
            req.order.code = cvc;
            req.order.expiration = fechaExpiration;
            HttpClient httpClient = new HttpClient();

            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url + "api/Order/validate", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    ResponseOrder res = new ResponseOrder();
                    var responseOrder = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<ResponseOrder>(responseOrder);
                    res.Errors = new List<string>();

                    if (res.Result)
                    {
                        // Mostrar un mensaje de pago completado con �xito
                        await DisplayAlert("Pago completado", res.Message, "OK");

                        CarritoCompra.ProductosCarrito.Clear();

                        // Navegar de regreso a la p�gina de inicio
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Failed! ", "Review your card details and make sure you have enough money!", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error de conexion", "Error al encontrar el endpoint", "Aceptar");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }

    public int?[] llenarCantidad()
    {
        int?[] arrayCantidad = new int?[IdsCarrito.ids.Length];
        int i = 0;

        while (i < IdsCarrito.ids.Length)
        {
            arrayCantidad[i] = 1;
            i++;
        }
        
        return arrayCantidad;
    }
}