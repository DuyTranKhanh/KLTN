using System.Windows.Input;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using KLTN.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;

namespace KLTN.ViewModel
{
    public class BangGia_ViewModel : BaseViewModel
    {
        #region Properties to Tranfer Data
        public static ObservableCollection<BangGia_Model> DataOut = new ObservableCollection<BangGia_Model>();
        #endregion

        #region Properties
        private ObservableCollection<BangGia_Model> _DanhSach;
        public ObservableCollection<BangGia_Model> DanhSach
        {
            get
            {
                if(_DanhSach == null)
                {
                    _DanhSach = new ObservableCollection<BangGia_Model>();
                }
                return _DanhSach;
            }
            set
            {
                if (_DanhSach != value)
                {
                    _DanhSach = value;
                    OnPropertyChanged(nameof(DanhSach));
                }
                
            }
        }

        private Dictionary<int, string> _LoaiSanCbb;
        public Dictionary<int, string> LoaiSanCbb
        {
            get
            {
                if(_LoaiSanCbb == null)
                {
                    _LoaiSanCbb = new Dictionary<int, string>();
                }
                return _LoaiSanCbb;
            }
            set
            {
                if (_LoaiSanCbb != value)
                {
                    _LoaiSanCbb = value;
                    OnPropertyChanged(nameof(LoaiSanCbb));
                }


            }
        }

        private ObservableCollection<LoaiSan_Model> _DanhsachLoaiSan;
        public ObservableCollection<LoaiSan_Model> DanhsachLoaiSan
        {
            get
            {
                if (_DanhsachLoaiSan == null)
                {
                    _DanhsachLoaiSan = new ObservableCollection<LoaiSan_Model>();
                    _DanhsachLoaiSan = Yard_ViewModel.DataLoaiSan;
                }
                return _DanhsachLoaiSan;
            }
            set
            {
                if (_DanhsachLoaiSan != value)
                {
                    _DanhsachLoaiSan = value;
                    OnPropertyChanged(nameof(DanhsachLoaiSan));
                }
            }
        }

        private BangGia_Model _SelectedItem;
        public BangGia_Model SelectedItem
        {
            get
            {
                if(_SelectedItem == null)
                {
                    _SelectedItem = new BangGia_Model();
                }
                return _SelectedItem;
            }
            set
            {
                if(_SelectedItem != value)
                {
                    _SelectedItem = value;
                    if(value != null)
                    {
                        NgayApDung = value.NgayApDung;
                        SelectedLoaiSan = Warpper(value.TenLoaiSan);
                        TimeStart = value.TimeStart.ToString();
                        TimeEnd = value.TimeEnd.ToString();
                        GiaTien = value.GiaTien.ToString();
                        IdSelected = value.Id;
                        if (_NgayApDung == "...")
                        {
                            IsEnableToAdd = true;
                            IsEnableToEdit = false;
                            IsEnableDisable = false;
                            TenTrangThai = "...";
                        }
                        else
                        {
                            IsEnableToAdd = false;
                            IsEnableToEdit = true;
                            IsEnableDisable = true;
                            TenTrangThai = "Enable";
                            if (SelectedItem.Status == false)
                            {
                                IsEnableToEdit = false;
                                TenTrangThai = "Disable";
                            }

                        }
                        IsEnableToSave = false;
                        IsEnableForTextbox = false;
                    }
                   OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private string _NgayApDung;
        private int _SelectedLoaiSan;
        private string _TimeStart;
        private string _TimeEnd;
        private string _GiaTien;

        private bool _IsEnableToAdd;
        private bool _IsEnableToEdit;
        private bool _IsEnableDisable;
        private bool _IsEnableToSave;
        private bool _IsEnableForTextbox;

        public bool IsEnableToAdd
        {
            get => _IsEnableToAdd;
            set
            {
                if(_IsEnableToAdd != value)
                {
                    _IsEnableToAdd = value;
                    OnPropertyChanged(nameof(IsEnableToAdd));
                }
            }
        }

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

        public bool IsEnableToSave
        {
            get => _IsEnableToSave;
            set
            {
                if (_IsEnableToSave != value)
                {
                    _IsEnableToSave = value;
                    OnPropertyChanged(nameof(IsEnableToSave));
                }
            }
        }

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

        private string _TenTrangThai;
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

        public bool IsEnableToEdit
        {
            get => _IsEnableToEdit;
            set
            {
                if (_IsEnableToEdit != value)
                {
                    _IsEnableToEdit = value;
                    OnPropertyChanged(nameof(IsEnableToEdit));
                }
            }
        }
        public string NgayApDung
        {
            get
            {
                if(_NgayApDung == null)
                {
                    _NgayApDung = "";
                }
                return _NgayApDung;
            }
            set
            {
                _NgayApDung = value.ToString() ;
                OnPropertyChanged(nameof(NgayApDung));
            }
        }

        public int SelectedLoaiSan
        {
            get => _SelectedLoaiSan;
            set
            {
                if(_SelectedLoaiSan != value)
                {
                    _SelectedLoaiSan = value;
                    OnPropertyChanged(nameof(SelectedLoaiSan));
                }
            }
        }

        public string TimeStart
        {
            get => _TimeStart;
            set
            {
                _TimeStart = value;
                OnPropertyChanged(nameof(TimeStart));
            }
        }

        public string TimeEnd
        {
            get => _TimeEnd;
            set
            {
                _TimeEnd = value;
                OnPropertyChanged(nameof(TimeEnd));
            }
        }

        public string GiaTien
        {
            get => _GiaTien;
            set
            {
                _GiaTien = value;
                OnPropertyChanged(nameof(GiaTien));
            }
        }

        private ICommand _ClickAddCommand;
        private ICommand _ClickDisableommand;
        private ICommand _ClickSaveCommand;

        public ICommand ClickAddCommand
        {
            get
            {
                if(_ClickAddCommand == null)
                {
                    _ClickAddCommand = new RelayCommand(ClickAdd, IsExecute);
                }
                return _ClickAddCommand;
            }
        }

        public ICommand ClickSaveCommand
        {
            get
            {
                if (_ClickSaveCommand == null)
                {
                    _ClickSaveCommand = new RelayCommand(ClickSave, IsExecute);
                }
                return _ClickSaveCommand;
            }
        }

        public ICommand ClickDisableCommand
        {
            get
            {
                if (_ClickDisableommand == null)
                {
                    _ClickDisableommand = new RelayCommand(ClickDisable, IsExecute);
                }
                return _ClickDisableommand;
            }
        }
        #endregion

        public BangGia_ViewModel()
        {
            LoadData();
            LoadDataForCombobox();
            SelectedItem = DanhSach[0];
            //GetDataForCombobox();
        }
        #region Method

        public void LoadData()
        {
            if ( Yard_ViewModel.DataBangGia.Count > 0 )
            {
                foreach(var item in Yard_ViewModel.DataBangGia)
                {
                    DanhSach.Add(item);
                }
            }
            DanhsachLoaiSan = Yard_ViewModel.DataLoaiSan;
            AddLastItem();
        }

        public void AddLastItem()
        {
            BangGia_Model temp = new BangGia_Model();
            temp.Id = DanhSach.Last().Id + 1;
            temp.NgayApDung = "...";
            temp.TenLoaiSan = "...";
            temp.TimeEnd = 0;
            temp.TimeStart = 0;
            temp.GiaTien = 0;
            temp.Status = false;
            DanhSach.Add(temp);
        }
        public void LoadDataForCombobox()
        {
            //LoaiSanCbb = new Dictionary<int, string>()
            //{
            //    {0,"San 5" },
            //    {1, "San 7" },
            //    {2, "San 11" },
            //};
            for (int i = 0; i < DanhsachLoaiSan.Count; i++)
            {
                string item;
                //Enable
                if(DanhsachLoaiSan[i].Status == false)
                {
                    item = DanhsachLoaiSan[i].Ten_LoaiSan.ToString();
                    LoaiSanCbb.Add(i, item);
                }
                
            }
        }

        public bool IsExecute()
        {
            return true;
        }

        public void ClickSave()
        {
            if(IsEnableToAdd)
            {
                DanhSach.RemoveAt(DanhSach.Count() - 1);
                BangGia_Model temp = new BangGia_Model();
                temp.Id = DanhSach.Last().Id + 1;
                temp.NgayApDung = NgayApDung;
                temp.TenLoaiSan = WarpperIntToString(SelectedLoaiSan);
                temp.TimeEnd = Convert.ToInt32(TimeEnd);
                temp.TimeStart = Convert.ToInt32(TimeStart);
                temp.GiaTien = Convert.ToInt32(GiaTien);
                temp.Status = true;
                DanhSach.Add(temp);

                AddLastItem();
            }

            IsEnableToAdd = false;
            IsEnableToSave = false;
            IsEnableForTextbox = false;
            Sync();
        }

        public void Sync()
        {
            ObservableCollection<BangGia_Model> l_List = new ObservableCollection<BangGia_Model>();
            foreach (var item in DanhSach)
            {
                if(item.TenLoaiSan != "...")
                {
                    BangGia_Model obj = new BangGia_Model();
                    obj = item.Clone();
                    l_List.Add(obj);
                }
            }
            Yard_ViewModel.DataBangGia = l_List;

        }
        public void ClickAdd()
        {
            IsEnableToSave = true;
            IsEnableForTextbox = true;
        }

        public void ClickDisable()
        {
            foreach (var item in DanhSach)
            {
                if (item.Id == SelectedItem.Id)
                {
                    if (DanhSach[SelectedItem.Id].Status)
                    {
                        DanhSach[SelectedItem.Id].Status = false;
                    }
                    else
                    {
                        DanhSach[SelectedItem.Id].Status = true;
                    }

                    break;
                }
            }
            ObservableCollection<BangGia_Model> l_List = new ObservableCollection<BangGia_Model>();
            foreach (var item1 in DanhSach)
            {
                if (item1.TenLoaiSan != "...")
                {
                    BangGia_Model obj = new BangGia_Model();
                    obj = item1.Clone();
                    l_List.Add(obj);
                }
            }
            DanhSach = l_List;
            AddLastItem();
            SelectedItem = DanhSach[IdSelected];
            Sync();

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
            switch (selectedItem)
            {
                case 0: return "San 5";
                case 1: return "San 7";
                case 2: return "San 11";
                default: return "San 5";
            }
        }
        #endregion
    }
}
