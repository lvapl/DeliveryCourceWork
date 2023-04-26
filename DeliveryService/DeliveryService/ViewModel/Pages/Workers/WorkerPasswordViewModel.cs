using System.Collections.ObjectModel;
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
                        Window window = new ErrorWindow("Не у далось выполнить действие. Недостаточно прав.");
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

            Workers = new ObservableCollection<WorkerDTO>(_service.GetAll());
        }
    }
}
