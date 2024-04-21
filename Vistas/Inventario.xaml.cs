using Login1.Utilidades;

namespace Login1.Vistas;

public partial class Inventario : ContentPage
{
    int NameSelectedPosition;
    char? categoria;

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
            else
            {
                //Llamar API Actualizar inventario
            }
        }
        await Navigation.PushAsync(new MainPageAdmin());
    }
}