using System.Windows;
using DeliveryService.Enums;
using DeliveryService.Model;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private Fields
        private Window _window;

        private IAuthenticationService _authenticationService;

        private RelayCommand? _changePageCommand;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _maximazeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private AppPages? _currentPage;

        private Worker? _currentWorker;
        #endregion

        #region Properties
        public double MaxHight => SystemParameters.MaximizedPrimaryScreenHeight;

        public AppPages? CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ChangePageCommand
        {
            get
            {
                return _changePageCommand ??= new RelayCommand((obj) =>
                {
                    if (obj != null && _authenticationService.HasAccessToSection((AppPages)obj))
                    {
                        CurrentPage = (AppPages)obj;
                    }
                    else
                    {
                        CurrentPage = null;
                    }
                });
            }
        }

        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _closeWindowCommand ??= new RelayCommand((obj) =>
                {
                    App.Current.Shutdown();
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

        public RelayCommand MaximazeWindowCommand
        {
            get
            {
                return _maximazeWindowCommand ??= new RelayCommand((obj) =>
                {
                    _window.WindowState = _window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                });
            }
        }

        public Worker? CurrentWorker
        {
            get => _currentWorker;
            set
            {
                _currentWorker = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public MainWindowViewModel(Window window)
        {
            _window = window;
            
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
