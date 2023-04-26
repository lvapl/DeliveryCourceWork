using DeliveryService.ViewModel.Pages.Delivery;
using DeliveryService.ViewModel.Pages.WorkersPickUpPoints;
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

namespace DeliveryService.View.Pages.WorkersPickUpPoints
{
    /// <summary>
    /// Логика взаимодействия для DeliveryGeneralInfoPage.xaml
    /// </summary>
    public partial class WorkerPickUpPointGeneralInfoPage : Page
    {
        public WorkerPickUpPointGeneralInfoPage()
        {
            InitializeComponent();
            DataContext = new WorkerPickUpPointGeneralInfoViewModel();
        }
    }
}
