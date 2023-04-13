
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace KLTN.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Fields for Enable of button
        private bool _IsButtonAddEnable = true;
        private bool _IsButtonModifyEnable;
        private bool _IsButtonSaveEnable;
        private bool _IsButtonExitEnable = true;
        private bool _IsTextboxEnable;
        #endregion Fields for Enable of button

        #region Properties for Enable of button

        public bool IsButtonAddEnable
        {
            get => _IsButtonAddEnable;
            set
            {
                if (_IsButtonAddEnable != value)
                {
                    _IsButtonAddEnable = value;
                    OnPropertyChanged(nameof(IsButtonAddEnable));
                }
            }
        }
        public bool IsButtonModifyEnable
        {
            get => _IsButtonModifyEnable;
            set
            {
                if (_IsButtonModifyEnable != value)
                {
                    _IsButtonModifyEnable = value;
                    OnPropertyChanged(nameof(IsButtonModifyEnable));
                }
            }
        }

        public bool IsButtonSaveEnable
        {
            get => _IsButtonSaveEnable;
            set
            {
                if (_IsButtonSaveEnable != value)
                {
                    _IsButtonSaveEnable = value;
                    OnPropertyChanged(nameof(IsButtonSaveEnable));
                }
            }
        }

        public bool IsButtonExitEnable
        {
            get => _IsButtonExitEnable;
            set
            {
                if (_IsButtonExitEnable != value)
                {
                    _IsButtonExitEnable = value;
                    OnPropertyChanged(nameof(IsButtonExitEnable));
                }
            }
        }

        public bool IsTextboxEnable
        {
            get => _IsTextboxEnable;
            set
            {
                if (_IsTextboxEnable != value)
                {
                    _IsTextboxEnable = value;
                    OnPropertyChanged(nameof(IsTextboxEnable));
                }
            }
        }
        #endregion Properties for Enable of button

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Action when click button Add
        /// </summary>
        public virtual void AddItemFunction()
        {

        }

        /// <summary>
        /// Action when click button Disable/Enable
        /// </summary>
        public virtual void UpdateStatusOfItemFunction()
        {

        }

        /// <summary>
        /// Action when click button Save in CRUD
        /// </summary>
        public virtual void SaveDataToDatabase()
        {

        }

        /// <summary>
        /// Get data from Database
        /// </summary>
        public virtual void GetDataFromDatabase()
        {

        }


        #endregion

        #region Language
        public string AddLabel => "Thêm mới";
        public string ModifyLabel => "Enable/Disable";
        public string SaveLabel => "Save";
        public string ExitLabel => "Thoát";

        public string EnableLabel => "Có thể sử dụng";
        public string DisableLabel => "Không thể sử dụng";
        #endregion

        #region ICommand
        #region Fields
        private ICommand _ModifyCommand;
        private ICommand _AddCommand;
        private ICommand _SaveCommand;
        #endregion Fields

        #region Properties

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new RelayCommand(ActionWhenBtnSaveClicked, CanExecute);
                }
                return _SaveCommand;
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new RelayCommand(ActionWhenBtnAddClicked, CanExecute);
                }
                return _AddCommand;
            }
        }

        public ICommand ModifyCommand
        {
            get
            {
                if (_ModifyCommand == null)
                {
                    _ModifyCommand = new RelayCommand(ActionWhenBtnModifyClicked, CanExecute);
                }
                return _ModifyCommand;
            }
        }
        #endregion Properties

        #region Method

        /// <summary>
        /// Action when click btn Modify
        /// </summary>
        public virtual void ActionWhenBtnModifyClicked()
        {

        }

        /// <summary>
        /// Action when click btn Add
        /// </summary>
        public virtual void ActionWhenBtnAddClicked()
        {

        }

        /// <summary>
        /// Action when click btn Save
        /// </summary>
        public virtual void ActionWhenBtnSaveClicked()
        {

        }

        public virtual void ReloadCollection()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanExecute()
        {
            return true;
        }
        #endregion Method

        #endregion ICommand

        #region Constant
        public const string _HoatDong = "Hoạt động";
        public const string _KhongHoatDong = "Không hoạt động";
        public const string _San5 = "Sân 5";
        public const string _San7 = "Sân 7";
        public const string _San11 = "Sân 11";
        public const string _SanOther = "Sân khác";
        #endregion Constant
    }
}
