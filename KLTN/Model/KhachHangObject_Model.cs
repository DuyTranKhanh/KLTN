
namespace KLTN.Model
{
    public class KhachHangObject_Model
    {
        private BaseObject_Model _BaseObject;
        private string _SdtObject;
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
        public string SdtObject
        {
            get => _SdtObject;
            set
            {
                if (_SdtObject != value)
                {
                    _SdtObject = value;
                }
            }
        }
        public KhachHangObject_Model Clone()
        {
            KhachHangObject_Model item = new KhachHangObject_Model();
            item.BaseObject = BaseObject.Clone();
            item.SdtObject = SdtObject;
            return item;
        }
    }
}
