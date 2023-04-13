using KLTN.Model;
using KLTN.Models;
using KLTN.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace KLTN.Service
{
    public class NuocUong_Service : MainService<NuocUongObject_Model>
    {
        KLTN_DatabaseEntities Database;
        public NuocUong_Service()
        {
            Database = new KLTN_DatabaseEntities();
        }
        public override bool Add(NuocUongObject_Model parameter)
        {
            bool _IsAdd = false;
            try
            {
                var temp = new NuocUong_Db();
                temp.Id_NuocUong = parameter.BaseObject.IdObject;
                temp.Ten_NuocUong = parameter.BaseObject.TenObject;
                temp.GiaTien = Convert.ToDecimal(parameter.GiaTienObject);
                temp.TrangThai_NuocUong = parameter.BaseObject.TrangThaiObject;
                Database.NuocUong_Db.Add(temp);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public override ObservableCollection<NuocUongObject_Model> GetAll()
        {
            ObservableCollection<NuocUongObject_Model> objList = new ObservableCollection<NuocUongObject_Model>();
            try
            {
                var objQuery = from KhachHang in Database.NuocUong_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    var temp = new NuocUongObject_Model();
                    temp.BaseObject.IdObject = item.Id_NuocUong;
                    temp.GiaTienObject = item.GiaTien.ToString();
                    temp.BaseObject.TenObject = item.Ten_NuocUong;
                    temp.BaseObject.TrangThaiObject = item.TrangThai_NuocUong;
                    objList.Add(temp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public override bool UpdateItem(NuocUongObject_Model parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.NuocUong_Db.Find(parameter.BaseObject.IdObject);
                {
                    if(item != null)
                    {

                        item.GiaTien = Convert.ToDecimal( parameter.GiaTienObject);
                        item.Ten_NuocUong = parameter.BaseObject.TenObject;
                        item.TrangThai_NuocUong = parameter.BaseObject.TrangThaiObject;
                        var NoOfRowsAffected = Database.SaveChanges();
                        l_IsUpdate = NoOfRowsAffected > 0;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
