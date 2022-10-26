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
        private San_Model _SelectedItem;
        public San_Model SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    LoaiSan = Warpper(value.LoaiSan);
                    TenSan = value.TenSan;
                    if(TenSan == "...")
                    {
                        IsDis = true;
                        IsEdit = false;
                    }
                    else
                    {
                        IsDis = false;
                        IsEdit = true;
                    }
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private bool _IsDis;
        public bool IsDis
        {
            get => _IsDis;
            set
            {
                if(_IsDis != value)
                {
                    _IsDis = value;
                    OnPropertyChanged(nameof(IsDis));
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

        private ICommand _ClickEdit;
        public ICommand ClickEdit
        {
            get
            {
                if (_ClickEdit == null)
                {
                    _ClickEdit = new RelayCommand(Edit, IsExecuted);
                }
                return _ClickEdit;
            }
        }

        public San_ViewModel()
        {
            LoadData();
            LoadDataForCombobox();
        }

        #region Method
        public void LoadData()
        {
            //HardCode
            string[] l_LoaiSan = { "San 5", "San 7", "San 11" };
            string[] l_TenSan = { "San 5-1", "San 5-2", "San 5-3", "San 7-1", "San 7-2", "San 11-1" };
            DanhSach_San.Clear();
            for (int i = 0; i < 6; i++)
            {
                San_Model temp = new San_Model();
                temp.Id = i;
                temp.IsActive = true;
                if (i < 3)
                {
                    temp.LoaiSan = l_LoaiSan[0];
                    temp.TenSan = l_TenSan[i];
                }
                else if (i == 3 || i == 4)
                {
                    temp.LoaiSan = l_LoaiSan[1];
                    temp.TenSan = l_TenSan[i];
                }
                else
                {
                    temp.LoaiSan = l_LoaiSan[2];
                    temp.TenSan = l_TenSan[i];
                }
                DanhSach_San.Add(temp);
            }
            AddLastItem();

        }

        public void AddLastItem()
        {
            San_Model temp1 = new San_Model();
            temp1.Id = DanhSach_San.Last().Id + 1;
            temp1.LoaiSan = "...";
            temp1.TenSan = "...";
            DanhSach_San.Add(temp1);
        }

        public void AddItem()
        {
            DanhSach_San.RemoveAt(DanhSach_San.Count() - 1);
            San_Model temp1 = new San_Model();
            temp1.Id = DanhSach_San.Last().Id + 1;
            temp1.LoaiSan = WarpperIntToString(LoaiSan);
            temp1.TenSan = TenSan;

            DanhSach_San.Add(temp1);
            //DanhSach_San.Last().LoaiSan = WarpperIntToString(LoaiSan);
            //DanhSach_San.Last().TenSan = TenSan;
            AddLastItem();
        }

        public bool IsExecuted()
        {
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
            set { _LoaiSanCbb = value; }
        }

        public void LoadDataForCombobox()
        {
            _LoaiSanCbb = new Dictionary<int, string>()
            {
                {0,"San 5" },
                {1, "San 7" },
                {2, "San 11" },
            };
        }

        public void Disable()
        {
            DanhSach_San[SelectedItem.Id].IsActive = false;
        }

        public void Edit()
        {
            DanhSach_San[SelectedItem.Id].LoaiSan = WarpperIntToString(LoaiSan);
            DanhSach_San[SelectedItem.Id].TenSan = TenSan;
        }
    }
}
