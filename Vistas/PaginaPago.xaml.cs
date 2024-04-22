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

        // Verificar si alguno de los campos est� vac�o
        if (string.IsNullOrWhiteSpace(nombreTarjeta) ||
            string.IsNullOrWhiteSpace(numeroTarjeta) ||
            string.IsNullOrWhiteSpace(fechaExpiracion) ||
            string.IsNullOrWhiteSpace(cvc))
        {
            // Mostrar mensaje de error si alg�n campo est� vac�o
            await DisplayAlert("Error", "Por favor, completa todos los campos", "OK");
            return; // Salir del m�todo sin procesar el pago
        }

       

        // Mostrar un mensaje de pago completado con �xito
        await DisplayAlert("Pago completado", "El pago se ha completado con �xito", "OK");

        // Navegar de regreso a la p�gina de inicio
        await Navigation.PushAsync(new MainPage());
    }
}