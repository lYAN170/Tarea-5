using CarritoApp.Models;
using CarritoApp.Services;
using System.Collections.Generic;
using System.IO;
using Microsoft.Maui.Controls;
using CarritoApp.Controllers;
using SQLite;
using System.Threading.Tasks;

namespace CarritoApp.Views
{
    public partial class ProveedorListPage : ContentPage
    {
        private readonly ProveedorController _proveedorController;

        public ProveedorListPage()
        {
            InitializeComponent();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "proveedores.db3");
            _proveedorController = new ProveedorController(dbPath);
            LoadProveedores();
        }

        private async Task LoadProveedores()
        {
            var proveedores = await _proveedorController.GetAllProveedores();
            ProveedoresListView.ItemsSource = proveedores;
        }

        private async void OnProveedorTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var selectedProveedor = (Proveedor)e.Item;
                await Navigation.PushAsync(new ProveedorEditPage(selectedProveedor.Id));
            }
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProveedorEditPage());
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var proveedorId = (int)button.CommandParameter;

            await Navigation.PushAsync(new ProveedorEditPage(proveedorId));
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var proveedorId = (int)button.CommandParameter;

            var confirm = await DisplayAlert("Confirmar", "¿Está seguro de que desea eliminar este proveedor?", "Sí", "No");
            if (confirm)
            {
                await _proveedorController.DeleteProveedor(proveedorId);
                await LoadProveedores();
            }
        }
    }
}
