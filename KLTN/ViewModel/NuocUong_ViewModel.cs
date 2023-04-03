using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.ViewModel
{
    public partial class NuocUong_ViewModel : BaseViewModel
    {

    }

    public partial class NuocUong_ViewModel : BaseViewModel
    {
        #region Danh Sách 
        public string DanhSachLabel => "Danh sách sản phẩm";
        public string CotTenLabel => "Tên sản phẩm";
        public string TrangThaiLabel => "Trạng Thái";
        public string CotGiaTienLabel => "Giá tiền";

        #endregion Danh sách

        #region Thông tin Item
        public string ThongTinLabel => "Thông tin sản phẩm";
        public string TenItemLabel => "Tên sản phẩm";
        public string IdLabel => "Id sản phẩm";

        #endregion Thông tin Item
    }
}
