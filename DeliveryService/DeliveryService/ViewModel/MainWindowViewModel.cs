using System.Windows;
using DeliveryService.Enums;
using DeliveryService.Model;
using DeliveryService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel
{
    /// <summary>
    /// Модель представления главного окна.
    /// </summary>
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
        /// <summary>
        /// Максимальная высота главного окна.
        /// </summary>
        public double MaxHight => SystemParameters.MaximizedPrimaryScreenHeight;

        /// <summary>
        /// Текущая страница приложения.
        /// </summary>
        public AppPages? CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для изменения текущей страницы приложения.
        /// </summary>
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

        /// <summary>
        /// Команда для закрытия главного окна.
        /// </summary>
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

        /// <summary>
        /// Команда для сворачивания главного окна.
        /// </summary>
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

        /// <summary>
        /// Команда для разворачивания/свертывания главного окна.
        /// </summary>
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

        /// <summary>
        /// Текущий работник.
        /// </summary>
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

        /// <summary>
        /// Конструктор класса <see cref="MainWindowViewModel"/>.
        /// </summary>
        /// <param name="window">Главное окно.</param>
        public MainWindowViewModel(Window window)
        {
            _window = window;
            
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
        }
    }
}
