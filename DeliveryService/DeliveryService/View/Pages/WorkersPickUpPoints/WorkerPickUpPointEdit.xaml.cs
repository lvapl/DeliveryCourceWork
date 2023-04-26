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
using System.Windows.Shapes;

namespace DeliveryService.View.Pages.WorkersPickUpPoints
{
    /// <summary>
    /// Логика взаимодействия для WorkerPickUpPointEdit.xaml
    /// </summary>
    public partial class WorkerPickUpPointEdit : Window
    {
        public WorkerPickUpPointEdit(int? id)
        {
            InitializeComponent();
            this.DataContext = new WorkerPickUpPointEditViewModel(this, id);
        }
    }
}
