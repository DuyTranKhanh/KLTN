using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.Model
{
    public class BaseObject_Model
    {
        private int _IdObject;
        private string _TenObject;
        private string _TrangThaiObject;

        public int IdObject
        {
            get => _IdObject;
            set
            {
                if(_IdObject != value)
                {
                    _IdObject = value;
                }
            }
        }

        public string TenObject
        {
            get => _TenObject;
            set
            {
                if(_TenObject != value)
                {
                    _TenObject = value;
                }
            }
        }

        public string TrangThaiObject
        {
            get => _TrangThaiObject;
            set
            {
                if (_TrangThaiObject != value)
                {
                    _TrangThaiObject = value;
                }
            }
        }

        public BaseObject_Model Clone()
        {
            var item = new BaseObject_Model();
            item.TenObject = TenObject;
            item.IdObject = IdObject;
            item.TrangThaiObject = TrangThaiObject;
            return item;
        }
    }
}
