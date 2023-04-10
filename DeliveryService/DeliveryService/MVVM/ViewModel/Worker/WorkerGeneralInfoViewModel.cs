using DeliveryService.MVVM.Model.DTO;
using DeliveryService.MVVM.View.Worker;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.MVVM.ViewModel
{
    public class WorkerGeneralInfoViewModel : ViewModelBase
    {
        #region Private Fields
        private IWorkerGeneralInfoService _service;

        private ObservableCollection<WorkerGeneralInfoDTO>? _workers;

        private RelayCommand? _editWorkerCommand;

        private RelayCommand? _deleteWorkerCommand;
        #endregion

        #region Properties
        public ObservableCollection<WorkerGeneralInfoDTO>? Workers
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
                return _editWorkerCommand ?? (_editWorkerCommand = new RelayCommand((object? obj) =>
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
                return _deleteWorkerCommand ?? (_deleteWorkerCommand = new RelayCommand((object? obj) =>
                {
                    if (obj != null)
                    {
                        _service.Remove((int)obj);
                        UpdateData();
                    }
                }));
            }
        }
        #endregion

        public WorkerGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IWorkerGeneralInfoService>();
            UpdateData();
        }

        private void UpdateData()
        {
            Workers = new ObservableCollection<WorkerGeneralInfoDTO>(_service.GetAll());
        }
    }
}
