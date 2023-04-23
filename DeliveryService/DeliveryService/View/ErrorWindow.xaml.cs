using System.Windows;
using DeliveryService.ViewModel;

namespace DeliveryService.View
{
    /// <summary>
    /// Логика взаимодействия для ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        public ErrorWindow(string message)
        {
            InitializeComponent();
            this.DataContext = new ErrorViewModel(this, message);
        }
    }
}
