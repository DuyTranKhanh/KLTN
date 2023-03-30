using System.Collections.ObjectModel;
using KLTN.Model;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System;

namespace KLTN.ViewModel
{
    public enum TrangThaiSan
    {
        SanSangSuDung = 0,
        DangDuocSuDung = 1,
        DaXuatHoaDon = 2,
        KhongTheSuDung = 3,
        ChuaThuTien = 4
    }

    public class Obj_San : San_Model
    {
        private string _TrangThaiSan;

        public string TrangThaiSan
        {
            get => _TrangThaiSan;
            set { _TrangThaiSan = value; }
        }
    }
    public class Yard_ViewModel : BaseViewModel
    {
        private ObservableCollection<HoaDon_Model> _DanhSachSan5;
        private ObservableCollection<HoaDon_Model> _DanhSachSan7;
        private ObservableCollection<HoaDon_Model> _DanhSachSan11;
        private ObservableCollection<HoaDon_Model> _DanhSachSanOthers;
        private ObservableCollection<Obj_San> _San5;
        private ObservableCollection<San_Model> _San7;
        private ObservableCollection<San_Model> _San11;
        private ObservableCollection<San_Model> _SanOther;
        private ObservableCollection<San_Model> _DanhSach;
        private int _SelectedIndexTabItem;
        private string _trangThaiSuDung;
        private string _tenSan;
        private string _ThoiGianBatDau;
        private string _ThoiGianKetThuc;
        private Obj_San _SelectedObj;

        public string TrangThaiSuDung
        {
            get => _trangThaiSuDung;
            set
            {
                if(_trangThaiSuDung != value)
                {
                    _trangThaiSuDung = value;
                    OnPropertyChanged(nameof(TrangThaiSuDung));
                }
            }
        }

        public string ThoiGianBatDau
        {
            get => _ThoiGianBatDau;
            set
            {
                if (_ThoiGianBatDau != value)
                {
                    _ThoiGianBatDau = value;
                    OnPropertyChanged(nameof(ThoiGianBatDau));
                }
            }
        }

        public string ThoiGianKetThuc
        {
            get => _ThoiGianKetThuc;
            set
            {
                if (_ThoiGianKetThuc != value)
                {
                    _ThoiGianKetThuc = value;
                    OnPropertyChanged(nameof(ThoiGianKetThuc));
                }
            }
        }

        public string TenSan
        {
            get => _tenSan;
            set
            {
                if (_tenSan != value)
                {
                    _tenSan = value;
                    OnPropertyChanged(nameof(TenSan));
                }
            }
        }
        public Obj_San SelectedObj
        {
            get
            {
                if(_SelectedObj == null)
                {
                    _SelectedObj = new Obj_San();
                }
                return _SelectedObj;
            }
            set
            {
                if(_SelectedObj != value)
                {
                    _SelectedObj = value;
                    TrangThaiSuDung = value.TrangThaiSan;
                    TenSan = value.TenSan;
                    ThoiGianBatDau = "";
                    ThoiGianKetThuc = "";
                    //San 5
                    if(SelectedIndexTabItem == 0)
                    {
                        FindRecordSan5();
                    }
                    OnPropertyChanged(nameof(SelectedObj));
                }
            }
        }
        public int SelectedIndexTabItem
        {
            get => _SelectedIndexTabItem;
            set
            {
                if(_SelectedIndexTabItem != value)
                {
                    _SelectedIndexTabItem = value;
                    OnPropertyChanged(nameof(SelectedIndexTabItem));
                }
            }
        }
        public ObservableCollection<San_Model> DanhSach
        {
            get
            {
                if (_DanhSach == null)
                {
                    _DanhSach = new ObservableCollection<San_Model>();
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

        public ObservableCollection<HoaDon_Model> DanhSachSan5
        {
            get
            {
                if(_DanhSachSan5 == null)
                {
                    _DanhSachSan5 = new ObservableCollection<HoaDon_Model>();
                }
                return _DanhSachSan5;
            }
            set
            {
                if (_DanhSachSan5 != value)
                {
                    _DanhSachSan5 = value;
                    OnPropertyChanged(nameof(DanhSachSan5));
                }
            }
        }
        public ObservableCollection<Obj_San> San5
        {
            get
            {
                if (_San5 == null)
                {
                    _San5 = new ObservableCollection<Obj_San>();
                }
                return _San5;
            }
            set
            {
                if (_San5 != value)
                {
                    _San5 = value;
                    OnPropertyChanged(nameof(San5));
                }
            }
        }

        public ObservableCollection<San_Model> SanOther
        {
            get
            {
                if (_SanOther == null)
                {
                    _SanOther = new ObservableCollection<San_Model>();
                }
                return _SanOther;
            }
            set
            {
                if (_SanOther != value)
                {
                    _SanOther = value;
                    OnPropertyChanged(nameof(SanOther));
                }
            }
        }

        public ObservableCollection<San_Model> San7
        {
            get
            {
                if (_San7 == null)
                {
                    _San7 = new ObservableCollection<San_Model>();
                }
                return _San7;
            }
            set
            {
                if (_San7 != value)
                {
                    _San7 = value;
                    OnPropertyChanged(nameof(San7));
                }
            }
        }

        public ObservableCollection<San_Model> San11
        {
            get
            {
                if (_San11 == null)
                {
                    _San11 = new ObservableCollection<San_Model>();
                }
                return _San11;
            }
            set
            {
                if (_San11 != value)
                {
                    _San11 = value;
                    OnPropertyChanged(nameof(San11));
                }
            }
        }

        #region Data Static
        public static ObservableCollection<San_Model> DataSans = new ObservableCollection<San_Model>();
        public static ObservableCollection<BangGia_Model> DataBangGia = new ObservableCollection<BangGia_Model>();
        public static ObservableCollection<KhachHang_Model> DataKhachHang = new ObservableCollection<KhachHang_Model>();
        public static ObservableCollection<LoaiSan_Model> DataLoaiSan = new ObservableCollection<LoaiSan_Model>();
        public static ObservableCollection<DichVuKhac_Model> DataDichVu = new ObservableCollection<DichVuKhac_Model>();
        public static ObservableCollection<NuocUong_Model> DataNuocUong = new ObservableCollection<NuocUong_Model>();

        #endregion

        public Yard_ViewModel()
        {
            InitDataForAllScreen();
            Sync();
            GetDataForSan();
        }
        public void Sync()
        {
            foreach(var item in DataSans)
            {
                DanhSach.Add(item);
            }
        }

        #region Get Data for San

        public void GetDataForSan()
        {
            GetDataForSan5();
            GetDataForSan7();
            GetDataForSan11();
            GetDataForSanOther();
        }
        public void GetDataForSan5()
        {
            //ObservableCollection<Obj_San> l_List = new ObservableCollection<Obj_San>();
            //foreach (var item in DanhSach)
            //{
            //    if (item.IdLoaiSan == "San 5")
            //    {
            //        Obj_San obj = new Obj_San();
            //        obj.Id = item.Id;
            //        obj.Status = item.Status;
            //        obj.IdLoaiSan = item.IdLoaiSan;
            //        obj.TenSan = item.TenSan;
            //        obj.TrangThaiSan = WrapperTrangThaiSan(TrangThaiSan.SanSangSuDung);
            //        l_List.Add(obj);
            //    }
            //}

            //foreach (var item in l_List)
            //{
            //    San5.Add(item);
            //}

        }

        public string WrapperTrangThaiSan(TrangThaiSan trangThai)
        {
            switch(trangThai)
            {
                case TrangThaiSan.SanSangSuDung:
                    return "San sang su dung";
                case TrangThaiSan.KhongTheSuDung:
                    return "Khong the su dung!";
                case TrangThaiSan.DaXuatHoaDon:
                    return "Da xuat hoa don:";
                case TrangThaiSan.DangDuocSuDung:
                    return "Dang duoc su dung";
                case TrangThaiSan.ChuaThuTien:
                    return "Chua Thu tien!";
                default: return "San sang su dung";
            }
        }
        public void GetDataForSanOther()
        {
            //ObservableCollection<San_Model> l_List = new ObservableCollection<San_Model>();
            //foreach (var item in DanhSach)
            //{
            //    if (item.IdLoaiSan != "San 5" && item.IdLoaiSan != "San 7" && item.IdLoaiSan != "San 11")
            //    {
            //        San_Model obj = new San_Model();
            //        obj = item.Clone();
            //        l_List.Add(obj);
            //    }
            //}

            //foreach (var item in l_List)
            //{
            //    SanOther.Add(item);
            //}

        }

        public void GetDataForSan7()
        {
            //ObservableCollection<San_Model> l_List = new ObservableCollection<San_Model>();
            //foreach (var item in DanhSach)
            //{
            //    if (item.IdLoaiSan == "San 7")
            //    {
            //        San_Model obj = new San_Model();
            //        obj = item.Clone();
            //        l_List.Add(obj);
            //    }
            //}

            //foreach (var item in l_List)
            //{
            //    San7.Add(item);
            //}

        }

        public void GetDataForSan11()
        {
            //ObservableCollection<San_Model> l_List = new ObservableCollection<San_Model>();
            //foreach (var item in DanhSach)
            //{
            //    if (item.IdLoaiSan == "San 11")
            //    {
            //        San_Model obj = new San_Model();
            //        obj = item.Clone();
            //        l_List.Add(obj);
            //    }
            //}

            //foreach (var item in l_List)
            //{
            //    San11.Add(item);
            //}

        }
        #endregion Get Data for San

        #region Action when click San 5, 7, 11, other

        public bool IsExecute()
        {
            return true;
        }

        public void GetDataForDanhSachSan5()
        {
            ObservableCollection<HoaDon_Model> l_List = new ObservableCollection<HoaDon_Model>();
            foreach(var item in San5)
            {
                HoaDon_Model obj = new HoaDon_Model();
                obj.San = item.Clone();                
            }
        }

        #endregion

        #region Command and Method Command
        private ICommand _BatDauSuDung;

        public ICommand BatDauSuDung
        {
            get
            {
                if(_BatDauSuDung == null)
                {
                    _BatDauSuDung = new RelayCommand(BatDauSuDungAction, IsExecute);
                }
                return _BatDauSuDung;
            }
        }

        public void BatDauSuDungAction()
        {
            HoaDon_Model item = new HoaDon_Model();
            item.San.Id = SelectedObj.Id;
            item.San.Status = SelectedObj.Status;
            item.San.IdLoaiSan = SelectedObj.IdLoaiSan;
            item.San.TenSan = SelectedObj.TenSan;
            item.GioVaoSan = DateTime.Now.ToString();
            item.TrangThaiSan = (int)(TrangThaiSan.DangDuocSuDung);
            DanhSachSan5.Add(item);

            ObservableCollection<Obj_San> l_list = new ObservableCollection<Obj_San>();

            San5[SelectedObj.Id].TrangThaiSan = WrapperTrangThaiSan(TrangThaiSan.DangDuocSuDung);
            TrangThaiSuDung = WrapperTrangThaiSan(TrangThaiSan.DangDuocSuDung);
            ThoiGianBatDau = DateTime.Now.ToString();
            foreach (var obj in San5)
            {
                l_list.Add(obj);
            }
            San5 = l_list;
        }

        public void KetThucSuDungAction()
        {
            //Yard_Model item = new Yard_Model();
            //item.San.Id = SelectedObj.Id;
            //item.San.IsActive = SelectedObj.IsActive;
            //item.San.LoaiSan = SelectedObj.LoaiSan;
            //item.San.TenSan = SelectedObj.TenSan;
            //item.GioKetThuc = DateTime.Now.ToString();
            //DanhSachSan5.Add(item);

            //ObservableCollection<Obj_San> l_list = new ObservableCollection<Obj_San>();

            //San5[SelectedObj.Id].TrangThaiSan = WrapperTrangThaiSan(TrangThaiSan.DangDuocSuDung);
            //TrangThaiSuDung = WrapperTrangThaiSan(TrangThaiSan.DangDuocSuDung);
            //ThoiGianBatDau = DateTime.Now.ToString();
            //foreach (var obj in San5)
            //{
            //    l_list.Add(obj);
            //}
            //San5 = l_list;
        }

        public void FindRecordSan5()
        {
            //foreach(var item in DanhSachSan5)
            //{
            //    if(item.San.IdLoaiSan == "San 5" && item.TrangThaiSan == (int)TrangThaiSan.DangDuocSuDung && item.San.TenSan == SelectedObj.TenSan)
            //    {
            //        ThoiGianBatDau = item.GioVaoSan;
            //    }
            //}
        }

        public void InitDataForAllScreen()
        {
            InitDataBangGia();
            InitDataForLoaiSan();
            InitDataForSan();
        }

        public void InitDataForLoaiSan()
        {
            string[] ListName = { "San 5", "San 7", "San 11" };
            //Hard code
            DataLoaiSan.Clear();
            for (int i = 0; i < 3; i++)
            {
                LoaiSan_Model temp = new LoaiSan_Model();
                temp.Id_LoaiSan = i;
                temp.Ten_LoaiSan = ListName[i];
                DataLoaiSan.Add(temp);

            }
        }
        public void InitDataBangGia()
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
                temp.Status = true;
                temp.NgayApDung = DateTime.Now.ToString("yyyy-MM-dd");
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
                DataBangGia.Add(temp);
            }
        }

        public void InitDataForSan()
        {
            ////HardCode
            //string[] l_LoaiSan = { "San 5", "San 7", "San 11" };
            //string[] l_TenSan = { "San 5-1", "San 5-2", "San 5-3", "San 7-1", "San 7-2", "San 11-1" };
            //DataSans.Clear();
            //for (int i = 0; i < 6; i++)
            //{
            //    San_Model temp = new San_Model();
            //    temp.Id = i;
            //    temp.Status = true;
            //    if (i < 3)
            //    {
            //        temp.IdLoaiSan = l_LoaiSan[0];
            //        temp.TenSan = l_TenSan[i];
            //    }
            //    else if (i == 3 || i == 4)
            //    {
            //        temp.IdLoaiSan = l_LoaiSan[1];
            //        temp.TenSan = l_TenSan[i];
            //    }
            //    else
            //    {
            //        temp.IdLoaiSan = l_LoaiSan[2];
            //        temp.TenSan = l_TenSan[i];
            //    }
            //    DataSans.Add(temp);
            //}
        }

        public void InitDataKhachHang()
        {

        }

        public void InitDataDichVu()
        {

        }

        public void InitDataNuocUong()
        {

        }
        #endregion
    }
}
