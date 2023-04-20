﻿using DeliveryService.DTO;
using DeliveryService.Enums;
using DeliveryService.Services;
using DeliveryService.View;
using DeliveryService.View.Pages.Delivery;
using DeliveryService.View.Pages.Storages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.ViewModel.Pages.Storages
{
    public class StorageGeneralInfoViewModel : ViewModelBase
    {
        #region Private Fields
        private IStorageDTOService _service;

        private IAuthenticationService _authenticationService;

        private ObservableCollection<StorageDTO>? _storages;

        private RelayCommand? _editStorageCommand;

        private RelayCommand? _deleteStorageCommand;

        private RelayCommand? _addStorageCommand;

        private string _textBoxSearch;
        #endregion

        #region Properties
        public ObservableCollection<StorageDTO>? Storages
        {
            get => _storages;
            set
            {
                _storages = value;
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

        public RelayCommand? EditStorageCommand
        {
            get
            {
                return _editStorageCommand ?? (_editStorageCommand = new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(StoragePages.StorageGeneralInfo))
                    {
                        if (obj != null)
                        {
                            Window window = new StorageEdit((int)obj);
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

        public RelayCommand? DeleteStorageCommand
        {
            get
            {
                return _deleteStorageCommand ?? (_deleteStorageCommand = new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(StoragePages.StorageGeneralInfo))
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

        public RelayCommand AddStorageCommand
        {
            get
            {
                return _addStorageCommand ?? (_addStorageCommand = new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(StoragePages.StorageGeneralInfo))
                    {
                        Window window = new StorageEdit(null);
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

        public StorageGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IStorageDTOService>();
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();

            UpdateData();
        }

        #region Methods
        private void UpdateData()
        {
            Storages = new ObservableCollection<StorageDTO>(_service.GetAll());
        }

        private void FilterTable()
        {
            if (_textBoxSearch != null)
            {
                Storages = new ObservableCollection<StorageDTO>(_service.GetAll().Where(x => x.Id.ToString().Contains(_textBoxSearch)
                                                                                          || (x.Title != null && x.Title.Contains(_textBoxSearch))
                                                                                          || (x.Address != null
                                                                                            && ((x.Address.Country != null && x.Address.Country.Contains(_textBoxSearch))
                                                                                             || (x.Address.City != null && x.Address.City.Contains(_textBoxSearch))
                                                                                             || (x.Address.Street != null && x.Address.Street.Contains(_textBoxSearch))
                                                                                             || (x.Address.House != null && x.Address.House.Contains(_textBoxSearch))))));
            }
        }
        #endregion
    }
}
