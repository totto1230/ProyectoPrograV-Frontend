using Login1.ViewModels;

namespace Login1.Vistas;

public partial class MainPageDriver : ContentPage
{
	public MainPageDriver()
	{
		InitializeComponent();
        BindingContext = new MainDriverViewModel();
    }

    private void AceptarViajeClicked(object sender, EventArgs e)
    {

    }

    private void BuscarViajesClicked(object sender, EventArgs e)
    {
        
    }
}