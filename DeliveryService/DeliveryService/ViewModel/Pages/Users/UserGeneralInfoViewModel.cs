﻿using DeliveryService.DTO;
using DeliveryService.Services;
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

        private ObservableCollection<UserDTO>? _users;

        private RelayCommand? _editUserCommand;

        private RelayCommand? _deleteUserCommand;

        private RelayCommand? _addUserCommand;

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
                    if (obj != null)
                    {
                        Window window = new UserEdit((int)obj);
                        window.ShowDialog();
                        UpdateData();
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
                    if (obj != null)
                    {
                        _service.Remove((int)obj);
                        UpdateData();
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
                    Window window = new UserEdit(null);
                    window.ShowDialog();
                    UpdateData();
                }));
            }
        }
        #endregion

        public UserGeneralInfoViewModel()
        {
            _service = App.ServiceProvider.GetRequiredService<IUserDTOService>();
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
