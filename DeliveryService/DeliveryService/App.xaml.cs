using AutoMapper;
using DeliveryService.Converters;
using DeliveryService.Model;
using DeliveryService.DTO;
using DeliveryService.ViewModel.Pages.Worker;
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

            services.AddSingleton<AppPageConverter>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var loginWindow = ServiceProvider.GetRequiredService<LoginWindow>();
            loginWindow.Show();
        }
    }
}
