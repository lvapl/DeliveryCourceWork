﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Enums;
using DeliveryService.Services;
using DeliveryService.View;
using DeliveryService.View.Pages.Storages;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.Storages
{
    /// <summary>
    /// ViewModel для страницы "Общая информация" раздела "Склады".
    /// </summary>
    public class StorageGeneralInfoViewModel : ViewModelBase
    {
        #region Private Fields
        private IStorageDTOService _service;
        private IAuthenticationService _authenticationService;
        private IPdfWriterService _pdfWriterService;

        private ObservableCollection<StorageDTO>? _storages;

        private RelayCommand? _editStorageCommand;
        private RelayCommand? _deleteStorageCommand;
        private RelayCommand? _addStorageCommand;
        private RelayCommand? _createPdf;

        private string _textBoxSearch;
        #endregion

        #region Properties
        /// <summary>
        /// Список складов <see cref="Model.Storage"/>
        /// </summary>
        public ObservableCollection<StorageDTO>? Storages
        {
            get => _storages;
            set
            {
                _storages = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Строка для поиска (фильтрации).
        /// </summary>
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

        /// <summary>
        /// Команда для открытия окна редактирования склада
        /// </summary>
        public RelayCommand EditStorageCommand
        {
            get
            {
                return _editStorageCommand ??= new RelayCommand((obj) =>
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
                        Window window = new ErrorWindow("Не удалось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                });
            }
        }

        /// <summary>
        /// Команда для удаления склада
        /// </summary>
        public RelayCommand DeleteStorageCommand
        {
            get
            {
                return _deleteStorageCommand ??= new RelayCommand((obj) =>
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
                        Window window = new ErrorWindow("Не удалось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                });
            }
        }

        /// <summary>
        /// Команда для открытия окна добавления склада.
        /// </summary>
        public RelayCommand AddStorageCommand
        {
            get
            {
                return _addStorageCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(StoragePages.StorageGeneralInfo))
                    {
                        Window window = new StorageEdit(null);
                        window.ShowDialog();
                        UpdateData();
                    }
                    else
                    {
                        Window window = new ErrorWindow("Не удалось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                });
            }
        }

        /// <summary>
        /// Команда для создания PDF-файла.
        /// </summary>
        public RelayCommand CreatePdf
        {
            get
            {
                return _createPdf ??= new RelayCommand((obj) =>
                {
                    _pdfWriterService.CreatePdfFile(new List<StorageDTO>(_service.GetAll()),
                        new Dictionary<string, string>
                        {
                            { "Id", "Id" },
                            { "Title", "Номер склада" },
                            { "Address", "Адрес" },
                        });
                });
            }
        }
        #endregion

        /// <summary>
        /// Конструктор класса <see cref="StorageGeneralInfoViewModel"./>
        /// </summary>
        public StorageGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IStorageDTOService>();
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
            _pdfWriterService = App.ServiceProvider.GetRequiredService<IPdfWriterService>();

            UpdateData();
        }

        #region Methods
        /// <summary>
        /// Метод обновления данных.
        /// </summary>
        private void UpdateData()
        {
            Storages = new ObservableCollection<StorageDTO>(_service.GetAll());
        }

        /// <summary>
        /// Метод фильтрации записей. Вызывается при обновлении строки поиска.
        /// </summary>
        private void FilterTable()
        {
            if (_textBoxSearch != String.Empty)
            {
                Storages = new ObservableCollection<StorageDTO>(_service.GetAll().Where(x => x.Id.ToString().Contains(_textBoxSearch)
                                                                                          || (x.Title != null && x.Title.Contains(_textBoxSearch))
                                                                                          || (x.Address != null
                                                                                            && ((x.Address.Country != null && x.Address.Country.Contains(_textBoxSearch))
                                                                                             || (x.Address.City != null && x.Address.City.Contains(_textBoxSearch))
                                                                                             || (x.Address.Street != null && x.Address.Street.Contains(_textBoxSearch))
                                                                                             || (x.Address.House != null && x.Address.House.Contains(_textBoxSearch))))));
            }
            else
            {
                UpdateData();
            }
        }
        #endregion
    }
}
