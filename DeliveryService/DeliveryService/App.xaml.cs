﻿using AutoMapper;
using DeliveryService.Converters;
using DeliveryService.MVVM.Model;
using DeliveryService.MVVM.Model.DTO;
using DeliveryService.MVVM.Model.Repositories;
using DeliveryService.MVVM.View;
using DeliveryService.MVVM.ViewModel.Worker;
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

            services.AddSingleton<IWorkerRepository, WorkerRepository>();
            services.AddSingleton<IEncryptionService, EncryptionService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IWorkerGeneralInfoService, WorkerGeneralInfoService>();

            services.AddSingleton<AppPageConverter>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var loginWindow = ServiceProvider.GetRequiredService<LoginWindow>();
            loginWindow.Show();
        }
    }
}
