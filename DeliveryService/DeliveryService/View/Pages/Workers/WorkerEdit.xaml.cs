using DeliveryService.ViewModel.Pages.Workers;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeliveryService.View.Workers
{
    /// <summary>
    /// Логика взаимодействия для WorkerEdit.xaml
    /// </summary>
    public partial class WorkerEdit : Window
    {
        public WorkerEdit(int? workerId)
        {
            InitializeComponent();
            this.DataContext = new WorkerEditViewModel(this, workerId);
        }
    }
}
