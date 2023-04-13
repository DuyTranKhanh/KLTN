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
                var temp = new San();
                temp.Id_San = parameter.BaseObject.IdObject;
                temp.Ten_LoaiSan = parameter.TenLoaiSan;
                temp.Ten_San = parameter.BaseObject.TenObject;
                temp.TrangThai = parameter.BaseObject.TrangThaiObject;
                Database.Sans.Add(temp);
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
                var objQuery = from listSan in Database.Sans
                               select listSan;
                foreach (var item in objQuery)
                {
                    var temp = new SanObject_Model();
                    temp.BaseObject.IdObject = item.Id_San;
                    temp.BaseObject.TenObject = item.Ten_San;
                    temp.TenLoaiSan = item.Ten_LoaiSan;
                    temp.BaseObject.TrangThaiObject = item.TrangThai;
                    objList.Add(temp);
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
                var item = Database.Sans.Find(parameter.BaseObject.IdObject);
                if(item != null)
                {

                    item.TrangThai = parameter.BaseObject.TrangThaiObject;
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
