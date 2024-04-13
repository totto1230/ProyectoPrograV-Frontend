using Login1.Models;
using Login1.Models.Response;
using Login1.Utilidades;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Maui.Controls.Xaml;


namespace Login1.Vistas;

public partial class Login : ContentPage
{
    string url = Url.url;

    public Login()
	{
		InitializeComponent();
    }

    private async void CreateAccount_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearNuevo());
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
        try
        {
            Requestlogin req = new Requestlogin();
            req.user = new Models.Login();
            req.user.Number = NumberTxt.Text;
            req.user.Password = PasswordTxt.Text;

            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(url+"api/Users/validate", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                ResponseLogin res = new ResponseLogin();
                var responseLogin = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<ResponseLogin>(responseLogin);
                res.Errors = new List<string>();

                if (res.Result)
                {
                    DisplayAlert("WELCOME! " , res.Message.ToString(), "GO!");
                    Session.name = res.name;
                    Session.typeU = res.typeU;
                    Session.email = res.email;

                    //Pantalla Christopher
                    if (Session.typeU == 'D')
                    {
                        //Driver Page
                        await Navigation.PushAsync(new MainPageDriver());
                        
                    }
                    else if (Session.typeU == 'U')
                    {
                        var response1 = await httpClient.GetAsync(url + "api/Productos/obtener");

                        if (response1.IsSuccessStatusCode)
                        {
                            ResponseProductos res1 = new ResponseProductos();
                            var responseProductos = await response1.Content.ReadAsStringAsync();
                            res1 = JsonConvert.DeserializeObject<ResponseProductos>(responseProductos);

                            if (!res.Result)
                            {
                                DisplayAlert("SOMETHING WENT WRONG! ", res.Errors.First().ToString(), "OK");

                            }
                            else
                            {
                                ProductosDisponibles.productos = res1.productos;

                                int i = 0;
                                Popular.id = new int?[4];
                                while (i < 4)
                                {
                                    Array.Sort(ProductosDisponibles.productos.IdProducto);
                                    Array.Sort(ProductosDisponibles.productos.Cantidad);
                                    Array.Reverse(ProductosDisponibles.productos.IdProducto);
                                    Array.Reverse(ProductosDisponibles.productos.Cantidad);
                                    Popular.id[i] = ProductosDisponibles.productos.IdProducto[i];
                                    i++;
                                }
                                //DisplayAlert("", Popular.id[0].ToString() + Popular.id[1].ToString() + Popular.id[2].ToString() + Popular.id[3].ToString(), "OK");

                            }
                            await Navigation.PushAsync(new MainPage());
                        }
                    }
                    else if (Session.typeU == 'A')
                    {
                        await Navigation.PushAsync(new MainPageAdmin());
                    }
                    else
                    {
                        DisplayAlert("SOMETHING WENT WRONG! ", " Invalid User type", "OK");
                    }

                }
                else {

                    DisplayAlert("SOMETHING WENT WRONG! ", res.Errors.First().ToString(), "OK");
                }
            }
            else
            {
                await DisplayAlert("Error de conexion", "Error al encontrar el endpoint", "Aceptar");
            }

        }
        catch (Exception ex)
        {
            DisplayAlert("UNEXPECTED ERROR! ", ex.ToString(), "OK!");
            throw;
        }

    }

    private async void OlvidarContrasena_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OlvidoContrasena());
    }
}




