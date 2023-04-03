using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.ViewModel
{
    public partial class KhachHang_ViewModel : BaseViewModel
    {
    }

    public partial class KhachHang_ViewModel : BaseViewModel
    {
        #region Danh Sách 
        public string DanhSachLabel => "Danh sách khách hàng";
        public string CotTenLabel => "Tên khách hàng";
        public string TrangThaiLabel => "Trạng Thái";
        public string CotDienThoaiLabel => "Số điện thoại";

        #endregion Danh sách

        #region Thông tin Item
        public string ThongTinLabel => "Thông tin khách hàng:";
        public string TenItemLabel => "Tên khách hàng";
        public string IdLabel => "Id khách hàng";

        #endregion Thông tin Item
    }
}
