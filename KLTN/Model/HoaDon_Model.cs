﻿using System.Collections.ObjectModel;

namespace KLTN.Model
{
    public class HoaDon_Model
    {
        private int _IdHoaDon;
        private San_Model _San;
        private KhachHang_Model _KhachHang;
        private string _GioVaoSan;
        private string _GioKetThuc;
        private int _SoGiothue;
        private ObservableCollection< SoLuongNuocUongModel> _DanhSachNuocUong;
        private ObservableCollection< SoLuongDichVuModel> _DanhSachDichVu;
        private int _TongTien;
        private int _TienKhachDua;
        private int _TienThoi;
        private int _TrangThaiSan;
        private string _Ngay;
        private string _GhiChu;
        private AccountOfNhanVien_Model _NhanVien;
        #region properties

        public AccountOfNhanVien_Model NhanVien
        {
            get
            {
                if(_NhanVien == null)
                {
                    _NhanVien = new AccountOfNhanVien_Model();
                }
                return _NhanVien;
            }
            set
            {
                _NhanVien = value;
            }
        }
        public San_Model San
        {
            get
            {
                if(_San == null)
                {
                    _San = new San_Model();
                }
                return _San;
            }
            set
            {
                _San = value;              
            }
        }

        public KhachHang_Model KhachHang
        {
            get
            {
                if (_KhachHang == null)
                {
                    _KhachHang = new KhachHang_Model();
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

        public int TrangThaiSan
        {
            get => _TrangThaiSan;
            set { _TrangThaiSan = value; }
        }

        public ObservableCollection<SoLuongDichVuModel> DanhSachDichVu
        {
            get
            {
                if(_DanhSachDichVu == null)
                {
                    _DanhSachDichVu = new ObservableCollection<SoLuongDichVuModel>();
                }
                return _DanhSachDichVu;
            }
            set
            {
                _DanhSachDichVu = value;
            }
        }

        public ObservableCollection<SoLuongNuocUongModel> DanhSachNuocUong
        {
            get
            {
                if (_DanhSachNuocUong == null)
                {
                    _DanhSachNuocUong = new ObservableCollection<SoLuongNuocUongModel>();
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
            temp.TrangThaiSan = TrangThaiSan;
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
            foreach(var itemDichVu in DanhSachDichVu)
            {
                temp.DanhSachDichVu.Add(itemDichVu);
            }
            return temp;
        }
    }

}