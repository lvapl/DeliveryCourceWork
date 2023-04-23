using System.Windows;
using DeliveryService.Services;
using DeliveryService.ViewModel;

namespace DeliveryService.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(IAuthenticationService authenticationService, MainWindow mainWindow)
        {
            InitializeComponent();
            DataContext = new LoginViewModel(authenticationService, this, mainWindow);
        }
    }
}
