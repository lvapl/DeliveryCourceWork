using DeliveryService.ViewModel.Pages.PickUpPoints;
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

namespace DeliveryService.View.Pages.PickUpPoints
{
    /// <summary>
    /// Логика взаимодействия для UserEdit.xaml
    /// </summary>
    public partial class PickUpPointEdit : Window
    {
        public PickUpPointEdit(int? pointId)
        {
            InitializeComponent();
            this.DataContext = new PickUpPointEditViewModel(this, pointId);
        }
    }
}
