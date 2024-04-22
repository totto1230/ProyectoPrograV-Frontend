using Login1.Models.Request;
using Login1.Models.Response;
using Login1.Utilidades;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Login1.Vistas;

public partial class Inventario : ContentPage
{
    string url = Url.url;
    int NameSelectedPosition;
    char? categoria;
    decimal? precio;
    int? cantidad;

    public Inventario()
    {
        InitializeComponent();
        string[] categoria = { "B", "D", "O" };
        Name.ItemsSource = ProductosDisponiblesAdmin.productos.Name;
        Categoria.ItemsSource = categoria;
    }

    private void Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = sender as Picker;

        // Retrieve the selected index
        int selectedIndex = picker.SelectedIndex;

        // Retrieve the selected item
        var selectedItem = picker.SelectedItem;

        NameSelectedPosition = selectedIndex;

        // Display the selected item and its position
        //DisplayAlert("", NameSelectedPosition.ToString() + " " + selectedItem.ToString(), "OK");
    }


    private void Categoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = sender as Picker;
        var selectedItem = picker.SelectedItem;

        switch (selectedItem)
        {
            case 'B':
                categoria = 'B';
                break;

            case 'O':
                categoria = 'O';
                break;

            case 'D':
                categoria = 'D';
                break;

                //default:
                //    DisplayAlert("", " INVALID CATEGORY ", "OK");   
                //    break;
        }



        //DisplayAlert("", categoria.ToString(), "OK");
    }

    private async void Actualizar_Producto_Clicked(object sender, EventArgs e)
    {

        if (NameSelectedPosition == null)
        {
            DisplayAlert("", " Select a product ", "OK");
        }
        else
        {
            if (categoria == null)
            {
                categoria = ProductosDisponiblesAdmin.productos.Categoria[NameSelectedPosition];
            }
            precio = decimal.Parse(Precio.Text);
            cantidad = int.Parse(Cantidad.Text);

            if (precio == null || cantidad == null)
            {
                precio = ProductosDisponiblesAdmin.productos.Precio[NameSelectedPosition];
                cantidad = ProductosDisponiblesAdmin.productos.Cantidad[NameSelectedPosition];
            }

                //Llamar API Actualizar inventario
                try
                {
                    RequestProductosAdminActualizar req = new RequestProductosAdminActualizar();
                    req.productosActualizar = new Models.Entidades.ProductosAdminActualizar();
                    req.productosActualizar.cantidad = (int)cantidad;
                    req.productosActualizar.precio = (decimal)precio;
                    req.productosActualizar.categoria = (char)categoria;
                    req.productosActualizar.id = (int)ProductosDisponiblesAdmin.productos.IdProducto[NameSelectedPosition];
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                    HttpClient httpClient = new HttpClient();
                    var response = await httpClient.PostAsync(url + "api/Admin/ProductosActualizar", jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        ResponseActualizarProductosAdmin res = new ResponseActualizarProductosAdmin();
                        var responseActualizar = await response.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<ResponseActualizarProductosAdmin>(responseActualizar);
                        res.Errors = new List<string>();

                        if (res.Result)
                        {
                            DisplayAlert("Completed!", res.Message, "OK");
                            await Navigation.PushAsync(new MainPageAdmin());
                        }
                        else
                        {
                            DisplayAlert("Failed", "Something went wrong " + res.Errors, "OK");
                        }
                    }
                    else
                    {
                        DisplayAlert("Failed", "Something went wrong", "OK");
                    }

                }
             catch (Exception ex)
             {
                 DisplayAlert("", ex.ToString(), "OK");
                throw;
             }
        }
    }
}