using Login1.Models;
using Login1.Models.Entidades;
using Login1.Utilidades;
using Login1.ViewModels;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Login1.Vistas;

public partial class TodosProductos : ContentPage
{
    //public ObservableCollection<Product> Productos { get; } = new ObservableCollection<Product>();

    public TodosProductos()
	{
		InitializeComponent();
        //DisplayAlert(" ", ProductosDisponibles.productos.IdProducto.Length.ToString() + " " + ProductosDisponibles.productos.Name.Length.ToString(), " ok ");
        BindingContext = new TodosLosProductosViewModel();
    }
    protected override async void OnAppearing()
    {

    }

    private void AgregarCarrito_Clicked(object sender, EventArgs e)
    {
        //TodosLosProductosViewModel viewModel = (TodosLosProductosViewModel)BindingContext;

        // Access the Productos collection
        //ObservableCollection<Product> productos = viewModel.Productos;

        //if (viewModel != null && viewModel.Productos != null && viewModel.Productos.Count > 0)
        //{
        //    // Access the Productos collection
        //    ObservableCollection<Product> productos = viewModel.Productos;

        //    // Assuming you want to add the first product to ProductosCarrito
        //    Product firstProduct = productos[0];

        //    // Add the first product's name to ProductosCarrito
        //    ProductosCarrito.productosCarrito.Name[0] = firstProduct.Name;

        //    DisplayAlert(" ", ProductosCarrito.productosCarrito.Name[0].ToString(), " ok");
        //}
        //else
        //{
        //    // Handle the case when the productos collection is empty
        //}
    }
}