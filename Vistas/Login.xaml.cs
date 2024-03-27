using Login1.Models;
using Login1.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Login1.Vistas;

public partial class Login : ContentPage
{
    string url = "https://proyectov-api20240325195643.azurewebsites.net/";

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

                if (res.Result)
                {
                    DisplayAlert("WELCOME! " , res.Message.ToString(), "GO!");

                    await Navigation.PushAsync(new MainPage());

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




