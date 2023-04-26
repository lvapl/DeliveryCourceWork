using System.Windows;

namespace DeliveryService.ViewModel
{
    /// <summary>
    /// Модель представления окна с ошибкой.
    /// </summary>
    public class ErrorViewModel
    {
        #region Private Fields
        private Window _window;

        private RelayCommand? _closeWindowCommand;
        private RelayCommand? _minimizeWindowCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Команда закрытия окна.
        /// </summary>
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

        /// <summary>
        /// Команда сворачивания окна.
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
        #endregion

        /// <summary>
        /// Конструктор класса <see cref="ErrorViewModel"/>.
        /// </summary>
        /// <param name="window">Окно, в котором отображается сообщение об ошибке.</param>
        /// <param name="message">Сообщение об ошибке.</param>
        public ErrorViewModel(Window window, string message)
        {
            _window = window;
            Message = message;
        }
    }
}
