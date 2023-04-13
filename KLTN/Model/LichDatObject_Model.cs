using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.Model
{
    public class LichDatObject_Model
    {
        private int _IdLichDat;
        private KhachHangObject_Model _KhachHang;
        private SanObject_Model _San;
        private string _GioBatDau;
        private string _GioKetThuc;
        private string _TrangThai; // Disable, Dat 1 lan duy nhat, hang tuan => se lien tiep 1 thang. 
        private string _NgayDat;
        private string _NgaySuDung;

        public string NgayDatSan
        {
            get => _NgayDat;
            set
            {
                if(_NgayDat != value)
                {
                    _NgayDat = value;
                }
            }
        }

        public string NgaySuDung
        {
            get => _NgaySuDung;
            set
            {
                if (_NgaySuDung != value)
                {
                    _NgaySuDung = value;
                }
            }
        }
        public int IdLichDat
        {
            get => _IdLichDat;
            set
            {
                if(_IdLichDat != value)
                {
                    _IdLichDat = value;
                }
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
                if (_KhachHang != value)
                {
                    _KhachHang = value;
                }
            }
        }

        public SanObject_Model San
        {
            get
            {
                if (_San == null)
                {
                    _San = new SanObject_Model();
                }
                return _San;
            }
            set
            {
                if (_San != value)
                {
                    _San = value;
                }
            }
        }
        public string GioBatDau
        {
            get => _GioBatDau;
            set
            {
                if (_GioBatDau != value)
                {
                    _GioBatDau = value;
                }
            }
        }

        public string TrangThai
        {
            get => _TrangThai;
            set
            {
                if (_TrangThai != value)
                {
                    _TrangThai = value;
                }
            }
        }
        public string GioKetThuc
        {
            get => _GioKetThuc;
            set
            {
                if (_GioKetThuc != value)
                {
                    _GioKetThuc = value;
                }
            }
        }

        public LichDatObject_Model Clone()
        {
            LichDatObject_Model item = new LichDatObject_Model();
            item._IdLichDat = _IdLichDat;
            item.KhachHang = KhachHang.Clone();
            item.GioBatDau = GioBatDau;
            item.GioKetThuc = GioKetThuc;
            item.NgayDatSan = NgayDatSan;
            item.NgaySuDung = NgaySuDung;
            item.San = San.Clone();
            return item;
        }

    }
}
