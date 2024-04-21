using Login1.Models.Request;
using Login1.Models.Response;
using Login1.Utilidades;
using Newtonsoft.Json;
using System;

namespace Login1.Vistas;

public partial class MainPageAdmin : ContentPage
{
    string url = Url.url;

    public MainPageAdmin()
	{
		InitializeComponent();
	}

    private async void Status_Clicked(object sender, EventArgs e)
    {
            await Navigation.PushAsync(new Status());
    }

    private async void Inventory_Clicked(object sender, EventArgs e)
    {
        try
        {
            RequestProductosAdmin req = new RequestProductosAdmin();
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url + "api/Admin/ProductosObtener");

            if (response.IsSuccessStatusCode)
            {
                ResponseProductosAdmin res = new ResponseProductosAdmin();
                var responseProductosAdminn = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<ResponseProductosAdmin>(responseProductosAdminn);

                if (!res.Result)
                {
                    DisplayAlert("SOMETHING WENT WRONG! ", res.Errors.First().ToString(), "OK");

                }
                else
                {
                    ProductosDisponiblesAdmin.productos = res.productos;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }


        await Navigation.PushAsync(new Inventario());
    }

    private async void RequestFeature_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RequestFeature());
    }

    private async void LogOut_Clicked(object sender, EventArgs e)
    {
        Session.name = null;
        Session.typeU = null;
        Session.email = null;
        await Navigation.PushAsync(new Login());
    }
}