
namespace KLTN.Model
{
    public class SanObject_Model
    {
        private BaseObject_Model _BaseObject;
        private int _IdLoaiSan;
        private string _TenLoaiSan;
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
        public int IdLoaiSan
        {
            get => _IdLoaiSan;
            set
            {
                if (_IdLoaiSan != value)
                {
                    _IdLoaiSan = value;
                }
            }
        }

        public string TenLoaiSan
        {
            get => _TenLoaiSan;
            set
            {
                if(_TenLoaiSan != value)
                {
                    _TenLoaiSan = value;
                }
            }
        }
        public SanObject_Model Clone()
        {
            var item = new SanObject_Model();
            item.BaseObject = BaseObject.Clone();
            item.IdLoaiSan = IdLoaiSan;
            item.TenLoaiSan = TenLoaiSan;
            return item;
        }
    }
}
