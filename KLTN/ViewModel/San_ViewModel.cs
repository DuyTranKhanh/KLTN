using System.Collections.ObjectModel;
using KLTN.Model;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace KLTN.ViewModel
{
    public class San_ViewModel : BaseViewModel
    {
        private int _LoaiSan;
        private string _TenSan;
        private string _TenTrangThai;
        public int LoaiSan
        {
            get => _LoaiSan;
            set
            {
                if (_LoaiSan != value)
                {
                    _LoaiSan = value;
                    OnPropertyChanged(nameof(LoaiSan));
                }
            }
        }

        public string TenSan
        {
            get => _TenSan;
            set
            {
                if (_TenSan != value)
                {
                    _TenSan = value;
                    OnPropertyChanged(nameof(TenSan));
                }
            }
        }

        public string TenTrangThai
        {
            get => _TenTrangThai;
            set
            {
                if (_TenTrangThai != value)
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

        private San_Model _SelectedItem;
        public San_Model SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    if(value != null)
                    {
                        //LoaiSan = Warpper(value.IdLoaiSan);
                        TenSan = value.TenSan;
                        IdSelected = value.Id;
                        if (TenSan == "...")
                        {
                            IsAdd = true;
                            IsEdit = false;
                            IsDisable = false;
                        }
                        else
                        {
                            IsAdd = false;
                            IsEdit = true;
                            IsDisable = true;
                            if (SelectedItem.Status)
                            {
                                TenTrangThai = "Enable";
                            }
                            else
                            {
                                IsEdit = false;
                                TenTrangThai = "Disable";
                            }
                        }
                        IsSave = false;
                        IsEnableForTextbox = false;
                    }
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private bool _IsSave;
        public bool IsSave
        {
            get => _IsSave;
            set
            {
                if(_IsSave != value)
                {
                    _IsSave = value;
                    OnPropertyChanged(nameof(IsSave));
                }
            }
        }

        private bool _IsEdit;
        public bool IsEdit
        {
            get => _IsEdit;
            set
            {
                if (_IsEdit != value)
                {
                    _IsEdit = value;
                    OnPropertyChanged(nameof(IsEdit));
                }
            }
        }

        private bool _IsAdd;
        public bool IsAdd
        {
            get => _IsAdd;
            set
            {
                if (_IsAdd != value)
                {
                    _IsAdd = value;
                    OnPropertyChanged(nameof(IsAdd));
                }
            }
        }

        private bool _IsDisable;
        public bool IsDisable
        {
            get => _IsDisable;
            set
            {
                if (_IsDisable != value)
                {
                    _IsDisable = value;
                    OnPropertyChanged(nameof(IsDisable));
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
        private ObservableCollection<San_Model> danhsach_San;
        public ObservableCollection<San_Model> DanhSach_San
        {
            get
            {
                if (danhsach_San == null)
                {
                    danhsach_San = new ObservableCollection<San_Model>();
                }
                return danhsach_San;
            }
            set
            {
                if (danhsach_San != value)
                {
                    danhsach_San = value;
                    OnPropertyChanged(nameof(DanhSach_San));
                }
            }
        }

        private ICommand _ClickAdd;
        public ICommand ClickAdd
        {
            get
            {
                if(_ClickAdd == null)
                {
                    _ClickAdd = new RelayCommand(AddItem, IsExecuted);
                }
                return _ClickAdd;
            }
        }

        private ICommand _ClickSave;
        public ICommand ClickSave
        {
            get
            {
                if (_ClickSave == null)
                {
                    _ClickSave = new RelayCommand(Save, IsExecuted);
                }
                return _ClickSave;
            }
        }

        private ICommand _ClickDisable;
        public ICommand ClickDisable
        {
            get
            {
                if (_ClickDisable == null)
                {
                    _ClickDisable = new RelayCommand(Disable, IsExecuted);
                }
                return _ClickDisable;
            }
        }

        private ICommand _Reload;
        public ICommand Reload
        {
            get
            {
                if(_Reload == null)
                {
                    _Reload = new RelayCommand(GetDataForCombobox, IsEnableReload);
                }
                return _Reload;
            }
        }

        public San_ViewModel()
        {
            LoadData();
            SelectedItem = DanhSach_San[0];
        }

        #region Method
        public void LoadData()
        {
            DanhSach_San.Clear();
            DanhSach_San = Yard_ViewModel.DataSans;
            //AddLastItem();
            GetDataForCombobox();

        }

        public void AddLastItem()
        {
            San_Model temp1 = new San_Model();
            temp1.Id = DanhSach_San.Last().Id + 1;
            //temp1.IdLoaiSan = "...";
            temp1.TenSan = "...";
            DanhSach_San.Add(temp1);
        }

        public void AddItem()
        {
            IsSave = true;
            IsEnableForTextbox = true;

        }

        public void Save()
        {
            if (IsAdd)
            {
                DanhSach_San.RemoveAt(DanhSach_San.Count() - 1);
                San_Model temp1 = new San_Model();
                temp1.Id = DanhSach_San.Last().Id + 1;
                //temp1.IdLoaiSan = WarpperIntToString(LoaiSan);
                temp1.TenSan = TenSan;

                DanhSach_San.Add(temp1);
                Sync();
                //AddLastItem();
            }
        }

        public void Sync()
        {
            ObservableCollection<San_Model> l_List = new ObservableCollection<San_Model>();
            foreach (var item in DanhSach_San)
            {
                if(item.TenSan != "...")
                {
                    San_Model temp = new San_Model();
                    temp = item.Clone();
                    l_List.Add(temp);
                }
            }
            Yard_ViewModel.DataSans = l_List;
        }

        public bool IsExecuted()
        {
            return true;
        }

        public bool IsEnableReload()
        {
            if(Yard_ViewModel.DataLoaiSan.Count == 0)
            {
                return false;
            }
            return true;
        }

        public int Warpper(string tenLoaiSan)
        {
            switch (tenLoaiSan)
            {
                case "San 5":
                    return 0;
                case "San 7":
                    return 1;
                case "San 11":
                    return 2;
                default: return 0;
            }

        }

        public string WarpperIntToString(int selectedItem)
        {
            switch(selectedItem)
            {
                case 0: return "San 5";
                case 1: return "San 7";
                case 2: return "San 11";
                default: return "San 5";
            }
        }
        #endregion

        private Dictionary<int, string> _LoaiSanCbb;
        public Dictionary<int, string> LoaiSanCbb
        {
            get { return _LoaiSanCbb; }
            set
            {
                if (_LoaiSanCbb != value)
                {
                    _LoaiSanCbb = value;
                    OnPropertyChanged(nameof(LoaiSanCbb));
                }
            }
        }

        public void GetDataForCombobox()
        {
            //LoaiSanCbb.Clear();
            Dictionary<int,string> l_LoaiSanCbb = new Dictionary<int, string>();
            int indexOfCombobox = 0;
            LoaiSan = indexOfCombobox;
            for (int i = 0; i< Yard_ViewModel.DataLoaiSan.Count;i++)
            {
                
                //Enable
                if(Yard_ViewModel.DataLoaiSan[i].Status == false)
                {
                    string temp = Yard_ViewModel.DataLoaiSan[i].Ten_LoaiSan.ToString();
                    l_LoaiSanCbb.Add(indexOfCombobox, temp);
                    indexOfCombobox++;
                }
            }
            LoaiSanCbb = l_LoaiSanCbb;
        }

        public void Disable()
        {
            if(DanhSach_San[SelectedItem.Id].Status)
            {
                DanhSach_San[SelectedItem.Id].Status = false;
            }
            else
            {
                DanhSach_San[SelectedItem.Id].Status = true;
            }
            
            ObservableCollection<San_Model> l_List = new ObservableCollection<San_Model>();
            foreach (var item in DanhSach_San)
            {
                San_Model temp = new San_Model();
                temp = item.Clone();
                l_List.Add(temp);
            }
            DanhSach_San = l_List;
            Sync();
            SelectedItem = DanhSach_San[IdSelected];
        }
    }
}
