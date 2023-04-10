using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.ViewModel
{
    public class NuocUongObject : BaseObjectSingle
    {
        private string _GiaTien;
        public string GiaTien
        {
            get => _GiaTien;
            set
            {
                if(_GiaTien != value)
                {
                    _GiaTien = value;
                    OnPropertyChanged(nameof(GiaTien));
                }
            }
        }
    }
    public partial class NuocUong_ViewModel : BaseViewModel
    {
        #region Selected Item
        private NuocUongObject _SelectedItem;
        public NuocUongObject SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new NuocUongObject();
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

        #region Method when Selected Item
        /// <summary>
        /// Update value when select an item
        /// </summary>
        public void ActionWhenChangeItem()
        {
            Id = SelectedItem.Id.ToString();
            TenItem = SelectedItem.TenObject;
            TrangThaiItem = SelectedItem.TrangThaiObject;
            GiaTienItem = SelectedItem.GiaTien;
            IsButtonModifyEnable = true;
            IsButtonSaveEnable = false;
        }
        #endregion Method when Selected Item
        #endregion

        private ObservableCollection<NuocUongObject> _DanhSachNuocUong;

        public ObservableCollection<NuocUongObject> DanhSach_NuocUong
        {
            get
            {
                if (_DanhSachNuocUong == null)
                {
                    _DanhSachNuocUong = new ObservableCollection<NuocUongObject>();
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
            //Dummy Data
            NuocUongObject item = new NuocUongObject();
            item.TenObject = "sting";
            item.Id = 0;
            item.TrangThaiObject = "Hoạt động";
            item.GiaTien = "10.000";
            DanhSach_NuocUong.Add(item);
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
            if (SelectedItem.TrangThaiObject == _HoatDong)
            {
                SelectedItem.TrangThaiObject = _KhongHoatDong;
            }
            else
            {
                SelectedItem.TrangThaiObject = _HoatDong;
            }
            TrangThaiItem = SelectedItem.TrangThaiObject;
        }
        public override void ActionWhenBtnSaveClicked()
        {
            if (TenItem != string.Empty && TenItem.Length > 0 & GiaTienItem.Length > 1000)
            {
                NuocUongObject temp = new NuocUongObject();
                temp.TenObject = TenItem;
                temp.Id = Convert.ToInt32(Id);
                temp.TrangThaiObject = TrangThaiItem;
                temp.GiaTien = GiaTienItem;
                DanhSach_NuocUong.Add(temp);
                IsButtonSaveEnable = false;
                IsButtonModifyEnable = true;
                IsTextboxEnable = false;
                SelectedItem = DanhSach_NuocUong[0];
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
