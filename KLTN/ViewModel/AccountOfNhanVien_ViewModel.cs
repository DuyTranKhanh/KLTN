using System.Collections.ObjectModel;
using KLTN.Model;
using KLTN.Service;

namespace KLTN.ViewModel
{
    public partial class AccountOfNhanVien_ViewModel : BaseViewModel
    {
        #region Textbox
        #region Fields
        private string _HoVaTen;
        private string _TenTaiKhoan;
        private string _MatKhau;
        private string _SDT;
        private string _Cmnd;
        private string _TrangThai;
        private bool _IsAdmin;
        #endregion Fields

        #region Properties
        public string HoVaTen
        {
            get => _HoVaTen;
            set
            {
                if (_HoVaTen != value)
                {
                    _HoVaTen = value;
                    OnPropertyChanged(nameof(HoVaTen));
                }
            }
        }
        public string TenTaiKhoan
        {
            get => _TenTaiKhoan;
            set
            {
                if (_TenTaiKhoan != value)
                {
                    _TenTaiKhoan = value;
                    OnPropertyChanged(nameof(TenTaiKhoan));
                }
            }
        }
        public string MatKhau
        {
            get => _MatKhau;
            set
            {
                if (_MatKhau != value)
                {
                    _MatKhau = value;
                    OnPropertyChanged(nameof(MatKhau));
                }
            }
        }
        public string SDT
        {
            get => _SDT;
            set
            {
                if (_SDT != value)
                {
                    _SDT = value;
                    OnPropertyChanged(nameof(SDT));
                }
            }
        }
        public string Cmnd
        {
            get => _Cmnd;
            set
            {
                if (_Cmnd != value)
                {
                    _Cmnd = value;
                    OnPropertyChanged(nameof(Cmnd));
                }
            }
        }
        public string TrangThai
        {
            get => _TrangThai;
            set
            {
                if (_TrangThai != value)
                {
                    _TrangThai = value;
                    OnPropertyChanged(nameof(TrangThai));
                }
            }
        }
        public bool IsAdmin
        {
            get => _IsAdmin;
            set
            {
                if (_IsAdmin != value)
                {
                    _IsAdmin = value;
                    OnPropertyChanged(nameof(IsAdmin));
                }
            }
        }

        #endregion Properties
        #endregion

        #region Selected Item
        private AccountObject_Model _SelectedItem;
        public AccountObject_Model SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new AccountObject_Model();
                }
                return _SelectedItem;
            }
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    ActionWhenChangeItem();
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }
        #endregion Selected Item

        #region Constructor
        public AccountOfNhanVien_ViewModel()
        {
            TheDatabase = new AccountOfNhanVien_Service();
        }
        #endregion

        AccountOfNhanVien_Service TheDatabase;
        private ObservableCollection<AccountObject_Model> _DanhSachAccount;

        public ObservableCollection<AccountObject_Model> DanhSachAccount
        {
            get
            {
                if (_DanhSachAccount == null)
                {
                    _DanhSachAccount = new ObservableCollection<AccountObject_Model>();
                    GetDataFromDatabase();
                }
                return _DanhSachAccount;
            }
            set
            {
                if (_DanhSachAccount != value)
                {
                    _DanhSachAccount = value;
                    OnPropertyChanged(nameof(DanhSachAccount));
                }
            }
        }
        #region Method

        //Flag for Edit or Save

        bool _FlagSave = false; //If value is false that mean btn Add is clicked, ortherwise btn Modify is Clicked
        /// <summary>
        /// Update value when select an item
        /// </summary>
        public void ActionWhenChangeItem()
        {
            HoVaTen = SelectedItem.HoVaTen.ToString();
            TenTaiKhoan = SelectedItem.Account.ToString();
            MatKhau = SelectedItem.Password.ToString();
            SDT = SelectedItem.Sdt.ToString();
            Cmnd = SelectedItem.Cmnd.ToString();
            TrangThai = SelectedItem.Status.ToString();
            IsAdmin = SelectedItem.IsAdmin;
            IsButtonSaveEnable = false;
            IsButtonModifyEnable = true;
            IsTextboxEnable = false;
        }

        public override void ActionWhenBtnAddClicked()
        {
            //Clear all information in textbox
            HoVaTen = "";
            TrangThai = "Hoạt động";
            SDT = "";
            Cmnd = "";
            MatKhau = "";
            TenTaiKhoan = "";
            IsAdmin = false;
            HoVaTen = "";

            _FlagSave = true;
            IsButtonAddEnable = false;
            IsButtonSaveEnable = true;
            IsTextboxEnable = true;
            IsButtonModifyEnable = false;
        }

        public override void ActionWhenBtnModifyClicked()
        {
            _FlagSave = false;
            IsButtonAddEnable = false;
            IsButtonSaveEnable = true;
            IsTextboxEnable = true;
            IsButtonModifyEnable = false;
            //if (SelectedItem.Status == _HoatDong)
            //{
            //    SelectedItem.Status = _KhongHoatDong;
            //}
            //else
            //{
            //    SelectedItem.Status = _HoatDong;
            //}
            //TheDatabase.UpdateItem(SelectedItem);
            //TrangThai = SelectedItem.Status;
        }

        public override void ActionWhenBtnSaveClicked()
        {
            AccountObject_Model temp = new AccountObject_Model();
            temp.Password = MatKhau;
            temp.Sdt = SDT;
            temp.Cmnd = Cmnd;
            temp.IsAdmin = IsAdmin;
            temp.Status = TrangThai;
            temp.Account = TenTaiKhoan;
            temp.HoVaTen = HoVaTen;

            //Add item
            if (_FlagSave)
            {
                DanhSachAccount.Add(temp);
                //Save to database
                TheDatabase.Add(temp);
            }
            //Modify Item
            else
            {
                string idSelected = SelectedItem.Account;
                var tempList = new ObservableCollection<AccountObject_Model>();
                for(int i = 0; i < DanhSachAccount.Count;i++)
                {
                    tempList.Add(DanhSachAccount[i].Clone());
                }
                DanhSachAccount = tempList;
                TheDatabase.UpdateItem(temp);
            }
            SelectedItem = DanhSachAccount[0];
            IsButtonAddEnable = true;
            IsButtonSaveEnable = false;
            IsTextboxEnable = false;
            IsButtonModifyEnable = true;

        }

        public override void GetDataFromDatabase()
        {
            DanhSachAccount = TheDatabase.GetAll();
        }
        #endregion Method
    }
    public partial class AccountOfNhanVien_ViewModel : BaseViewModel
    {
        #region Danh Sách 
        public string DanhSachLabel => "Danh sách tài khoản";
        public string CotTaiKhoanLabel => "Tài khoản";
        public string CotMatKhauLabel => "Mật khẩu";
        public string TrangThaiLabel => "Trạng Thái";
        public string CotIsAdmin => "Có quyền Admin";
        public string Modify_Label => "Edit";

        #endregion Danh sách

        #region Thông tin Item
        public string ThongTinLabel => "Thông tin tài khoản";
        public string TenTaiKhoanItemLabel => "Tài khoản";
        public string TenMatKhauItemLabel => "Mật khẩu";
        public string SdtItemLabel => "Số điện thoại";
        public string HoVaTenItemLabel => "Họ và tên";
        public string CmndItemLabel => "CMND/CCCD";

        #endregion Thông tin Item
    }
}
