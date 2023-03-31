
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

        /// <summary>
        /// Action when click button Add
        /// </summary>
        public virtual void AddItemFunction()
        {

        }

        /// <summary>
        /// Action when click button Disable/Enable
        /// </summary>
        public virtual void UpdateStatusOfItemFunction()
        {

        }

        /// <summary>
        /// Action when click button Save in CRUD
        /// </summary>
        public virtual void SaveDataToDatabase()
        {
            
        }

        /// <summary>
        /// Get data from Database
        /// </summary>
        public virtual void GetDataFromDatabase()
        {

        }


        #endregion
    }
}
