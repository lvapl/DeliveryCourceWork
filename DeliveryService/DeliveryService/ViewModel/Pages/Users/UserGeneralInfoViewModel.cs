using DeliveryService.DTO;
using DeliveryService.Enums;
using DeliveryService.Services;
using DeliveryService.View;
using DeliveryService.View.Pages.Users;
using DeliveryService.View.Workers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryService.ViewModel.Pages.Users
{
    public class UserGeneralInfoViewModel : ViewModelBase
    {
        #region Private Fields
        private IUserDTOService _service;

        private IAuthenticationService _authenticationService;

        private IPdfWriterService _pdfWriterService;

        private ObservableCollection<UserDTO>? _users;

        private RelayCommand? _editUserCommand;

        private RelayCommand? _deleteUserCommand;

        private RelayCommand? _addUserCommand;

        private RelayCommand? _createPdf;

        private string _textBoxSearch;
        #endregion

        #region Properties
        public ObservableCollection<UserDTO>? Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public string TextBoxSearch
        {
            get => _textBoxSearch;
            set
            {
                _textBoxSearch = value;
                OnPropertyChanged();
                FilterTable();
            }
        }

        public RelayCommand? EditUserCommand
        {
            get
            {
                return _editUserCommand ?? (_editUserCommand = new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(UserPages.UserGenerlaInfo))
                    {
                        if (obj != null)
                        {
                            Window window = new UserEdit((int)obj);
                            window.ShowDialog();
                            UpdateData();
                        }
                    }
                    else
                    {
                        Window window = new ErrorWindow("Не у далось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                }));
            }
        }

        public RelayCommand? DeleteUserCommand
        {
            get
            {
                return _deleteUserCommand ?? (_deleteUserCommand = new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(UserPages.UserGenerlaInfo))
                    {
                        if (obj != null)
                        {
                            _service.Remove((int)obj);
                            UpdateData();
                        }
                    }
                    else
                    {
                        Window window = new ErrorWindow("Не у далось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                }));
            }
        }

        public RelayCommand AddUserCommand
        {
            get
            {
                return _addUserCommand ?? (_addUserCommand = new RelayCommand((obj) =>
                {
                    if (_authenticationService.HasPermissionToModifySubsection(UserPages.UserGenerlaInfo))
                    {
                        Window window = new UserEdit(null);
                        window.ShowDialog();
                        UpdateData();
                    }
                    else
                    {
                        Window window = new ErrorWindow("Не у далось выполнить действие. Недостаточно прав.");
                        window.ShowDialog();
                    }
                }));
            }
        }

        public RelayCommand? CreatePdf
        {
            get
            {
                return _createPdf ?? (_createPdf = new RelayCommand((obj) =>
                {
                    _pdfWriterService.CreatePdfFile(new List<UserDTO>(_service.GetAll()),
                                                    new Dictionary<string, string>
                                                    {
                                                        { "Id", "Id" },
                                                        { "FirstName", "Имя" },
                                                        { "LastName", "Фамилия" },
                                                        { "Patronymic", "Отчество" },
                                                        { "PassportNumber", "Номер паспорта" },
                                                        { "PassportSeries", "Серия паспорта" },
                                                        { "TelephoneNumber", "Номер телефона" },
                                                        { "Address", "Адрес проживания" },
                                                        { "PassportAddress", "Адрес по паспорту" },
                                                    });
                }));
            }
        }
        #endregion

        public UserGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IUserDTOService>();
            _authenticationService = App.ServiceProvider.GetRequiredService<IAuthenticationService>();
            _pdfWriterService = App.ServiceProvider.GetRequiredService<IPdfWriterService>();

            UpdateData();
        }

        #region Methods
        private void UpdateData()
        {
            Users = new ObservableCollection<UserDTO>(_service.GetAll());
        }

        private void FilterTable()
        {
            if (_textBoxSearch != null)
            {
                Users = new ObservableCollection<UserDTO>(_service.GetAll().Where(x => x.Id.ToString().Contains(_textBoxSearch)
                                                                                    || x.FirstName.Contains(_textBoxSearch)
                                                                                    || x.LastName.Contains(_textBoxSearch)
                                                                                    || (x.Patronymic != null && x.Patronymic.Contains(_textBoxSearch))
                                                                                    || x.TelephoneNumber.Contains(_textBoxSearch)
                                                                                    || (x.Address != null
                                                                                        && ((x.Address.Country != null && x.Address.Country.Contains(_textBoxSearch))
                                                                                            || (x.Address.City != null && x.Address.City.Contains(_textBoxSearch))
                                                                                            || (x.Address.Street != null && x.Address.Street.Contains(_textBoxSearch))
                                                                                            || (x.Address.House != null && x.Address.House.Contains(_textBoxSearch))))));
            }

        }
        #endregion
    }
}
