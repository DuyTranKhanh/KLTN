using KLTN.Model;
using KLTN.Models;
using KLTN.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.Service
{
    public class LoaiSan_Service : MainService<LoaiSan_Model>
    {
        KLTN_DatabaseEntities Database;
        public LoaiSan_Service()
        {
            Database = new KLTN_DatabaseEntities();
        }
        public override bool Add(LoaiSan_Model parameter)
        {
            bool _IsAdd = false;
            try
            {
                var temp = new LoaiSan_Db();
                temp.Id_LoaiSan = parameter.BaseObject.IdObject;
                temp.Ten_LoaiSan = parameter.BaseObject.TenObject;
                temp.TrangThai_LoaiSan = parameter.BaseObject.TrangThaiObject;
                Database.LoaiSan_Db.Add(temp);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public override ObservableCollection<LoaiSan_Model> GetAll()
        {
            ObservableCollection<LoaiSan_Model> objList = new ObservableCollection<LoaiSan_Model>();
            try
            {
                var objQuery = from KhachHang in Database.LoaiSan_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    var temp = new LoaiSan_Model();
                    temp.BaseObject.IdObject = item.Id_LoaiSan;
                    temp.BaseObject.TenObject = item.Ten_LoaiSan;
                    temp.BaseObject.TrangThaiObject = item.TrangThai_LoaiSan;
                    objList.Add(temp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public override bool UpdateItem(LoaiSan_Model parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.LoaiSan_Db.Find(parameter.BaseObject.IdObject);
                if(item != null)
                {
                    item.Ten_LoaiSan = parameter.BaseObject.TenObject;
                    item.TrangThai_LoaiSan = parameter.BaseObject.TrangThaiObject;
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }

            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
