using Login1.Models.Request;
using Login1.Models.Response;
using Newtonsoft.Json;
using System.Text;
using Login1.Utilidades;

namespace Login1.Vistas;

public partial class OlvidoContrasenaCode : ContentPage
{
    string url = Url.url;

    public OlvidoContrasenaCode()
	{
		InitializeComponent();
	}

    private async void Resetear_Clicked(object sender, EventArgs e)
    {
		try
		{
            HttpClient httpClient = new HttpClient();
            ResponseCodigoEmail res1 = new ResponseCodigoEmail();
            //Code.IsEnabled = true;
            int code = 1;
            RequestCodigo req1 = new RequestCodigo();

            if (code == 1)
            {
                code = Int32.Parse(Code.Text);
                
            }

            req1.codigo = code;
            var jsonContent1 = new StringContent(JsonConvert.SerializeObject(req1), Encoding.UTF8, "application/json");
            var response1 = await httpClient.PostAsync(url + "api/Users/passwordReset/Code", jsonContent1);

            if (response1.IsSuccessStatusCode)
            {
                
                var responseCodigo = await response1.Content.ReadAsStringAsync();
                res1 = JsonConvert.DeserializeObject<ResponseCodigoEmail>(responseCodigo);

                if (res1.Result)
                {
                    await Navigation.PushAsync(new Login());
                }
                else
                {
                    DisplayAlert("SOMETHING WENT WRONG! ", res1.Errors.First().ToString(), "OK");
                }

            }
            else
            {
                DisplayAlert("SOMETHING WENT WRONG! ", res1.Errors.First().ToString(), "OK");
            }
        }
		catch (Exception ex)
		{
            DisplayAlert("UNEXPECTED ERROR! ", ex.ToString(), "OK!");
            throw;
		}
    }
}