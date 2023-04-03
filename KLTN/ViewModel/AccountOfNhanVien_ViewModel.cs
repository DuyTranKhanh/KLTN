using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.ViewModel
{
    public partial class AccountOfNhanVien_ViewModel : BaseViewModel
    {
    }
    public partial class AccountOfNhanVien_ViewModel : BaseViewModel
    {
        #region Danh Sách 
        public string DanhSachLabel => "Danh sách tài khoản";
        public string CotTaiKhoanLabel => "Tài khoản";
        public string CotMatKhauLabel => "Mật khẩu";
        public string TrangThaiLabel => "Trạng Thái";
        public string CotIsAdmin => "Có quyền Admin";

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
