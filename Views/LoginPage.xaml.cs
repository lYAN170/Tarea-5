using MiApp.Controllers;
using global::MiApp.Repositories;
using MiApp.Services;


namespace MiApp.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginController _loginController;

        public LoginPage(LoginController loginController)
        {
            InitializeComponent();
            _loginController = loginController;
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var nombreUsuario = NombreUsuarioEntry.Text;
            var contrasena = ContrasenaEntry.Text;

            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MensajeLabel.Text = "Por favor, complete todos los campos.";
                MensajeLabel.IsVisible = true;
                return;
            }

            if (await _loginController.Autenticar(nombreUsuario, contrasena))
            {
                await DisplayAlert("�xito", "�Inicio de sesi�n exitoso!", "OK");

                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                MensajeLabel.Text = "Nombre de usuario o contrase�a incorrectos.";
                MensajeLabel.IsVisible = true;
            }
        }
        private async void OnCreateAccountButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(_loginController));
        }
    }
}