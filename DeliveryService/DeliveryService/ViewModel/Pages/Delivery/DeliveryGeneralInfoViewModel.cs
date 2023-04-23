﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Enums;
using DeliveryService.Services;
using DeliveryService.View;
using DeliveryService.View.Pages.Delivery;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.Delivery
{
    public class DeliveryGeneralInfoViewModel : ViewModelBase
    {
        #region Private Fields
        private IDeliveryDTOService _service;

        private IAuthenticationService _authenticationService;

        private IPdfWriterService _pdfWriterService;

        private ObservableCollection<DeliveryDTO>? _deliveries;

        private RelayCommand? _editDeliveryCommand;

        private RelayCommand? _deleteDeliveryCommand;

        private RelayCommand? _addDeliveryCommand;

        private RelayCommand? _createPdf;

        private string _textBoxSearch;
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

        public RelayCommand EditDeliveryCommand
        {
            get
            {
                return _editDeliveryCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(DeliveryPages.DeliveryGeneralInfo))
                    {
                        if (obj != null)
                        {
                            Window window = new DeliveryEdit((int)obj);
                            window.ShowDialog();
                            UpdateData();
                        }
                    }
                    else
                    {
                        Window window = new ErrorWindow("Не у далось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                });
            }
        }

        public RelayCommand DeleteDeliveryCommand
        {
            get
            {
                return _deleteDeliveryCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(DeliveryPages.DeliveryGeneralInfo))
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
                });
            }
        }

        public RelayCommand AddDeliveryCommand
        {
            get
            {
                return _addDeliveryCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(DeliveryPages.DeliveryGeneralInfo))
                    {
                        Window window = new DeliveryEdit(null);
                        window.ShowDialog();
                        UpdateData();
                    }
                    else
                    {
                        Window window = new ErrorWindow("Не у далось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                });
            }
        }

        public RelayCommand CreatePdf
        {
            get
            {
                return _createPdf ??= new RelayCommand((obj) =>
                {
                    _pdfWriterService.CreatePdfFile(new List<DeliveryDTO>(_service.GetAll()),
                        new Dictionary<string, string>
                        {
                            { "Id", "Id" },
                            { "TariffTitle", "Тариф" },
                            { "Price", "Цена" },
                            { "Sender", "Отправитель" },
                            { "Recipient", "Получатель" },
                            { "PickPointId", "Точка получения" },
                            { "UpPointId", "Точки выдачи" },
                        });
                });
            }
        }
        #endregion

        public DeliveryGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IDeliveryDTOService>();
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
            _pdfWriterService = App.ServiceProvider.GetRequiredService<IPdfWriterService>();

            UpdateData();
        }

        #region Methods
        private void UpdateData()
        {
            Deliveries = new ObservableCollection<DeliveryDTO>(_service.GetAll());
        }

        private void FilterTable()
        {
            if (_textBoxSearch != String.Empty)
            {
                Deliveries = new ObservableCollection<DeliveryDTO>(_service.GetAll().Where(x => x.Id.ToString().Contains(_textBoxSearch)
                                                                                             || (x.Sender != null 
                                                                                                && (x.Sender.Id.ToString().Contains(_textBoxSearch)
                                                                                                 || x.Sender.FirstName.Contains(_textBoxSearch)
                                                                                                 || x.Sender.LastName.Contains(_textBoxSearch)
                                                                                                 || (x.Sender.Patronymic != null && x.Sender.Patronymic.Contains(_textBoxSearch))))
                                                                                             || (x.Recipient != null
                                                                                                && (x.Recipient.Id.ToString().Contains(_textBoxSearch)
                                                                                                 || x.Recipient.FirstName.Contains(_textBoxSearch)
                                                                                                 || x.Recipient.LastName.Contains(_textBoxSearch)
                                                                                                 || (x.Recipient.Patronymic != null && x.Recipient.Patronymic.Contains(_textBoxSearch))))
                                                                                             || (x.Price != null && x.Price.ToString()!.Contains(_textBoxSearch))));
            }
        }
        #endregion
    }
}
