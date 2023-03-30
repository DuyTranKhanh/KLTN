
namespace KLTN.Model
{
    public class San_Model
    {
        private int id;
        private string tenSan;
        private bool _Status;
        private int _IdLoaiSan;

        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }

        public bool Status
        {
            get => _Status;
            set
            {
                _Status = value;
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

        public int IdLoaiSan
        {
            get
            {
                return _IdLoaiSan;
            }
            set
            {
                _IdLoaiSan = value;
            }
        }

        public San_Model Clone()
        {
            var temp = new San_Model();
            temp.IdLoaiSan = IdLoaiSan;
            temp.Id = Id;
            temp.TenSan = TenSan;
            temp.Status = Status;
            return temp;
        }

        public bool Equals(San_Model obj)
        {
            if (obj.TenSan != TenSan) return false;
            if (obj.IdLoaiSan != IdLoaiSan) return false;
            if (obj.Id != Id) return false;
            if (obj.Status != Status) return false;
            return true;

        }
    }
}
