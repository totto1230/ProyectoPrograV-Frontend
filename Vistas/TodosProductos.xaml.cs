using Login1.Models.Entidades;
using Login1.Utilidades;
using Login1.ViewModels;

namespace Login1.Vistas;

public partial class TodosProductos : ContentPage
{
	public TodosProductos()
	{
		InitializeComponent();
        //DisplayAlert(" ", ProductosDisponibles.productos.IdProducto.Length.ToString() + " " + ProductosDisponibles.productos.Name.Length.ToString(), " ok ");
        BindingContext = new TodosLosProductosViewModel();
    }
    protected override async void OnAppearing()
    {

    }
}