using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.ViewModel
{
    public partial class DatSan_ViewModel : BaseViewModel
    {
        public DateTime StartDay = DateTime.Today;

        public DateTime RangeDay = DateTime.Today.AddDays(3);

        private DateTime _UsingDay = DateTime.Today;
        public DateTime UsingDay
        {
            get
            {
                return _UsingDay;
            }

            set
            {
                if(_UsingDay != value)
                {
                    _UsingDay = value;
                    OnPropertyChanged(nameof(UsingDay));
                }
            }
        }
    }
}
