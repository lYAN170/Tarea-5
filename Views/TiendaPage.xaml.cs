using MiApp.Controllers;
using MiApp.Models;
using MiApp.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Maui.Controls;
using SQLite;

namespace MiApp.Views
{
    public partial class TiendaPage : ContentPage
    {
        private readonly TiendaController _tiendaController;

        public TiendaPage()
        {
            InitializeComponent();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tiendas.db3");
            _tiendaController = new TiendaController(new TiendaRepository(new SQLiteConnection(dbPath)));
            LoadTiendas();
        }

        private async void LoadTiendas()
        {
            var tiendas = await _tiendaController.GetAllTiendas();
            TiendasListView.ItemsSource = tiendas;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var nombre = NombreTiendaEntry.Text;
            var direccion = DireccionTiendaEntry.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(direccion))
            {
                await DisplayAlert("Error", "Por favor, ingrese todos los campos.", "OK");
                return;
            }

            var tienda = new Tienda { Nombre = nombre, Direccion = direccion };
            await _tiendaController.AddTienda(tienda);
            NombreTiendaEntry.Text = string.Empty;
            DireccionTiendaEntry.Text = string.Empty;
            LoadTiendas();
        }

        private async void OnTiendaTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var selectedTienda = (Tienda)e.Item;
                NombreTiendaEntry.Text = selectedTienda.Nombre;
                DireccionTiendaEntry.Text = selectedTienda.Direccion;
            }
        }
    }
}
