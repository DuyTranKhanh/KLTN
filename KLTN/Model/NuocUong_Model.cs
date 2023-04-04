

namespace KLTN.Model
{
    public class NuocUong_Model
    {
        private int _IdNuocUong;
        private string _TenMatHang;
        private double _GiaTien;
        private bool _Status;

        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }
        public int IdNuocUong
        {
            get => _IdNuocUong;
            set { _IdNuocUong = value; }
        }

        public double GiaTien
        {
            get => _GiaTien;
            set { _GiaTien = value; }
        }

        public string TenMatHang
        {
            get => _TenMatHang;
            set { _TenMatHang = value; }
        }

        public NuocUong_Model Clone()
        {
            NuocUong_Model temp = new NuocUong_Model();
            temp.IdNuocUong = IdNuocUong;
            temp.GiaTien = GiaTien;
            temp.TenMatHang = TenMatHang;
            temp.Status = Status;
            return temp;
        }
    }

    public class SoLuongNuocUongModel
    {
        private NuocUong_Model _NuocUong;
        private int _Soluong;

        public NuocUong_Model NuocUong
        {
            get
            {
                if (_NuocUong == null)
                {
                    _NuocUong = new NuocUong_Model();
                }
                return _NuocUong;
            }

            set
            {
                _NuocUong = value;
            }
        }

        public int Soluong
        {
            get => _Soluong;
            set { _Soluong = value; }
        }

        public SoLuongNuocUongModel Clone()
        {
            SoLuongNuocUongModel temp = new SoLuongNuocUongModel();
            temp.NuocUong = NuocUong;
            temp.Soluong = Soluong;
            return temp;
        }

    }
}
