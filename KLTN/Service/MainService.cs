using KLTN.Models;
using KLTN.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.Service
{
    public abstract class MainService<T>
    {
        public abstract ObservableCollection<T> GetAll();
        public abstract bool Add(T parameter);
        public abstract bool UpdateItem(T parameter);
    }
}
