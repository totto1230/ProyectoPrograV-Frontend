using Login1.Models.Request;
using Login1.Models.Response;
using Newtonsoft.Json;
using System.Text;

namespace Login1.Vistas;

public partial class OlvidoContrasena : ContentPage
{
    string url = "https://proyectov-api20240405215800.azurewebsites.net/";

    public OlvidoContrasena()
	{
        InitializeComponent();
	}

    private async void Resetear_Clicked(object sender, EventArgs e)
    {
		try
		{
            HttpClient httpClient = new HttpClient();
            RequestPasswordReset req = new RequestPasswordReset();
            req.reset = new Models.Entidades.PasswordReset();
			req.reset.Number = NumberTxtReset.Text;
			req.reset.Email = EmailTxtReset.Text;
			req.reset.Password = PasswordTxtReset.Text;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url + "api/Users/passwordReset", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                ResponsePasswordReset res = new ResponsePasswordReset();
                var responsePwReset = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<ResponsePasswordReset>(responsePwReset);

                if (res.Result)
                {
                    DisplayAlert(" ", "Validated correctly! Proceed with the recover", "GO!");

                    await Navigation.PushAsync(new OlvidoContrasenaCode());
                }
                else
                {
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
}