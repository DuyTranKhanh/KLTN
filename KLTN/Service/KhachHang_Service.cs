using KLTN.Model;
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

        public ObservableCollection<KhachHangObject_Model> GetAll()
        {
            ObservableCollection<KhachHangObject_Model> objList = new ObservableCollection<KhachHangObject_Model>();
            try
            {
                var objQuery = from KhachHang in Database.KhachHang_Db
                               select KhachHang;
                foreach(var item in objQuery)
                {
                        var temp = new KhachHangObject_Model();
                        temp.BaseObject.IdObject = item.Id_KhachHang;
                        temp.SdtObject = item.Sdt_KhachHang;
                        temp.BaseObject.TenObject = item.Ten_KhachHang;
                        temp.BaseObject.TrangThaiObject = item.TrangThai_KhachHang;
                        objList.Add(temp);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return objList;
        }

        public ObservableCollection<KhachHangObject_Model> GetWithCondition()
        {
            ObservableCollection<KhachHangObject_Model> objList = new ObservableCollection<KhachHangObject_Model>();
            try
            {
                var objQuery = from KhachHang in Database.KhachHang_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    if(item.TrangThai_KhachHang == "Không hoạt động")
                    {
                        continue;
                    }
                    else
                    {
                        var temp = new KhachHangObject_Model();
                        temp.BaseObject.IdObject = item.Id_KhachHang;
                        temp.SdtObject = item.Sdt_KhachHang;
                        temp.BaseObject.TenObject = item.Ten_KhachHang;
                        temp.BaseObject.TrangThaiObject = item.TrangThai_KhachHang;
                        objList.Add(temp);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public bool Add(KhachHangObject_Model objectIn)
        {
            bool _IsAdd = false;
            if (objectIn.SdtObject.ToString().Length > 10)
                throw new ArgumentException("Invalid Sdt");
            try
            {
                var temp = new KhachHang_Db();
                temp.Id_KhachHang = objectIn.BaseObject.IdObject;
                temp.Ten_KhachHang = objectIn.BaseObject.TenObject;
                temp.Sdt_KhachHang = objectIn.SdtObject;
                temp.TrangThai_KhachHang = objectIn.BaseObject.TrangThaiObject;
                Database.KhachHang_Db.Add(temp);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }catch(Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public bool Update(KhachHangObject_Model objectIn)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.KhachHang_Db.Find(objectIn.BaseObject.IdObject);
                item.Sdt_KhachHang = objectIn.SdtObject;
                item.Ten_KhachHang = objectIn.BaseObject.TenObject;
                item.TrangThai_KhachHang = objectIn.BaseObject.TrangThaiObject;
                var NoOfRowsAffected = Database.SaveChanges();
                l_IsUpdate = NoOfRowsAffected > 0;
            }
            catch(Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
