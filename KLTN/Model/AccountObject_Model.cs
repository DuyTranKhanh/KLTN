using System.Collections.ObjectModel;

namespace KLTN.Model
{
    public class AccountObject_Model
    {
        private string _Sdt = string.Empty;
        private string _Cmnd = string.Empty;
        private string _Account = string.Empty;
        private string _Password = string.Empty;
        private string _HoVaTen = string.Empty;
        private string _Status = string.Empty;
        private bool _IsAdmin;

        public bool IsAdmin
        {
            get => _IsAdmin;
            set
            {
                _IsAdmin = value;
            }
        }
        public string Sdt
        {
            get => _Sdt;
            set
            {
                _Sdt = value;
            }
        }

        public string Cmnd
        {
            get => _Cmnd;
            set
            {
                _Cmnd = value;
            }
        }

        public string Account
        {
            get => _Account;
            set
            {
                _Account = value;
            }
        }

        public string Password
        {
            get => _Password;
            set
            {
                _Password = value;
            }
        }

        public string HoVaTen
        {
            get => _HoVaTen;
            set
            {
                _HoVaTen = value;
            }
        }

        public string Status
        {
            get => _Status;
            set
            {
                _Status = value;
            }
        }

        public AccountObject_Model Clone()
        {
            var temp = new AccountObject_Model();
            temp.Sdt = Sdt;
            temp.Status = Status;
            temp.HoVaTen = HoVaTen;
            temp.Password = Password;
            temp.Cmnd = Cmnd;
            temp.Account = Account;
            temp.IsAdmin = IsAdmin;
            return temp;
        }
    }
}
