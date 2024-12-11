using MiApp.Controllers;
using MiApp.Data;
using MiApp.Repositories;
using MiApp.Services;
using MiApp.Views;
using SQLite;

namespace MiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var services = ConfigureServices();
            var loginController = services.GetRequiredService<LoginController>();


            MainPage = new NavigationPage(new LoginPage(loginController));
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<SQLiteConnection>(provider =>
                new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, "mi_app.db3")));

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddTransient<LoginController>();

            return services.BuildServiceProvider();
        }
    }
}
