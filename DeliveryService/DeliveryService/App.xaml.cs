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
    /// Класс приложения. Он содержит методы для настройки сервисов, используемых в приложении, и обработку исключений.
    /// </summary>
    public partial class App : Application
    {
        #region Public Fields
        public static ServiceProvider ServiceProvider = null!;
        #endregion

        /// <summary>
        /// Конструктор класса App, который вызывает метод ConfigureServices() для настройки сервисов и создает сервис-провайдер.
        /// </summary>
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        #region Methods
        /// <summary>
        /// Метод, в котором настраиваются сервисы приложения.
        /// </summary>
        /// <param name="services">Коллекция сервисов, в которую добавляются сервисы приложения.</param>
        private void ConfigureServices(IServiceCollection services)
        {
            #region Database Context
            services.AddDbContext<DsContext>();
            #endregion

            #region Windows
            services.AddSingleton<LoginWindow>();
            services.AddSingleton<MainWindow>();
            #endregion
            
            #region Repositories
            services.AddSingleton<IWorkerRepository, WorkerRepository>();
            services.AddSingleton<IStorageRepository, StorageRepository>();
            services.AddSingleton<IPickUpPointRepository, PickUpPointRepository>();
            services.AddSingleton<IDeliveryRepository, DeliveryRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IPositionRepository, PositionRepository>();
            services.AddSingleton<IAddressRepository, AddressRepository>();
            #endregion

            #region Services
            services.AddSingleton<IEncryptionService, EncryptionService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IPdfWriterService, PdfWriterService>();
            #endregion

            #region DTO Services
            services.AddSingleton<IWorkerDTOService, WorkerDTOService>();
            services.AddSingleton<IAddressDTOService, AddressDTOService>();
            services.AddSingleton<IUserDTOService, UserDTOService>();
            services.AddSingleton<IDeliveryDTOService, DeliveryDTOService>();
            services.AddSingleton<IPickUpPointDTOService, PickUpPointDTOService>();
            services.AddSingleton<IStorageDTOService, StorageDTOService>();
            #endregion
        }

        /// <summary>
        /// Метод, который вызывается при запуске приложения. Он добавляет обработчик необработанных исключений и отображает окно входа в систему.
        /// </summary>
        /// <param name="e">Аргументы запуска приложения.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            var loginWindow = ServiceProvider.GetRequiredService<LoginWindow>();
            loginWindow.Show();
        }

        /// <summary>
        /// Метод-обработчик необработанных исключений. Он отображает окно с сообщением об ошибке.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Аргументы события.</param>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true; // не даёт закрыться приложению при появлении ошибки (Предотвращает обработку необработанных исключений по умолчанию)

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
        #endregion
    }
}
