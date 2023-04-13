using DeliveryService.DTO;
using DeliveryService.ViewModel.Pages.Workers;
using System;
using System.Collections.Generic;
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

namespace DeliveryService.View.Pages.Workers
{
    /// <summary>
    /// Логика взаимодействия для WorkerEditPassword.xaml
    /// </summary>
    public partial class WorkerEditPassword : Window
    {
        public WorkerEditPassword(WorkerDTO worker)
        {
            InitializeComponent();
            this.DataContext = new WorkerEditPasswordViewModel(this, worker);
        }
    }
}
