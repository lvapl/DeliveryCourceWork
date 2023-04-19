using DeliveryService.ViewModel.Pages.Storages;
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

namespace DeliveryService.View.Pages.Storages
{
    /// <summary>
    /// Логика взаимодействия для UserEdit.xaml
    /// </summary>
    public partial class StorageEdit : Window
    {
        public StorageEdit(int? storageId)
        {
            InitializeComponent();
            this.DataContext = new StorageEditViewModel(this, storageId);
        }
    }
}
