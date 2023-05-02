using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Enums;
using DeliveryService.Services;
using DeliveryService.View;
using DeliveryService.View.Pages.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.Workers
{
    /// <summary>
    /// ViewModel для страницы "Пароли" раздела "Сотрудники".
    /// </summary>
    public class WorkerPasswordViewModel : ViewModelBase
    {
        #region Private Fields
        private IAuthenticationService _authenticationService;
        private IWorkerDTOService _service;

        private ObservableCollection<WorkerDTO>? _workers;

        private RelayCommand? _editPasswordCommand;

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
        /// Команда для открытия окна редактирования пароля.
        /// </summary>
        public RelayCommand EditPasswordCommand
        {
            get
            {
                return _editPasswordCommand ??= new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(WorkerPages.WorkerPassword))
                    {
                        WorkerDTO worker = _service.GetById((int)(obj ?? 0));

                        Window window = new WorkerEditPassword(worker);
                        window.ShowDialog();

                        OnPropertyChanged(nameof(Workers));

                        _service.Edit(worker);
                    }
                    else
                    {
                        Window window = new ErrorWindow("Не удалось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                });
            }
        }
        #endregion

        /// <summary>
        /// Конструктор класса <see cref="WorkerPasswordViewModel"./>
        /// </summary>
        public WorkerPasswordViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IWorkerDTOService>();
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();

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
                                                                                        || (x.Patronymic != null && x.Patronymic.Contains(_textBoxSearch))));
            }
            else
            {
                UpdateData();
            }
        }
        #endregion
    }
}
