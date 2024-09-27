using CarritoApp.Models;
using CarritoApp.Repositories;
using CarritoApp.Services;
using System.Collections.Generic;
using System.IO;
using Microsoft.Maui.Controls;
using CarritoApp.Controllers;
using SQLite;

namespace CarritoApp.Views
{
    public partial class DepartamentoPage : ContentPage
    {
        private readonly DepartamentoController _departamentoController;
        private Departamento _selectedDepartamento;

        public DepartamentoPage()
        {
            InitializeComponent();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "departamentos.db3");
            _departamentoController = new DepartamentoController(new DepartamentoRepository(new SQLiteConnection(dbPath)));
            LoadDepartamentos();
        }

        private async void LoadDepartamentos()
        {
            var departamentos = await _departamentoController.GetAllDepartamentos();
            DepartamentosListView.ItemsSource = departamentos;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var nombre = NombreDepartamentoEntry.Text;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                await DisplayAlert("Error", "Por favor, ingrese el nombre del departamento.", "OK");
                return;
            }

            if (_selectedDepartamento != null)
            {
                _selectedDepartamento.NombreDepartamento = nombre;
                await _departamentoController.UpdateDepartamento(_selectedDepartamento);
                _selectedDepartamento = null; 
            }
            else
            {
                var departamento = new Departamento { NombreDepartamento = nombre };
                await _departamentoController.AddDepartamento(departamento);
            }

            NombreDepartamentoEntry.Text = string.Empty;
            LoadDepartamentos();
        }

        private async void OnDepartmentTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                _selectedDepartamento = (Departamento)e.Item;
                NombreDepartamentoEntry.Text = _selectedDepartamento.NombreDepartamento;
            }
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var departamento = button?.CommandParameter as Departamento;

            if (departamento != null)
            {
                _selectedDepartamento = departamento;
                NombreDepartamentoEntry.Text = _selectedDepartamento.NombreDepartamento;
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var departamento = button?.CommandParameter as Departamento;

            if (departamento != null)
            {
                bool confirm = await DisplayAlert("Confirmar Eliminación", $"¿Está seguro de que desea eliminar '{departamento.NombreDepartamento}'?", "Sí", "No");
                if (confirm)
                {
                    await _departamentoController.DeleteDepartamento(departamento);
                    LoadDepartamentos();
                }
            }
        }
    }
}
