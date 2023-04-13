﻿
namespace KLTN.Model
{
    public class LoaiSan_Model
    {
        private BaseObject_Model _BaseObject;
        public BaseObject_Model BaseObject
        {
            get
            {
                if (_BaseObject == null)
                {
                    _BaseObject = new BaseObject_Model();
                }
                return _BaseObject;
            }
            set
            {
                if (_BaseObject != value)
                {
                    _BaseObject = value;
                }
            }
        }

        public LoaiSan_Model Clone()
        {
            LoaiSan_Model item = new LoaiSan_Model();
            item.BaseObject = BaseObject.Clone();
            return item;
        }

    }
}
