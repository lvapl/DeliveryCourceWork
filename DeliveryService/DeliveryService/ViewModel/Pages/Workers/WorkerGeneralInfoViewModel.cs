using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Enums;
using DeliveryService.Services;
using DeliveryService.View;
using DeliveryService.View.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.Workers
{
    /// <summary>
    /// ViewModel для страницы "Общая информация" раздела "Доставки".
    /// </summary>
    public class WorkerGeneralInfoViewModel : ViewModelBase
    {
        #region Private Fields
        private IWorkerDTOService _service;
        private IAuthenticationService _authenticationService;
        private IPdfWriterService _pdfWriterService;

        private ObservableCollection<WorkerDTO>? _workers;

        private RelayCommand? _editWorkerCommand;
        private RelayCommand? _addWorkerCommand;
        private RelayCommand? _deleteWorkerCommand;
        private RelayCommand? _createPdf;

        private string _textBoxSearch;
        #endregion

        #region Properties
        /// <summary>
        /// Список сотрудников <see cref="Model.Worker"/>
        /// </summary>
        public ObservableCollection<WorkerDTO>? Workers
        {
            get => _workers;
            set
            {
                _workers = value;
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
        /// Команда для открытия окна редактирования сотрудника.
        /// </summary>
        public RelayCommand EditWorkerCommand
        {
            get
            {
                return _editWorkerCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(WorkerPages.WorkerGeneralInfo))
                    {
                        if (obj != null)
                        {
                            Window window = new WorkerEdit((int)obj);
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
        /// Команда для удаления сотрудника.
        /// </summary>
        public RelayCommand DeleteWorkerCommand
        {
            get
            {
                return _deleteWorkerCommand ??= new RelayCommand((obj) =>
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
                        Window window = new ErrorWindow("Не удалось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                });
            }
        }

        /// <summary>
        /// Команда для открытия окна добавления сотрудника.
        /// </summary>
        public RelayCommand AddWorkerCommand
        {
            get
            {
                return _addWorkerCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(WorkerPages.WorkerGeneralInfo))
                    {
                        Window window = new WorkerEdit(null);
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
                    _pdfWriterService.CreatePdfFile(new List<WorkerDTO>(_service.GetAll()),
                        new Dictionary<string, string>
                        {
                            { "Id", "Id" },
                            { "FirstName", "Имя" },
                            { "LastName", "Фамилия" },
                            { "Patronymic", "Отчество" },
                            { "Title", "Должность" },
                            { "Login", "Логин" },
                            { "PassportNumber", "Номер паспорта" },
                            { "PassportSeries", "Серия паспорта" },
                            { "TelephoneNumber", "Номер телефона" },
                            { "Address", "Адрес проживания" },
                            { "PassportAddress", "Адрес по паспорту" },
                        });
                });
            }
        }
        #endregion

        /// <summary>
        /// Конструктор класса <see cref="WorkerGeneralInfoViewModel"./>
        /// </summary>
        public WorkerGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IWorkerDTOService>();
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
            Workers = new ObservableCollection<WorkerDTO>(_service.GetAll());
        }

        /// <summary>
        /// Метод фильтрации записей. Вызывается при обновлении строки поиска.
        /// </summary>
        private void FilterTable()
        {
            if (_textBoxSearch != String.Empty)
            {
                Workers = new ObservableCollection<WorkerDTO>(_service.GetAll().Where(x => x.Id.ToString().Contains(_textBoxSearch)
                                                                                        || x.FirstName.Contains(_textBoxSearch)
                                                                                        || x.LastName.Contains(_textBoxSearch)
                                                                                        || (x.Patronymic != null && x.Patronymic.Contains(_textBoxSearch))
                                                                                        || x.Title.Contains(_textBoxSearch)
                                                                                        || x.TelephoneNumber.Contains(_textBoxSearch)
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
