
using System.ComponentModel;


namespace KLTN.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public virtual void AddItemFunction()
        {

        }

        public virtual void UpdateStatusOfItemFunction()
        {

        }
        #endregion
    }
}
