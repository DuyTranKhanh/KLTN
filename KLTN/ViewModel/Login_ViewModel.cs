using GalaSoft.MvvmLight.Command;
using KLTN.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KLTN.ViewModel
{
    public partial class Login_ViewModel : BaseViewModel
    {
        private bool _IsValid = false;
        public bool IsValid
        {
            get => _IsValid;
            set
            {
                if(_IsValid != value)
                {
                    _IsValid = value;
                    OnPropertyChanged(nameof(IsValid));
                }
            }
        }

        private string _Account;
        public string Account
        {
            get => _Account;
            set
            {
                if(_Account != value)
                {
                    _Account = value;
                    OnPropertyChanged(nameof(Account));
                }
            }
        }

        private string _PassWord;
        public string Password
        {
            get => _PassWord;
            set
            {
                if (_PassWord != value)
                {
                    _PassWord = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private ICommand _LoginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if(_LoginCommand == null)
                {
                    _LoginCommand = new RelayCommand<object>(LoginAction, true);
                }
                return _LoginCommand;
            }
        }

        private Window _window;
        private void LoginAction(object obj)
        {
            if(obj != null)
            {
                var passControl = obj as PasswordBox;
                Password = passControl.Password;
                if (Account == "Admin" && Password == "Admin123")
                {
                    IsValid = true;
                    _window = new YardView();
                    _window.Show();
                }
                else IsValid = false;
            }
        }
    }
    public partial class Login_ViewModel : BaseViewModel
    {
        
    }
}
