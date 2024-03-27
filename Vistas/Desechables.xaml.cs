namespace Login1.Vistas;

public partial class Desechables : ContentPage
{
	public Desechables()
	{
		InitializeComponent();
	}
    private async void IrADesechables_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Desechables());
    }
}