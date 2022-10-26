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
        private LoaiSan_Model _SelectedItem;
        public LoaiSan_Model SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if(_SelectedItem != value)
                {
                    _SelectedItem = value;
                    TenLoaiSan = value.Ten_LoaiSan;
                    IsEnableRemove = true;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private bool _IsEnableEdit;
        public bool IsEnableEdit
        {
            get => _IsEnableEdit;
            set
            {
                if(_IsEnableEdit != value)
                {
                    _IsEnableEdit = value;
                    OnPropertyChanged(nameof(IsEnableEdit));
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

        private bool _IsEnableRemove;
        public bool IsEnableRemove
        {
            get => _IsEnableRemove;
            set
            {
                if (_IsEnableRemove != value)
                {
                    _IsEnableRemove = value;
                    OnPropertyChanged(nameof(IsEnableRemove));
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
                    OnPropertyChanged(nameof(_IsEnableAdd));
                }
            }
        }


        #region Command
        #region Fields
        private ICommand _ClickEditCommand;
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
                    _ClickRemoveCommand = new RelayCommand(Remove, CanExecute);
                }
                return _ClickRemoveCommand;
            }
        }

        public ICommand ClickEditCommand
        {
            get
            {
                if (_ClickEditCommand == null)
                {
                    _ClickEditCommand = new RelayCommand(Edit, CanExecute);
                }
                return _ClickEditCommand;
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
            string[] ListName = { "San 5", "San 7", "San 11" };
            //Hard code
            DanhSach_LoaiSan.Clear();
            for (int i = 0; i < 3; i++)
            {
                LoaiSan_Model temp = new LoaiSan_Model();
                temp.Id_LoaiSan = i;
                temp.Ten_LoaiSan = ListName[i];
                DanhSach_LoaiSan.Add(temp);

            }
        }

        #region Method
        public void Save()
        {
            SelectedItem.Ten_LoaiSan = TenLoaiSan;

            DanhSach_LoaiSan[SelectedItem.Id_LoaiSan].Ten_LoaiSan = SelectedItem.Ten_LoaiSan;
        }

        public void Edit()
        {
            IsEnableEdit = true;
            IsEnableSave = true;
        }
        public bool CanExecute()
        {
            return true;
        }

        public void Remove()
        {
            //DanhSach_LoaiSan[SelectedItem.Id_LoaiSan].Ten_LoaiSan = "";
            foreach(var item in DanhSach_LoaiSan)
            {
                if(item.Id_LoaiSan == SelectedItem.Id_LoaiSan)
                {
                    DanhSach_LoaiSan.Remove(item);
                    Default();
                    break;
                }
            }
        }

        public void Default()
        {
            SelectedItem = DanhSach_LoaiSan[0];
            TenLoaiSan = SelectedItem.Ten_LoaiSan;

        }

        public void Add()
        {
            IsEnableEdit = true;
            LoaiSan_Model temp = new LoaiSan_Model();
            temp.Ten_LoaiSan = TenLoaiSan;
            temp.Id_LoaiSan = DanhSach_LoaiSan.Last().Id_LoaiSan + 1;

            DanhSach_LoaiSan.Add(temp);
        }
        #endregion
    }
}
