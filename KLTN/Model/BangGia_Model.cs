using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
