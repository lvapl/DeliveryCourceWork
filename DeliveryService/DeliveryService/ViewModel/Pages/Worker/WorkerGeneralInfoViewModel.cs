using DeliveryService.DTO;
using DeliveryService.View.Worker;
using DeliveryService.Services;
using DeliveryService.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.ViewModel.Pages.Worker
{
    public class WorkerGeneralInfoViewModel : ViewModelBase
    {
        #region Private Fields
        private IWorkerDTOService _service;

        private ObservableCollection<WorkerDTO>? _workers;

        private RelayCommand? _editWorkerCommand;

        private RelayCommand? _deleteWorkerCommand;

        private RelayCommand? _addWorkerCommand;
        #endregion

        #region Properties
        public ObservableCollection<WorkerDTO>? Workers
        {
            get => _workers;
            set
            {
                _workers = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand? EditWorkerCommand
        {
            get
            {
                return _editWorkerCommand ?? (_editWorkerCommand = new RelayCommand((obj) =>
                {
                    if (obj != null)
                    {
                        Window window = new WorkerEdit((int)obj);
                        window.ShowDialog();
                        UpdateData();
                    }
                }));
            }
        }

        public RelayCommand? DeleteWorkerCommand
        {
            get
            {
                return _deleteWorkerCommand ?? (_deleteWorkerCommand = new RelayCommand((obj) =>
                {
                    if (obj != null)
                    {
                        _service.Remove((int)obj);
                        UpdateData();
                    }
                }));
            }
        }

        public RelayCommand? AddWorkerCommand
        {
            get
            {
                return _addWorkerCommand ?? (_addWorkerCommand = new RelayCommand((obj) =>
                {
                    Window window = new WorkerEdit();
                    window.ShowDialog();
                    UpdateData();
                }));
            }
        }
        #endregion

        public WorkerGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IWorkerDTOService>();
            UpdateData();
        }

        private void UpdateData()
        {
            Workers = new ObservableCollection<WorkerDTO>(_service.GetAll());
        }
    }
}
