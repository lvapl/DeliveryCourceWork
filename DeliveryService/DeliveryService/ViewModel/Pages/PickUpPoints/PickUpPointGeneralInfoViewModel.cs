using DeliveryService.DTO;
using DeliveryService.Enums;
using DeliveryService.Services;
using DeliveryService.View;
using DeliveryService.View.Pages.Delivery;
using DeliveryService.View.Pages.PickUpPoints;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.ViewModel.Pages.PickUpPoints
{
    public class PickUpPointGeneralInfoViewModel : ViewModelBase
    {
        #region Private Fields
        private IPickUpPointDTOService _service;

        private IAuthenticationService _authenticationService;

        private ObservableCollection<PickUpPointDTO>? _pickUpPoints;

        private RelayCommand? _editPickUpPointCommand;

        private RelayCommand? _deletePickUpPointCommand;

        private RelayCommand? _addPickUpPointCommand;

        private string _textBoxSearch;
        #endregion

        #region Properties
        public ObservableCollection<PickUpPointDTO>? PickUpPoints
        {
            get => _pickUpPoints;
            set
            {
                _pickUpPoints = value;
                OnPropertyChanged();
            }
        }

        public string TextBoxSearch
        {
            get => _textBoxSearch;
            set
            {
                _textBoxSearch = value;
                OnPropertyChanged();
                FilterTable();
            }
        }

        public RelayCommand? EditPickUpPointCommand
        {
            get
            {
                return _editPickUpPointCommand ?? (_editPickUpPointCommand = new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(PickUpPointPages.PickUpPointGeneralInfo))
                    {
                        if (obj != null)
                        {
                            Window window = new PickUpPointEdit((int)obj);
                            window.ShowDialog();
                            UpdateData();
                        }
                    }
                    else
                    {
                        Window window = new ErrorWindow("Не у далось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                }));
            }
        }

        public RelayCommand? DeletePickUpPointCommand
        {
            get
            {
                return _deletePickUpPointCommand ?? (_deletePickUpPointCommand = new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(PickUpPointPages.PickUpPointGeneralInfo))
                    {
                        if (obj != null)
                        {
                            _service.Remove((int)obj);
                            UpdateData();
                        }
                    }
                    else
                    {
                        Window window = new ErrorWindow("Не у далось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                }));
            }
        }

        public RelayCommand AddPickUpPointCommand
        {
            get
            {
                return _addPickUpPointCommand ?? (_addPickUpPointCommand = new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(PickUpPointPages.PickUpPointGeneralInfo))
                    {
                        Window window = new PickUpPointEdit(null);
                        window.ShowDialog();
                        UpdateData();
                    }
                    else
                    {
                        Window window = new ErrorWindow("Не у далось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                }));
            }
        }
        #endregion

        public PickUpPointGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IPickUpPointDTOService>();
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();

            UpdateData();
        }

        #region Methods
        private void UpdateData()
        {
            PickUpPoints = new ObservableCollection<PickUpPointDTO>(_service.GetAll());
        }

        private void FilterTable()
        {
            if (_textBoxSearch != null)
            {
                PickUpPoints = new ObservableCollection<PickUpPointDTO>(_service.GetAll().Where(x => x.Id.ToString().Contains(_textBoxSearch)
                                                                                               || x.Address != null
                                                                                                   && (x.Address.Country != null && x.Address.Country.Contains(_textBoxSearch)
                                                                                                    || x.Address.City != null && x.Address.City.Contains(_textBoxSearch)
                                                                                                    || x.Address.Street != null && x.Address.Street.Contains(_textBoxSearch)
                                                                                                    || x.Address.House != null && x.Address.House.Contains(_textBoxSearch))));
            }

        }
        #endregion
    }
}
