using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.Model
{
    public class San_Model
    {
        private int id;
        private string tenSan;
        private bool _IsActive;
        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }

        public bool IsActive
        {
            get => _IsActive;
            set
            {
                _IsActive = value;
            }
        }
        public string TenSan
        {
            get => tenSan;
            set
            {
                tenSan = value;
            }
        }

        private string loaisan;
        public string LoaiSan
        {
            get
            {
                return loaisan;
            }
            set
            {
                loaisan = value;
            }
        }

        public San_Model Clone()
        {
            var temp = new San_Model();
            temp.LoaiSan = LoaiSan;
            temp.Id = Id;
            temp.TenSan = TenSan;
            temp.IsActive = IsActive;
            return temp;
        }

        public bool Equals(San_Model obj)
        {
            if (obj.TenSan != TenSan) return false;
            if (obj.LoaiSan != LoaiSan) return false;
            if (obj.Id != Id) return false;
            if (obj.IsActive != IsActive) return false;
            return true;

        }
    }
}
