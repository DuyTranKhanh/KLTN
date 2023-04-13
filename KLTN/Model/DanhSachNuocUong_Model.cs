using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.Model
{
    public class HoatDongNuocUong_Model
    {
        private int _IdNuocUong;
        private int _IdSan;
        private int _IdHoaDon;
        private string _TenNuocUong;
        private int _SoLuong;
        private decimal _GiaTien;

        public int IdHoaDon
        {
            get => _IdHoaDon;
            set
            {
                if (_IdHoaDon != value)
                {
                    _IdHoaDon = value;
                }
            }
        }
        public int IdSan
        {
            get => _IdSan;
            set
            {
                if(_IdSan != value)
                {
                    _IdSan = value;
                }
            }
        }
        public int IdNuocUong
        {
            get => _IdNuocUong;
            set
            {
                if (_IdNuocUong != value)
                {
                    _IdNuocUong = value;
                }
            }
        }
        public string TenNuocUong
        {
            get => _TenNuocUong;
            set
            {
                if (_TenNuocUong != value)
                {
                    _TenNuocUong = value;
                }
            }
        }

        public int SoLuong
        {
            get => _SoLuong;
            set
            {
                if (_SoLuong != value)
                {
                    _SoLuong = value;
                }
            }
        }

        public decimal GiaTien
        {
            get => _GiaTien;
            set
            {
                if (_GiaTien != value)
                {
                    _GiaTien = value;
                }
            }
        }

        public HoatDongNuocUong_Model Clone()
        {
            HoatDongNuocUong_Model item = new HoatDongNuocUong_Model();
            item.IdNuocUong = IdNuocUong;
            item.TenNuocUong = TenNuocUong;
            item.SoLuong = SoLuong;
            item.GiaTien = GiaTien;
            item.IdSan = IdSan;

            return item;
        }

    }
}
