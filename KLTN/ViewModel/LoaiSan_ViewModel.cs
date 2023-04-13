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
        private LoaiSan_Model _SelectedItem;
        public LoaiSan_Model SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new LoaiSan_Model();
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
            Id = SelectedItem.BaseObject.IdObject.ToString() ;
            TenItem = SelectedItem.BaseObject.TenObject;
            TrangThaiItem = SelectedItem.BaseObject.TrangThaiObject;
            IsButtonModifyEnable = true;
            IsButtonSaveEnable = false;
        }
        #endregion Method when Selected Item
        #endregion

        private ObservableCollection<LoaiSan_Model> _DanhSachLoaiSan;

        public ObservableCollection<LoaiSan_Model> DanhSach_LoaiSan
        {
            get
            {
                if (_DanhSachLoaiSan == null)
                {
                    _DanhSachLoaiSan = new ObservableCollection<LoaiSan_Model>();
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
            IsTextboxEnable = true;
            IsButtonModifyEnable = false;
        }

        public override void ActionWhenBtnModifyClicked()
        {
            if(SelectedItem.BaseObject.TrangThaiObject == _HoatDong)
            {
                SelectedItem.BaseObject.TrangThaiObject = _KhongHoatDong;
            }    
            else
            {
                SelectedItem.BaseObject.TrangThaiObject = _HoatDong;
            }
            TrangThaiItem = SelectedItem.BaseObject.TrangThaiObject;
        }
        public override void ActionWhenBtnSaveClicked()
        {
            if (TenItem != string.Empty && TenItem.Length > 0)
            {
                LoaiSan_Model temp = new LoaiSan_Model();
                temp.BaseObject.TenObject = TenItem;
                temp.BaseObject.IdObject = Convert.ToInt32(Id);
                temp.BaseObject.TrangThaiObject = TrangThaiItem;
                DanhSach_LoaiSan.Add(temp);
                IsButtonSaveEnable = false;
                IsButtonModifyEnable = true;
                IsTextboxEnable = false;
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
