﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Login1.Models;
using System.Collections.ObjectModel;

namespace Login1.ViewModels
{
    public partial class MainDriverViewModel : ObservableObject
    {
        [ObservableProperty]
        bool mostrarSpinner;
        [ObservableProperty]
        bool mostrarBuscarOrden;
        [ObservableProperty]
        bool mostrarAceptarOrden;
        [ObservableProperty]
        bool mostrarOrdenAceptada;
        [ObservableProperty]
        string cantidadProductosText;

        public ObservableCollection<Product> Productos { get; } = new ObservableCollection<Product>();

        public MainDriverViewModel()
        {
            MostrarSpinner = false;
            MostrarBuscarOrden = true;
            MostrarAceptarOrden = false;
            MostrarOrdenAceptada = false;
        }

        [RelayCommand]
        public async Task ToggleMostrarSpinner()
        {
            MostrarBuscarOrden = false;
            MostrarSpinner = true;
            LlenarProductosOrden();
            await Task.Delay(2000);
            // Llamar API para buscar orden...
            MostrarSpinner = false;
            MostrarAceptarOrden = true;
        }

        [RelayCommand]
        public async Task AceptarOrden()
        {
            MostrarAceptarOrden = false;
            MostrarSpinner = true;
            await Task.Delay(2000);
            MostrarSpinner = false;
            MostrarOrdenAceptada = true;
        }

        [RelayCommand]
        public async Task CancelarOrden()
        {
            Productos.Clear();
            MostrarAceptarOrden = false;
            MostrarBuscarOrden = true;
        }

        [RelayCommand]
        public async Task TerminarViaje()
        {
            Productos.Clear();
            MostrarSpinner = true;
            MostrarOrdenAceptada = false;
            await Task.Delay(2000);
            MostrarSpinner = false;
            MostrarBuscarOrden = true;
        }

        private void LlenarProductosOrden()
        {
            Productos.Clear();
            Productos.Add(new Product
            {
                Name = "Rose Milk Tea",
                Cantidad = 2,
            });
            Productos.Add(new Product
            {
                Name = "Lavender Milk",
                Cantidad = 1,
            });
            Productos.Add(new Product
            {
                Name = "Almond Milk",
                Cantidad = 2,
            });
            Productos.Add(new Product
            {
                Name = "Honey Lemonade",
                Cantidad = 3,
            });
            Productos.Add(new Product
            {
                Name = "Jasmine Tea",
                Cantidad = 1,
            });

            int? cantidadProductos = 0;

            foreach(var product in Productos)
            {
                cantidadProductos += product.Cantidad;
            }

            CantidadProductosText = "Cantidad de productos: " + cantidadProductos;
        }
    }
}

