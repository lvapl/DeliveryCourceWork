using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DeliveryService.DTO;
using DeliveryService.Model;
using DeliveryService.Repository;
using DeliveryService.Services;
using DeliveryService.View;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.WorkersPickUpPoints
{
    public class WorkerPickUpPointEditViewModel : ViewModelBase
    {
        #region Private Fields
        private WorkersInPickUpPointsDTO _workersInPickUpPointsDTO;

        private IWorkerPickUpPointService _workerPointService;
        private IWorkerRepository _workerRepository;
        private IPickUpPointRepository _pointRepository;
        private IShiftRepository _shiftRepository;

        private DsContext _context;

        private Window _window;

        private RelayCommand? _closeWindowCommand;
        private RelayCommand? _minimizeWindowCommand;
        private RelayCommand? _saveCommand;
        private RelayCommand? _cancelCommand;
        #endregion

        #region Properties
        public WorkersInPickUpPointsDTO WorkersInPickUpPointsDTO
        {
            get => _workersInPickUpPointsDTO;
            set
            {
                _workersInPickUpPointsDTO = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Worker> Workers => new ObservableCollection<Worker>(_workerRepository.GetAll());

        public Worker? Worker
        {
            get => _workersInPickUpPointsDTO.WorkerId == 0 ? null : _workerRepository.GetById(_workersInPickUpPointsDTO.WorkerId);
            set
            {
                _workersInPickUpPointsDTO.WorkerId = value?.Id ?? 0;
                OnPropertyChanged();
            }
        }

        public IEnumerable<PickUpPoint> PickUpPoints => new ObservableCollection<PickUpPoint>(_pointRepository.GetAll());

        public PickUpPoint? PickUpPoint
        {
            get => _workersInPickUpPointsDTO.PickUpPointId == 0 ? null : _pointRepository.GetById(_workersInPickUpPointsDTO.PickUpPointId);
            set
            {
                _workersInPickUpPointsDTO.PickUpPointId = value?.Id ?? 0;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Shift> Shifts => new ObservableCollection<Shift>(_shiftRepository.GetAll());

        public Shift? Shift
        {
            get => _workersInPickUpPointsDTO.ShiftId == 0 ? null : _shiftRepository.GetById(_workersInPickUpPointsDTO.ShiftId);
            set
            {
                _workersInPickUpPointsDTO.ShiftId = value?.Id ?? 0;
                OnPropertyChanged();
            }
        }

        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _closeWindowCommand ??= new RelayCommand((obj) =>
                {
                    _window.Close();
                });
            }
        }

        public RelayCommand MinimizeWindowCommand
        {
            get
            {
                return _minimizeWindowCommand ??= new RelayCommand((obj) =>
                {
                    _window.WindowState = WindowState.Minimized;
                });
            }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??= new RelayCommand((obj) =>
                {
                    if (_workersInPickUpPointsDTO.WorkerIdOriginal != 0)
                    {
                        _workerPointService.Edit(_workersInPickUpPointsDTO);
                        _window.Close();
                    }
                    else
                    {
                        if (_context.WorkersInPickUpPoints.FirstOrDefault(x => x.WorkerId == _workersInPickUpPointsDTO.WorkerId
                                                                            && x.PickUpPointId == _workersInPickUpPointsDTO.PickUpPointId
                                                                            && x.WorkingShift == _workersInPickUpPointsDTO.ShiftId) == null)
                        {
                            _workerPointService.Add(_workersInPickUpPointsDTO);
                            _window.Close();
                        }
                        else
                        {
                            Window window = new ErrorWindow("Запись с такими данными уже существует!");
                            window.ShowDialog();
                        }
                    }
                });
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ??= new RelayCommand((obj) =>
                {
                    _window.Close();
                });
            }
        }
        #endregion

        public WorkerPickUpPointEditViewModel(Window window, int? id)
        {
            _window = window;

            _workerRepository = App.ServiceProvider.GetRequiredService<IWorkerRepository>();
            _pointRepository = App.ServiceProvider.GetRequiredService<IPickUpPointRepository>();
            _shiftRepository = App.ServiceProvider.GetRequiredService<IShiftRepository>();

            _workerPointService = App.ServiceProvider.GetRequiredService<IWorkerPickUpPointService>();

            _context = App.ServiceProvider.GetRequiredService<DsContext>();

            _workersInPickUpPointsDTO = id == null ? new WorkersInPickUpPointsDTO() : _workerPointService.GetById((int)id);
        }
    }
}
