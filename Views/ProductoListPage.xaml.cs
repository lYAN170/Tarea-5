using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Maui.Controls;
using CarritoApp.Repositories;
using CarritoApp.Controller;
using CarritoApp.Models;
using MiApp.Models;
using MiApp.Controller;

namespace CarritoApp.View;

public partial class ProductoListPage : ContentPage
{
    private ProductoController _productoController;

    public ProductoListPage()
    {
        InitializeComponent();
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
        _productoController = new ProductoController(dbPath);
        LoadProductos();
    }

    private async void LoadProductos()
    {
        var productos = await _productoController.GetAllProductos();
        ProductosCollectionView.ItemsSource = productos; 
    }

    private async void OnProductoTapped(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var producto = (Producto)e.CurrentSelection[0]; 
            await Navigation.PushAsync(new ProductoEditPage(producto)); 
        }
    }

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductoEditPage()); 
    }
    private async void OnEditProductClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var producto = (Producto)button.BindingContext; 
        await Navigation.PushAsync(new ProductoEditPage(producto)); 
    }

    private async void OnDeleteProductClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var producto = (Producto)button.BindingContext;

        bool confirm = await DisplayAlert("Confirmar", "¿Estás seguro de que deseas eliminar este producto?", "Sí", "No");
        if (confirm)
        {
            await _productoController.DeleteProducto(producto.Id); 
            LoadProductos(); 
        }
    }
}