using KLTN.Models;
using KLTN.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.Service
{
    public class KhachHang_Service
    {
        KLTN_DatabaseEntities Database;
        public KhachHang_Service()
        {
            Database = new KLTN_DatabaseEntities();
        }

        public ObservableCollection<KhachHangObject> GetAll()
        {
            ObservableCollection<KhachHangObject> objList = new ObservableCollection<KhachHangObject>();
            try
            {
                var objQuery = from KhachHang in Database.KhachHangs
                               select KhachHang;
                foreach(var item in objQuery)
                {
                    var temp = new KhachHangObject();
                    temp.Id = item.Id_KhachHang;
                    temp.Sdt = item.Sdt_KhachTrang;
                    temp.TenObject = item.Ten_KhachHang;
                    temp.TrangThaiObject = item.TrangThai;
                    objList.Add(temp);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return objList;
        }

        public bool Add(KhachHangObject objectIn)
        {
            bool _IsAdd = false;
            if (objectIn.Sdt.ToString().Length > 10)
                throw new ArgumentException("Invalid Sdt");
            try
            {
                var temp = new KhachHang();
                temp.Id_KhachHang = objectIn.Id;
                temp.Ten_KhachHang = objectIn.TenObject;
                temp.Sdt_KhachTrang = objectIn.Sdt;
                temp.TrangThai = objectIn.TrangThaiObject;
                Database.KhachHangs.Add(temp);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }catch(Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public bool Update(KhachHangObject objectIn)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.KhachHangs.Find(objectIn.Id);
                item.Sdt_KhachTrang = objectIn.Sdt;
                item.Ten_KhachHang = objectIn.TenObject;
                item.TrangThai = objectIn.TrangThaiObject;
                var NoOfRowsAffected = Database.SaveChanges();
                l_IsUpdate = NoOfRowsAffected > 0;
            }
            catch(Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
