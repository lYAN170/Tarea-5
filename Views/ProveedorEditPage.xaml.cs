using CarritoApp.Models;
using CarritoApp.Services;
using System.IO;
using Microsoft.Maui.Controls;
using SQLite;
using CarritoApp.Controllers;

namespace CarritoApp.Views
{
    public partial class ProveedorEditPage : ContentPage
    {
        private readonly ProveedorController _proveedorController;
        private int _proveedorId;

        public ProveedorEditPage()
        {
            InitializeComponent();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "proveedores.db3");
            _proveedorController = new ProveedorController(dbPath);
        }

        public ProveedorEditPage(int proveedorId) : this()
        {
            _proveedorId = proveedorId;
            LoadProveedor();
        }

        private async void LoadProveedor()
        {
            var proveedores = await _proveedorController.GetAllProveedores();
            var selectedProveedor = proveedores.Find(p => p.Id == _proveedorId);

            if (selectedProveedor != null)
            {
                NombreProveedorEntry.Text = selectedProveedor.Nombre;
                TelefonoProveedorEntry.Text = selectedProveedor.Telefono;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var nombre = NombreProveedorEntry.Text;
            var telefono = TelefonoProveedorEntry.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(telefono))
            {
                await DisplayAlert("Error", "Por favor, ingrese el nombre y el teléfono del proveedor.", "OK");
                return;
            }

            if (_proveedorId == 0)
            {
                var proveedor = new Proveedor { Nombre = nombre, Telefono = telefono };
                await _proveedorController.AddProveedor(proveedor);
            }
            else
            {
                var proveedor = new Proveedor { Id = _proveedorId, Nombre = nombre, Telefono = telefono };
                await _proveedorController.UpdateProveedor(proveedor);
            }


            await Navigation.PopAsync();

            
        }
    }
}

