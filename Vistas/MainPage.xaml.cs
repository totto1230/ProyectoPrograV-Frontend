using Login1.Models.Request;
using Login1.Models.Response;
using Newtonsoft.Json;
using System.Text;
using Login1.Utilidades;
using System.Diagnostics;

namespace Login1.Vistas;

public partial class MainPage : ContentPage
{
    string url = Url.url;

    public MainPage()
	{
        
        InitializeComponent();
        Image1.Source = ImageSource.FromUri(new Uri(Images.url[(int)Popular.id[0] - 1 ]));
        Image2.Source = ImageSource.FromUri(new Uri(Images.url[(int)Popular.id[1] - 1]));
        Image3.Source = ImageSource.FromUri(new Uri(Images.url[(int)Popular.id[2] - 1]));
        Image4.Source = ImageSource.FromUri(new Uri(Images.url[(int)Popular.id[3] - 1]));

    }
    

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
    private async void IrADesechables_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Desechables());
    }
    private async void IrAOtrosProductos_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OtrosProductos());
    }
    private async void TodosLosProductos_Clicked(object sender, EventArgs e)
    {
        try
        {
            //RequestProductos req = new RequestProductos();
            //var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url + "api/Productos/obtener");

            if (response.IsSuccessStatusCode)
            {
                ResponseProductos res = new ResponseProductos();
                var responseProductos = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<ResponseProductos>(responseProductos);

                if (!res.Result)
                {
                    DisplayAlert("SOMETHING WENT WRONG! ", res.Errors.First().ToString(), "OK");

                }
                else
                {
                    ProductosDisponibles.productos = res.productos;
                    await Navigation.PushAsync(new TodosProductos());
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