using System.Collections.ObjectModel;

namespace KLTN.Model
{
    public class HoaDon_Model
    {
        private int _IdHoaDon;
        private SanObject_Model _San;
        private KhachHangObject_Model _KhachHang;
        private string _GioVaoSan;
        private string _GioKetThuc;
        private int _SoGiothue;
        private ObservableCollection<HoatDongNuocUong_Model> _DanhSachNuocUong;
        private int _TongTien;
        private int _TienKhachDua;
        private int _TienThoi;
        private string _Ngay;
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

        public string GioVaoSan
        {
            get => _GioVaoSan;
            set { _GioVaoSan = value; }
        }

        public string GioKetThuc
        {
            get => _GioKetThuc;
            set { _GioKetThuc = value; }
        }

        public string Ngay
        {
            get => _Ngay;
            set { _Ngay = value; }
        }

        public int SoGioThue
        { 
            get => _SoGiothue;
            set { _SoGiothue = value; }
        }

        public int TongTien
        {
            get => _TongTien;
            set { _TongTien = value; }
        }

        public int TienKhachDua
        {
            get => _TienKhachDua;
            set { _TienKhachDua = value; }
        }

        public int IdHoaDon
        {
            get => _IdHoaDon;
            set { _IdHoaDon = value; }
        }

        public int TienThoi
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
            temp.GioKetThuc = GioKetThuc;
            temp.GioVaoSan = GioVaoSan;
            temp.KhachHang = KhachHang.Clone();
            temp.Ngay = Ngay;
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

        private int _TrangThaiSan;
        public int TrangThaiSan
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
