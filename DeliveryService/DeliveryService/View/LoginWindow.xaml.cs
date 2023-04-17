﻿using DeliveryService.Model;
using DeliveryService.ViewModel;
using DeliveryService.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeliveryService.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(IAuthenticationService authenticationService, DsContext context, MainWindow mainWindow)
        {
            InitializeComponent();
            DataContext = new LoginViewModel(authenticationService, context, mainWindow, this);
        }
    }
}
