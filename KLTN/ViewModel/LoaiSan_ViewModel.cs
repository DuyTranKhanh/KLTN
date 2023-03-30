using System.Windows.Input;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using KLTN.Model;
using GalaSoft.MvvmLight.Command;

namespace KLTN.ViewModel
{
    public class LoaiSan_ViewModel : BaseViewModel
    {
        private ObservableCollection<LoaiSan_Model> danhSach_LoaiSan;
        public ObservableCollection<LoaiSan_Model> DanhSach_LoaiSan
        {
            get
            {
                if(danhSach_LoaiSan == null)
                {
                    danhSach_LoaiSan = new ObservableCollection<LoaiSan_Model>();
                }
                return danhSach_LoaiSan;
            }
            set
            {
                if(danhSach_LoaiSan != value)
                {
                    danhSach_LoaiSan = value;
                    OnPropertyChanged(nameof(DanhSach_LoaiSan));
                }
            }
        }

        private string _TenLoaiSan;
        public string TenLoaiSan
        {
            get => _TenLoaiSan;
            set
            {
                if(_TenLoaiSan != value)
                {
                    _TenLoaiSan = value;
                    OnPropertyChanged(nameof(TenLoaiSan));
                }
            }

        }

        private string _TenTrangThai;
        public string TenTrangThai
        {
            get => _TenTrangThai;
            set
            {
                if(_TenTrangThai != value)
                {
                    _TenTrangThai = value;
                    OnPropertyChanged(nameof(TenTrangThai));
                }
            }
        }

        private int _IdSelected;
        public int IdSelected
        {
            get => _IdSelected;
            set
            {
                if (_IdSelected != value)
                {
                    _IdSelected = value;
                    OnPropertyChanged(nameof(IdSelected));
                }
            }
        }

        private LoaiSan_Model _SelectedItem;
        public LoaiSan_Model SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if(_SelectedItem != value)
                {
                    _SelectedItem = value;
                    if (value != null)
                    {
                        TenLoaiSan = value.Ten_LoaiSan;
                        IdSelected = SelectedItem.Id_LoaiSan;
                        if (TenLoaiSan == "...")
                        {
                            IsEnableAdd = true;
                            TenTrangThai = "...";
                            IsEnableDisable = false;


                        }
                        else
                        {
                            IsEnableAdd = false;
                            IsEnableDisable = true;
                            BoolToString();
                        }
                        IsEnableSave = false;
                        IsEnableForTextbox = false;
                    }

                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private bool _IsEnableForTextbox;


        public bool IsEnableForTextbox
        {
            get => _IsEnableForTextbox;
            set
            {
                if (_IsEnableForTextbox != value)
                {
                    _IsEnableForTextbox = value;
                    OnPropertyChanged(nameof(IsEnableForTextbox));
                }
            }
        }

        private bool _IsEnableSave;
        public bool IsEnableSave
        {
            get => _IsEnableSave;
            set
            {
                if (_IsEnableSave != value)
                {
                    _IsEnableSave = value;
                    OnPropertyChanged(nameof(IsEnableSave));
                }
            }
        }

        private bool _IsEnableDisable;
        public bool IsEnableDisable
        {
            get => _IsEnableDisable;
            set
            {
                if (_IsEnableDisable != value)
                {
                    _IsEnableDisable = value;
                    OnPropertyChanged(nameof(IsEnableDisable));
                }
            }
        }

        private bool _IsEnableAdd;
        public bool IsEnableAdd
        {
            get => _IsEnableAdd;
            set
            {
                if (_IsEnableAdd != value)
                {
                    _IsEnableAdd = value;
                    OnPropertyChanged(nameof(IsEnableAdd));
                }
            }
        }


        #region Command
        #region Fields
        private ICommand _ClickSaveCommand;
        private ICommand _ClickRemoveCommand;
        private ICommand _ClickAddCommand;
        #endregion

        #region Properties
        public ICommand ClickSaveCommand
        {
            get
            {
                if(_ClickSaveCommand == null)
                {
                    _ClickSaveCommand = new RelayCommand(Save, CanExecute);
                }
                return _ClickSaveCommand;
            }
        }

        public ICommand ClickRemoveCommand
        {
            get
            {
                if (_ClickRemoveCommand == null)
                {
                    _ClickRemoveCommand = new RelayCommand(EnableOrDisable, CanExecute);
                }
                return _ClickRemoveCommand;
            }
        }

        public ICommand ClickAddCommand
        {
            get
            {
                if (_ClickAddCommand == null)
                {
                    _ClickAddCommand = new RelayCommand(Add, CanExecute);
                }
                return _ClickAddCommand;
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public LoaiSan_ViewModel()
        {
            DanhSach_LoaiSan.Clear();
            DanhSach_LoaiSan = Yard_ViewModel.DataLoaiSan;
            AddLastItem();

            SelectedItem = DanhSach_LoaiSan[0];

        }

        #region Method
        public void Save()
        {
            if (SelectedItem != null)
            {
                if (IsEnableAdd)
                {
                    DanhSach_LoaiSan.RemoveAt(DanhSach_LoaiSan.Count() - 1);
                    LoaiSan_Model temp = new LoaiSan_Model();
                    temp.Ten_LoaiSan = TenLoaiSan;
                    temp.Status = TenTrangThai == "Disable" ? false : true;
                    temp.Id_LoaiSan = DanhSach_LoaiSan.Last().Id_LoaiSan + 1;
                    DanhSach_LoaiSan.Add(temp);
                    SyncData();
                    AddLastItem();
                }
                
            }
        }

        public void BoolToString()
        {
            if (DanhSach_LoaiSan[SelectedItem.Id_LoaiSan].Status)
            {
                TenTrangThai = "Disable";
            }
            else
            {
                TenTrangThai = "Enable";
            }
        }
        public void SyncData()
        {
            ObservableCollection<LoaiSan_Model> l_List = new ObservableCollection<LoaiSan_Model>();
            foreach (var item in DanhSach_LoaiSan)
            {
                if(item.Ten_LoaiSan != "...")
                {
                    LoaiSan_Model obj = new LoaiSan_Model();
                    obj = item.Clone();
                    l_List.Add(obj);
                }
            }
            Yard_ViewModel.DataLoaiSan = l_List;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void EnableOrDisable()
        {
            //DanhSach_LoaiSan[SelectedItem.Id_LoaiSan].Ten_LoaiSan = "";
            foreach(var item in DanhSach_LoaiSan)
            {
                if(item.Id_LoaiSan == SelectedItem.Id_LoaiSan)
                {
                    if(DanhSach_LoaiSan[SelectedItem.Id_LoaiSan].Status)
                    {
                        DanhSach_LoaiSan[SelectedItem.Id_LoaiSan].Status = false;
                    }
                    else
                    {
                        DanhSach_LoaiSan[SelectedItem.Id_LoaiSan].Status = true;
                    }
                    
                    break;
                }
            }
            ObservableCollection<LoaiSan_Model> l_List = new ObservableCollection<LoaiSan_Model>();
            foreach (var item1 in DanhSach_LoaiSan)
            {
                if (item1.Ten_LoaiSan != "...")
                {
                    LoaiSan_Model obj = new LoaiSan_Model();
                    obj = item1.Clone();
                    l_List.Add(obj);
                }
            }
            DanhSach_LoaiSan = l_List;
            SyncData();
            Default();
            AddLastItem();
            
        }

        public void Default()
        {
            SelectedItem = DanhSach_LoaiSan[IdSelected];
            TenLoaiSan = SelectedItem.Ten_LoaiSan;

        }

        public void AddLastItem()
        {
            LoaiSan_Model temp = new LoaiSan_Model();
            temp.Ten_LoaiSan = "...";
            temp.Id_LoaiSan = DanhSach_LoaiSan.Last().Id_LoaiSan + 1;
            DanhSach_LoaiSan.Add(temp);

        }
        public void Add()
        {
            IsEnableForTextbox = true;
            IsEnableSave = true;
            TenTrangThai = "Disable";
        }
        #endregion
    }
}
