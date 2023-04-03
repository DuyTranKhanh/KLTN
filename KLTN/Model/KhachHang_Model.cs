
namespace KLTN.Model
{
    public class KhachHang_Model
    {
        private int _IdKhachHang;
        private string _TenKhachHang;
        private int _Sdt;
        private string _Status;

        public string Status
        {
            get => _Status;
            set
            {
                _Status = value;
            }
        }

        public int IdKhachHang
        {
            get => _IdKhachHang;
            set
            {
                _IdKhachHang = value;
            }
        }

        public string TenKhachHang
        {
            get => _TenKhachHang;
            set
            {
                _TenKhachHang = value;
            }
        }

        public int Sdt
        {
            get => _Sdt;
            set
            {
                _Sdt = value;
            }
        }

        public KhachHang_Model Clone()
        {
            KhachHang_Model temp = new KhachHang_Model();
            temp.IdKhachHang = IdKhachHang;
            temp.TenKhachHang = TenKhachHang;
            temp.Status = Status;
            temp.Sdt = Sdt;
            return temp;
        }
    }
}
