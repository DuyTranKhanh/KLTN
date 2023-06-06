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

        public DateTime_Model(DateTime item)
        {
            Minute = item.Minute.ToString().Trim();
            Year = item.Year.ToString().Trim();
            Month = item.Month.ToString().Trim();
            Hour = item.Hour.ToString().Trim();
            Day = item.Day.ToString().Trim();
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

        /// <summary>
        /// Compare Day, Month, Year with type DateTime
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool CompareDay(DateTime item)
        {
            DateTime_Model temp = new DateTime_Model(item);

            if(temp.Day != Day.Trim())
            {
                return false;
            }
            else if(temp.Month != Month.Trim())
            {
                return false;
            }
            else if (temp.Year != Year.Trim())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Compare with NgayThucHien HoaDon
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool CompareShortString(DateTime dateTime)
        {
            bool result = true;
            string item = DateTime.Today.ToShortDateString().Trim();
            if(item.Length != Day.Length)
            {
                result = false;
            }
            else
            {
                for(int i = 0; i < item.Length; i++)
                {
                    if(item[i] != Day[i])
                    {
                        result = false;
                    }
                }
            }
            return result;

        }
        /// <summary>
        /// Compare Day, Month, Year with type DateTime_Model
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool CompareDay(DateTime_Model item)
        {
            if (item.Day != Day)
            {
                return false;
            }
            else if (item.Month != Month)
            {
                return false;
            }
            else if (item.Year != Year)
            {
                return false;
            }
            return true;
        }

        public bool CompareHour(DateTime_Model item)
        {
            if (item.Hour != Hour)
            {
                return false;
            }
            else if (item.Minute != Minute)
            {
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Check if The day is past or present/ Future
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if Day is Past, False is otherwise</returns>
        public bool IsPastDay(DateTime item)
        {
            DateTime_Model temp = new DateTime_Model(item);
            if (Convert.ToInt32(temp.Year) > Convert.ToInt32(Year))
            {
                return true;
            }
            else if (Convert.ToInt32(temp.Month) > Convert.ToInt32(Month))
            {
                return true;
            }
            else if (Convert.ToInt32(temp.Day) > Convert.ToInt32(Day))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Calculate
        /// </summary>
        /// <param name="gioBatDau"></param>
        /// <param name="gioKetThuc"></param>
        /// <returns></returns>
        public string SoGioThue(DateTime_Model gioBatDau, DateTime_Model gioKetThuc)
        {
            int l_GioBatDau, l_PhutBatDau, l_GioKetThuc, l_PhutKetThuc, result = 0;
            l_GioBatDau = Convert.ToInt32(gioBatDau.Hour.Trim());
            l_PhutBatDau = Convert.ToInt32(gioBatDau.Minute.Trim());
            l_GioKetThuc = Convert.ToInt32(gioKetThuc.Hour.Trim());
            l_PhutKetThuc = Convert.ToInt32(gioKetThuc.Minute.Trim());
            //ex: 16: 00 17:00 
            if(l_PhutKetThuc > l_PhutBatDau)
            {
                result = (l_GioKetThuc - l_GioBatDau) * 60 + l_PhutKetThuc - l_PhutBatDau;
            }

            //ex: 16:30 17:20
            else
            {
                result = (l_GioKetThuc * 60 + l_PhutKetThuc) - (l_GioBatDau * 60 + l_PhutBatDau);
            }

            return result.ToString().Trim();
        }
    }

}
