using KLTN.Model;
using System;
using KLTN.Service;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.ViewModel
{
    public partial class NuocUong_ViewModel : BaseViewModel
    {
        #region Selected Item
        private NuocUongObject_Model _SelectedItem;
        public NuocUongObject_Model SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new NuocUongObject_Model();
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
        private string _GiaTienItem;
        #endregion Dummy Fields

        #region Properties of selected item
        /// <summary>
        /// Get set value of Id
        /// </summary>
        public string Id
        {
            get => _Id;
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    OnPropertyChanged(nameof(Id));
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

        /// <summary>
        /// Get set value of Sdt
        /// </summary>
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
        #endregion Properties of selected item

        NuocUong_Service Database;
        public NuocUong_ViewModel()
        {
            Database = new NuocUong_Service();
        }
        #region Method when Selected Item
        /// <summary>
        /// Update value when select an item
        /// </summary>
        public void ActionWhenChangeItem()
        {
            Id = SelectedItem.BaseObject.IdObject.ToString();
            TenItem = SelectedItem.BaseObject.TenObject;
            TrangThaiItem = SelectedItem.BaseObject.TrangThaiObject;
            GiaTienItem = SelectedItem.GiaTienObject;
            IsButtonModifyEnable = true;
            IsButtonSaveEnable = false;
        }
        #endregion Method when Selected Item
        #endregion

        private ObservableCollection<NuocUongObject_Model> _DanhSachNuocUong;

        public ObservableCollection<NuocUongObject_Model> DanhSach_NuocUong
        {
            get
            {
                if (_DanhSachNuocUong == null)
                {
                    _DanhSachNuocUong = new ObservableCollection<NuocUongObject_Model>();
                    GetDataFromDatabase();
                }
                return _DanhSachNuocUong;
            }
            set
            {
                if (_DanhSachNuocUong != value)
                {
                    _DanhSachNuocUong = value;
                    OnPropertyChanged(nameof(DanhSach_NuocUong));
                }
            }
        }

        #region Method
        public override void GetDataFromDatabase()
        {
            DanhSach_NuocUong = Database.GetAll();
        }

        public override void ActionWhenBtnAddClicked()
        {
            //Clear all information in textbox
            TenItem = "";
            TrangThaiItem = "Hoạt động";
            GiaTienItem = "";

            //Get last item in DanhSach_LoaiSan
            if (DanhSach_NuocUong.Count > 0)
            {
                Id = DanhSach_NuocUong.Count().ToString();
            }
            else
            {
                Id = "0";
            }
            IsButtonSaveEnable = true;
            IsTextboxEnable = true;
            IsButtonModifyEnable = false;
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
            TrangThaiItem = SelectedItem.BaseObject.TrangThaiObject;
            Database.UpdateItem(SelectedItem);
        }
        public override void ActionWhenBtnSaveClicked()
        {
            if (TenItem != string.Empty && TenItem.Length > 0 & Convert.ToInt32(GiaTienItem) > 1000)
            {
                NuocUongObject_Model temp = new NuocUongObject_Model();
                temp.BaseObject.TenObject = TenItem;
                temp.BaseObject.IdObject = Convert.ToInt32(Id);
                temp.BaseObject.TrangThaiObject = TrangThaiItem;
                temp.GiaTienObject = GiaTienItem;
                DanhSach_NuocUong.Add(temp);
                IsButtonSaveEnable = false;
                IsButtonModifyEnable = true;
                IsTextboxEnable = false;
                SelectedItem = DanhSach_NuocUong[0];
                Database.Add(temp);
            }
        }
        #endregion Method
    }

    public partial class NuocUong_ViewModel : BaseViewModel
    {
        #region Danh Sách 
        public string DanhSachLabel => "Danh sách sản phẩm";
        public string CotTenLabel => "Tên sản phẩm";
        public string TrangThaiLabel => "Trạng Thái";
        public string CotGiaTienLabel => "Giá tiền";

        #endregion Danh sách

        #region Thông tin Item
        public string ThongTinLabel => "Thông tin sản phẩm";
        public string TenItemLabel => "Tên sản phẩm";
        public string IdLabel => "Id sản phẩm";

        #endregion Thông tin Item
    }
}
