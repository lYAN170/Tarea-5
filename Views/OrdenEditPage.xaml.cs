using MiApp.Models;
using MiApp.Controller;
using MiApp.Services;
using Microsoft.Maui.Controls;
using System;
using System.IO;

namespace MiApp.Views
{
    public partial class OrdenEditPage : ContentPage
    {
        private readonly OrdenController _ordenController;
        private int _ordenId;

        public OrdenEditPage(int ordenId = 0)
        {
            InitializeComponent();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ordenes.db3");
            _ordenController = new OrdenController(dbPath); 
            _ordenId = ordenId;

            LoadProductos();
            if (_ordenId != 0)
            {
                LoadOrden();
            }
        }

        private async void LoadProductos()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3"); // Cambia según corresponda
            var productoController = new ProductoController(dbPath); 
            var productos = await productoController.GetAllProductos();
            ProductoPicker.ItemsSource = productos;
            ProductoPicker.ItemDisplayBinding = new Binding("Nombre"); 
        }

        private async void LoadOrden()
        {
            var orden = await _ordenController.GetOrden(_ordenId);
            if (orden != null)
            {
                FechaPicker.Date = orden.Fecha;
                ProductoPicker.SelectedItem = orden.ProductoId;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var fecha = FechaPicker.Date;
            var selectedProducto = (Producto)ProductoPicker.SelectedItem;

            if (selectedProducto == null)
            {
                await DisplayAlert("Error", "Por favor, selecciona un producto.", "OK");
                return;
            }

            var orden = new Orden
            {
                Id = _ordenId,
                Fecha = fecha,
                ProductoId = selectedProducto.Id 
            };

            if (_ordenId == 0)
            {
                await _ordenController.AddOrden(orden);
            }
            else
            {
                await _ordenController.UpdateOrden(orden);
            }

            await Navigation.PopAsync();
        }
    }
}
