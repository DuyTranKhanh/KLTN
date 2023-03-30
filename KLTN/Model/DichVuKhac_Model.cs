
namespace KLTN.Model
{
    public class DichVuKhac_Model
    {
        private int _IdDichVu;
        private string _TenDichVu;
        private int _GiaTien;
        private bool _Status;

        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }

        public int IdDichVu
        {
            get => _IdDichVu;
            set { _IdDichVu = value; }
        }

        public int GiaTien
        {
            get => _GiaTien;
            set { _GiaTien = value; }
        }
        public string TenDichVu
        {
            get => _TenDichVu;
            set { _TenDichVu = value; }
        }

        public DichVuKhac_Model Clone()
        {
            DichVuKhac_Model temp = new DichVuKhac_Model();
            temp.IdDichVu = IdDichVu;
            temp.GiaTien = GiaTien;
            temp.TenDichVu = _TenDichVu;
            temp.Status = Status;
            return temp;
        }
    }
    
    public class SoLuongDichVuModel
    {
        private DichVuKhac_Model _DichVu;
        private int _Soluong;

        public DichVuKhac_Model DichVu
        {
            get
            {
                if(_DichVu == null)
                {
                    _DichVu = new DichVuKhac_Model();
                }
                return _DichVu;
            }

            set
            {
                _DichVu = value;
            }
        }

        public int Soluong
        {
            get => _Soluong;
            set { _Soluong = value; }
        }

        public SoLuongDichVuModel Clone()
        {
            SoLuongDichVuModel temp = new SoLuongDichVuModel();
            temp._DichVu = _DichVu;
            temp.Soluong = Soluong;
            return temp;
        }

    }
}
