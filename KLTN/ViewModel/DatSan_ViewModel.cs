using KLTN.Model;
using KLTN.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace KLTN.ViewModel
{
    public partial class DatSan_ViewModel : BaseViewModel
    {
        public DateTime StartDay = DateTime.Today;

        public DateTime RangeDay = DateTime.Today.AddDays(3);


    }

    /// <summary>
    /// Database
    /// </summary>
    public partial class DatSan_ViewModel : BaseViewModel
    {
        LoaiSan_Service LoaiSan_Database;
        DatLich_Service Database_LichDat;
        KhachHang_Service Database_KhachHang;

        /// <summary>
        /// Constructor
        /// </summary>
        public DatSan_ViewModel()
        {
            LoaiSan_Database = new LoaiSan_Service();
            Database_KhachHang = new KhachHang_Service();
            Database_LichDat = new DatLich_Service();
        }
    }

    /// <summary>
    /// Selected Item
    /// </summary>
    public partial class DatSan_ViewModel : BaseViewModel
    {
        #region Fields
        private string _TenKhachHang;
        private string _Sdt;
        private int _LoaiSanSelected; // Su dung enum de define
        private string _TenLoaiSan = "Sân 5";
        private DateTime _GioBatDau_HienThi;
        private DateTime_Model _GioBatDau;
        private DateTime _GioKetThuc_HienThi;
        private DateTime_Model _GioKetThuc;
        private string _TrangThai;
        private string _NgayTao;
        private DateTime _NgaySuDung_HienThi = DateTime.Today;
        private DateTime_Model _NgaySuDung;
        private LichDatObject_Model _SelectedItem;
        private ObservableCollection<LichDatObject_Model> _DanhSach_DatLich;
        private Dictionary<int, string> _DanhSach_LoaiSan;
        private Dictionary<int, string> _DanhSach_KhachHang;

        private string _GioBatDau_String;
        private string _GioKetThuc_String;
        private string _NgaySuDung_String;
        #endregion Fields

        #region Properties

        /// <summary>
        /// Get set Ten Khach Hang
        /// </summary>
        public string TenKhachHang
        {
            get => _TenKhachHang;
            set
            {
                if(_TenKhachHang != value)
                {
                    _TenKhachHang = value;
                    OnPropertyChanged(nameof(TenKhachHang));
                }
            }
        }

        /// <summary>
        /// Get set Sdt
        /// </summary>
        public string Sdt
        {
            get => _Sdt;
            set
            {
                if (_Sdt != value)
                {
                    _Sdt = value;
                    OnPropertyChanged(nameof(Sdt));
                }
            }
        }

        /// <summary>
        /// Get set Trang Thai cua item selected
        /// </summary>
        public string TrangThai
        {
            get => _TrangThai;
            set
            {
                if (_TrangThai != value)
                {
                    _TrangThai = value;
                    OnPropertyChanged(nameof(TrangThai));
                }
            }
        }

        /// <summary>
        /// Ten Loai San
        /// </summary>
        public string TenLoaiSan
        {
            get => _TenLoaiSan;
            set
            {
                if (_TenLoaiSan != value)
                {
                    _TenLoaiSan = value;
                    OnPropertyChanged(nameof(TenLoaiSan));
                }
            }
        }

        /// <summary>
        /// Get set Ngay Tao
        /// </summary>
        public string NgayTao
        {
            get => _NgayTao;
            set
            {
                if (_NgayTao != value)
                {
                    _NgayTao = value;
                    OnPropertyChanged(nameof(NgayTao));
                }
            }
        }

        /// <summary>
        /// Get set Loai San
        /// </summary>
        public int LoaiSanSelected
        {
            get => _LoaiSanSelected;
            set
            {
                if (_LoaiSanSelected != value)
                {
                    _LoaiSanSelected = value;
                    TenLoaiSan = DanhSach_LoaiSan.FirstOrDefault(x => x.Key == value).Value;
                    OnPropertyChanged(nameof(LoaiSanSelected));
                }
            }
        }


        /// <summary>
        /// Get set
        /// </summary>
        public DateTime GioBatDau_HienThi
        {
            get
            {
                if(_GioBatDau_HienThi == null)
                {
                    _GioBatDau_HienThi = new DateTime();
                }
                return _GioBatDau_HienThi;
            }
            set
            {
                if(_GioBatDau_HienThi != value)
                {
                    _GioBatDau_HienThi = value;
                    GioBatDau.Minute = value.Minute.ToString().Trim();
                    GioBatDau.Hour = value.Hour.ToString().Trim();
                    OnPropertyChanged(nameof(GioBatDau_HienThi));
                }
            }
        }

        /// <summary>
        /// Get set
        /// </summary>
        public DateTime GioKetThuc_HienThi
        {
            get
            {
                if (_GioKetThuc_HienThi == null)
                {
                    _GioKetThuc_HienThi = new DateTime();
                }
                return _GioKetThuc_HienThi;
            }
            set
            {
                if (_GioKetThuc_HienThi != value)
                {
                    _GioKetThuc_HienThi = value;
                    GioKetThuc.Minute = value.Minute.ToString().Trim();
                    GioKetThuc.Hour = value.Hour.ToString().Trim();
                    OnPropertyChanged(nameof(GioKetThuc_HienThi));
                }
            }
        }


        /// <summary>
        /// Get set GioBatDau
        /// </summary>
        public DateTime_Model GioBatDau
        {
            get
            {
                if(_GioBatDau == null)
                {
                    _GioBatDau = new DateTime_Model();
                }
                return _GioBatDau;
            }
            set
            {
                if(_GioBatDau != value)
                {
                    _GioBatDau = value;
                    OnPropertyChanged(nameof(GioBatDau));
                }
            }
        }

        /// <summary>
        /// Get set GioKetThuc
        /// </summary>
        public DateTime_Model GioKetThuc
        {
            get
            {
                if (_GioKetThuc == null)
                {
                    _GioKetThuc = new DateTime_Model();
                }
                return _GioKetThuc;
            }
            set
            {
                if (_GioKetThuc != value)
                {
                    _GioKetThuc = value;
                    OnPropertyChanged(nameof(GioKetThuc));
                }
            }
        }

        /// <summary>
        /// Get set GioKetThuc
        /// </summary>
        public DateTime_Model NgaySuDung
        {
            get
            {
                if (_NgaySuDung == null)
                {
                    _NgaySuDung = new DateTime_Model();
                    _NgaySuDung.Year = NgaySuDung_HienThi.Year.ToString().Trim();
                    _NgaySuDung.Month = NgaySuDung_HienThi.Month.ToString().Trim();
                    _NgaySuDung.Day = NgaySuDung_HienThi.Day.ToString().Trim();
                }
                return _NgaySuDung;
            }
            set
            {
                if (_NgaySuDung != value)
                {
                    _NgaySuDung = value;
                    OnPropertyChanged(nameof(NgaySuDung));
                }
            }
        }

        public DateTime NgaySuDung_HienThi
        {
            get
            {
                return _NgaySuDung_HienThi;
            }
            set
            {
                if (_NgaySuDung_HienThi != value)
                {
                    _NgaySuDung_HienThi = value;
                    OnPropertyChanged(nameof(NgaySuDung_HienThi));
                    NgaySuDung.Year = value.Year.ToString().Trim();
                    NgaySuDung.Month = value.Month.ToString().Trim();
                    NgaySuDung.Day = value.Day.ToString().Trim();
                }
            }
        }
        /// <summary>
        /// Get set value of Selected Item
        /// </summary>
        public LichDatObject_Model SelectedItem
        {
            get
            {
                if(_SelectedItem == null)
                {
                    _SelectedItem = new LichDatObject_Model();
                }
                return _SelectedItem;
            }
            set
            {
                if(_SelectedItem != value)
                {
                    _SelectedItem = value;
                    ActionWhenChangeSelectedItem();
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        /// <summary>
        /// Get set List DanhSach
        /// </summary>
        public ObservableCollection<LichDatObject_Model> DanhSach_DatLich
        {
            get
            {
                if(_DanhSach_DatLich == null)
                {
                    _DanhSach_DatLich = new ObservableCollection<LichDatObject_Model>();
                    _DanhSach_DatLich = LoadDanhSachDatLich();
                }
                return _DanhSach_DatLich;
            }
            set
            {
                if(_DanhSach_DatLich != value)
                {
                    _DanhSach_DatLich = value;
                    OnPropertyChanged(nameof(DanhSach_DatLich));
                }
            }
        }

        public Dictionary<int, string> DanhSach_LoaiSan
        {
            get
            {
                if (_DanhSach_LoaiSan == null)
                {
                    _DanhSach_LoaiSan = new Dictionary<int, string>();
                    _DanhSach_LoaiSan = LoadDanhSachLoaiSan();
                }
                return _DanhSach_LoaiSan;
            }
            set
            {
                if (_DanhSach_LoaiSan != value)
                {
                    _DanhSach_LoaiSan = value;
                    OnPropertyChanged(nameof(DanhSach_LoaiSan));
                }
            }
        }

        public Dictionary<int, string> DanhSach_KhachHang
        {
            get
            {
                if (_DanhSach_KhachHang == null)
                {
                    _DanhSach_KhachHang = new Dictionary<int, string>();
                    _DanhSach_KhachHang = LoadDanhSachKhachHang();
                }
                return _DanhSach_KhachHang;
            }
            set
            {
                if (_DanhSach_KhachHang != value)
                {
                    _DanhSach_KhachHang = value;
                    OnPropertyChanged(nameof(DanhSach_KhachHang));
                }
            }
        }

        public string GioBatDau_String
        {
            get => _GioBatDau_String;
            set
            {
                if (_GioBatDau_String != value)
                {
                    _GioBatDau_String = value;
                    OnPropertyChanged(nameof(GioBatDau_String));
                }
            }
        }

        public string GioKetThuc_String
        {
            get => _GioKetThuc_String;
            set
            {
                if (_GioKetThuc_String != value)
                {
                    _GioKetThuc_String = value;
                    OnPropertyChanged(nameof(GioKetThuc_String));
                }
            }
        }

        public string NgaySuDung_String
        {
            get => _NgaySuDung_String;
            set
            {
                if (_NgaySuDung_String != value)
                {
                    _NgaySuDung_String = value;
                    OnPropertyChanged(nameof(NgaySuDung_String));
                }
            }
        }
        #endregion Properties

        #region Method
        public void ActionWhenChangeSelectedItem()
        {
            TenKhachHang = SelectedItem.KhachHang.BaseObject.TenObject;

            IsButtonModifyEnable = true;

            if (SelectedItem.NgaySuDung.Year.Length > 1  && SelectedItem.NgaySuDung.IsPastDay(DateTime.Today))
            {
                IsButtonModifyEnable = false;
            }

            LoaiSanSelected = SelectedItem.San.IdLoaiSan;
            TrangThai = SelectedItem.TrangThai;
            NgayTao = SelectedItem.NgayDatSan;
            Sdt = SelectedItem.KhachHang.SdtObject.Trim();

            NgaySuDung = SelectedItem.NgaySuDung.Clone();
            GioBatDau = SelectedItem.GioBatDau.Clone();
            GioKetThuc = SelectedItem.GioKetThuc.Clone();
            NgaySuDung_String = NgaySuDung.Day.Trim() + "/ " + NgaySuDung.Month.Trim() + "/ " + NgaySuDung.Year.Trim();
            GioBatDau_String = GioBatDau.Hour.Trim() + " : " + GioBatDau.Minute.Trim();
            GioKetThuc_String = GioKetThuc.Hour.Trim() + " : " + GioKetThuc.Minute.Trim();
        }


        /// <summary>
        /// Load Data from D.B
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<LichDatObject_Model> LoadDanhSachDatLich()
        {
            ObservableCollection<LichDatObject_Model> result = new ObservableCollection<LichDatObject_Model>();
            result = Database_LichDat.GetAll();
            return result;
        }

        public Dictionary<int, string> LoadDanhSachLoaiSan()
        {
            //Get List Data of LoaiSan from Db.
            Dictionary<int, string> temp = new Dictionary<int, string>();
            var listLoaiSan = LoaiSan_Database.GetAll();
            for (int i = 0; i < listLoaiSan.Count; i++)
            {
                temp.Add(i, listLoaiSan[i].BaseObject.TenObject);
            }
            return temp;
        }

        public Dictionary<int, string> LoadDanhSachKhachHang()
        {
            //Get List Data of LoaiSan from Db.
            Dictionary<int, string> temp = new Dictionary<int, string>();
            var listLoaiSan = Database_KhachHang.GetAll();
            for (int i = 0; i < listLoaiSan.Count; i++)
            {
                temp.Add(i, listLoaiSan[i].BaseObject.TenObject);
            }
            return temp;
        }

        /// <summary>
        /// Action when click btn Add
        /// </summary>
        public override void ActionWhenBtnAddClicked()
        {
            IsButtonSaveEnable = true;
            IsButtonAddEnable = false;
            IsButtonModifyEnable = false;
            IsTextboxEnable = true;

            TenKhachHang = string.Empty;
            LoaiSanSelected = (int)LoaiSanIndex.San5;
            TrangThai = string.Empty;
            NgayTao = DateTime.Today.ToString();
            Sdt = string.Empty;

            NgaySuDung_String = string.Empty;
            GioBatDau_String = string.Empty;
            GioKetThuc_String = string.Empty;
        }

        /// <summary>
        /// Action when click btn Save
        /// </summary>
        public override void ActionWhenBtnSaveClicked()
        {
            IsButtonSaveEnable = false;
            IsButtonAddEnable = true;
            IsButtonModifyEnable = true;
            IsTextboxEnable = false;

            LichDatObject_Model temp = new LichDatObject_Model();
            temp.TrangThai = _HoatDong;
            temp.KhachHang = new KhachHangObject_Model();
            temp.KhachHang.BaseObject.TenObject = TenKhachHang.Trim();
            temp.KhachHang.SdtObject = Sdt.Trim();
            temp.San = new SanObject_Model();
            temp.San.IdLoaiSan = LoaiSanSelected;
            temp.San.TenLoaiSan = TenLoaiSan;
            temp.GioBatDau = new DateTime_Model();

            temp.GioBatDau.Minute = GioBatDau.Minute.Trim();
            temp.GioBatDau.Hour = GioBatDau.Hour.Trim();

            temp.GioKetThuc = new DateTime_Model();
            temp.GioKetThuc.Hour = GioKetThuc.Hour.Trim();
            temp.GioKetThuc.Minute = GioKetThuc.Minute.Trim();

            temp.NgaySuDung = new DateTime_Model();
            temp.NgaySuDung.Year = NgaySuDung.Year.Trim();
            temp.NgaySuDung.Month = NgaySuDung.Month.Trim();
            temp.NgaySuDung.Day = NgaySuDung.Day.Trim();

            Database_LichDat.Add(temp);

            DanhSach_DatLich = LoadDanhSachDatLich();
        }

        public override void ActionWhenBtnModifyClicked()
        {
            if(SelectedItem.TrangThai == "Vô hiệu")
            {
                SelectedItem.TrangThai = "Sử dụng";
            }
            else
            {
                SelectedItem.TrangThai = "Vô hiệu";
            }

            Database_LichDat.UpdateTrangThai(SelectedItem);
            DanhSach_DatLich = LoadDanhSachDatLich();
            IsButtonModifyEnable = false;
        }
        #endregion Method
    }
}
