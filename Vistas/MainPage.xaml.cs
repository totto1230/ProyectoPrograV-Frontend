using Login1.Models.Request;
using Login1.Models.Response;
using Newtonsoft.Json;
using System.Text;

namespace Login1.Vistas;

public partial class MainPage : ContentPage
{
    string url = "http://172.210.102.217/";

    public MainPage()
	{
		InitializeComponent();
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