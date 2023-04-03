using System.Collections.ObjectModel;
using KLTN.Model;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace KLTN.ViewModel
{
    public partial class San_ViewModel : BaseViewModel
    {
        
    }

    /// <summary>
    /// Class for Language
    /// </summary>
    public partial class San_ViewModel : BaseViewModel
    {

        #region Danh Sách 
        public string DanhSachLabel => "Danh sách sân";
        public string CotTenLabel => "Tên sân";
        public string LoaiSanLabel => "Loại Sân";
        public string TrangThaiLabel => "Trạng Thái";

        #endregion Danh sách

        #region Thông tin Item
        public string ThongTinLabel => "Thông tin sân";
        public string TenItemLabel => "Tên Sân";
        public string IdLabel => "Id Sân";
        
        #endregion Thông tin Item

    }
}
