using System;

namespace KLTN.Model
{
    public class BangGiaObject_Model
    {
        private BaseObject_Model _BaseObject;
        private string _ThoiGianBatDau;
        private string _ThoiGianKetThuc;
        private decimal _GiaTienObject;
        private string _NgayTao;
        private int _IdLoaiSan;

        public int IdLoaiSan
        {
            get => _IdLoaiSan;
            set
            {
                if(_IdLoaiSan != value)
                {
                    _IdLoaiSan = value;
                }
            }
        }
        public BaseObject_Model BaseObject
        {
            get
            {
                if (_BaseObject == null)
                {
                    _BaseObject = new BaseObject_Model();
                }
                return _BaseObject;
            }
            set
            {
                if (_BaseObject != value)
                {
                    _BaseObject = value;
                }
            }
        }

        public string ThoiGianBatDau
        {
            get => _ThoiGianBatDau;
            set
            {
                if (_ThoiGianBatDau != value)
                {
                    _ThoiGianBatDau = value;
                }
            }
        }

        public string ThoiGianKetThuc
        {
            get => _ThoiGianKetThuc;
            set
            {
                if (_ThoiGianKetThuc != value)
                {
                    _ThoiGianKetThuc = value;
                }
            }
        }

        public decimal GiaTienObject
        {
            get => _GiaTienObject;
            set
            {
                if (_GiaTienObject != value)
                {
                    _GiaTienObject = value;
                }
            }
        }

        public string NgayTao
        {
            get => _NgayTao;
            set
            {
                if (_NgayTao != value)
                {
                    _NgayTao = value;
                }
            }
        }

        public BangGiaObject_Model Clone()
        {
            BangGiaObject_Model item = new BangGiaObject_Model();
            item.BaseObject = BaseObject.Clone();
            item.ThoiGianBatDau = ThoiGianBatDau;
            item.ThoiGianKetThuc = ThoiGianKetThuc;
            item.GiaTienObject = GiaTienObject;
            item.NgayTao = NgayTao;
            return item;
        }
    }
}
