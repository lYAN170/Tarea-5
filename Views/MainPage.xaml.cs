using System;
using Microsoft.Maui.Controls;
using MiApp.Views;
using CarritoApp.Views;
using CarritoApp.View;

namespace MiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnProductosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductoListPage());
        }

        private async void OnCategoriasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoriaListPage());
        }
        private async void OnDepartamentosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DepartamentoPage());
        }

        private async void OnProvinciasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProvinciaPage());
        }

        private async void OnTiendasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TiendaPage());
        }

        private async void OnProveedoresClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProveedorListPage());
        }

        private async void OnOrdenesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrdenListPage());
        }

    }
}




