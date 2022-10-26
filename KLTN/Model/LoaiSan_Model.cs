using System.ComponentModel;

namespace KLTN.Model
{
    public class LoaiSan_Model
    {
        private int id_LoaiSan;
        private string ten_LoaiSan;
        private bool _IsDisable;

        public bool IsDisable
        {
            get => _IsDisable;
            set { _IsDisable = value; }
        }
        public int Id_LoaiSan
        {
            get
            {
                return id_LoaiSan;
            }
            set
            {
                id_LoaiSan = value;
            }
        }

        public string Ten_LoaiSan
        {
            get => ten_LoaiSan;
            set
            {
                ten_LoaiSan = value;
            }
        }



        public LoaiSan_Model Clone()
        {
            var obj = new LoaiSan_Model();
            obj.Id_LoaiSan = Id_LoaiSan;
            obj.Ten_LoaiSan = Ten_LoaiSan;
            return obj;
        }

        public bool Equal(LoaiSan_Model obj)
        {
            if (obj.Id_LoaiSan != Id_LoaiSan) return false;
            if (obj.Ten_LoaiSan != Ten_LoaiSan) return false;
            return true;
        }

    }
}
