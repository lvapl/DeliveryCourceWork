using System.Windows;

namespace DeliveryService.ViewModel
{
    public class ErrorViewModel
    {
        private Window _window;

        private RelayCommand? _closeWindowCommand;

        private RelayCommand? _minimizeWindowCommand;



        public string Message { get; set; }

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


        public ErrorViewModel(Window window, string message)
        {
            _window = window;
            Message = message;
        }
    }
}
