using System.Windows;
using CredentialChecker;
using CredentialChecker.Enums;
using DeliveryService.DTO;
using DeliveryService.Services;
using DeliveryService.View;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryService.ViewModel.Pages.Workers
{
    /// <summary>
    /// ViewModel для редактирования/добавления <see cref="Model.Worker.Password"/>.
    /// </summary>
    public class WorkerEditPasswordViewModel : ViewModelBase
    {
        #region Private Fields
        private WorkerDTO _worker;

        private IEncryptionService _service;

        private Window _window;

        private RelayCommand? _saveCommand;
        private RelayCommand? _closeWindowCommand;
        private RelayCommand? _minimizeWindowCommand;
        private RelayCommand? _cancelWindowCommand;

        private string? _password;

        private int _progressPassword;
        #endregion

        #region Properties
        /// <summary>
        /// Информация для редактирования.
        /// </summary>
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                ShowValidationPassword();
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Заполеннность шкалы сложности пароля.
        /// </summary>
        public int ProgressPassword
        {
            get => _progressPassword;
            set
            {
                _progressPassword = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для сохранения.
        /// </summary>
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand((obj) =>
                {
                    if ((int)PasswordChecker.Check(_password) > 1 && _password != null)
                    {
                        _worker.Password = _service.EncryptPassword(_password);
                        _window.Close();
                    }
                    else
                    {
                        Window window = new ErrorWindow("Пароль не введён или слишком простой.");
                        window.ShowDialog();
                    }
                }));
            }
        }

        /// <summary>
        /// Команда для закрытия окна.
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
        /// Команда для сворачивания окна.
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
        /// Команда для отмены изменений и закрытия окна.
        /// </summary>
        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelWindowCommand ??= new RelayCommand((obj) =>
                {
                    _window.Close();
                });
            }
        }
        #endregion

        /// <summary>
        /// Конструктор класса <see cref="DeliveryEditViewModel"/>.
        /// </summary>
        /// <param name="window">Окно для редактирования данных.</param>
        /// <param name="worker">DTO сотрудника.</param>
        public WorkerEditPasswordViewModel(Window window, WorkerDTO worker)
        {
            _worker = worker;
            _window = window;
            _service = App.ServiceProvider.GetRequiredService<IEncryptionService>();
        }

        /// <summary>
        /// Метод изменяющий <see cref="ProgressPassword"/>.
        /// </summary>
        private void ShowValidationPassword()
        {
            PasswordDifficulty passwordDifficulty = PasswordChecker.Check(_password);

            ProgressPassword = (int)passwordDifficulty * 25;
        }
    }
}
