using KLTN.Model;
using KLTN.Models;
using KLTN.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.Service
{
    public class San_Service : MainService<SanObject_Model>
    {
        KLTN_DatabaseEntities Database;
        public San_Service()
        {
            Database = new KLTN_DatabaseEntities();
        }
        public override bool Add(SanObject_Model parameter)
        {
            bool _IsAdd = false;
            try
            {
                var temp = new San_Db();
                temp.Id_San = parameter.BaseObject.IdObject;
                temp.Ten_LoaiSan = parameter.TenLoaiSan;
                temp.Ten_San = parameter.BaseObject.TenObject;
                temp.TrangThai_San = parameter.BaseObject.TrangThaiObject;
                Database.San_Db.Add(temp);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public override ObservableCollection<SanObject_Model> GetAll()
        {
            ObservableCollection<SanObject_Model> objList = new ObservableCollection<SanObject_Model>();
            try
            {
                var objQuery = from listSan in Database.San_Db
                               select listSan;
                foreach (var item in objQuery)
                {
                    var temp = new SanObject_Model();
                    temp.BaseObject.IdObject = item.Id_San;
                    temp.BaseObject.TenObject = item.Ten_San;
                    temp.TenLoaiSan = item.Ten_LoaiSan;
                    temp.BaseObject.TrangThaiObject = item.TrangThai_San;
                    objList.Add(temp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public ObservableCollection<SanObject_Model> GetWithCondition()
        {
            ObservableCollection<SanObject_Model> objList = new ObservableCollection<SanObject_Model>();
            try
            {
                var objQuery = from listSan in Database.San_Db
                               select listSan;
                foreach (var item in objQuery)
                {
                    if(item.TrangThai_San == "Hoạt động")
                    {
                        var temp = new SanObject_Model();
                        temp.BaseObject.IdObject = item.Id_San;
                        temp.BaseObject.TenObject = item.Ten_San;
                        temp.TenLoaiSan = item.Ten_LoaiSan;
                        temp.BaseObject.TrangThaiObject = item.TrangThai_San;
                        objList.Add(temp);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public override bool UpdateItem(SanObject_Model parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.San_Db.Find(parameter.BaseObject.IdObject);
                if(item != null)
                {

                    item.TrangThai_San = parameter.BaseObject.TrangThaiObject;
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
