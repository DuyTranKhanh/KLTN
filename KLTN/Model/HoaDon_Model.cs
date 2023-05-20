using System.Collections.ObjectModel;

namespace KLTN.Model
{
    public class HoaDon_Model
    {
        private int _IdHoaDon;
        private SanObject_Model _San;
        private KhachHangObject_Model _KhachHang;
        private DateTime_Model _GioVaoSan;
        private DateTime_Model _GioKetThuc;
        private double _SoGiothue;
        private ObservableCollection<HoatDongNuocUong_Model> _DanhSachNuocUong;
        private decimal _TongTien;
        private decimal _TienKhachDua;
        private decimal _TienThoi;
        private DateTime_Model _Ngay;
        private string _GhiChu;
        private AccountObject_Model _NhanVien;
        #region properties

        public AccountObject_Model NhanVien
        {
            get
            {
                if(_NhanVien == null)
                {
                    _NhanVien = new AccountObject_Model();
                }
                return _NhanVien;
            }
            set
            {
                _NhanVien = value;
            }
        }
        public SanObject_Model San
        {
            get
            {
                if(_San == null)
                {
                    _San = new SanObject_Model();
                }
                return _San;
            }
            set
            {
                _San = value;              
            }
        }

        public KhachHangObject_Model KhachHang
        {
            get
            {
                if (_KhachHang == null)
                {
                    _KhachHang = new KhachHangObject_Model();
                }
                return _KhachHang;
            }
            set
            {
                _KhachHang = value;
            }
        }

        public string GhiChu
        {
            get => _GhiChu;
            set
            {
                _GhiChu = value;
            }
        }

        public DateTime_Model GioVaoSan
        {
            get
            {
                if(_GioVaoSan == null)
                {
                    _GioVaoSan = new DateTime_Model();
                }
                return _GioVaoSan;
            }
            set
            {
                if(_GioVaoSan != value)
                {
                    _GioVaoSan = value;
                }
            }
        }

        public DateTime_Model GioKetThuc
        {
            get
            {
                if (_GioKetThuc == null)
                {
                    _GioKetThuc = new DateTime_Model();
                }
                return _GioKetThuc;
            }
            set
            {
                if (_GioKetThuc != value)
                {
                    _GioKetThuc = value;
                }
            }
        }

        public DateTime_Model Ngay
        {
            get
            {
                if (_Ngay == null)
                {
                    _Ngay = new DateTime_Model();
                }
                return _Ngay;
            }
            set
            {
                if (_Ngay != value)
                {
                    _Ngay = value;
                }
            }
        }

        public double SoGioThue
        { 
            get => _SoGiothue;
            set { _SoGiothue = value; }
        }

        public decimal TongTien
        {
            get => _TongTien;
            set { _TongTien = value; }
        }

        public decimal TienKhachDua
        {
            get => _TienKhachDua;
            set { _TienKhachDua = value; }
        }

        public int IdHoaDon
        {
            get => _IdHoaDon;
            set { _IdHoaDon = value; }
        }

        public decimal TienThoi
        {
            get => _TienThoi;
            set { _TienThoi = value; }
        }

        public ObservableCollection<HoatDongNuocUong_Model> DanhSachNuocUong
        {
            get
            {
                if (_DanhSachNuocUong == null)
                {
                    _DanhSachNuocUong = new ObservableCollection<HoatDongNuocUong_Model>();
                }
                return _DanhSachNuocUong;
            }
            set
            {
                _DanhSachNuocUong = value;
            }
        }

        #endregion
        public HoaDon_Model Clone()
        {
            HoaDon_Model temp = new HoaDon_Model();
            temp.GioKetThuc = GioKetThuc.Clone();
            temp.GioVaoSan = GioVaoSan.Clone();
            temp.KhachHang = KhachHang.Clone();
            temp.Ngay = Ngay.Clone();
            temp.San = San.Clone();
            temp.SoGioThue = SoGioThue;
            temp.TienKhachDua = TienKhachDua;
            temp.TienThoi = TienThoi;
            temp.TongTien = TongTien;
            temp.IdHoaDon = IdHoaDon;
            temp.GhiChu = GhiChu;
            temp.NhanVien = NhanVien;

            foreach(var itemNuocUong in DanhSachNuocUong)
            {
                temp.DanhSachNuocUong.Add(itemNuocUong);
            }
            return temp;
        }
    }

    public class HoatDongHienTaiModel
    {

        private string _TrangThaiSan;
        public string TrangThaiSan
        {
            get => _TrangThaiSan;
            set { _TrangThaiSan = value; }
        }

        private HoaDon_Model _HoatDongCuaSan;
        public HoaDon_Model HoatDongCuaSan
        {
            get
            {
                if(_HoatDongCuaSan == null)
                {
                    _HoatDongCuaSan = new HoaDon_Model();
                }
                return _HoatDongCuaSan;
            }
            set
            {
                if(_HoatDongCuaSan != value)
                {
                    _HoatDongCuaSan = value;
                }
            }
        }
        public HoatDongHienTaiModel Clone()
        {
            HoatDongHienTaiModel temp = new HoatDongHienTaiModel();
            temp.TrangThaiSan = TrangThaiSan;
            temp.HoatDongCuaSan = HoatDongCuaSan.Clone();
            return temp;
        }
    }

}
