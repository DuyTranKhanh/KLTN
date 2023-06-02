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
        TamDungSuDung = 4,
    }

    //Visibility
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

    //Language
    public partial class Yard_ViewModel : BaseViewModel
    {
        public string SanSangSuDungContent => "Sẵn sàng sử dụng";
        public string TamDungSuDungContent => "Tạm dừng sử dụng";
        public string TiepTucSuDungContent => "Tiếp tục sử dụng";
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

        private string _ContentOfPause;
        public string ContentOfBtnPause
        {
            get => _ContentOfPause;
            set
            {
                if (_ContentOfPause != value)
                {
                    _ContentOfPause = value;
                    OnPropertyChanged(nameof(ContentOfBtnPause));
                }
            }
        }
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
            DanhSachHoatDongHienTai = Database_HoatDongHienTai.GetWithCondition();
            Database_HoaDon = new HoaDon_Service();
            Database_NuocUongHoaDon = new DanhSachHoaDon_NuocUong_Service();
        }
        KhachHang_Service Database_KhachHang;
        BangGia_Service Database_BangGia;
        San_Service Database_San;
        DatLich_Service Database_LichDat;
        DanhSachHienTai_NuocUong_Service Database_NuocUongHienTai;
        NuocUong_Service Database_NuocUong;
        HoatDongHienTai_Service Database_HoatDongHienTai;
        CurrentUser_Service Database_Account;
        HoaDon_Service Database_HoaDon;
        DanhSachHoaDon_NuocUong_Service Database_NuocUongHoaDon;

        #region Method Get data from Database

        public AccountObject_Model GetDatabase_CurrentAccount()
        {
            var temp = Database_Account.GetSingleItem();
            return temp;
        }
        public ObservableCollection<KhachHangObject_Model> GetDatabase_KhachHang()
        {
            var temp = Database_KhachHang.GetWithCondition();
            return temp;
        }

        public ObservableCollection<BangGiaObject_Model> GetDatabase_BangGia()
        {
            var temp = Database_BangGia.GetWithCondition();
            return temp;
        }

        public ObservableCollection<SanObject_Model> GetDatabase_San()
        {
            var temp = Database_San.GetWithCondition();
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
            var temp = Database_NuocUong.GetWithCondition();
            return temp;
        }

        public ObservableCollection<HoatDongHienTaiModel> GetDatabase_HoatDongHienTai()
        {
            var temp = Database_HoatDongHienTai.GetWithCondition();
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

        //Items for combobox NuocUong in Menu
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

        /// <summary>
        /// Danh sach nhung loai nuoc uong dang duoc san su dung
        /// </summary>
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
                for (int i = 0; i < DanhSachNuocUong.Count; i++)
                {
                    if(DanhSachNuocUong[i].BaseObject.TrangThaiObject == _HoatDong)
                    {
                        temp.Add(i, DanhSachNuocUong[i].BaseObject.TenObject);
                    }
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
        private DateTime_Model _GioVaoSan;
        private DateTime_Model _GioKetThuc;
        private string _GioKetThuc_string;
        private string _GioVaoSan_string;
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
                    Database_HoatDongHienTai.UpdateItem(SelectedItem);
                }
            }
        }

        public string GioVaoSan_string
        {
            get
            {
                _GioVaoSan_string = GioVaoSan.Hour + " : " + GioVaoSan.Minute;
                return _GioVaoSan_string;
            }
            set
            {
                if(_GioVaoSan_string != value)
                {
                    _GioVaoSan_string = value;
                    OnPropertyChanged(nameof(GioVaoSan_string));
                }
            }
        }

        public string GioKetThuc_string
        {
            get
            {
                _GioKetThuc_string = GioKetThuc.Hour + " : " + GioKetThuc.Minute;
                return _GioKetThuc_string;
            }
            set
            {
                if (_GioKetThuc_string != value)
                {
                    _GioKetThuc_string = value;
                    OnPropertyChanged(nameof(GioKetThuc_string));
                }
            }
        }
        public DateTime_Model GioVaoSan
        {
            get
            {
                if(_GioVaoSan == null)
                {
                    _GioVaoSan = new DateTime_Model();
                }
                return _GioVaoSan;
            }
            set
            {
                if (_GioVaoSan != value)
                {
                    _GioVaoSan = value;
                    SelectedItem.HoatDongCuaSan.GioVaoSan = value;
                    GioVaoSan_string = GioVaoSan.Hour + " : " + GioVaoSan.Minute;
                    OnPropertyChanged(nameof(GioVaoSan));
                    Database_HoatDongHienTai.UpdateItem(SelectedItem);
                }
            }
        }
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
                    SelectedItem.HoatDongCuaSan.GioKetThuc = value;
                    GioKetThuc_string = GioVaoSan.Hour + " : " + GioVaoSan.Minute;
                    OnPropertyChanged(nameof(GioKetThuc));
                    Database_HoatDongHienTai.UpdateItem(SelectedItem);
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
                    Database_HoatDongHienTai.UpdateItem(SelectedItem);
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
                    Database_HoatDongHienTai.UpdateItem(SelectedItem);
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
                    Database_HoatDongHienTai.UpdateItem(SelectedItem);
                }
            }
        }

        public string TinhTrang
        {
            get => _TinhTrang;
            set
            {
                if (_TinhTrang != value)
                {
                    _TinhTrang = value;
                    SelectedItem.TrangThaiSan = value;
                    OnPropertyChanged(nameof(TinhTrang));
                }
            }
        }

        private ObservableCollection<HoatDongNuocUong_Model> _DanhSachNuocUongItem;

        public ObservableCollection<HoatDongNuocUong_Model> DanhSachNuocUongItem
        {
            get
            {
                if (_DanhSachNuocUongItem == null)
                {
                    _DanhSachNuocUongItem = new ObservableCollection<HoatDongNuocUong_Model>();
                }
                return _DanhSachNuocUongItem;
            }
            set
            {
                if (_DanhSachNuocUongItem != value)
                {
                    _DanhSachNuocUongItem = value;
                    OnPropertyChanged(nameof(DanhSachNuocUongItem));
                }
            }
        }
        public HoatDongHienTaiModel SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new HoatDongHienTaiModel();
                }
                return _SelectedItem;
            }
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    ActionWhenChangeSelectedItem();
                    Database_HoatDongHienTai.UpdateItem(SelectedItem);
                }
                OnPropertyChanged(nameof(SelectedItem));

            }
        }

        public void ActionWhenChangeSelectedItem()
        {
            TenKhachHang = SelectedItem.HoatDongCuaSan.KhachHang.BaseObject.TenObject;
            GioVaoSan = SelectedItem.HoatDongCuaSan.GioVaoSan;
            GioKetThuc = SelectedItem.HoatDongCuaSan.GioKetThuc;
            GioVaoSan_string = GioVaoSan.Hour + " : " + GioVaoSan.Minute;
            GioKetThuc_string = GioKetThuc.Hour + " : " + GioKetThuc.Minute;
            TongGio = SelectedItem.HoatDongCuaSan.SoGioThue;
            TenSan = SelectedItem.HoatDongCuaSan.San.BaseObject.TenObject;
            TongTien = SelectedItem.HoatDongCuaSan.TongTien;
            TienKhachDua = SelectedItem.HoatDongCuaSan.TienKhachDua;
            TienThoi = SelectedItem.HoatDongCuaSan.TienThoi;
            GhiChu = SelectedItem.HoatDongCuaSan.GhiChu;
            TinhTrang = SelectedItem.TrangThaiSan;
            DanhSachNuocUongItem = GetListNuocUongHienTai(SelectedItem.HoatDongCuaSan.San.BaseObject.IdObject);
            TongTienNuoc = CalculateMoneyDrink().ToString();
            if (TinhTrang == DangDuocSuDungContent)
            {
                DangDuocSuDung();
            }
            else if (TinhTrang == SanSangSuDungContent)
            {
                SanSangSuDung();
            }
            else if (TinhTrang == DaXuatHoaDonContent)
            {
                DaXuatHoaDon();
            }
            else if (TinhTrang == TamDungSuDungContent)
            {
                TamDungSuDung();
            }
        }

        public void SanSangSuDung()
        {
            IsBtnBatDauSudungEnable = true;
            IsBtnTamDungSuDungEnable = false;
            IsInforFieldEnable = false;
            IsBtnInphieuEnable = false;
            IsBtnHuyInPhieuEnable = false;
            IsBtnThuTienEnable = false;
            IsBtnDoiSanEnable = false;
            IsBtnHuySanEnable = false;
            SelectedItem.TrangThaiSan = SanSangSuDungContent;
        }
        public void DangDuocSuDung()
        {
            IsBtnBatDauSudungEnable = false;
            IsBtnTamDungSuDungEnable = true;
            IsInforFieldEnable = true;
            IsBtnInphieuEnable = true;
            IsBtnHuyInPhieuEnable = false;
            IsBtnThuTienEnable = false;
            IsBtnDoiSanEnable = true;
            IsBtnHuySanEnable = true;
            SelectedItem.TrangThaiSan = DangDuocSuDungContent;
            ContentOfBtnPause = TamDungSuDungContent;
        }

        public void DaXuatHoaDon()
        {
            IsBtnBatDauSudungEnable = false;
            IsBtnTamDungSuDungEnable = false;
            IsInforFieldEnable = false;
            IsBtnInphieuEnable = false;
            IsBtnHuyInPhieuEnable = true;
            IsBtnThuTienEnable = true;
            IsBtnDoiSanEnable = false;
            IsBtnHuySanEnable = false;
            SelectedItem.TrangThaiSan = DaXuatHoaDonContent;
        }

        public void TamDungSuDung()
        {
            IsBtnBatDauSudungEnable = false;
            IsBtnTamDungSuDungEnable = true;
            if (SelectedItem.TrangThaiSan == TamDungSuDungContent)
            {
                IsInforFieldEnable = false;
                IsBtnInphieuEnable = false;
                IsBtnHuyInPhieuEnable = false;
                IsBtnThuTienEnable = false;
                IsBtnDoiSanEnable = false;
                IsBtnHuySanEnable = true;
                ContentOfBtnPause = TiepTucSuDungContent;

            }
            else
            {
                //Tiep tuc hoat dong
                IsInforFieldEnable = true;
                IsBtnInphieuEnable = true;
                IsBtnHuyInPhieuEnable = false;
                IsBtnThuTienEnable = false;
                IsBtnDoiSanEnable = true;
                IsBtnHuySanEnable = true;
                ContentOfBtnPause = TamDungSuDungContent;
            }

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
                if (_DanhSachSan5 == null)
                {
                    _DanhSachSan5 = new ObservableCollection<HoatDongHienTaiModel>();
                    _DanhSachSan5 = GetCorrectSan((int)LoaiSanIndex.San5);
                }
                return _DanhSachSan5;
            }
            set
            {
                if (_DanhSachSan5 != value)
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
                }
                OnPropertyChanged(nameof(DanhSachSan7));

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
                }
                OnPropertyChanged(nameof(DanhSachSan11));
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
                }
                OnPropertyChanged(nameof(DanhSachSanOther));
            }
        }

        #region Method to get correct San
        public ObservableCollection<HoatDongHienTaiModel> GetCorrectSan(int loaisan)
        {
            ObservableCollection<HoatDongHienTaiModel> temp = new ObservableCollection<HoatDongHienTaiModel>();
            foreach (var item in DanhSachHoatDongHienTai)
            {
                if (item.HoatDongCuaSan.San.IdLoaiSan == loaisan)
                {
                    temp.Add(item);
                }
            }
            return temp;
        }
        #endregion
        #endregion
    }


    //Danh sach san Pham nuoc uong
    public partial class Yard_ViewModel : BaseViewModel
    {
        #region Fields
        private string _NuocUongSelectedItem;
        private string _GiaTienSelecteItem;
        private string _SoLuongSelectedItem;
        private string _TongTienNuoc;
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
                    UpdateGiaTien();
                    CheckItemIsExist();
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

        public string TongTienNuoc
        {
            get => _TongTienNuoc;
            set
            {
                if (_TongTienNuoc != value)
                {
                    _TongTienNuoc = value;
                    OnPropertyChanged(nameof(TongTienNuoc));
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
                    if(value == "0")
                    {
                        value = "1";
                    }
                    _SoLuongSelectedItem = value;
                    OnPropertyChanged(nameof(SoLuongSelectedItem));
                }
            }
        }

        private HoatDongNuocUong_Model _SelectedNuocUongItem;

        public HoatDongNuocUong_Model SelectedNuocUongItem
        {
            get
            {
                if (_SelectedNuocUongItem == null)
                {
                    _SelectedNuocUongItem = new HoatDongNuocUong_Model();
                }
                return _SelectedNuocUongItem;
            }
            set
            {
                if (_SelectedNuocUongItem != value)
                {
                    _SelectedNuocUongItem = value;
                    ActionWhenChangeSelectedNuocUongItem();
                    if (value != null)
                    {
                        IsBtnDeleteEnable = true;
                    }
                    else IsBtnDeleteEnable = false;
                    OnPropertyChanged(nameof(SelectedNuocUongItem));
                }
            }
        }
        #endregion

        #region Method
        //Add item 
        public void ActionBtnAddClicked()
        {
            var itemSelected = new HoatDongNuocUong_Model();
            int idSan = SelectedItem.HoatDongCuaSan.San.BaseObject.IdObject;
            var id_NuocUong = DanhSachNuocUong.Where( m => m.BaseObject.TenObject == NuocUongSelectedItem.ToString()).Single();
            if (id_NuocUong != null)
            {
                itemSelected.IdNuocUong = id_NuocUong.BaseObject.IdObject;
                itemSelected.TenNuocUong = NuocUongSelectedItem.ToString();
                if(SoLuongSelectedItem == string.Empty)
                {
                    SoLuongSelectedItem = "1";
                }
                itemSelected.SoLuong = Convert.ToInt32(SoLuongSelectedItem);
                itemSelected.GiaTien = Convert.ToDecimal(GiaTienSelecteItem);
                itemSelected.IdSan = idSan;

                // Add item into DanhSachNuocUongItem
                ObservableCollection<HoatDongNuocUong_Model> tempItem = new ObservableCollection<HoatDongNuocUong_Model>();
                foreach(var item in DanhSachNuocUongItem)
                {
                    tempItem.Add(item.Clone());
                }
                tempItem.Add(itemSelected);

                DanhSachNuocUongItem = new ObservableCollection<HoatDongNuocUong_Model>();
                foreach(var item in tempItem)
                {
                    DanhSachNuocUongItem.Add(item.Clone());
                }
                Database_NuocUongHienTai.Add(itemSelected);
                DanhSachNuocUongHienTai = GetDatabase_NuocUongHienTai();
                TongTienNuoc = CalculateMoneyDrink().ToString();
                //SelectedNuocUongItem = null;
            }
        }

        //Modify number of item base id san and Id Nuoc Uong
        public void ActionBtnModifyClicked()
        {
            if (SoLuongSelectedItem == string.Empty)
            {
                SoLuongSelectedItem = "1";
            }
            SelectedNuocUongItem.SoLuong = Convert.ToInt32(SoLuongSelectedItem);
            Database_NuocUongHienTai.UpdateItem(SelectedNuocUongItem);

            ObservableCollection<HoatDongNuocUong_Model> tempItem = new ObservableCollection<HoatDongNuocUong_Model>();
            foreach (var item in DanhSachNuocUongItem)
            {
                tempItem.Add(item.Clone());
            }
            DanhSachNuocUongItem = new ObservableCollection<HoatDongNuocUong_Model>();
            foreach (var item in tempItem)
            {
                DanhSachNuocUongItem.Add(item.Clone());
            }
            DanhSachNuocUongHienTai = GetDatabase_NuocUongHienTai();
            TongTienNuoc = CalculateMoneyDrink().ToString();
            //SelectedNuocUongItem = null;
        }

        //Remove item
        public void ActionBtnDeleteClicked()
        {
            if(SelectedNuocUongItem != null)
            {
                //Remove item

                ObservableCollection<HoatDongNuocUong_Model> tempItem = new ObservableCollection<HoatDongNuocUong_Model>();
                foreach (var item in DanhSachNuocUongItem)
                {
                    tempItem.Add(item.Clone());
                }
                Database_NuocUongHienTai.RemoveItem(SelectedNuocUongItem);
                tempItem.Remove(tempItem.Where(x => x.IdNuocUong == SelectedNuocUongItem.IdNuocUong).Single());
                DanhSachNuocUongItem = new ObservableCollection<HoatDongNuocUong_Model>();
                if(tempItem.Count > 0)
                {
                    foreach (var item in tempItem)
                    {
                        DanhSachNuocUongItem.Add(item.Clone());
                    }
                }
                //SelectedNuocUongItem = null;
                IsBtnDeleteEnable = false;
                DanhSachNuocUongHienTai = GetDatabase_NuocUongHienTai();
                TongTienNuoc = CalculateMoneyDrink().ToString();
            }
        }

        //Save into Db
        public void ActionBtnSaveClicked()
        {
            
        }

        public void ActionWhenChangeSelectedNuocUongItem()
        {
            NuocUongSelectedItem = SelectedNuocUongItem.TenNuocUong;
            SoLuongSelectedItem = SelectedNuocUongItem.SoLuong.ToString();
            GiaTienSelecteItem = SelectedNuocUongItem.GiaTien.ToString();
            

        }
        public void UpdateGiaTien()
        {
            foreach (var item in DanhSachNuocUong)
            {
                if (item.BaseObject.TenObject == NuocUongSelectedItem)
                {
                    GiaTienSelecteItem = item.GiaTienObject.ToString();
                }
            }
        }
        public void CheckItemIsExist()
        {

            bool result = false;
            foreach(var item in DanhSachNuocUongItem)
            {
                if(item.TenNuocUong == NuocUongSelectedItem)
                {
                    result = true;
                }
            }
            if (result)
            {
                IsBtnModifyEnable = true;
                IsBtnAddEnable = false;
                IsBtnSaveEnable = false;
            }
            else
            {
                SoLuongSelectedItem = "1";
                IsBtnAddEnable = true;
                IsBtnModifyEnable = false;
                IsBtnSaveEnable = false;
            }
        }
        public ObservableCollection<HoatDongNuocUong_Model> GetListNuocUongHienTai(int idSan)
        {
            var listDanhSach = new ObservableCollection<HoatDongNuocUong_Model>();

            foreach (var item in DanhSachNuocUongHienTai)
            {
                if (item.IdSan == idSan)
                {
                    listDanhSach.Add(item.Clone());
                }
            }
            return listDanhSach;
        }

        public decimal CalculateMoneyDrink()
        {
            decimal _SumMoney = 0;
            foreach(var item in DanhSachNuocUongItem)
            {
                _SumMoney = _SumMoney + item.GiaTien * item.SoLuong;
            }
            return _SumMoney;
            
        }
        #endregion
    }


    //Status of Btn and Command
    public partial class Yard_ViewModel : BaseViewModel
    {
        #region Status
        #region Fields of Status
        private bool _IsInforFieldEnable;
        private bool _IsBtnAddEnable = false;
        private bool _IsBtnModifyEnable = false;
        private bool _IsBtnSaveEnable = false;
        private bool _IsBtnDeleteEnable = false;
        private bool _IsBtnBatDauSudungEnable;
        private bool _IsBtnTamDungSuDungEnable;
        private bool _IsBtnInphieuEnable;
        private bool _IsBtnHuyInPhieuEnable;
        private bool _IsBtnThuTienEnable;
        private bool _IsBtnDoiSanEnable;
        private bool _IsBtnHuySanEnable;
        #endregion Status of Fields

        #region Properties of Status
        public bool IsInforFieldEnable
        {
            get => _IsInforFieldEnable;
            set
            {
                if (_IsInforFieldEnable != value)
                {
                    _IsInforFieldEnable = value;
                    OnPropertyChanged(nameof(IsInforFieldEnable));
                }
            }
        }
        public bool IsBtnAddEnable
        {
            get => _IsBtnAddEnable;
            set
            {
                if (_IsBtnAddEnable != value)
                {
                    _IsBtnAddEnable = value;
                    OnPropertyChanged(nameof(IsBtnAddEnable));
                }
            }
        }
        public bool IsBtnModifyEnable
        {
            get => _IsBtnModifyEnable;
            set
            {
                if (_IsBtnModifyEnable != value)
                {
                    _IsBtnModifyEnable = value;
                    OnPropertyChanged(nameof(IsBtnModifyEnable));
                }
            }
        }
        public bool IsBtnSaveEnable
        {
            get => _IsBtnSaveEnable;
            set
            {
                if (_IsBtnSaveEnable != value)
                {
                    _IsBtnSaveEnable = value;
                    OnPropertyChanged(nameof(IsBtnSaveEnable));
                }
            }
        }
        public bool IsBtnDeleteEnable
        {
            get => _IsBtnDeleteEnable;
            set
            {
                if (_IsBtnDeleteEnable != value)
                {
                    _IsBtnDeleteEnable = value;
                    OnPropertyChanged(nameof(IsBtnDeleteEnable));
                }
            }
        }
        public bool IsBtnBatDauSudungEnable
        {
            get => _IsBtnBatDauSudungEnable;
            set
            {
                if (_IsBtnBatDauSudungEnable != value)
                {
                    _IsBtnBatDauSudungEnable = value;
                    OnPropertyChanged(nameof(IsBtnBatDauSudungEnable));
                }
            }
        }
        public bool IsBtnTamDungSuDungEnable
        {
            get => _IsBtnTamDungSuDungEnable;
            set
            {
                if (_IsBtnTamDungSuDungEnable != value)
                {
                    _IsBtnTamDungSuDungEnable = value;
                    OnPropertyChanged(nameof(IsBtnTamDungSuDungEnable));
                }
            }
        }
        public bool IsBtnInphieuEnable
        {
            get => _IsBtnInphieuEnable;
            set
            {
                if (_IsBtnInphieuEnable != value)
                {
                    _IsBtnInphieuEnable = value;
                    OnPropertyChanged(nameof(IsBtnInphieuEnable));
                }
            }
        }
        public bool IsBtnHuyInPhieuEnable
        {
            get => _IsBtnHuyInPhieuEnable;
            set
            {
                if (_IsBtnHuyInPhieuEnable != value)
                {
                    _IsBtnHuyInPhieuEnable = value;
                    OnPropertyChanged(nameof(IsBtnHuyInPhieuEnable));
                }
            }
        }
        public bool IsBtnThuTienEnable
        {
            get => _IsBtnThuTienEnable;
            set
            {
                if (_IsBtnThuTienEnable != value)
                {
                    _IsBtnThuTienEnable = value;
                    OnPropertyChanged(nameof(IsBtnThuTienEnable));
                }
            }
        }
        public bool IsBtnDoiSanEnable
        {
            get => _IsBtnDoiSanEnable;
            set
            {
                if (_IsBtnDoiSanEnable != value)
                {
                    _IsBtnDoiSanEnable = value;
                    OnPropertyChanged(nameof(IsBtnDoiSanEnable));
                }
            }
        }
        public bool IsBtnHuySanEnable
        {
            get => _IsBtnHuySanEnable;
            set
            {
                if (_IsBtnHuySanEnable != value)
                {
                    _IsBtnHuySanEnable = value;
                    OnPropertyChanged(nameof(IsBtnHuySanEnable));
                }
            }
        }
        #endregion Property of Status

        #endregion Status

        #region Command
        #region Fields of Command
        private ICommand _BtnAddCommand;
        private ICommand _BtnModifyCommand;
        private ICommand _BtnSaveCommand;
        private ICommand _BtnDeleteCommand;
        private ICommand _BtnBatDauSuDungCommand;
        private ICommand _BtnTamDungSuDungCommand;
        private ICommand _BtnInphieuCommand;
        private ICommand _BtnHuyInPhieuCommand;
        private ICommand _BtnThuTienCommand;
        private ICommand _BtnHuySanCommand;
        private ICommand _BtnBatDauTinhGioCommand;
        private ICommand _BtnKetThucTinhGioCommand;
        #endregion Fields of Command
        #region Property of Command
        public ICommand BtnAddCommand
        {
            get
            {
                if (_BtnAddCommand == null)
                {
                    _BtnAddCommand = new RelayCommand(ActionBtnAddClicked, CanExecute);
                }
                return _BtnAddCommand;
            }
        }
        public ICommand BtnModifyCommand
        {
            get
            {
                if (_BtnModifyCommand == null)
                {
                    _BtnModifyCommand = new RelayCommand(ActionBtnModifyClicked, CanExecute);
                }
                return _BtnModifyCommand;
            }
        }
        public ICommand BtnSaveCommand
        {
            get
            {
                if (_BtnSaveCommand == null)
                {
                    _BtnSaveCommand = new RelayCommand(ActionBtnSaveClicked, CanExecute);
                }
                return _BtnSaveCommand;
            }
        }
        public ICommand BtnDeleteCommand
        {
            get
            {
                if (_BtnDeleteCommand == null)
                {
                    _BtnDeleteCommand = new RelayCommand(ActionBtnDeleteClicked, CanExecute);
                }
                return _BtnDeleteCommand;
            }
        }
        public ICommand BtnBatDauSuDungCommand
        {
            get
            {
                if (_BtnBatDauSuDungCommand == null)
                {
                    _BtnBatDauSuDungCommand = new RelayCommand(ActionWhenBtnBatDauSuDungClicked, CanExecute);
                }
                return _BtnBatDauSuDungCommand;
            }
        }
        public ICommand BtnTamDungSuDungCommand
        {
            get
            {
                if (_BtnTamDungSuDungCommand == null)
                {
                    _BtnTamDungSuDungCommand = new RelayCommand(ActionWhenBtnTamDungSuDungClicked, CanExecute);
                }
                return _BtnTamDungSuDungCommand;
            }
        }

        public ICommand BtnInphieuCommand
        {
            get
            {
                if (_BtnInphieuCommand == null)
                {
                    _BtnInphieuCommand = new RelayCommand(ActionWhenBtnInPhieuClicked, CanExecute);
                }
                return _BtnInphieuCommand;
            }
        }
        public ICommand BtnHuyInPhieuCommand
        {
            get
            {
                if (_BtnHuyInPhieuCommand == null)
                {
                    _BtnHuyInPhieuCommand = new RelayCommand(ActionWhenBtnHuyInPhieuClicked, CanExecute);
                }
                return _BtnHuyInPhieuCommand;
            }
        }
        public ICommand BtnThuTienCommand
        {
            get
            {
                if (_BtnThuTienCommand == null)
                {
                    _BtnThuTienCommand = new RelayCommand(ActionWhenBtnThuTienClicked, CanExecute);
                }
                return _BtnThuTienCommand;
            }
        }
        public ICommand BtnHuySanCommand
        {
            get
            {
                if (_BtnHuySanCommand == null)
                {
                    _BtnHuySanCommand = new RelayCommand(ActionWhenBtnHuySanClicked, CanExecute);
                }
                return _BtnHuySanCommand;
            }
        }

        public ICommand BtnBatDauTinhGioCommand
        {
            get
            {
                if(_BtnBatDauTinhGioCommand == null)
                {
                    _BtnBatDauTinhGioCommand = new RelayCommand(ActionWhenClickBatDauTinhGio, CanExecute);
                }
                return _BtnBatDauTinhGioCommand;
            }
        }

        public ICommand BtnKetThucTinhGioCommand
        {
            get
            {
                if (_BtnKetThucTinhGioCommand == null)
                {
                    _BtnKetThucTinhGioCommand = new RelayCommand(ActionWhenClickKetThucTinhGio, CanExecute);
                }
                return _BtnKetThucTinhGioCommand;
            }
        }

        #endregion Property of Command

        #region Method of Command

        public void ActionWhenClickBatDauTinhGio()
        {
            //SelectedItem.HoatDongCuaSan.GioVaoSan = value;
            //OnPropertyChanged(nameof(GioVaoSan));
            //Database_HoatDongHienTai.UpdateItem(SelectedItem);

            DateTime_Model temp = new DateTime_Model();
            temp.Minute = DateTime.Now.ToString("mm").Trim();
            temp.Hour = DateTime.Now.ToString("HH").Trim();

            GioVaoSan = temp.Clone();


        }

        public void ActionWhenClickKetThucTinhGio()
        {
            DateTime_Model temp = new DateTime_Model();
            temp.Minute = DateTime.Now.ToString("mm").Trim();
            temp.Hour = DateTime.Now.ToString("HH").Trim();

            GioKetThuc = temp.Clone();
        }
        //Update trang thai va update status cua Info_Of_Field
        public void ActionWhenBtnBatDauSuDungClicked()
        {
            IsBtnBatDauSudungEnable = false;
            IsBtnTamDungSuDungEnable = true;
            IsInforFieldEnable = true;
            IsBtnInphieuEnable = true;
            IsBtnHuyInPhieuEnable = false;
            IsBtnThuTienEnable = false;
            IsBtnDoiSanEnable = true;
            IsBtnHuySanEnable = true;
            SelectedItem.TrangThaiSan = DangDuocSuDungContent;
            TinhTrang = SelectedItem.TrangThaiSan;
            ContentOfBtnPause = TamDungSuDungContent;
            UpdateCollection();
        }

        /// <summary>
        /// Update Information of LoaiSan and SelectedItem
        /// </summary>
        public void UpdateCollection()
        {
            int tempSelectedItem = SelectedItem.HoatDongCuaSan.San.BaseObject.IdObject;
            var listDanhSach = new ObservableCollection<HoatDongHienTaiModel>();
            if (SelectedItem.HoatDongCuaSan.San.IdLoaiSan == 0)
            {
                for (int i = 0; i < DanhSachSan5.Count; i++)
                {
                    listDanhSach.Add(DanhSachSan5[i].Clone());
                }
                DanhSachSan5 = listDanhSach;
                //SelectedItem = DanhSachSan5[tempSelectedItem];
                SelectedItem = DanhSachSan5.Where(item => item.HoatDongCuaSan.San.BaseObject.IdObject == tempSelectedItem).Single();
            }
            else if (SelectedItem.HoatDongCuaSan.San.IdLoaiSan == 1)
            {
                for (int i = 0; i < DanhSachSan7.Count; i++)
                {
                    listDanhSach.Add(DanhSachSan7[i].Clone());
                }
                DanhSachSan7 = listDanhSach;
                SelectedItem = DanhSachSan7.Where(item => item.HoatDongCuaSan.San.BaseObject.IdObject == tempSelectedItem).Single();
            }
            else if (SelectedItem.HoatDongCuaSan.San.IdLoaiSan == 2)
            {
                for (int i = 0; i < DanhSachSan11.Count; i++)
                {
                    listDanhSach.Add(DanhSachSan11[i].Clone());
                }
                DanhSachSan11 = listDanhSach;
                SelectedItem = DanhSachSan11.Where(item => item.HoatDongCuaSan.San.BaseObject.IdObject == tempSelectedItem).Single();
            }
            else
            {
                for (int i = 0; i < DanhSachSanOther.Count; i++)
                {
                    listDanhSach.Add(DanhSachSanOther[i].Clone());
                }
                DanhSachSanOther = listDanhSach;
                SelectedItem = DanhSachSanOther.Where(item => item.HoatDongCuaSan.San.BaseObject.IdObject == tempSelectedItem).Single();
            }
            Database_HoatDongHienTai.UpdateItem(SelectedItem);
        }
        //Update trang thai va Update status cua nhung btn sau
        //Status cua Info_Of_Field
        public void ActionWhenBtnTamDungSuDungClicked()
        {
            IsBtnBatDauSudungEnable = false;
            IsBtnTamDungSuDungEnable = true;
            if (SelectedItem.TrangThaiSan == DangDuocSuDungContent)
            {
                //Tam dung hoat dong
                IsInforFieldEnable = false;
                IsBtnInphieuEnable = true;
                IsBtnHuyInPhieuEnable = false;
                IsBtnThuTienEnable = false;
                IsBtnDoiSanEnable = false;
                IsBtnHuySanEnable = true;
                SelectedItem.TrangThaiSan = TamDungSuDungContent;
                TinhTrang = SelectedItem.TrangThaiSan;
                ContentOfBtnPause = TiepTucSuDungContent;
            }
            else
            {
                //Tiep tuc hoat dong
                IsInforFieldEnable = true;
                IsBtnInphieuEnable = true;
                IsBtnHuyInPhieuEnable = false;
                IsBtnThuTienEnable = true;
                IsBtnDoiSanEnable = true;
                IsBtnHuySanEnable = true;
                SelectedItem.TrangThaiSan = DangDuocSuDungContent;
                TinhTrang = SelectedItem.TrangThaiSan;
                ContentOfBtnPause = TamDungSuDungContent;
            }
            UpdateCollection();

        }

        //Add item vao InPhieu_Db
        //Update trang thai
        public void ActionWhenBtnInPhieuClicked()
        {
            IsBtnBatDauSudungEnable = false;
            IsBtnTamDungSuDungEnable = false;
            IsInforFieldEnable = false;
            IsBtnInphieuEnable = false;
            IsBtnHuyInPhieuEnable = true;
            IsBtnThuTienEnable = true;
            IsBtnDoiSanEnable = false;
            IsBtnHuySanEnable = false;
            SelectedItem.TrangThaiSan = DaXuatHoaDonContent;
            TinhTrang = SelectedItem.TrangThaiSan;
            ContentOfBtnPause = "";
            UpdateCollection();
        }

        //Clear thong tin trong InPhieu_Db
        //Update lai trang thai
        public void ActionWhenBtnHuyInPhieuClicked()
        {
            IsBtnBatDauSudungEnable = false;
            IsBtnTamDungSuDungEnable = true;
            IsInforFieldEnable = true;
            IsBtnInphieuEnable = true;
            IsBtnHuyInPhieuEnable = false;
            IsBtnThuTienEnable = false;
            IsBtnDoiSanEnable = true;
            IsBtnHuySanEnable = true;
            SelectedItem.TrangThaiSan = DangDuocSuDungContent;
            TinhTrang = SelectedItem.TrangThaiSan;
            ContentOfBtnPause = TamDungSuDungContent;
            UpdateCollection();
        }

        //Add thong tin cua Selected item vao HoaDon_Db
        //Clear thong tin cua san roi update vao lai Hoatdong_HienTai
        //Update lai trang thai thanh co the su dung
        public void ActionWhenBtnThuTienClicked()
        {
            IsBtnBatDauSudungEnable = true;
            IsBtnTamDungSuDungEnable = false;
            IsInforFieldEnable = false;
            IsBtnInphieuEnable = false;
            IsBtnHuyInPhieuEnable = false;
            IsBtnThuTienEnable = false;
            IsBtnDoiSanEnable = false;
            IsBtnHuySanEnable = false;
            SelectedItem.TrangThaiSan = SanSangSuDungContent;
            TinhTrang = SelectedItem.TrangThaiSan;
            ContentOfBtnPause = "";

            // Add Record to HoaDon
            var tempItemHoaDon = SelectedItem.HoatDongCuaSan.Clone();
            Database_HoaDon.Add(tempItemHoaDon);

            // Add danh sach nuoc uong to HoaDon
            //San co Add nuoc uong
            if(DanhSachNuocUongItem.Count() >= 1)
            {
                foreach(var item in DanhSachNuocUongItem)
                {
                    Database_NuocUongHoaDon.Add(item);
                }
            }

            //Clear Information of SelectedItem and update Item
            HoatDongHienTaiModel tempSelectedItem = new HoatDongHienTaiModel();
            tempSelectedItem.HoatDongCuaSan.San = SelectedItem.HoatDongCuaSan.San.Clone();
            tempSelectedItem.TrangThaiSan = SanSangSuDungContent;
            Database_HoatDongHienTai.UpdateItem(tempSelectedItem);

            // Update danh sach Nuoc uong HienTai
            Database_NuocUongHienTai.RemoveByIdSan(tempSelectedItem);

            //Get to update info
            DanhSachHoatDongHienTai = Database_HoatDongHienTai.GetWithCondition();
            DanhSachNuocUongHienTai = GetDatabase_NuocUongHienTai();

            UpdateCollection();
        }

        //Clear thong tin cua san do
        //Update lai trang thai thanh co the su dung
        public void ActionWhenBtnHuySanClicked()
        {
            IsBtnBatDauSudungEnable = true;
            IsBtnTamDungSuDungEnable = false;
            IsInforFieldEnable = false;
            IsBtnInphieuEnable = false;
            IsBtnHuyInPhieuEnable = false;
            IsBtnThuTienEnable = false;
            IsBtnDoiSanEnable = false;
            IsBtnHuySanEnable = false;

            Database_NuocUongHienTai.RemoveByIdSan(SelectedItem);
            DanhSachNuocUongHienTai = GetDatabase_NuocUongHienTai();

            SelectedItem.TrangThaiSan = SanSangSuDungContent;
            SelectedItem.HoatDongCuaSan.GioVaoSan = new DateTime_Model();
            SelectedItem.HoatDongCuaSan.GioKetThuc = new DateTime_Model();
            SelectedItem.HoatDongCuaSan.KhachHang = new KhachHangObject_Model();
            SelectedItem.HoatDongCuaSan.GhiChu = string.Empty;
            SelectedItem.HoatDongCuaSan.SoGioThue = 0;
            SelectedItem.HoatDongCuaSan.TongTien = 0;
            SelectedItem.HoatDongCuaSan.TienKhachDua = 0;
            SelectedItem.HoatDongCuaSan.TienThoi = 0;
            TinhTrang = SelectedItem.TrangThaiSan;
            ContentOfBtnPause = "";
            UpdateCollection();
        }
        #endregion Method of Command
        #endregion Command

    }
}
