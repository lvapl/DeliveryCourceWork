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
using DeliveryService.View.Pages.WorkersPickUpPoints;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.WorkersPickUpPoints
{
    public class WorkerPickUpPointGeneralInfoViewModel : ViewModelBase
    {
        #region Private Fields
        private IWorkerPickUpPointService _service;

        private IAuthenticationService _authenticationService;

        private IPdfWriterService _pdfWriterService;

        private ObservableCollection<WorkersInPickUpPointsDTO> _workersInPickUpPoints;

        private RelayCommand? _editWorkerPickUpPointCommand;

        private RelayCommand? _deleteWorkerPickUpPointCommand;

        private RelayCommand? _addWorkerPickUpPointCommand;

        private RelayCommand? _createPdf;

        private string _textBoxSearch;
        #endregion

        #region Properties
        public ObservableCollection<WorkersInPickUpPointsDTO> WorkersInPickUpPoints
        {
            get => _workersInPickUpPoints;
            set
            {
                _workersInPickUpPoints = value;
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

        public RelayCommand EditWorkerPickUpPointCommand
        {
            get
            {
                return _editWorkerPickUpPointCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(PickUpPointPages.PickUpPointGeneralInfo))
                    {
                        if (obj != null)
                        {
                            Window window = new WorkerPickUpPointEdit((int)obj);
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

        public RelayCommand DeleteWorkerPickUpPointCommand
        {
            get
            {
                return _deleteWorkerPickUpPointCommand ??= new RelayCommand((obj) =>
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
                        Window window = new ErrorWindow("Не удалось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                });
            }
        }

        public RelayCommand AddWorkerPickUpPointCommand
        {
            get
            {
                return _addWorkerPickUpPointCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(PickUpPointPages.PickUpPointGeneralInfo))
                    {
                        Window window = new WorkerPickUpPointEdit(null);
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

        public RelayCommand CreatePdf
        {
            get
            {
                return _createPdf ??= new RelayCommand((obj) =>
                {
                    _pdfWriterService.CreatePdfFile(new List<WorkersInPickUpPointsDTO>(_service.GetAll()),
                        new Dictionary<string, string>
                        {
                            { "Id", "Id" },
                            { "WorkerId", "Id сотрудника" },
                            { "FirstName", "Имя" },
                            { "LastName", "Фамилия" },
                            { "Patronymic", "Отчество" },
                            { "PichUpPointId", "Id точки выдачи" },
                            { "Address", "Адрес" },
                            { "ShiftId", "Id смены" },
                            { "StartedShiftAt", "Начало смены" },
                            { "EndedShiftAt", "Окончание смены" },
                        });
                });
            }
        }
        #endregion

        public WorkerPickUpPointGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IWorkerPickUpPointService>();
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
            _pdfWriterService = App.ServiceProvider.GetRequiredService<IPdfWriterService>();

            UpdateData();
        }

        #region Methods
        private void UpdateData()
        {
            WorkersInPickUpPoints = new ObservableCollection<WorkersInPickUpPointsDTO>(_service.GetAll());
        }

        private void FilterTable()
        {
            if (_textBoxSearch != string.Empty)
            {
                WorkersInPickUpPoints = new ObservableCollection<WorkersInPickUpPointsDTO>(_service.GetAll().Where(x => x.Id.ToString().Contains(_textBoxSearch)
                                                                                                                     || x.WorkerId.ToString().Contains(_textBoxSearch)
                                                                                                                     || x.FirstName.Contains(_textBoxSearch)
                                                                                                                     || (x.Patronymic != null && x.Patronymic.Contains(_textBoxSearch))
                                                                                                                     || x.PickUpPointId.ToString().Contains(_textBoxSearch)
                                                                                                                     || x.ShiftId.ToString().Contains(_textBoxSearch)
                                                                                                                     || x.StartedShiftAt.ToString().Contains(_textBoxSearch)
                                                                                                                     || x.EndedShiftAt.ToString().Contains(_textBoxSearch)
                                                                                                                     || x.Address != null
                                                                                                                         && (x.Address.Country != null && x.Address.Country.Contains(_textBoxSearch)
                                                                                                                          || x.Address.City != null && x.Address.City.Contains(_textBoxSearch)
                                                                                                                          || x.Address.Street != null && x.Address.Street.Contains(_textBoxSearch)
                                                                                                                          || x.Address.House != null && x.Address.House.Contains(_textBoxSearch))));
            }
            else
            {
                UpdateData();
            }
        }
        #endregion
    }
}
