

namespace KLTN.Model
{
    public class NuocUongObject_Model
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
        private string _GiaTienObject;
        public string GiaTienObject
        {
            get => _GiaTienObject;
            set
            {
                if (_GiaTienObject != value)
                {
                    _GiaTienObject = value;
                }
            }
        }

        public NuocUongObject_Model Clone()
        {
            var item = new NuocUongObject_Model();
            item.BaseObject = BaseObject.Clone();
            item.GiaTienObject = GiaTienObject;
            return item;
        }
    }
}
