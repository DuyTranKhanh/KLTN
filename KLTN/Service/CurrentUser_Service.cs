using KLTN.Model;
using KLTN.Models;
using KLTN.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.Service
{
    public class CurrentUser_Service : MainService<AccountObject_Model>
    {
        KLTN_DatabaseEntities Database;
        public CurrentUser_Service()
        {
            Database = new KLTN_DatabaseEntities();
        }
        public override bool Add(AccountObject_Model parameter)
        {
            throw new NotImplementedException();
        }

        public override ObservableCollection<AccountObject_Model> GetAll()
        {
            ObservableCollection<AccountObject_Model> objList = new ObservableCollection<AccountObject_Model>();
            try
            {
                var objQuery = from KhachHang in Database.CurrentUser_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    var temp = new AccountObject_Model();
                    temp.Account = item.Account;
                    temp.Sdt = item.Sdt;
                    temp.Cmnd = item.Cmnd;
                    temp.Password = item.Password;
                    temp.HoVaTen = item.HoVaTen;
                    temp.Status = item.TrangThai_Account;
                    temp.IsAdmin = Convert.ToBoolean(item.IsAdmin);
                    objList.Add(temp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public AccountObject_Model GetSingleItem()
        {
            try
            {
                AccountObject_Model objSingle = new AccountObject_Model();
                var objectUser = Database.CurrentUser_Db.Find(0);
                {
                    objSingle.Account = objectUser.Account;
                    objSingle.Sdt = objectUser.Sdt;
                    objSingle.Cmnd = objectUser.Cmnd;
                    objSingle.Password = objectUser.Password;
                    objSingle.HoVaTen = objectUser.HoVaTen;
                    objSingle.Status = objectUser.TrangThai_Account;
                    objSingle.IsAdmin = Convert.ToBoolean(objectUser.IsAdmin);
                }
                return objSingle;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public override bool UpdateItem(AccountObject_Model parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.CurrentUser_Db.Find(0);
                if (item != null)
                {
                    item.Account = parameter.Account;
                    item.HoVaTen = parameter.HoVaTen;
                    item.IsAdmin = parameter.IsAdmin;
                    item.Sdt = parameter.Sdt.ToString();
                    item.Cmnd = parameter.Cmnd.ToString();
                    item.Password = parameter.Password;
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }

        public bool ModifyItem(AccountObject_Model parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.CurrentUser_Db.Find(0);
                if (item != null)
                {
                    item.Sdt = parameter.Sdt.ToString();
                    item.Cmnd = parameter.Cmnd.ToString();
                    item.Password = parameter.Password;
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
