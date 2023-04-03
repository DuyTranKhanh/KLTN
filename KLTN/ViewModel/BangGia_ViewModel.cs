using System.Windows.Input;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using KLTN.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;

namespace KLTN.ViewModel
{
    public partial class BangGia_ViewModel : BaseViewModel
    {
    }

    public partial class BangGia_ViewModel : BaseViewModel
    {
        #region Danh Sách 
        public string DanhSachLabel => "Danh sách bảng giá";
        public string CotTenLabel => "Loại sân";
        public string TrangThaiLabel => "Trạng Thái";

        #endregion Danh sách

        #region Thông tin Item
        public string ThongTinLabel => "Thông tin bảng giá:";
        public string LoaiSanItemLabel => "Loại sân";
        public string ThoiGianBatDauItemLabel => "Thời gian bắt đầu";
        public string ThoiGianKetThucItemLabel => "Thời gian kết thúc";
        public string NgayApDungItemLabel => "Ngày áp dụng";
        public string DonGiaItemLabel => "Đơn giá:";
        public string IdLabel => "Id bảng giá";

        #endregion Thông tin Item
    }
}
