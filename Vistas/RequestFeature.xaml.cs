using Login1.Models;
using Login1.Models.Response;
using Login1.Utilidades;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Maui.Controls.Xaml;
using Login1.Models.Request;
using System;


namespace Login1.Vistas;

public partial class RequestFeature : ContentPage
{
    string url = Url.url;

    public RequestFeature()
	{
        InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        RequestFeatureRequest req = new RequestFeatureRequest();
        req.fr = new Models.FeatureRequest();
        req.fr.titulo = TitleEntry.Text;
        req.fr.descripcion = DescriptionEditor.Text;
        req.fr.contactAdmin = Session.email;
        HttpClient httpClient = new HttpClient();

        
        try
		{
            var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url + "api/Admin/featureRequest", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                ResponseFeatureRequest res = new ResponseFeatureRequest();
                var responseFR = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<ResponseFeatureRequest>(responseFR);
                res.Errors = new List<string>();

                if (res.Result)
                {
                    TitleEntry.Text = "";
                    DescriptionEditor.Text = "";
                    DisplayAlert("Success! ", res.Message.ToString(), "GO!");
                    await Navigation.PushAsync(new MainPageAdmin());
                }
                else
                {
                    DisplayAlert("Failed! ", res.Errors.ToString(), "Ok!");
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
  