using DeliveryService.DTO;
using DeliveryService.ViewModel;
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

namespace DeliveryService.View
{
    /// <summary>
    /// Логика взаимодействия для AddressEdit.xaml
    /// </summary>
    public partial class AddressEdit : Window
    {
        public AddressEdit(AddressDTO address)
        {
            InitializeComponent();
            this.DataContext = new AddressEditViewModel(this, address);
        }
    }
}
