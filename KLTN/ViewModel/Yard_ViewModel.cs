using System.Collections.ObjectModel;
using KLTN.Model;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System;
using KLTN.Service;

namespace KLTN.ViewModel
{
    public enum LoaiSanIndex
    {
        San5 = 0,
        San7 = 1,
        San11 = 2,
        SanOther = 3,
    }
    public enum TrangThaiSan
    {
        SanSangSuDung = 0,
        DangDuocSuDung = 1,
        DaXuatHoaDon = 2,
        KhongTheSuDung = 3,
    }
    public partial class Yard_ViewModel : BaseViewModel
    {

        #region Danh sách sân vs Bảng giá

        #region Fields

        #region Visibility
        private Visibility _IsDanhSachSanVisible = Visibility.Visible;
        private Visibility _IsDanhSachBangGiaVisible = Visibility.Collapsed;
        #endregion Visibility

        #region ICommand
        private ICommand _DanhSachSanCommand;
        private ICommand _DanhSachBangGiaCommand;
        #endregion ICommand

        #endregion Fields

        #region Properties

        #region Visibility
        public Visibility IsDanhSachSanVisible
        {
            get => _IsDanhSachSanVisible;
            set
            {
                if (_IsDanhSachSanVisible != value)
                {
                    _IsDanhSachSanVisible = value;
                    OnPropertyChanged(nameof(IsDanhSachSanVisible));
                }
            }
        }

        public Visibility IsDanhSachBangGiaVisible
        {
            get => _IsDanhSachBangGiaVisible;
            set
            {
                if (_IsDanhSachBangGiaVisible != value)
                {
                    _IsDanhSachBangGiaVisible = value;
                    OnPropertyChanged(nameof(IsDanhSachBangGiaVisible));
                }
            }
        }
        #endregion Visibility

        #region ICommand
        public ICommand DanhSachSanCommand
        {
            get
            {
                if (_DanhSachSanCommand == null)
                {
                    _DanhSachSanCommand = new RelayCommand(BtnDanhSachSanClicked, CanExecute);
                }
                return _DanhSachSanCommand;
            }
        }

        public ICommand DanhSachBangGiaCommand
        {
            get
            {
                if (_DanhSachBangGiaCommand == null)
                {
                    _DanhSachBangGiaCommand = new RelayCommand(BtnDanhSachBangGiaClicked, CanExecute);
                }
                return _DanhSachBangGiaCommand;
            }
        }

        #endregion Icommand

        #endregion Properties

        #region Method
        public void BtnDanhSachSanClicked()
        {
            IsDanhSachSanVisible = Visibility.Visible;
            IsDanhSachBangGiaVisible = Visibility.Collapsed;
        }

        public void BtnDanhSachBangGiaClicked()
        {
            IsDanhSachSanVisible = Visibility.Collapsed;
            IsDanhSachBangGiaVisible = Visibility.Visible;
        }
        #endregion Method

        #endregion Danh sách sân vs Bảng giá
    }

    public partial class Yard_ViewModel : BaseViewModel
    {
        public string SanSangSuDungContent => "Sẵn sàng sử dụng";
        public string DangDuocSuDungContent => "Đang được sử dụng";
        public string DaXuatHoaDonContent => "Đã in phiếu thu tiền";
        public string KhongTheSuDungContent => "Không thể sử dụng";
        public string AdminLabel => "Admin";
        public string NuocUongButtonLabel => "Danh sách nước uống";
        public string KhachHangButtonLabel => "Danh sách khách hàng";
        public string SanButtonLabel => "Danh sách sân";
        public string BangGiaButtonLabel => "Danh sách bảng giá";
        public string LoaiSanLabel => "Danh sách loại sân";
        public string AccountNhanVienButtonLabel => "Danh sách nhân viên";
        public string InformationOfUser => "Xem và chỉnh sửa thông tin account";
        public string AdminDescriptionLabel => "Thêm xóa item";
        public string LogoutDescriptionLabel => "Đăng xuất";
        public string CloseDescriptionLabel => "Close";

        #region Header in Danhsach_BangGia
        public string CotTenLabel => "Loại sân";
        public string ThoiGianBatDauItemLabel => "Giờ bắt đầu";
        public string ThoiGianKetThucItemLabel => "Giờ kết thúc";
        public string DonGiaItemLabel => "(Vnđ/ giờ)";
        public string DanhSachCameraLabel => "Danh sách camera";
        public string BatDauSuDungLabel => "Bắt đầu sử dụng";
        public string KetThucSuDungLabel => "Kết thúc sử dụng";
        public string ThoiGianSuDungLabel => "Thời gian sử dụng";
        #endregion

    }

    //Database
    public partial class Yard_ViewModel : BaseViewModel
    {
        public Yard_ViewModel()
        {
            Database_KhachHang = new KhachHang_Service();
            Database_BangGia = new BangGia_Service();
            Database_HoatDongHienTai = new HoatDongHienTai_Service();
            Database_San = new San_Service();
            Database_NuocUongHienTai = new DanhSachHienTai_NuocUong_Service();
            Database_NuocUong = new NuocUong_Service();
            Database_LichDat = new DatLich_Service();
            Database_Account = new CurrentUser_Service();
            DanhSachHoatDongHienTai = Database_HoatDongHienTai.GetAll();
        }
        KhachHang_Service Database_KhachHang;
        BangGia_Service Database_BangGia;
        San_Service Database_San;
        DatLich_Service Database_LichDat;
        DanhSachHienTai_NuocUong_Service Database_NuocUongHienTai;
        NuocUong_Service Database_NuocUong;
        HoatDongHienTai_Service Database_HoatDongHienTai;
        CurrentUser_Service Database_Account;

        #region Method Get data from Database

        public AccountObject_Model GetDatabase_CurrentAccount()
        {
            var temp = Database_Account.GetSingleItem();
            return temp;
        }
        public ObservableCollection<KhachHangObject_Model> GetDatabase_KhachHang()
        {
            var temp = Database_KhachHang.GetAll();
            return temp;
        }

        public ObservableCollection<BangGiaObject_Model> GetDatabase_BangGia()
        {
            var temp = Database_BangGia.GetAll();
            return temp;
        }

        public ObservableCollection<SanObject_Model> GetDatabase_San()
        {
            var temp = Database_San.GetAll();
            return temp;
        }

        public ObservableCollection<LichDatObject_Model> GetDatabase_LichDat()
        {
            var temp = Database_LichDat.GetAll();
            return temp;
        }

        public ObservableCollection<HoatDongNuocUong_Model> GetDatabase_NuocUongHienTai()
        {
            var temp = Database_NuocUongHienTai.GetAll();
            return temp;
        }

        public ObservableCollection<NuocUongObject_Model> GetDatabase_NuocUong()
        {
            var temp = Database_NuocUong.GetAll();
            return temp;
        }

        public ObservableCollection<HoatDongHienTaiModel> GetDatabase_HoatDongHienTai()
        {
            var temp = Database_HoatDongHienTai.GetAll();
            return temp;
        }
        #endregion
    }

    //Declare Properties ObservableCollection
    public partial class Yard_ViewModel : BaseViewModel
    {
        private ObservableCollection<KhachHangObject_Model> _DanhSachKhachHang;
        private ObservableCollection<BangGiaObject_Model> _DanhSachBangGia;
        private ObservableCollection<SanObject_Model> _DanhSachSan;
        private ObservableCollection<LichDatObject_Model> _DanhSachLichDat;
        private ObservableCollection<NuocUongObject_Model> _DanhSachNuocUong;
        private ObservableCollection<HoatDongNuocUong_Model> _DanhSachNuocUongHienTai;
        private ObservableCollection<HoatDongHienTaiModel> _DanhSachHoatDongHienTai;

        public ObservableCollection<KhachHangObject_Model> DanhSachKhachHang
        {
            get
            {
                if (_DanhSachKhachHang == null)
                {
                    _DanhSachKhachHang = new ObservableCollection<KhachHangObject_Model>();
                    _DanhSachKhachHang = GetDatabase_KhachHang();
                }
                return _DanhSachKhachHang;
            }
            set
            {
                if (_DanhSachKhachHang != value)
                {
                    _DanhSachKhachHang = value;
                    OnPropertyChanged(nameof(DanhSachKhachHang));
                }
            }
        }
        public ObservableCollection<BangGiaObject_Model> DanhSachBangGia
        {
            get
            {
                if (_DanhSachBangGia == null)
                {
                    _DanhSachBangGia = new ObservableCollection<BangGiaObject_Model>();
                    _DanhSachBangGia = GetDatabase_BangGia();
                }
                return _DanhSachBangGia;
            }
            set
            {
                if (_DanhSachBangGia != value)
                {
                    _DanhSachBangGia = value;
                    OnPropertyChanged(nameof(DanhSachBangGia));
                }
            }
        }
        public ObservableCollection<SanObject_Model> DanhSachSan
        {
            get
            {
                if (_DanhSachSan == null)
                {
                    _DanhSachSan = new ObservableCollection<SanObject_Model>();
                    _DanhSachSan = GetDatabase_San();
                }
                return _DanhSachSan;
            }
            set
            {
                if (_DanhSachSan != value)
                {
                    _DanhSachSan = value;
                    OnPropertyChanged(nameof(DanhSachSan));
                }
            }
        }
        public ObservableCollection<LichDatObject_Model> DanhSachLichDat
        {
            get
            {
                if (_DanhSachLichDat == null)
                {
                    _DanhSachLichDat = new ObservableCollection<LichDatObject_Model>();
                    _DanhSachLichDat = GetDatabase_LichDat();
                }
                return _DanhSachLichDat;
            }
            set
            {
                if (_DanhSachLichDat != value)
                {
                    _DanhSachLichDat = value;
                    OnPropertyChanged(nameof(DanhSachLichDat));
                }
            }
        }
        public ObservableCollection<NuocUongObject_Model> DanhSachNuocUong
        {
            get
            {
                if (_DanhSachNuocUong == null)
                {
                    _DanhSachNuocUong = new ObservableCollection<NuocUongObject_Model>();
                    _DanhSachNuocUong = GetDatabase_NuocUong();
                }
                return _DanhSachNuocUong;
            }
            set
            {
                if (_DanhSachNuocUong != value)
                {
                    _DanhSachNuocUong = value;
                    OnPropertyChanged(nameof(DanhSachNuocUong));
                }
            }
        }
        public ObservableCollection<HoatDongNuocUong_Model> DanhSachNuocUongHienTai
        {
            get
            {
                if (_DanhSachNuocUongHienTai == null)
                {
                    _DanhSachNuocUongHienTai = new ObservableCollection<HoatDongNuocUong_Model>();
                    _DanhSachNuocUongHienTai = GetDatabase_NuocUongHienTai();
                }
                return _DanhSachNuocUongHienTai;
            }
            set
            {
                if (_DanhSachNuocUongHienTai != value)
                {
                    _DanhSachNuocUongHienTai = value;
                    OnPropertyChanged(nameof(DanhSachNuocUongHienTai));
                }
            }
        }
        public ObservableCollection<HoatDongHienTaiModel> DanhSachHoatDongHienTai
        {
            get
            {
                if (_DanhSachHoatDongHienTai == null)
                {
                    _DanhSachHoatDongHienTai = new ObservableCollection<HoatDongHienTaiModel>();
                }
                return _DanhSachHoatDongHienTai;
            }
            set
            {
                if (_DanhSachHoatDongHienTai != value)
                {
                    _DanhSachHoatDongHienTai = value;
                    OnPropertyChanged(nameof(DanhSachHoatDongHienTai));
                }
            }
        }

        public Dictionary<int, string> Dictionary_NuocUong
        {
            get
            {
                Dictionary<int, string> temp = new Dictionary<int, string>();
                for(int i = 0; i < DanhSachNuocUong.Count; i++)
                {
                    temp.Add(i, DanhSachNuocUong[i].BaseObject.TenObject);
                }
                return temp;
            }
        }

        public Dictionary<int, string> Dictionary_KhachHang
        {
            get
            {
                Dictionary<int, string> temp = new Dictionary<int, string>();
                for (int i = 0; i < DanhSachKhachHang.Count; i++)
                {
                    temp.Add(i, DanhSachKhachHang[i].BaseObject.TenObject);
                }
                return temp;
            }
        }

    }


    //Selected Item
    public partial class Yard_ViewModel : BaseViewModel
    {
        #region Selected Item
        private HoatDongHienTaiModel _SelectedItem;
        private string _TenKhachHang;
        private string _GioVaoSan;
        private string _GioKetThuc;
        private double _TongGio;
        private string _TenSan;
        private decimal _TongTien;
        private decimal _TienKhachDua;
        private decimal _TienThoi;
        private string _GhiChu;
        private string _TinhTrang;
        
        public string TenKhachHang
        {
            get => _TenKhachHang;
            set
            {
                if (_TenKhachHang != value)
                {
                    _TenKhachHang = value;
                    SelectedItem.HoatDongCuaSan.KhachHang.BaseObject.TenObject = value;
                    OnPropertyChanged(nameof(TenKhachHang));
                }
            }
        }
        public string GioVaoSan
        {
            get => _GioVaoSan;
            set
            {
                if (_GioVaoSan != value)
                {
                    _GioVaoSan = value;
                    SelectedItem.HoatDongCuaSan.GioVaoSan = value;
                    OnPropertyChanged(nameof(GioVaoSan));
                }
            }
        }
        public string GioKetThuc
        {
            get => _GioKetThuc;
            set
            {
                if (_GioKetThuc != value)
                {
                    _GioKetThuc = value;
                    SelectedItem.HoatDongCuaSan.GioKetThuc = value;
                    OnPropertyChanged(nameof(GioKetThuc));
                }
            }
        }
        public double TongGio
        {
            get => _TongGio;
            set
            {
                if (_TongGio != value)
                {
                    _TongGio = value;
                    SelectedItem.HoatDongCuaSan.SoGioThue = value;
                    OnPropertyChanged(nameof(TongGio));
                }
            }
        }
        public string TenSan
        {
            get => _TenSan;
            set
            {
                if (_TenSan != value)
                {
                    _TenSan = value;
                    OnPropertyChanged(nameof(TenSan));
                }
            }
        }
        public decimal TongTien
        {
            get => _TongTien;
            set
            {
                if (_TongTien != value)
                {
                    _TongTien = value;
                    OnPropertyChanged(nameof(TongTien));
                }
            }
        }
        public decimal TienKhachDua
        {
            get => _TienKhachDua;
            set
            {
                if (_TienKhachDua != value)
                {
                    _TienKhachDua = value;
                    SelectedItem.HoatDongCuaSan.TienKhachDua = value;
                    OnPropertyChanged(nameof(TienKhachDua));
                }
            }
        }
        public decimal TienThoi
        {
            get => _TienThoi;
            set
            {
                if (_TienThoi != value)
                {
                    _TienThoi = value;
                    SelectedItem.HoatDongCuaSan.TienThoi = value;
                    OnPropertyChanged(nameof(TienThoi));
                }
            }
        }
        public string GhiChu
        {
            get => _GhiChu;
            set
            {
                if (_GhiChu != value)
                {
                    _GhiChu = value;
                    SelectedItem.HoatDongCuaSan.GhiChu = value;
                    OnPropertyChanged(nameof(GhiChu));
                }
            }
        }

        public string TinhTrang
        {
            get => _TinhTrang;
            set
            {
                if(_TinhTrang != value)
                {
                    _TinhTrang = value;
                    SelectedItem.TrangThaiSan = value;
                    OnPropertyChanged(nameof(TinhTrang));
                }
            }
        }

        public HoatDongHienTaiModel SelectedItem
        {
            get
            {
                if(_SelectedItem == null)
                {
                    _SelectedItem = new HoatDongHienTaiModel();
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

        public void ActionWhenChangeSelectedItem()
        {
            TenKhachHang = SelectedItem.HoatDongCuaSan.KhachHang.BaseObject.TenObject;
            GioVaoSan = SelectedItem.HoatDongCuaSan.GioVaoSan;
            GioKetThuc = SelectedItem.HoatDongCuaSan.GioKetThuc;
            TongGio = SelectedItem.HoatDongCuaSan.SoGioThue;
            TenSan = SelectedItem.HoatDongCuaSan.San.BaseObject.TenObject;
            TongTien = SelectedItem.HoatDongCuaSan.TongTien;
            TienKhachDua = SelectedItem.HoatDongCuaSan.TienKhachDua;
            TienThoi = SelectedItem.HoatDongCuaSan.TienThoi;
            GhiChu = SelectedItem.HoatDongCuaSan.GhiChu;
            TinhTrang = SelectedItem.TrangThaiSan;
        }
        #endregion Selected item

        #region Danh Sach San
        private ObservableCollection<HoatDongHienTaiModel> _DanhSachSan5;
        private ObservableCollection<HoatDongHienTaiModel> _DanhSachSan7;
        private ObservableCollection<HoatDongHienTaiModel> _DanhSachSan11;
        private ObservableCollection<HoatDongHienTaiModel> _DanhSachSanOther;

        public ObservableCollection<HoatDongHienTaiModel> DanhSachSan5
        {
            get
            {
                if(_DanhSachSan5 == null)
                {
                    _DanhSachSan5 = new ObservableCollection<HoatDongHienTaiModel>();
                    _DanhSachSan5 = GetCorrectSan((int)LoaiSanIndex.San5);
                }
                return _DanhSachSan5;
            }
            set
            {
                if(_DanhSachSan5 != value)
                {
                    _DanhSachSan5 = value;
                    OnPropertyChanged(nameof(DanhSachSan5));
                }
            }
        }

        public ObservableCollection<HoatDongHienTaiModel> DanhSachSan7
        {
            get
            {
                if (_DanhSachSan7 == null)
                {
                    _DanhSachSan7 = new ObservableCollection<HoatDongHienTaiModel>();
                    _DanhSachSan7 = GetCorrectSan((int)LoaiSanIndex.San7);
                }
                return _DanhSachSan7;
            }
            set
            {
                if (_DanhSachSan7 != value)
                {
                    _DanhSachSan7 = value;
                    OnPropertyChanged(nameof(DanhSachSan7));
                }
            }
        }

        public ObservableCollection<HoatDongHienTaiModel> DanhSachSan11
        {
            get
            {
                if (_DanhSachSan11 == null)
                {
                    _DanhSachSan11 = new ObservableCollection<HoatDongHienTaiModel>();
                    _DanhSachSan11 = GetCorrectSan((int)LoaiSanIndex.San11);
                }
                return _DanhSachSan11;
            }
            set
            {
                if (_DanhSachSan11 != value)
                {
                    _DanhSachSan11 = value;
                    OnPropertyChanged(nameof(DanhSachSan11));
                }
            }
        }

        public ObservableCollection<HoatDongHienTaiModel> DanhSachSanOther
        {
            get
            {
                if (_DanhSachSanOther == null)
                {
                    _DanhSachSanOther = new ObservableCollection<HoatDongHienTaiModel>();
                    _DanhSachSanOther = GetCorrectSan((int)LoaiSanIndex.SanOther);
                }
                return _DanhSachSanOther;
            }
            set
            {
                if (_DanhSachSanOther != value)
                {
                    _DanhSachSanOther = value;
                    OnPropertyChanged(nameof(DanhSachSanOther));
                }
            }
        }

        #region Method to get correct San
        public ObservableCollection<HoatDongHienTaiModel> GetCorrectSan(int loaisan)
        {
            ObservableCollection<HoatDongHienTaiModel> temp = new ObservableCollection<HoatDongHienTaiModel>();
            foreach(var item in DanhSachHoatDongHienTai)
            {
                if(item.HoatDongCuaSan.San.IdLoaiSan == loaisan)
                {
                    temp.Add(item);
                }
            }
            return temp;
        }
        #endregion
        #endregion
    }


    //Danh sach san Pham
    public partial class Yard_ViewModel : BaseViewModel
    {
        #region Fields
        private string _NuocUongSelectedItem;
        private string _GiaTienSelecteItem;
        private string _SoLuongSelectedItem;
        #endregion
        #region Properties
        public string NuocUongSelectedItem
        {
            get => _NuocUongSelectedItem;
            set
            {
                if (_NuocUongSelectedItem != value)
                {
                    _NuocUongSelectedItem = value;
                    OnPropertyChanged(nameof(NuocUongSelectedItem));
                }
            }
        }

        public string GiaTienSelecteItem
        {
            get => _GiaTienSelecteItem;
            set
            {
                if (_GiaTienSelecteItem != value)
                {
                    _GiaTienSelecteItem = value;
                    OnPropertyChanged(nameof(GiaTienSelecteItem));
                }
            }
        }

        public string SoLuongSelectedItem
        {
            get => _SoLuongSelectedItem;
            set
            {
                if (_SoLuongSelectedItem != value)
                {
                    _SoLuongSelectedItem = value;
                    OnPropertyChanged(nameof(SoLuongSelectedItem));
                }
            }
        }
        #endregion
    }
}
