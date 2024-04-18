using Login1.Utilidades;

namespace Login1.Vistas;

public partial class MainPageAdmin : ContentPage
{
 
	public MainPageAdmin()
	{
		InitializeComponent();
	}

    private async void Status_Clicked(object sender, EventArgs e)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(Url.python);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (responseBody == null)
                    {
                        StatusCheck.status = "Health endpoint down!!";
                    }
                    else if (responseBody == " Haven't tried yet!")
                    {
                        StatusCheck.status = "Health endpoint down!!";
                    }
                    else if (responseBody == "All the endpoints are working fine! ")
                    {
                        StatusCheck.status = responseBody;
                    }
                    else
                    {
                        StatusCheck.status = responseBody;
                    }
                }
                else
                {
                    StatusCheck.status = "Health endpoint down!!";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

            await Navigation.PushAsync(new Status());
    }

    private async void Inventory_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Inventario());
    }
}