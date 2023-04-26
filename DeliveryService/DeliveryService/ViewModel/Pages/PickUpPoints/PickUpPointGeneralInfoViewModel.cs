using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Enums;
using DeliveryService.Services;
using DeliveryService.View;
using DeliveryService.View.Pages.PickUpPoints;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.PickUpPoints
{
    /// <summary>
    /// ViewModel для страницы "Общая информация" раздела "Пункты выдачи".
    /// </summary>
    public class PickUpPointGeneralInfoViewModel : ViewModelBase
    {
        #region Private Fields
        private IPickUpPointDTOService _service;
        private IAuthenticationService _authenticationService;
        private IPdfWriterService _pdfWriterService;

        private ObservableCollection<PickUpPointDTO>? _pickUpPoints;

        private RelayCommand? _editPickUpPointCommand;
        private RelayCommand? _deletePickUpPointCommand;
        private RelayCommand? _addPickUpPointCommand;
        private RelayCommand? _createPdf;

        private string _textBoxSearch;
        #endregion

        #region Properties
        /// <summary>
        /// Список пунктов выдачи <see cref="Model.PickUpPoint"/>
        /// </summary>
        public ObservableCollection<PickUpPointDTO>? PickUpPoints
        {
            get => _pickUpPoints;
            set
            {
                _pickUpPoints = value;
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
        /// Команда для открытия окна редактирования пункта выдачи.
        /// </summary>
        public RelayCommand EditPickUpPointCommand
        {
            get
            {
                return _editPickUpPointCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(WorkerPages.WorkerGeneralInfo))
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
                });
            }
        }

        /// <summary>
        /// Команда для удаления пункта выдачи.
        /// </summary>
        public RelayCommand DeletePickUpPointCommand
        {
            get
            {
                return _deletePickUpPointCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(WorkerPages.WorkerGeneralInfo))
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

        /// <summary>
        /// Команда для открытия окна добавления пункта выдачи.
        /// </summary>
        public RelayCommand AddPickUpPointCommand
        {
            get
            {
                return _addPickUpPointCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(WorkerPages.WorkerGeneralInfo))
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
                    _pdfWriterService.CreatePdfFile(new List<PickUpPointDTO>(_service.GetAll()),
                        new Dictionary<string, string>
                        {
                            { "Id", "Id" },
                            { "Address", "Адрес" },
                        });
                });
            }
        }
        #endregion

        /// <summary>
        /// Конструктор класса <see cref="PickUpPointGeneralInfoViewModel"./>
        /// </summary>
        public PickUpPointGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IPickUpPointDTOService>();
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
            PickUpPoints = new ObservableCollection<PickUpPointDTO>(_service.GetAll());
        }

        /// <summary>
        /// Метод фильтрации записей. Вызывается при обновлении строки поиска.
        /// </summary>
        private void FilterTable()
        {
            if (_textBoxSearch != String.Empty)
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
