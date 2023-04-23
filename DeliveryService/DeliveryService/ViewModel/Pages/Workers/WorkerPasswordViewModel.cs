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
    public class WorkerPasswordViewModel : ViewModelBase
    {
        private IAuthenticationService _authenticationService;

        private IWorkerDTOService _service;

        private ObservableCollection<WorkerDTO>? _workers;

        private RelayCommand? _editPasswordCommand;



        public ObservableCollection<WorkerDTO>? Workers
        {
            get => _workers;
            set
            {
                _workers = value;
                OnPropertyChanged();
            }
        }

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


        public WorkerPasswordViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IWorkerDTOService>();
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();

            Workers = new ObservableCollection<WorkerDTO>(_service.GetAll());
        }
    }
}
