
namespace KLTN.Model
{
    public class LoaiSan_Model
    {
        private int id_LoaiSan;
        private string ten_LoaiSan;
        private bool _Status;

        public bool Status
        {
            get => _Status;
            set { _Status = value; }
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
            obj.Status = Status;
            return obj;
        }

        public bool Equal(LoaiSan_Model obj)
        {
            if (obj.Id_LoaiSan != Id_LoaiSan) return false;
            if (obj.Ten_LoaiSan != Ten_LoaiSan) return false;
            if (obj.Status != Status) return false;
            return true;
        }

    }
}
