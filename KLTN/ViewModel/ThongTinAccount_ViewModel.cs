using System.Collections.ObjectModel;
using KLTN.Model;
using KLTN.Service;

namespace KLTN.ViewModel
{
    public partial class ThongTinAccount_ViewModel : BaseViewModel
    {
        #region Textbox

        #region Properties
        public string HoVaTen
        {
            get => Database.HoVaTen;
        }
        public string TenTaiKhoan
        {
            get => Database.Account;
        }
        public string MatKhau
        {
            get => Database.Password.Trim();
            set
            {
                if (Database.Password != value)
                {
                    Database.Password = value.Trim();
                    OnPropertyChanged(nameof(MatKhau));
                }
            }
        }
        public string SDT
        {
            get => Database.Sdt;
            set
            {
                if (Database.Sdt != value)
                {
                    Database.Sdt = value.Trim();
                    OnPropertyChanged(nameof(SDT));
                }
            }
        }
        public string Cmnd
        {
            get => Database.Cmnd;
            set
            {
                if (Database.Cmnd != value)
                {
                    Database.Cmnd = value.Trim();
                    OnPropertyChanged(nameof(Cmnd));
                }
            }
        }

        #endregion Properties
        #endregion

        private AccountObject_Model _SelectedItem;
        public AccountObject_Model Database
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
                    OnPropertyChanged(nameof(Database));
                }
            }
        }
        CurrentUser_Service Service;
        AccountOfNhanVien_Service _AccountService;
        public ThongTinAccount_ViewModel()
        {
            Service = new CurrentUser_Service();
            _AccountService = new AccountOfNhanVien_Service();
            IsButtonModifyEnable = true;
            GetDataFromDatabase();
        }
        public override void GetDataFromDatabase()
        {
            Database = Service.GetSingleItem();
        }

        /// <summary>
        /// Update value when select an item
        /// </summary>

        public override void ActionWhenBtnModifyClicked()
        {
            IsButtonSaveEnable = true;
            IsButtonModifyEnable = false;
            IsTextboxEnable = true;
        }

        public override void ActionWhenBtnSaveClicked()
        {
            IsButtonSaveEnable = false;
            IsButtonModifyEnable = true;
            IsTextboxEnable = false;
            _AccountService.ModifyItem(Database);

        }
    }
    public partial class ThongTinAccount_ViewModel : BaseViewModel
    {
        #region
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
