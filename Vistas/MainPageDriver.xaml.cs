using Login1.ViewModels;

namespace Login1.Vistas;

public partial class MainPageDriver : ContentPage
{
	public MainPageDriver()
	{
		InitializeComponent();
        BindingContext = new MainDriverViewModel();
    }

    private async void IrAPerfil_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PerfilDriver());
    }
}