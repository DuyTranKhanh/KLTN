using GalaSoft.MvvmLight.Command;
using KLTN.Model;
using KLTN.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KLTN.ViewModel
{
    public partial class Replace_Field_ViewModel : BaseViewModel
    {
        private int _LoaiSanSelected = 0;
        public int LoaiSanSelected
        {
            get => _LoaiSanSelected;
            set
            {
                if(_LoaiSanSelected != value)
                {
                    _LoaiSanSelected = value;
                    ActionWhenChangeLoaiSan();
                    OnPropertyChanged(nameof(LoaiSanSelected));
                }
            }
        }
        private ObservableCollection<HoatDongHienTaiModel> _DanhSachHoatDongHienTai;
        public ObservableCollection<HoatDongHienTaiModel> DanhSachHoatDongHienTai
        {
            get
            {
                if (_DanhSachHoatDongHienTai == null)
                {
                    _DanhSachHoatDongHienTai = new ObservableCollection<HoatDongHienTaiModel>();
                    _DanhSachHoatDongHienTai = HoatDongHienTai_Database.GetAll();
                }
                return _DanhSachHoatDongHienTai;
            }
            set
            {
                if (_DanhSachHoatDongHienTai != value)
                {
                    _DanhSachHoatDongHienTai = value;
                    OnPropertyChanged(nameof(DanhSachHoatDongHienTai));
                }
            }
        }

        private ObservableCollection<HoatDongHienTaiModel> _DanhSach_SanChuaHoatDong;
        public ObservableCollection<HoatDongHienTaiModel> DanhSach_SanChuaHoatDong
        {
            get
            {
                if (_DanhSach_SanChuaHoatDong == null)
                {
                    _DanhSach_SanChuaHoatDong = new ObservableCollection<HoatDongHienTaiModel>();
                    _DanhSach_SanChuaHoatDong = GetDataForDest((int)LoaiSanIndex.San5);
                }
                return _DanhSach_SanChuaHoatDong;
            }
            set
            {
                if (_DanhSach_SanChuaHoatDong != value)
                {
                    _DanhSach_SanChuaHoatDong = value;
                    OnPropertyChanged(nameof(DanhSach_SanChuaHoatDong));
                }
            }
        }

        private ObservableCollection<HoatDongHienTaiModel> _DanhSach_SanDangHoatDong;
        public ObservableCollection<HoatDongHienTaiModel> DanhSach_SanDangHoatDong
        {
            get
            {
                if (_DanhSach_SanDangHoatDong == null)
                {
                    _DanhSach_SanDangHoatDong = new ObservableCollection<HoatDongHienTaiModel>();
                    _DanhSach_SanDangHoatDong = GetDataForFirst((int)LoaiSanIndex.San5);
                }
                return _DanhSach_SanDangHoatDong;
            }
            set
            {
                if (_DanhSach_SanDangHoatDong != value)
                {
                    _DanhSach_SanDangHoatDong = value;
                    OnPropertyChanged(nameof(DanhSach_SanDangHoatDong));
                }
            }
        }

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

        private HoatDongHienTaiModel _SelectedItemDangHoatDong;
        public HoatDongHienTaiModel SelectedItemDangHoatDong
        {
            get
            {
                if(_SelectedItemDangHoatDong == null)
                {
                    _SelectedItemDangHoatDong = new HoatDongHienTaiModel();
                }
                return _SelectedItemDangHoatDong;
            }
            set
            {
                if(_SelectedItemDangHoatDong != value)
                {
                    _SelectedItemDangHoatDong = value;
                    StatusOfBtn = IsEnable();
                    OnPropertyChanged(nameof(SelectedItemDangHoatDong));
                }
            }
        }

        /// <summary>
        /// Data of Selected Item Chua hoat dong
        /// </summary>
        private HoatDongHienTaiModel _SelectedItemChuaHoatDong;
        public HoatDongHienTaiModel SelectedItemChuaHoatDong
        {
            get
            {
                if (_SelectedItemChuaHoatDong == null)
                {
                    _SelectedItemChuaHoatDong = new HoatDongHienTaiModel();
                }
                return _SelectedItemChuaHoatDong;
            }
            set
            {
                if (_SelectedItemChuaHoatDong != value)
                {
                    _SelectedItemChuaHoatDong = value;
                    StatusOfBtn = IsEnable();
                    OnPropertyChanged(nameof(SelectedItemChuaHoatDong));
                }
            }
        }

        /// <summary>
        /// Command of Btn
        /// </summary>
        private ICommand _ReplaceCommand;
        public ICommand ReplaceCommand
        {
            get
            {
                if (_ReplaceCommand == null)
                {
                    _ReplaceCommand = new RelayCommand(ActionWhenReplaceBtnClicked, StatusOfBtn);
                }
                return _ReplaceCommand;
            }
        }

        private bool _StatusOfBtn;
        public bool StatusOfBtn
        {
            get => _StatusOfBtn;
            set
            {
                if (_StatusOfBtn != value)
                {
                    _StatusOfBtn = value;
                    OnPropertyChanged(nameof(StatusOfBtn));
                }
            }
        }
        LoaiSan_Service LoaiSan_Database;
        HoatDongHienTai_Service HoatDongHienTai_Database;
        DanhSachHienTai_NuocUong_Service DanhSachNuocUong_Database;

        /// <summary>
        /// Constructor
        /// </summary>
        public Replace_Field_ViewModel()
        {
            LoaiSan_Database = new LoaiSan_Service();
            HoatDongHienTai_Database = new HoatDongHienTai_Service();
            DanhSachNuocUong_Database = new DanhSachHienTai_NuocUong_Service();
        }

        public Dictionary<int, string> GetDataForComboboxLoaiSan()
        {
            //Get List Data of LoaiSan from Db.
            Dictionary<int, string> temp = new Dictionary<int, string>();
            var listLoaiSan = LoaiSan_Database.GetAll();
            for (int i = 0; i < listLoaiSan.Count; i++)
            {
                temp.Add(i, listLoaiSan[i].BaseObject.TenObject);
            }
            return temp;
        }

        public void ActionWhenChangeLoaiSan()
        {
            DanhSach_SanDangHoatDong =  GetDataForFirst(LoaiSanSelected);
            DanhSach_SanChuaHoatDong =  GetDataForDest(LoaiSanSelected);
        }

        /// <summary>
        /// Get Data for DanhSach_DangHoatDong
        /// </summary>
        /// <param name="loaiSanIndex"></param>
        /// <returns></returns>
        public ObservableCollection<HoatDongHienTaiModel> GetDataForFirst(int loaiSanIndex)
        {
            ObservableCollection<HoatDongHienTaiModel> result = new ObservableCollection<HoatDongHienTaiModel>();
            foreach(var item in DanhSachHoatDongHienTai)
            {
                if(item.HoatDongCuaSan.San.IdLoaiSan == (int)loaiSanIndex && item.TrangThaiSan == "Đang được sử dụng")
                {
                    result.Add(item.Clone());
                }
                else
                { continue; }
            }
            return result;
        }

        /// <summary>
        /// Get Data for DanhSach_ChuaHoatDong
        /// </summary>
        /// <param name="loaiSanIndex"></param>
        /// <returns></returns>
        public ObservableCollection<HoatDongHienTaiModel> GetDataForDest(int loaiSanIndex)
        {
            ObservableCollection<HoatDongHienTaiModel> result = new ObservableCollection<HoatDongHienTaiModel>();
            foreach (var item in DanhSachHoatDongHienTai)
            {
                if (item.HoatDongCuaSan.San.IdLoaiSan == (int)loaiSanIndex && item.TrangThaiSan == "Sẵn sàng sử dụng")
                {
                    result.Add(item.Clone());
                }
                else
                { continue; }
            }
            return result;
        }

        /// <summary>
        /// Action when click button Replace
        /// </summary>
        public void ActionWhenReplaceBtnClicked()
        {
            HoatDongHienTaiModel dataOfFirstItem = new HoatDongHienTaiModel();
            HoatDongHienTaiModel dataOfSecondItem = new HoatDongHienTaiModel();
            
            //Get Data of ItemSelected to temp variable
            dataOfFirstItem = SelectedItemDangHoatDong.Clone();
            dataOfSecondItem = SelectedItemChuaHoatDong.Clone();

            //Get Infor like ID San, Loai San ...
            dataOfFirstItem.HoatDongCuaSan.San = SelectedItemChuaHoatDong.HoatDongCuaSan.San.Clone();
            dataOfSecondItem.HoatDongCuaSan.San = SelectedItemDangHoatDong.HoatDongCuaSan.San.Clone();

            //Update DanhSachNuocUong
            DanhSachNuocUong_Database.UpdateIdSan(SelectedItemDangHoatDong.HoatDongCuaSan.San, SelectedItemChuaHoatDong.HoatDongCuaSan.San);
            
            //Update information from first to dest into Database.
            HoatDongHienTai_Database.UpdateItem(dataOfFirstItem);
            HoatDongHienTai_Database.UpdateGioKetThuc(dataOfFirstItem);
            HoatDongHienTai_Database.UpdateGioVaoSan(dataOfFirstItem);

            //Update information from dest to first item into Database
            HoatDongHienTai_Database.UpdateItem(dataOfSecondItem);
            HoatDongHienTai_Database.UpdateGioKetThuc(dataOfSecondItem);
            HoatDongHienTai_Database.UpdateGioVaoSan(dataOfSecondItem);

            LoadData();
        }

        public void LoadData()
        {
            DanhSachHoatDongHienTai = HoatDongHienTai_Database.GetAll();
            DanhSach_SanDangHoatDong = GetDataForFirst(LoaiSanSelected);
            DanhSach_SanChuaHoatDong = GetDataForDest(LoaiSanSelected);
        }

        //Status of Button
        public bool IsEnable()
        {
            bool l_IsUpdate = false;
            if(SelectedItemChuaHoatDong.TrangThaiSan.Length > 1 && SelectedItemDangHoatDong.TrangThaiSan.Length > 1)
            {
                //Selected
                l_IsUpdate = true;
            }
            return l_IsUpdate;
        }

    }
}
