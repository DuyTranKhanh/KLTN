using System;

namespace KLTN.Model
{
    public class BangGia_Model
    {
        private int _Id;
        private string _NgayApDung;
        private string _TenLoaiSan;
        private int _TimeStart;
        private int _TimeEnd;
        private int _GiaTien;
        private bool _Status;

        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }
        public int Id
        {
            get => _Id;
            set { _Id = value; }
        }
        public string NgayApDung
        {
            get
            {
                if(_NgayApDung == "")
                {
                    _NgayApDung = DateTime.Today.ToString();
                }
                return _NgayApDung;
            }
            set { _NgayApDung = value; }
        }

        public string TenLoaiSan
        {
            get => _TenLoaiSan;
            set { _TenLoaiSan = value; }
        }

        public int TimeStart
        {
            get => _TimeStart;
            set { _TimeStart = value; }
        }

        public int TimeEnd
        {
            get => _TimeEnd;
            set { _TimeEnd = value; }
        }

        public int GiaTien
        {
            get
            {
                return _GiaTien;
            }
            set { _GiaTien = value; }
        }

        public bool Equal(BangGia_Model obj)
        {
            if (obj.Id != Id) return false;
            if (obj.GiaTien != GiaTien) return false;
            if (obj.TimeStart != TimeStart) return false;
            if (obj.TimeEnd != TimeEnd) return false;
            if (obj.TenLoaiSan != TenLoaiSan) return false;
            if (obj.NgayApDung != NgayApDung) return false;
            if (obj.Status != Status) return false;
            return true;
        }

        public BangGia_Model Clone()
        {
            BangGia_Model temp = new BangGia_Model();
            temp.Id = Id;
            temp.GiaTien = GiaTien;
            temp.TimeEnd = TimeEnd;
            temp.TimeStart = TimeStart;
            temp.TenLoaiSan = TenLoaiSan;
            temp.NgayApDung = NgayApDung;
            temp.Status = Status;
            return temp;
        }
    }
}
