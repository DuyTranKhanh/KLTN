using System.Collections.ObjectModel;
using KLTN.Model;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System;

namespace KLTN.ViewModel
{
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
        #endregion

    }
}
