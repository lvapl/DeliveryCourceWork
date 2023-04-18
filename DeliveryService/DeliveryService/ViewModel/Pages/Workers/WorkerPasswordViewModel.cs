using DeliveryService.DTO;
using DeliveryService.Model;
using DeliveryService.Services;
using DeliveryService.View.Pages.Workers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.ViewModel.Pages.Workers
{
    public class WorkerPasswordViewModel : ViewModelBase
    {
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

        public RelayCommand? EditPasswordCommand
        {
            get
            {
                return _editPasswordCommand ?? (_editPasswordCommand = new RelayCommand((obj) =>
                {
                    WorkerDTO worker = _service.GetById((int)(obj ?? 0));

                    Window window = new WorkerEditPassword(worker);
                    window.ShowDialog();

                    OnPropertyChanged(nameof(Workers));

                    _service.Edit(worker);
                }));
            }
        }


        public WorkerPasswordViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IWorkerDTOService>();

            Workers = new ObservableCollection<WorkerDTO>(_service.GetAll());
        }
    }
}
