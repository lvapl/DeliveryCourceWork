using DeliveryService.DTO;
using DeliveryService.Services;
using DeliveryService.View.Pages.Delivery;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.ViewModel.Pages.Delivery
{
    public class DeliveryGeneralInfoViewModel : ViewModelBase
    {
        #region Private Fields
        private IDeliveryDTOService _service;

        private ObservableCollection<DeliveryDTO>? _deliveries;

        private RelayCommand? _editDeliveryCommand;

        private RelayCommand? _deleteDeliveryCommand;

        private RelayCommand? _addDeliveryCommand;
        #endregion

        #region Properties
        public ObservableCollection<DeliveryDTO>? Deliveries
        {
            get => _deliveries;
            set
            {
                _deliveries = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand? EditDeliveryCommand
        {
            get
            {
                return _editDeliveryCommand ?? (_editDeliveryCommand = new RelayCommand((obj) =>
                {
                    if (obj != null)
                    {
                        Window window = new DeliveryEdit((int)obj);
                        window.ShowDialog();
                        UpdateData();
                    }
                }));
            }
        }

        public RelayCommand? DeleteDeliveryCommand
        {
            get
            {
                return _deleteDeliveryCommand ?? (_deleteDeliveryCommand = new RelayCommand((obj) =>
                {
                    if (obj != null)
                    {
                        _service.Remove((int)obj);
                        UpdateData();
                    }
                }));
            }
        }

        public RelayCommand AddDeliveryCommand
        {
            get
            {
                return _addDeliveryCommand ?? (_addDeliveryCommand = new RelayCommand((obj) =>
                {
                    Window window = new DeliveryEdit(null);
                    window.ShowDialog();
                    UpdateData();
                }));
            }
        }
        #endregion

        public DeliveryGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IDeliveryDTOService>();
            UpdateData();
        }

        #region Methods
        private void UpdateData()
        {
            Deliveries = new ObservableCollection<DeliveryDTO>(_service.GetAll());
        }
        #endregion
    }
}
