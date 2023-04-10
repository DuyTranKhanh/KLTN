using System.Windows.Input;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using KLTN.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;

namespace KLTN.ViewModel
{
    public class BangGiaObject : BaseObjectSingle
    {
        private DateTime _NgayApDungObject;
        private int _ThoiGianBatDauObject;
        private int _ThoiGianKetThucObject;
        private int _GiaTienObject;
        #region Properties
        public DateTime NgayApDungObject
        {
            get => _NgayApDungObject;
            set
            {
                if (_NgayApDungObject != value)
                {
                    _NgayApDungObject = value;
                    OnPropertyChanged(nameof(NgayApDungObject));
                }
            }
        }
        public int ThoiGianBatDauObject
        {
            get => _ThoiGianBatDauObject;
            set
            {
                if (_ThoiGianBatDauObject != value)
                {
                    _ThoiGianBatDauObject = value;
                    OnPropertyChanged(nameof(ThoiGianBatDauObject));
                }
            }
        }
        public int ThoiGianKetThucObject
        {
            get => _ThoiGianKetThucObject;
            set
            {
                if (_ThoiGianKetThucObject != value)
                {
                    _ThoiGianKetThucObject = value;
                    OnPropertyChanged(nameof(ThoiGianKetThucObject));
                }
            }
        }
        public int GiaTienObject
        {
            get => _GiaTienObject;
            set
            {
                if (_GiaTienObject != value)
                {
                    _GiaTienObject = value;
                    OnPropertyChanged(nameof(GiaTienObject));
                }
            }
        }
        #endregion Properties
    }
    public partial class BangGia_ViewModel : BaseViewModel
    {
        #region Selected Item
        private BangGiaObject _SelectedItem;
        public BangGiaObject SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new BangGiaObject();
                }
                return _SelectedItem;
            }
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    ActionWhenChangeItem();
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        #region Dummy Fields
        private string _Id;
        private string _TenItem;
        private string _TrangThaiItem;
        private DateTime _NgayApDungItem;
        private string _ThoiGianBatDauItem;
        private string _ThoiGianKetThucItem;
        private string _GiaTienItem;
        private string _TenLoaiSanItem;
        #endregion Dummy Fields

        #region Properties
        /// <summary>
        /// Get set value of Id
        /// </summary>
        public string IdItem
        {
            get => _Id;
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    OnPropertyChanged(nameof(IdItem));
                }
            }
        }

        /// <summary>
        /// Get set value of TenItem
        /// </summary>
        public string TenItem
        {
            get => _TenItem;
            set
            {
                if (_TenItem != value)
                {
                    _TenItem = value;
                    OnPropertyChanged(nameof(TenItem));
                }
            }
        }

        /// <summary>
        /// Get set value of TrangThaiItem
        /// </summary>
        public string TrangThaiItem
        {
            get => _TrangThaiItem;
            set
            {
                if (_TrangThaiItem != value)
                {
                    _TrangThaiItem = value;
                    OnPropertyChanged(nameof(TrangThaiItem));
                }
            }
        }
        public DateTime NgayApDungItem
        {
            get => _NgayApDungItem;
            set
            {
                if (_NgayApDungItem != value)
                {
                    _NgayApDungItem = value;
                    OnPropertyChanged(nameof(NgayApDungItem));
                }
            }
        }
        public string ThoiGianBatDauItem
        {
            get => _ThoiGianBatDauItem;
            set
            {
                if (_ThoiGianBatDauItem != value)
                {
                    _ThoiGianBatDauItem = value;
                    OnPropertyChanged(nameof(ThoiGianBatDauItem));
                }
            }
        }
        public string ThoiGianKetThucItem
        {
            get => _ThoiGianKetThucItem;
            set
            {
                if (_ThoiGianKetThucItem != value)
                {
                    _ThoiGianKetThucItem = value;
                    OnPropertyChanged(nameof(ThoiGianKetThucItem));
                }
            }
        }
        public string GiaTienItem
        {
            get => _GiaTienItem;
            set
            {
                if (_GiaTienItem != value)
                {
                    _GiaTienItem = value;
                    OnPropertyChanged(nameof(GiaTienItem));
                }
            }
        }
        public string TenLoaiSanItem
        {
            get => _TenLoaiSanItem;
            set
            {
                if (_TenLoaiSanItem != value)
                {
                    _TenLoaiSanItem = value;
                    OnPropertyChanged(nameof(TenLoaiSanItem));
                }
            }
        }

        #endregion Properties

        #region Method when Selected Item
        /// <summary>
        /// Update value when select an item
        /// </summary>
        public void ActionWhenChangeItem()
        {
            IdItem = SelectedItem.Id.ToString();
            TenItem = SelectedItem.TenObject;
            TrangThaiItem = SelectedItem.TrangThaiObject;
            NgayApDungItem = SelectedItem.NgayApDungObject;
            ThoiGianKetThucItem = SelectedItem.ThoiGianKetThucObject.ToString();
            ThoiGianBatDauItem = SelectedItem.ThoiGianBatDauObject.ToString();
            GiaTienItem = SelectedItem.GiaTienObject.ToString();
            IsButtonModifyEnable = true;
            IsButtonSaveEnable = false;
        }
        #endregion Method when Selected Item

        #endregion Selected Item

        private ObservableCollection<BangGiaObject> _DanhSach_BangGia;

        public ObservableCollection<BangGiaObject> DanhSach_BangGia
        {
            get
            {
                if (_DanhSach_BangGia == null)
                {
                    _DanhSach_BangGia = new ObservableCollection<BangGiaObject>();
                    GetDataFromDatabase();
                }
                return _DanhSach_BangGia;
            }
            set
            {
                if (_DanhSach_BangGia != value)
                {
                    _DanhSach_BangGia = value;
                    OnPropertyChanged(nameof(DanhSach_BangGia));
                }
            }
        }

        #region Combobox and Trigger
        private Dictionary<int, string> _DanhSach_LoaiSan;

        public Dictionary<int, string> DanhSach_LoaiSan
        {
            get
            {
                if (_DanhSach_LoaiSan == null)
                {
                    _DanhSach_LoaiSan = new Dictionary<int, string>();
                    _DanhSach_LoaiSan = GetDataForComboboxLoaiSan();
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

        /// <summary>
        /// Get data from Db to LoaiSanCbb
        /// </summary>
        public Dictionary<int, string> GetDataForComboboxLoaiSan()
        {
            //Get List Data of LoaiSan from Db.
            Dictionary<int, string> temp = new Dictionary<int, string>();
            temp.Add(0, "Sân 5");
            temp.Add(1, "Sân 7");
            temp.Add(2, "Sân 11");
            temp.Add(3, "Sân khác");
            return temp;
        }
        #endregion Combobox and Trigger

        #region Command
        private ICommand _ReloadCommand;
        public ICommand ReloadCommand
        {
            get
            {
                if (_ReloadCommand == null)
                {
                    _ReloadCommand = new RelayCommand(ActionWhenBtnReloadClicked, CanExecute);
                }
                return _ReloadCommand;
            }
        }

        void ActionWhenBtnReloadClicked()
        {
            DanhSach_LoaiSan = new Dictionary<int, string>();
            DanhSach_LoaiSan.Add(0, "Sân 5");
            DanhSach_LoaiSan.Add(1, "Sân 7");
            DanhSach_LoaiSan.Add(2, "Sân 11");
            DanhSach_LoaiSan.Add(3, "Sân khác");
        }
        #endregion

        #region Method
        public override void GetDataFromDatabase()
        {
            //Function Get data
            //Dummy Data
            BangGiaObject item = new BangGiaObject();
            item.TenObject = "Sân 5";
            item.Id = 0;
            item.TrangThaiObject = "Hoạt động";
            item.NgayApDungObject = DateTime.Today.Date;
            item.ThoiGianBatDauObject = 6;
            item.ThoiGianKetThucObject = 16;
            item.GiaTienObject = 150000;
            DanhSach_BangGia.Add(item);
        }

        public override void ActionWhenBtnAddClicked()
        {
            //Clear all information in textbox
            TenItem = "";
            GiaTienItem = "";
            TrangThaiItem = "Hoạt động";
            NgayApDungItem = DateTime.Today.Date;
            IsButtonSaveEnable = true;
            IsTextboxEnable = true;
            IsButtonModifyEnable = false;
            //Get last item in DanhSach_LoaiSan
            if (DanhSach_BangGia.Count > 0)
            {
                IdItem = DanhSach_BangGia.Count().ToString();
            }
            else
            {
                IdItem = "0";
            }
            IsButtonSaveEnable = true;
        }

        public override void ActionWhenBtnModifyClicked()
        {
            if (SelectedItem.TrangThaiObject == _HoatDong)
            {
                SelectedItem.TrangThaiObject = _KhongHoatDong;
            }
            else
            {
                SelectedItem.TrangThaiObject = _HoatDong;
            }
            TrangThaiItem = SelectedItem.TrangThaiObject;
            TenItem = SelectedItem.TenObject;
            ThoiGianBatDauItem = SelectedItem.ThoiGianBatDauObject.ToString();
            ThoiGianKetThucItem = SelectedItem.ThoiGianKetThucObject.ToString();
        }
        public override void ActionWhenBtnSaveClicked()
        {
            try
            {
                if (Convert.ToInt32(GiaTienItem) > 1000)
                {
                    BangGiaObject temp = new BangGiaObject();
                    temp.TenObject = TenItem;
                    temp.Id = Convert.ToInt32(IdItem);
                    temp.TrangThaiObject = TrangThaiItem;
                    temp.NgayApDungObject = NgayApDungItem.Date;
                    temp.ThoiGianBatDauObject = Convert.ToInt32(ThoiGianBatDauItem);
                    temp.ThoiGianKetThucObject = Convert.ToInt32(ThoiGianKetThucItem);
                    temp.GiaTienObject = Convert.ToInt32(GiaTienItem);
                    DanhSach_BangGia.Add(temp);
                    IsButtonSaveEnable = false;
                    IsTextboxEnable = true;
                    IsButtonModifyEnable = true;
                    SelectedItem = DanhSach_BangGia[0];
                }
            }
            catch(Exception)
            {
               
            }

        }
        #endregion Method
    }

    public partial class BangGia_ViewModel : BaseViewModel
    {
        #region Danh Sách 
        public string DanhSachLabel => "Danh sách bảng giá";
        public string CotTenLabel => "Loại sân";
        public string TrangThaiLabel => "Trạng Thái";

        #endregion Danh sách

        #region Thông tin Item
        public string ThongTinLabel => "Thông tin bảng giá:";
        public string LoaiSanItemLabel => "Loại sân";
        public string ThoiGianBatDauItemLabel => "Thời gian bắt đầu";
        public string ThoiGianKetThucItemLabel => "Thời gian kết thúc";
        public string NgayApDungItemLabel => "Ngày áp dụng";
        public string DonGiaItemLabel => "Đơn giá (Vnđ/ giờ)";
        public string IdLabel => "Id bảng giá";

        #endregion Thông tin Item
    }
}
