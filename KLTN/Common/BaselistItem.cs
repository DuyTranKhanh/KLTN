//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KLTN.Common
//{
//    public class BaselistItem<T> : ObservableObject
//    {
//        private T _Data;
//        public T Data
//        {
//            get => _Data;
//            set
//            {
//                if (_Data == null || value == null || _Data.GetHashCode() != value.GetHashCode())
//                {
//                    _Data = value;
//                    OnPropertyChanged();
//                }
//            }
//        }

//        private string _Name;
//        public string Name
//        {
//            get => _Name;
//            set
//            {
//                if(_Name != value)
//                {
//                    _Name = value;
//                    OnPropertyChanged(nameof(Name));
//                }
//            }
//        }
//        public BaselistItem<T> Parent { get; set; }
//        private List<BaselistItem<T>> _Child;
//        public List<BaselistItem<T>> Child
//        {
//            get
//            {
//                if(_Child == null)
//                {
//                    _Child = new List<BaselistItem<T>>();
//                }
//                return _Child;
//            }
//        }
//        public int Index => Parent.Child.IndexOf(this);

//        public BaselistItem<T> AddChild(BaselistItem<T> child)
//        {
//            Child.Add(child);
//            child.Parent = this;
//            OnPropertyChanged();
//            OnPropertyChanged(Child);
//            return this;
//        }
//    }
//}
