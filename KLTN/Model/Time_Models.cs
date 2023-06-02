using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.Model
{
    public class DateTime_Model
    {
        private string _Year;
        private string _Month;
        private string _Day;

        public string Day
        {
            get => _Day;
            set
            {
                if (_Day != value)
                {
                    _Day = value;
                }
            }
        }
        public string Month
        {
            get => _Month;
            set
            {
                if (_Month != value)
                {
                    _Month = value;
                }
            }
        }

        public string Year
        {
            get => _Year;
            set
            {
                if (_Year != value)
                {
                    _Year = value;
                }
            }
        }

        private string _Hour;
        private string _Minute;

        public string Hour
        {
            get => _Hour;
            set
            {
                if (_Hour != value)
                {
                    _Hour = value;
                }
            }
        }

        public string Minute
        {
            get => _Minute;
            set
            {
                if (_Minute != value)
                {
                    _Minute = value;
                }
            }
        }

        public DateTime_Model()
        {
            Minute = string.Empty;
            Year = string.Empty;
            Month = string.Empty;
            Hour = string.Empty;
            Day = string.Empty;
        }
        public DateTime_Model Clone()
        {
            var item = new DateTime_Model();
            item.Year = Year;
            item.Month = Month;
            item.Day = Day;
            item.Minute = Minute;
            item.Hour = Hour;
            return item;
        }
    }

}
