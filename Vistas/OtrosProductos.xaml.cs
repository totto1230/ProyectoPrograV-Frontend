using Login1.ViewModels;

namespace Login1.Vistas;

public partial class OtrosProductos : ContentPage
{
	public OtrosProductos()
	{
		InitializeComponent();
        BindingContext = new OtrosProductosViewModel();
    }
    private async void IrAOtrosProductos_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OtrosProductos());
    }
    protected override async void OnAppearing()
    {

    }
}