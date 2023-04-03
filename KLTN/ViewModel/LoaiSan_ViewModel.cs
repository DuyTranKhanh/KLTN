using System.Windows.Input;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using KLTN.Model;
using GalaSoft.MvvmLight.Command;

namespace KLTN.ViewModel
{
    public partial class LoaiSan_ViewModel : BaseViewModel
    {
    }

    /// <summary>
    /// Class for Language
    /// </summary>
    public partial class LoaiSan_ViewModel : BaseViewModel
    {

        #region Danh Sách 
        public string DanhSachLabel => "Danh sách loại sân";
        public string CotTenLabel => "Tên loại sân";
        public string TrangThaiLabel => "Trạng Thái";

        #endregion Danh sách

        #region Thông tin Item
        public string ThongTinLabel => "Thông tin loại sân";
        public string TenItemLabel => "Tên loại Sân";
        public string IdLabel => "Id Loại Sân";

        #endregion Thông tin Item

    }
}
