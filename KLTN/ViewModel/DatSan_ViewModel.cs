using KLTN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.ViewModel
{
    public partial class DatSan_ViewModel : BaseViewModel
    {
        public DateTime StartDay = DateTime.Today;

        public DateTime RangeDay = DateTime.Today.AddDays(3);


    }

    public partial class DatSan_ViewModel : BaseViewModel
    {
        private string _TenKhachHang;
        private string _Sdt;
        private int _LoaiSan; // Su dung enum de define
        private DateTime _GioBatDau_HienThi;
        private DateTime_Model _GioBatDau;
        private DateTime _GioKetThuc_HienThi;
        private DateTime_Model _GioKetThuc;
        private string _TrangThai;
        private string _NgayTao;
        private DateTime_Model _NgaySuDung;

        private LichDatObject_Model _SelectedItem;
    }
}
