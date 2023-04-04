using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.ViewModel
{
    public class KhachHangObject : BaseObjectSingle
    {
        private string _Sdt;
        public string Sdt
        {
            get => _Sdt;
            set
            {
                if(_Sdt != value)
                {
                    _Sdt = value;
                    OnPropertyChanged(nameof(Sdt));
                }
            }
        }
    }
    public partial class KhachHang_ViewModel : BaseViewModel
    {
        #region Selected Item
        private KhachHangObject _SelectedItem;
        public KhachHangObject SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new KhachHangObject();
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
            Id = SelectedItem.Id.ToString();
            TenItem = SelectedItem.TenObject;
            TrangThaiItem = SelectedItem.TrangThaiObject;
            SdtItem = SelectedItem.Sdt;
            IsButtonModifyEnable = true;
        }
        #endregion Method when Selected Item
        #endregion

        private ObservableCollection<KhachHangObject> _DanhSachKhachHang;

        public ObservableCollection<KhachHangObject> DanhSach_KhachHang
        {
            get
            {
                if (_DanhSachKhachHang == null)
                {
                    _DanhSachKhachHang = new ObservableCollection<KhachHangObject>();
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

        #region Method
        public override void GetDataFromDatabase()
        {
            //Dummy Data
            KhachHangObject item = new KhachHangObject();
            item.TenObject = "Khách vãng lai";
            item.Id = 0;
            item.TrangThaiObject = "Hoạt động";
            item.Sdt = "0123456789";
            DanhSach_KhachHang.Add(item);
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
        }
        public override void ActionWhenBtnSaveClicked()
        {
            if (TenItem != string.Empty && TenItem.Length > 0 & SdtItem.Length > 9)
            {
                KhachHangObject temp = new KhachHangObject();
                temp.TenObject = TenItem;
                temp.Id = Convert.ToInt32(Id);
                temp.TrangThaiObject = TrangThaiItem;
                temp.Sdt = SdtItem;
                DanhSach_KhachHang.Add(temp);
                IsButtonSaveEnable = false;
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
