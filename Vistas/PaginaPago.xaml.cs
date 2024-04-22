namespace Login1.Vistas;

public partial class PaginaPago : ContentPage
{
	public PaginaPago()
	{
		InitializeComponent();
	}

    private async void Pagar_Clicked(object sender, EventArgs e)
    {
        // Obtener los valores de los campos de entrada
        string nombreTarjeta = nombreEntry.Text;
        string numeroTarjeta = numeroEntry.Text;
        string fechaExpiracion = fechaEntry.Text;
        string cvc = cvcEntry.Text;

        // Verificar si alguno de los campos está vacío
        if (string.IsNullOrWhiteSpace(nombreTarjeta) ||
            string.IsNullOrWhiteSpace(numeroTarjeta) ||
            string.IsNullOrWhiteSpace(fechaExpiracion) ||
            string.IsNullOrWhiteSpace(cvc))
        {
            // Mostrar mensaje de error si algún campo está vacío
            await DisplayAlert("Error", "Por favor, completa todos los campos", "OK");
            return; // Salir del método sin procesar el pago
        }

       

        // Mostrar un mensaje de pago completado con éxito
        await DisplayAlert("Pago completado", "El pago se ha completado con éxito", "OK");

        // Navegar de regreso a la página de inicio
        await Navigation.PushAsync(new MainPage());
    }
}