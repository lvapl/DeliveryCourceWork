using AutoMapper;
using DeliveryService.Converters;
using DeliveryService.Model;
using DeliveryService.DTO;
using DeliveryService.Repository;
using DeliveryService.Services;
using DeliveryService.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
            services.AddSingleton<IAddressRepository, AdderssRepository>();
            services.AddSingleton<IAddressDTOService, AddressDTOService>();
            services.AddSingleton<IPositionRepository, PositionRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserDTOService, UserDTOService>();
            services.AddSingleton<IDeliveryRepository, DeliveryRepository>();
            services.AddSingleton<IDeliveryDTOService, DeliveryDTOService>();
            services.AddSingleton<IPickUpPointRepository, PickUpPointRepository>();

            services.AddSingleton<AppPageConverter>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            var loginWindow = ServiceProvider.GetRequiredService<LoginWindow>();
            loginWindow.Show();
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            Window window = new ErrorWindow(e.Exception.Message);
            window.ShowDialog();
        }
    }
}
