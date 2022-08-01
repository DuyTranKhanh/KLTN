using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace KLTN.Common
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string name = "")
        {
            OnPropertyChanged(this, name);
        }
        public virtual void OnPropertyChanged(object sender, string name = "")
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(name));
        }
    }
}
