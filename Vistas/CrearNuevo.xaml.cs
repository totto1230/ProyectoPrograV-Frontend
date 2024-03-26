using Login1.Models;
using Login1.Models.Request;
using Login1.Models.Response;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Login1.Vistas;

public partial class CrearNuevo : ContentPage
{
    string url = "https://proyectov-api20240325195643.azurewebsites.net/";

    public CrearNuevo()
	{
		InitializeComponent();
	}

    private async void Registrar_Clicked(object sender, EventArgs e)
    {
        try
        {
            RequestRegistration req = new RequestRegistration();
            req.user = new User();
            req.user.Name = NombreTxt.Text;
            req.user.Password = PasswordTxt.Text;
            req.user.Email = EmailTxt.Text;
            req.user.TypeU = 'a';
            req.user.Number = "111111111";
            //req.user.TypeU = TypeUTxt.Text;
            //req.user.Number = NumberTxt.Text;


            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(url+"api/Users/create", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                ResponseRegistration res = new ResponseRegistration();
                var responseRegistration = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<ResponseRegistration>(responseRegistration);

                if (res.Result)
                {
                    DisplayAlert("Welcome! ", res.Message.ToString() + " YOU WILL BE REDIRECTED TO THE LOGIN, USE YOUR CREDENTIALS! ", "GO!");
                    await Navigation.PushAsync(new Login());

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