using DeliveryService.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeliveryService.MVVM.View.Worker
{
    /// <summary>
    /// Логика взаимодействия для WorkerGeneralInfoPage.xaml
    /// </summary>
    public partial class WorkerGeneralInfoPage : Page
    {
        public WorkerGeneralInfoPage()
        {
            InitializeComponent();
            this.DataContext = new WorkerGeneralInfoViewModel();
        }
    }
}
