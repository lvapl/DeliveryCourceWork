using System;
using System.Windows.Input;

namespace DeliveryService
{
    /// <summary>
    /// Класс, реализующий <see cref="ICommand"/> интерфейс, чтобы позволить привязку команд к действиям.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Fields
        private Action<object?> _execute;
        private Func<object?, bool>? _canExecute;
        #endregion

        #region Properties
        /// <summary>
        /// Событие, вызываемое при изменении состояния команды.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        #endregion
        
        /// <summary>
        /// Конструктор класса RelayCommand.
        /// </summary>
        /// <param name="execute">Действие, которое должно быть выполнено командой.</param>
        /// <param name="canExecute">Метод, который определяет, может ли команда выполняться в данный момент (опционально).</param>
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        
        #region Methods
        /// <summary>
        /// Определяет, может ли команда выполняться в данный момент.
        /// </summary>
        /// <param name="parameter">Параметр, переданный команде.</param>
        /// <returns>True, если команда может выполняться; false в противном случае.</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Выполняет действие команды.
        /// </summary>
        /// <param name="parameter">Параметр, переданный команде.</param>
        public void Execute(object? parameter)
        {
            _execute(parameter ?? null);
        }
        #endregion
    }
}
