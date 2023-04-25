using KLTN.Model;
using KLTN.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.ViewModel
{
    public partial class KhachHang_ViewModel : BaseViewModel
    {
        #region Selected Item
        private KhachHangObject_Model _SelectedItem;
        public KhachHangObject_Model SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new KhachHangObject_Model();
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
        private string _Sdt;
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
        public string SdtItem
        {
            get => _Sdt;
            set
            {
                if (_Sdt != value)
                {
                    _Sdt = value;
                    OnPropertyChanged(nameof(SdtItem));
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
            Id = SelectedItem.BaseObject.IdObject.ToString();
            TenItem = SelectedItem.BaseObject.TenObject;
            TrangThaiItem = SelectedItem.BaseObject.TrangThaiObject;
            SdtItem = SelectedItem.SdtObject;
            IsButtonSaveEnable = false;
            IsButtonModifyEnable = true;
        }
        #endregion Method when Selected Item
        #endregion

        private ObservableCollection<KhachHangObject_Model> _DanhSachKhachHang;

        public ObservableCollection<KhachHangObject_Model> DanhSach_KhachHang
        {
            get
            {
                if (_DanhSachKhachHang == null)
                {
                    _DanhSachKhachHang = new ObservableCollection<KhachHangObject_Model>();
                    GetDataFromDatabase();
                }
                return _DanhSachKhachHang;
            }
            set
            {
                if (_DanhSachKhachHang != value)
                {
                    _DanhSachKhachHang = value;
                    OnPropertyChanged(nameof(DanhSach_KhachHang));
                }
            }
        }

        KhachHang_Service TheDatabase_KhachHang;
        public KhachHang_ViewModel()
        {
            TheDatabase_KhachHang = new KhachHang_Service();

        }
        #region Method
        public override void GetDataFromDatabase()
        {
            DanhSach_KhachHang = TheDatabase_KhachHang.GetAll();
        }

        public override void ActionWhenBtnAddClicked()
        {
            //Clear all information in textbox
            TenItem = "";
            TrangThaiItem = "Hoạt động";
            SdtItem = "";

            //Get last item in DanhSach_LoaiSan
            if (DanhSach_KhachHang.Count > 0)
            {
                Id = DanhSach_KhachHang.Count().ToString();
            }
            else
            {
                Id = "0";
            }
            IsButtonAddEnable = false;
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
            var tempList = new ObservableCollection<KhachHangObject_Model>();
            for (int i = 0; i < DanhSach_KhachHang.Count; i++)
            {
                tempList.Add(DanhSach_KhachHang[i].Clone());
            }
            DanhSach_KhachHang = tempList;
            TheDatabase_KhachHang.Update(SelectedItem);
            TrangThaiItem = SelectedItem.BaseObject.TrangThaiObject;
        }
        public override void ActionWhenBtnSaveClicked()
        {
            if (TenItem != string.Empty && TenItem.Length > 0 & SdtItem.Length > 9)
            {
                KhachHangObject_Model temp = new KhachHangObject_Model();
                temp.BaseObject.TenObject = TenItem;
                temp.BaseObject.IdObject = Convert.ToInt32(Id);
                temp.BaseObject.TrangThaiObject = TrangThaiItem;
                temp.SdtObject = SdtItem;
                DanhSach_KhachHang.Add(temp);
                //Save to database
                TheDatabase_KhachHang.Add(temp);
                IsButtonSaveEnable = false;
                IsButtonModifyEnable = true;
                IsTextboxEnable = false;
                SelectedItem = DanhSach_KhachHang[0];
            }
        }
        #endregion Method
    }

    public partial class KhachHang_ViewModel : BaseViewModel
    {
        #region Danh Sách 
        public string DanhSachLabel => "Danh sách khách hàng";
        public string CotTenLabel => "Tên khách hàng";
        public string TrangThaiLabel => "Trạng Thái";
        public string CotDienThoaiLabel => "Số điện thoại";

        #endregion Danh sách

        #region Thông tin Item
        public string ThongTinLabel => "Thông tin khách hàng:";
        public string TenItemLabel => "Tên khách hàng";
        public string IdLabel => "Id khách hàng";

        #endregion Thông tin Item
    }
}
