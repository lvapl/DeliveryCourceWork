using DeliveryService.Enums;
using DeliveryService.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DeliveryService.MVVM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private Fields
        private Window _window;

        private RelayCommand? _changePageCommand;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _maximazeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;

        private AppPages? _currentPage;
        #endregion

        #region Properties
        public double MaxHight
        {
            get
            {
                return SystemParameters.MaximizedPrimaryScreenHeight;
            }
        }

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
                return _changePageCommand ?? (_changePageCommand = new RelayCommand((object? obj) =>
                {
                    CurrentPage = (AppPages?)obj;
                    
                }));
            }
        }

        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _closeWindowCommand ?? (_closeWindowCommand = new RelayCommand((object? obj) =>
                {
                    _window.Close();
                }));
            }
        }

        public RelayCommand MinimizeWindowCommand
        {
            get
            {
                return _minimizeWindowCommand ?? (_minimizeWindowCommand = new RelayCommand((object? obj) =>
                {
                    _window.WindowState = WindowState.Minimized;
                }));
            }
        }

        public RelayCommand MaximazeWindowCommand
        {
            get
            {
                return _maximazeWindowCommand ?? (_maximazeWindowCommand = new RelayCommand((object? obj) =>
                {
                    if (_window.WindowState == WindowState.Maximized)
                    {
                        _window.WindowState = WindowState.Normal;
                    }
                    else
                    {
                        _window.WindowState = WindowState.Maximized;
                    }
                }));
            }
        }
        #endregion

        public MainWindowViewModel(Window window)
        {
            _window = window;
        }
    }
}
