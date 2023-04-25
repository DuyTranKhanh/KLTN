using System.Windows.Input;
using System.Linq;
using KLTN.Service;
using System.Collections.ObjectModel;
using KLTN.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;

namespace KLTN.ViewModel
{
    public partial class BangGia_ViewModel : BaseViewModel
    {
        #region Selected Item
        private BangGiaObject_Model _SelectedItem;
        public BangGiaObject_Model SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new BangGiaObject_Model();
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
        private string _NgayApDungItem;
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
        public string NgayApDungItem
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
            IdItem = SelectedItem.BaseObject.IdObject.ToString();
            TenItem = SelectedItem.BaseObject.TenObject;
            TrangThaiItem = SelectedItem.BaseObject.TrangThaiObject;
            NgayApDungItem = SelectedItem.NgayTao;
            ThoiGianKetThucItem = SelectedItem.ThoiGianBatDau.ToString();
            ThoiGianBatDauItem = SelectedItem.ThoiGianKetThuc.ToString();
            GiaTienItem = SelectedItem.GiaTienObject.ToString();
            IsButtonModifyEnable = true;
            IsButtonSaveEnable = false;
        }
        #endregion Method when Selected Item

        #endregion Selected Item

        private ObservableCollection<BangGiaObject_Model> _DanhSach_BangGia;

        public ObservableCollection<BangGiaObject_Model> DanhSach_BangGia
        {
            get
            {
                if (_DanhSach_BangGia == null)
                {
                    _DanhSach_BangGia = new ObservableCollection<BangGiaObject_Model>();
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

            var listOfLoaiSan = _LoaiSanDatabase.GetAll();
            for(int i= 0; i < listOfLoaiSan.Count; i++)
            {
                temp.Add(i, listOfLoaiSan[i].BaseObject.TenObject);
            }

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

        #region Service
        BangGia_Service TheDatabase;
        LoaiSan_Service _LoaiSanDatabase;
        #endregion Service

        #region Constructor
        public BangGia_ViewModel()
        {
            TheDatabase = new BangGia_Service();
            _LoaiSanDatabase = new LoaiSan_Service();
        }
        #endregion
        #region Method
        public override void GetDataFromDatabase()
        {
            //Function Get data
            DanhSach_BangGia = TheDatabase.GetAll();
        }

        public override void ActionWhenBtnAddClicked()
        {
            //Clear all information in textbox
            TenItem = "";
            GiaTienItem = "";
            TrangThaiItem = _HoatDong;
            NgayApDungItem = DateTime.Today.Date.ToString();
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
            if (SelectedItem.BaseObject.TrangThaiObject == _HoatDong)
            {
                SelectedItem.BaseObject.TrangThaiObject = _KhongHoatDong;
            }
            else
            {
                SelectedItem.BaseObject.TrangThaiObject = _HoatDong;
            }
            TheDatabase.UpdateItem(SelectedItem);
            TrangThaiItem = SelectedItem.BaseObject.TrangThaiObject;
            var tempList = new ObservableCollection<BangGiaObject_Model>();
            for (int i = 0; i < DanhSach_BangGia.Count; i++)
            {
                tempList.Add(DanhSach_BangGia[i].Clone());
            }
            DanhSach_BangGia = tempList;
            //TenItem = SelectedItem.BaseObject.TenObject;
            //ThoiGianBatDauItem = SelectedItem.ThoiGianBatDau.ToString();
            //ThoiGianKetThucItem = SelectedItem.ThoiGianKetThuc.ToString();
        }
        public override void ActionWhenBtnSaveClicked()
        {
            try
            {
                if (Convert.ToInt32(GiaTienItem) > 1000)
                {
                    BangGiaObject_Model temp = new BangGiaObject_Model();
                    temp.BaseObject.TenObject = TenItem;
                    temp.BaseObject.IdObject = Convert.ToInt32(IdItem);
                    temp.BaseObject.TrangThaiObject = TrangThaiItem;
                    temp.NgayTao = NgayApDungItem;
                    temp.ThoiGianBatDau = (ThoiGianBatDauItem);
                    temp.ThoiGianKetThuc = (ThoiGianKetThucItem);
                    temp.GiaTienObject = Convert.ToInt32(GiaTienItem);
                    DanhSach_BangGia.Add(temp);
                    IsButtonSaveEnable = false;
                    IsTextboxEnable = true;
                    IsButtonModifyEnable = true;
                    SelectedItem = DanhSach_BangGia[0];
                    TheDatabase.Add(temp);
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
