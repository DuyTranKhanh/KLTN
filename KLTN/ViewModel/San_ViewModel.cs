using System.Collections.ObjectModel;
using KLTN.Model;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;
using KLTN.Service;

namespace KLTN.ViewModel
{
    public partial class San_ViewModel : BaseViewModel
    {
        #region Selected Item
        private SanObject_Model _SelectedItem;
        public SanObject_Model SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new SanObject_Model();
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
        private string _TenLoaiSanItem;
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

        public string TenLoaiSanItem
        {
            get => _TenLoaiSanItem;
            set
            {
                if(_TenLoaiSanItem != value)
                {
                    _TenLoaiSanItem = value;
                    OnPropertyChanged(nameof(TenLoaiSanItem));
                }    
            }
        }
        #endregion Properties of selected item

        San_Service Database;
        LoaiSan_Service LoaiSan_Database;
        HoatDongHienTai_Service HoatDongHienTai_Database;
        public San_ViewModel()
        {
            Database = new San_Service();
            LoaiSan_Database = new LoaiSan_Service();
            HoatDongHienTai_Database = new HoatDongHienTai_Service();
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
            TenLoaiSanItem = SelectedItem.TenLoaiSan;
            IsButtonModifyEnable = true;
            IsButtonSaveEnable = false;
        }
        #endregion Method when Selected Item
        #endregion

        private ObservableCollection<SanObject_Model> _DanhSach_San;

        public ObservableCollection<SanObject_Model> DanhSach_San
        {
            get
            {
                if (_DanhSach_San == null)
                {
                    _DanhSach_San = new ObservableCollection<SanObject_Model>();
                    GetDataFromDatabase();
                }
                return _DanhSach_San;
            }
            set
            {
                if (_DanhSach_San != value)
                {
                    _DanhSach_San = value;
                    OnPropertyChanged(nameof(DanhSach_San));
                }
            }
        }

        #region Method
        public override void GetDataFromDatabase()
        {
            DanhSach_San = Database.GetAll();
        }

        public override void ActionWhenBtnAddClicked()
        {
            //Clear all information in textbox
            TenItem = "";
            TenLoaiSanItem = "";
            TrangThaiItem = "Hoạt động";

            //Get last item in DanhSach_LoaiSan
            if (DanhSach_San.Count > 0)
            {
                Id = DanhSach_San.Count().ToString();
            }
            else
            {
                Id = "0";
            }
            IsButtonSaveEnable = true;
            IsButtonModifyEnable = false;
            IsTextboxEnable = true;
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
            if (TenItem != string.Empty && TenItem.Length > 0)
            {
                SanObject_Model temp = new SanObject_Model();
                temp.BaseObject.TenObject = TenItem;
                temp.TenLoaiSan = TenLoaiSanItem;
                temp.BaseObject.IdObject = Convert.ToInt32(Id);
                temp.BaseObject.TrangThaiObject = TrangThaiItem;
                DanhSach_San.Add(temp);
                IsButtonSaveEnable = false;
                IsButtonModifyEnable = true;
                IsTextboxEnable = false;
                SelectedItem = DanhSach_San[0];
                Database.Add(temp);
                HoatDongHienTaiModel item = new HoatDongHienTaiModel();
                item.TrangThaiSan = "Sẵn sàng sử dụng";
                item.HoatDongCuaSan.San = temp.Clone();
                HoatDongHienTai_Database.Add(item);
            }
        }
        #endregion Method

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
            DanhSach_LoaiSan = GetDataForComboboxLoaiSan();
        }
        #endregion

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
            var listLoaiSan = LoaiSan_Database.GetAll();
            for(int i = 0; i < listLoaiSan.Count; i++)
            {
                temp.Add(i, listLoaiSan[i].BaseObject.TenObject);
            }
            return temp;
        }
        #endregion Combobox and Trigger
    }

    /// <summary>
    /// Class for Language
    /// </summary>
    public partial class San_ViewModel : BaseViewModel
    {

        #region Danh Sách 
        public string DanhSachLabel => "Danh sách sân";
        public string CotTenLabel => "Tên sân";
        public string LoaiSanLabel => "Loại Sân";
        public string TrangThaiLabel => "Trạng Thái";

        #endregion Danh sách

        #region Thông tin Item
        public string ThongTinLabel => "Thông tin sân";
        public string TenItemLabel => "Tên Sân";
        public string IdLabel => "Id Sân";
        
        #endregion Thông tin Item

    }
}
