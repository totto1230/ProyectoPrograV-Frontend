using Login1.Models;
using Login1.Models.Request;
using Login1.Models.Response;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;
using Login1.Utilidades;
using Login1.Models.Entidades;


namespace Login1.Vistas;

public partial class CrearNuevo : ContentPage
{
    string url = Url.url;
    string urlURi = Url.imageURl;
    string number;

    public CrearNuevo()
	{
		InitializeComponent();

        Picker picker = new Picker { Title = "Seleccione un rol" };
        picker.ItemsSource = new List<string>
{
    "Usuario Regular",
    "Driver"
};
    }

    private async void Registrar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string? typeUConvert = typeU.SelectedItem.ToString();
            RequestRegistration req = new RequestRegistration();
            req.user = new User();
            req.user.Name = NombreTxt.Text;
            req.user.Password = PasswordTxt.Text;
            req.user.Email = EmailTxt.Text;
            req.user.TypeU = GetTypeU(typeUConvert);
            req.user.Number = NumberTxt.Text;

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

    private char GetTypeU(string? typeUConvert)
    {
        char typeU = 'X';
        if (typeUConvert == "Usuario Regular")
        {
            typeU = 'U';
        }
        else if (typeUConvert == "Driver")
        {
            typeU = 'D';
        }

        return typeU;
    }

    private async void Upload_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            PickOptions options = new PickOptions()
            {
                PickerTitle = "Select a file"
            };


            var result = await FilePicker.Default.PickAsync(options);
            using var fileStream = File.OpenRead(result.FullPath);
            byte[] byteArray;

            using (var memoryStream = new  MemoryStream())
            {
                await fileStream.CopyToAsync(memoryStream);
                byteArray = memoryStream.ToArray();
            }

            if (byteArray == null)
            {
                Session.imageUrl = "https://storage.googleapis.com/proyectoprograv/Profile/usuario.png";
            }
            else
            {
                RequestUploadImage req = new RequestUploadImage();
                req.image = new Models.ImageUpload();
                string numeroIngresado = NumberTxt.Text;
                req.image.Name = numeroIngresado;
                req.image.File = byteArray;
                req.image.Type = "image/jpg";
                HttpClient httpClient = new HttpClient();

                try
                {
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(urlURi + "api/Admin/UploadImage", jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        ResponseUploadImage res = new ResponseUploadImage();
                        var responseIU = await response.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<ResponseUploadImage>(responseIU);
                        res.Errors = new List<string>();

                        if (res.Result)
                        {
                            Session.imageUrl = res.url;
                            await DisplayAlert("Success! ", res.Message.ToString(), "GO!");
                        }
                        else
                        {
                            await DisplayAlert("Failed! ", res.Errors.ToString(), "Ok!");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Failed! ", "TRY AGAIN LATER!", "Ok!");
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
}