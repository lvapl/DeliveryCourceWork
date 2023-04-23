using System.Windows;
using System.Windows.Threading;
using DeliveryService.Converters;
using DeliveryService.Model;
using DeliveryService.Repository;
using DeliveryService.Services;
using DeliveryService.View;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DsContext>();

            services.AddSingleton<LoginWindow>();
            services.AddSingleton<MainWindow>();

            services.AddSingleton<IWorkerRepository, WorkerRepository>();
            services.AddSingleton<IEncryptionService, EncryptionService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IWorkerDTOService, WorkerDTOService>();
            services.AddSingleton<IAddressRepository, AddressRepository>();
            services.AddSingleton<IAddressDTOService, AddressDTOService>();
            services.AddSingleton<IPositionRepository, PositionRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserDTOService, UserDTOService>();
            services.AddSingleton<IDeliveryRepository, DeliveryRepository>();
            services.AddSingleton<IDeliveryDTOService, DeliveryDTOService>();
            services.AddSingleton<IPickUpPointRepository, PickUpPointRepository>();
            services.AddSingleton<IPickUpPointDTOService, PickUpPointDTOService>();
            services.AddSingleton<IStorageRepository, StorageRepository>();
            services.AddSingleton<IStorageDTOService, StorageDTOService>();
            services.AddSingleton<IPdfWriterService, PdfWriterService>();

            services.AddSingleton<AppPageConverter>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            var loginWindow = ServiceProvider.GetRequiredService<LoginWindow>();
            loginWindow.Show();
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            string message;

            switch (e.Exception)
            {
                case SqlException:
                    message = "Возникли проблемы с подключением к базе данных. Обратитесь к администратору";
                    break;
                default:
                    message = e.Exception.Message;
                    break;
            }
            Window window = new ErrorWindow(message);
            window.ShowDialog();
        }
    }
}
