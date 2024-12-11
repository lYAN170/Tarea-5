using MiApp.Models;
using MiApp.Controller;
using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MiApp.Views
{
    public partial class OrdenListPage : ContentPage
    {
        private readonly OrdenController _ordenController;

        public OrdenListPage()
        {
            InitializeComponent();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ordenes.db3");
            _ordenController = new OrdenController(dbPath);
            LoadOrdenes();
        }

        private async void LoadOrdenes()
        {
            var ordenes = await _ordenController.GetAllOrdenes();
            OrdenesCollectionView.ItemsSource = ordenes;
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrdenEditPage());
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = (Button)sender; 
            var selectedOrden = (Orden)button.BindingContext; 
            if (selectedOrden != null)
            {
                bool confirm = await DisplayAlert("Confirmar", "¿Está seguro de que desea eliminar esta orden?", "Sí", "No");
                if (confirm)
                {
                    await _ordenController.DeleteOrden(selectedOrden.Id);
                    LoadOrdenes();
                }
            }
        }
    }
}
