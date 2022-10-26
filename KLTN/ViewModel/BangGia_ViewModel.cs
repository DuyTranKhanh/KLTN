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
            get { return _LoaiSanCbb; }
            set { _LoaiSanCbb = value; }
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
                    NgayApDung = value.NgayApDung;
                    TenLoaiSan = Warpper(value.TenLoaiSan);
                    TimeStart = value.TimeStart.ToString();
                    TimeEnd = value.TimeEnd.ToString();
                    GiaTien = value.GiaTien.ToString();

                    if(NgayApDung == "...")
                    {
                        IsEnableToAdd = true;
                        IsEnableToEdit = false;
                    }
                    else
                    {
                        IsEnableToAdd = false;
                        IsEnableToEdit = true;
                    }
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private string _NgayApDung;
        private int _TenLoaiSan;
        private string _TimeStart;
        private string _TimeEnd;
        private string _GiaTien;

        private bool _IsEnableToAdd;
        private bool _IsEnableToEdit;

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

        public bool IsEnableToEdit
        {
            get => _IsEnableToEdit;
            set
            {
                if (_IsEnableToEdit != value)
                {
                    _IsEnableToEdit = value;
                    OnPropertyChanged(nameof(_IsEnableToEdit));
                }
            }
        }
        public string NgayApDung
        {
            get => _NgayApDung;
            set
            {
                _NgayApDung = value;
                OnPropertyChanged(nameof(NgayApDung));
            }
        }

        public int TenLoaiSan
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

        #endregion

        public BangGia_ViewModel()
        {
            LoadData();
            LoadDataForCombobox();
        }
        #region Method

        public void LoadData()
        {
            string[] l_LoaiSan = { "San 5", "San 7", "San 11" };
            int l_Start1 = 6;
            int l_Start2 = 18;
            int l_End1 = 18;
            int l_End2 = 24;

            for (int i = 0; i < 6; i++)
            {
                BangGia_Model temp = new BangGia_Model();
                temp.Id = i;
                temp.NgayApDung = DateTime.Today.ToString();
                if (i < 2)
                {
                    temp.TenLoaiSan = l_LoaiSan[0];
                    if (i == 0)
                    {
                        temp.TimeStart = l_Start1;
                        temp.TimeEnd = l_End1;
                        temp.GiaTien = 100000;
                    }
                    else
                    {
                        temp.TimeStart = l_Start2;
                        temp.TimeEnd = l_End2;
                        temp.GiaTien = 150000;
                    }
                }
                else if (2 <= i && i < 4)
                {
                    temp.TenLoaiSan = l_LoaiSan[1];
                    if (i == 2)
                    {
                        temp.TimeStart = l_Start1;
                        temp.TimeEnd = l_End1;
                        temp.GiaTien = 250000;
                    }
                    else
                    {
                        temp.TimeStart = l_Start2;
                        temp.TimeEnd = l_End2;
                        temp.GiaTien = 450000;
                    }
                }

                else
                {
                    temp.TenLoaiSan = l_LoaiSan[2];
                    if (i == 4)
                    {
                        temp.TimeStart = l_Start1;
                        temp.TimeEnd = l_End1;
                        temp.GiaTien = 500000;
                    }
                    else
                    {
                        temp.TimeStart = l_Start2;
                        temp.TimeEnd = l_End2;
                        temp.GiaTien = 900000;
                    }
                }
                DanhSach.Add(temp);
            }

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

        public bool IsExecute()
        {
            return true;
        }

        public void ClickAdd()
        {
            DanhSach.RemoveAt(DanhSach.Count() - 1);
            BangGia_Model temp = new BangGia_Model();
            temp.Id = DanhSach.Last().Id + 1;
            temp.NgayApDung = NgayApDung;
            temp.TenLoaiSan = WarpperIntToString(TenLoaiSan);
            temp.TimeEnd = Convert.ToInt32( TimeEnd);
            temp.TimeStart = Convert.ToInt32(TimeStart);
            temp.GiaTien = Convert.ToInt32(GiaTien);

            DanhSach.Add(temp);
            AddLastItem();
        }

        public void ClickModify()
        {

        }

        public void ClickDisable()
        {

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
