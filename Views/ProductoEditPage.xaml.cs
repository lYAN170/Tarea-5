using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Maui.Controls;
using CarritoApp.Repositories;
using CarritoApp.Controller;
using MiApp.Models;
using CarritoApp.Models;
using MiApp.Controller;


namespace CarritoApp.View;

public partial class ProductoEditPage : ContentPage
{
    private ProductoController _productoController;
    private CategoriaController _categoriaController;
    private Producto _producto; 

    public ProductoEditPage()
    {
        InitializeComponent();
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
        _productoController = new ProductoController(dbPath);
        _categoriaController = new CategoriaController(dbPath);
        LoadCategorias();
    }

    public ProductoEditPage(Producto producto) : this() 
    {
        _producto = producto;
        LoadProducto(); 
    }

    private async void LoadCategorias()
    {
        var categorias = await _categoriaController.GetAllCategorias();
        CategoriaPicker.ItemsSource = categorias;
        CategoriaPicker.ItemDisplayBinding = new Binding("Nombre");
    }

    private async void LoadProducto()
    {
        NombreEntry.Text = _producto.Nombre;
        PrecioEntry.Text = _producto.Precio.ToString();
        // Puedes agregar más campos según sea necesario
        // Asegúrate de establecer la categoría seleccionada
        // CategoriaPicker.SelectedItem = await _categoriaController.GetCategoriaById(_producto.CategoriaId);
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NombreEntry.Text))
        {
            await DisplayAlert("Error", "Por favor, ingrese el nombre del producto.", "OK");
            return;
        }

        if (!decimal.TryParse(PrecioEntry.Text, out var precio) || precio < 0)
        {
            await DisplayAlert("Error", "Por favor, ingrese un precio válido.", "OK");
            return;
        }

        var selectedCategoriaId = GetSelectedCategoriaId();
        if (selectedCategoriaId == 0)
        {
            await DisplayAlert("Error", "Por favor, seleccione una categoría.", "OK");
            return;
        }

        var producto = new Producto
        {
            Nombre = NombreEntry.Text,
            Precio = precio,
            CategoriaId = selectedCategoriaId
        };

        try
        {
            await _productoController.AddProducto(producto);
            await DisplayAlert("Éxito", "El producto ha sido guardado correctamente.", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error al guardar el producto: {ex.Message}", "OK");
        }
    }

    private int GetSelectedCategoriaId()
    {
        var selectedCategoria = (Categoria)CategoriaPicker.SelectedItem;
        return selectedCategoria?.Id ?? 0;
    }

    private async void OnCreateCategoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CategoriaEditPage());
    }
}
