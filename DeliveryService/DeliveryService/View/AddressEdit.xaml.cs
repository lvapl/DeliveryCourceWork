using System.Windows;
using DeliveryService.DTO;
using DeliveryService.ViewModel;

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
