using System.Windows.Input;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using KLTN.Model;
using GalaSoft.MvvmLight.Command;
using System;

namespace KLTN.ViewModel
{
    public partial class LoaiSan_ViewModel : BaseViewModel
    {
        #region Selected Item
        private BaseObjectSingle _SelectedItem;
        public BaseObjectSingle SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new BaseObjectSingle();
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
        #endregion Properties of selected item

        #region Method when Selected Item
        /// <summary>
        /// Update value when select an item
        /// </summary>
        public void ActionWhenChangeItem()
        {
            Id = SelectedItem.Id.ToString() ;
            TenItem = SelectedItem.TenObject;
            TrangThaiItem = SelectedItem.TrangThaiObject;
            IsButtonModifyEnable = true;
        }
        #endregion Method when Selected Item
        #endregion

        private ObservableCollection<BaseObjectSingle> _DanhSachLoaiSan;

        public ObservableCollection<BaseObjectSingle> DanhSach_LoaiSan
        {
            get
            {
                if (_DanhSachLoaiSan == null)
                {
                    _DanhSachLoaiSan = new ObservableCollection<BaseObjectSingle>();
                    GetDataFromDatabase();
                }
                return _DanhSachLoaiSan;
            }
            set
            {
                if (_DanhSachLoaiSan != value)
                {
                    _DanhSachLoaiSan = value;
                    OnPropertyChanged(nameof(DanhSach_LoaiSan));
                }
            }
        }

        #region Method
        public override void GetDataFromDatabase()
        {
            //Dummy Data
            BaseObjectSingle item = new BaseObjectSingle();
            item.TenObject = "San 5";
            item.Id = 0;
            item.TrangThaiObject = "Hoạt động";
            DanhSach_LoaiSan.Add(item);
        }

        public override void ActionWhenBtnAddClicked()
        {
            //Clear all information in textbox
            TenItem = "";
            TrangThaiItem = "Hoạt động";

            //Get last item in DanhSach_LoaiSan
            if(DanhSach_LoaiSan.Count > 0)
            {
                Id = DanhSach_LoaiSan.Count().ToString();
            }   
            else
            {
                Id = "0";
            }
            IsButtonSaveEnable = true;
        }

        public override void ActionWhenBtnModifyClicked()
        {
            if(SelectedItem.TrangThaiObject == _HoatDong)
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
            if (TenItem != string.Empty && TenItem.Length > 0)
            {
                BaseObjectSingle temp = new BaseObjectSingle();
                temp.TenObject = TenItem;
                temp.Id = Convert.ToInt32(Id);
                temp.TrangThaiObject = TrangThaiItem;
                DanhSach_LoaiSan.Add(temp);
                IsButtonSaveEnable = false;
                SelectedItem = DanhSach_LoaiSan[0];
            }
        }
        #endregion Method
    }

    /// <summary>
    /// Class for Language
    /// </summary>
    public partial class LoaiSan_ViewModel : BaseViewModel
    {

        #region Danh Sách 
        public string DanhSachLabel => "Danh sách loại sân";
        public string CotTenLabel => "Tên loại sân";
        public string TrangThaiLabel => "Trạng Thái";

        #endregion Danh sách

        #region Thông tin Item
        public string ThongTinLabel => "Thông tin loại sân";
        public string TenItemLabel => "Tên loại Sân";
        public string IdLabel => "Id Loại Sân";

        #endregion Thông tin Item

    }
}
