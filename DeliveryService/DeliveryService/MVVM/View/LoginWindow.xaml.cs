using DeliveryService.MVVM.Model;
using DeliveryService.MVVM.ViewModel;
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

namespace DeliveryService.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(IAuthenticationService authenticationService, MainWindow mainWindow)
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel(authenticationService, mainWindow, this);
        }
    }
}
