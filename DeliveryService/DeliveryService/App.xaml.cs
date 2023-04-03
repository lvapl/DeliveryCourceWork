using AutoMapper;
using DeliveryService.MVVM.Model;
using DeliveryService.MVVM.Model.DTO;
using DeliveryService.MVVM.Model.Repositories;
using DeliveryService.MVVM.View;
using DeliveryService.Services;
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
        public static ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DsContext>();
            services.AddSingleton<LoginWindow>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<IWorkerRepository, WorkerRepository>();
            services.AddSingleton<IEncryptionService, EncryptionService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IWorkerGeneralInfoService, WorkerGeneralInfoService>();
            services.AddAutoMapper(cfg => {
                cfg.CreateMap<Worker, WorkerGeneralInfoDTO>().IncludeMembers(x => x.IdNavigation, x => x.Position);
                cfg.CreateMap<User, WorkerGeneralInfoDTO>(MemberList.None);
                cfg.CreateMap<Position, WorkerGeneralInfoDTO>(MemberList.None);
            });
            services.AddSingleton<WorkerGeneralInfoService>();
            

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var loginWindow = _serviceProvider.GetRequiredService<LoginWindow>();
            loginWindow.Show();
        }
    }
}
