using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KLTN.Model;
using KLTN.Service;

namespace KLTN.ViewModel
{
    public partial class Invoice_ViewModel : BaseViewModel
    {
        #region Fields
        private string _GioBatDau = string.Empty;
        private string _GioKetThuc = string.Empty;
        private string _Date = string.Empty;
        private int _TuyChonSelected = 0;
        private HoaDon_Model _SelectedItem;
        private ObservableCollection<HoaDon_Model> _DanhSachToanBoHoaDon;
        private ObservableCollection<HoaDon_Model> _DanhSachHoaDon;
        private ObservableCollection<HoatDongNuocUong_Model> _DanhSachNuocUongItem;
        private ObservableCollection<HoatDongNuocUong_Model> _DanhSachToanBoNuocUong;
        #endregion Fields

        #region Properties
        public string GioBatDau
        {
            get => _GioBatDau;
            set
            {
                if (_GioBatDau != value)
                {
                    _GioBatDau = value;
                    OnPropertyChanged(nameof(GioBatDau));
                }
            }
        }

        public string GioKetThuc
        {
            get => _GioKetThuc;
            set
            {
                if (_GioKetThuc != value)
                {
                    _GioKetThuc = value;
                    OnPropertyChanged(nameof(GioKetThuc));
                }
            }
        }

        public string Date
        {
            get => _Date;
            set
            {
                if (_Date != value)
                {
                    _Date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        public ObservableCollection<HoaDon_Model> DanhSachToanBoHoaDon
        {
            get
            {
                if (_DanhSachToanBoHoaDon == null)
                {
                    _DanhSachToanBoHoaDon = new ObservableCollection<HoaDon_Model>();
                }
                return _DanhSachToanBoHoaDon;
            }
            set
            {
                if (_DanhSachToanBoHoaDon != value)
                {
                    _DanhSachToanBoHoaDon = value;
                    OnPropertyChanged(nameof(DanhSachToanBoHoaDon));
                }
            }
        }

        public ObservableCollection<HoaDon_Model> DanhSachHoaDon
        {
            get
            {
                if (_DanhSachHoaDon == null)
                {
                    _DanhSachHoaDon = new ObservableCollection<HoaDon_Model>();
                    foreach (var item in DanhSachToanBoHoaDon)
                    {
                        if (item.Ngay.CompareShortString(DateTime.Today))
                        {
                            _DanhSachHoaDon.Add(item.Clone());
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                return _DanhSachHoaDon;
            }
            set
            {
                if (_DanhSachHoaDon != value)
                {
                    _DanhSachHoaDon = value;
                    OnPropertyChanged(nameof(DanhSachHoaDon));
                }
            }
        }

        public ObservableCollection<HoatDongNuocUong_Model> DanhSachNuocUongSelectedItem
        {
            get
            {
                if (_DanhSachNuocUongItem == null)
                {
                    _DanhSachNuocUongItem = new ObservableCollection<HoatDongNuocUong_Model>();
                }
                return _DanhSachNuocUongItem;
            }
            set
            {
                if (_DanhSachNuocUongItem != value)
                {
                    _DanhSachNuocUongItem = value;
                    OnPropertyChanged(nameof(DanhSachNuocUongSelectedItem));
                }
            }
        }

        public ObservableCollection<HoatDongNuocUong_Model> DanhSachToanBoNuocUong
        {
            get
            {
                if (_DanhSachToanBoNuocUong == null)
                {
                    _DanhSachToanBoNuocUong = new ObservableCollection<HoatDongNuocUong_Model>();
                }
                return _DanhSachToanBoNuocUong;
            }
            set
            {
                if (_DanhSachToanBoNuocUong != value)
                {
                    _DanhSachToanBoNuocUong = value;
                    OnPropertyChanged(nameof(DanhSachToanBoNuocUong));
                }
            }
        }

        public HoaDon_Model SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                {
                    _SelectedItem = new HoaDon_Model();
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

        public Dictionary<int, string> DanhSachTuyChon
        {
            get
            {
                Dictionary<int, string> temp = new Dictionary<int, string>();
                temp.Add(0, "Doanh thu hôm nay");
                temp.Add(1, "Doanh thu toàn bộ");
                return temp;
            }
        }

        public int TuyChonSelected
        {
            get => _TuyChonSelected;
            set
            {
                if (_TuyChonSelected != value)
                {
                    _TuyChonSelected = value;
                    ActionWhenChangeKey();
                    OnPropertyChanged(nameof(TuyChonSelected));
                }
            }
        }
        #endregion Properties

        #region Service
        HoaDon_Service Database_HoaDon;
        DanhSachHoaDon_NuocUong_Service Database_NuocUong;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public Invoice_ViewModel()
        {
            Database_HoaDon = new HoaDon_Service();
            Database_NuocUong = new DanhSachHoaDon_NuocUong_Service();
            DanhSachToanBoNuocUong = Database_NuocUong.GetAll();
            DanhSachToanBoHoaDon = Database_HoaDon.GetAll();
        }

        #region Method

        /// <summary>
        /// Action when change item in DanhSachHoaDon
        /// </summary>
        public void ActionWhenChangeItem()
        {
            ClearInfor();
            GioBatDau = SelectedItem.GioVaoSan.Hour.Trim() + ":" + SelectedItem.GioVaoSan.Minute.Trim();
            GioKetThuc = SelectedItem.GioKetThuc.Hour.Trim() + ":" + SelectedItem.GioKetThuc.Minute.Trim();
            Date = SelectedItem.Ngay.Day.Trim() + "/" + SelectedItem.Ngay.Month.Trim() + "/" + SelectedItem.Ngay.Year.Trim();

            DanhSachNuocUongSelectedItem = new ObservableCollection<HoatDongNuocUong_Model>();
            foreach (var item in DanhSachToanBoNuocUong)
            {
                if (item.IdHoaDon == SelectedItem.IdHoaDon)
                {
                    DanhSachNuocUongSelectedItem.Add(item);
                }
                else
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Clear information Date, time
        /// </summary>
        public void ClearInfor()
        {
            GioBatDau = "";
            GioKetThuc = "";
            Date = "";
        }

        /// <summary>
        /// Action when change value combobox
        /// </summary>
        public void ActionWhenChangeKey()
        {
            ClearInfor();
            DanhSachNuocUongSelectedItem = new ObservableCollection<HoatDongNuocUong_Model>();
            DanhSachHoaDon = new ObservableCollection<HoaDon_Model>();
            //Option Today
            if (TuyChonSelected == 0)
            {
                foreach (var item in DanhSachToanBoHoaDon)
                {
                    if (item.Ngay.CompareShortString(DateTime.Today))
                    {
                        DanhSachHoaDon.Add(item.Clone());
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            //Option Toan bo
            else
            {
                foreach (var item in DanhSachToanBoHoaDon)
                {
                    DanhSachHoaDon.Add(item.Clone());
                }
            }
        }

        #endregion
    }
}
