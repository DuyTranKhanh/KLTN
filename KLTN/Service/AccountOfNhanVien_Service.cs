using KLTN.Model;
using KLTN.Models;
using KLTN.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.Service
{
    public class AccountOfNhanVien_Service : MainService<AccountObject_Model>
    {
        KLTN_DatabaseEntities Database;
        public AccountOfNhanVien_Service()
        {
            Database = new KLTN_DatabaseEntities();
        }
        public override bool Add(AccountObject_Model parameter)
        {
            bool _IsAdd = false;
            try
            {
                var temp = new Account_Db();
                temp.Account = parameter.Account;
                temp.Password = parameter.Password;
                temp.HoVaTen = parameter.HoVaTen;
                temp.Sdt = parameter.Sdt.ToString();
                temp.Cmnd = parameter.Cmnd.ToString();
                temp.TrangThai_Account = parameter.Status;
                temp.IsAdmin = parameter.IsAdmin;
                Database.Account_Db.Add(temp);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public override ObservableCollection<AccountObject_Model> GetAll()
        {
            ObservableCollection<AccountObject_Model> objList = new ObservableCollection<AccountObject_Model>();
            try
            {
                var objQuery = from KhachHang in Database.Account_Db
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

        public override bool UpdateItem(AccountObject_Model parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.Account_Db.Find(parameter.Account.ToString());
                if(item != null)
                {
                    item.Sdt = parameter.Sdt.ToString();
                    item.Cmnd = parameter.Cmnd.ToString();
                    item.TrangThai_Account = parameter.Status;
                    item.IsAdmin = parameter.IsAdmin;
                    item.Password = parameter.Password;
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
        public int Search(string account,string password)
        {
            int result = 0;
            try
            {
                var objectUser = Database.Account_Db.Find(account);
                if(objectUser == null)
                {
                    result = 0; // Khong co account nay
                }
                else if(objectUser != null && objectUser.Password != password)
                {
                    result = -1; // Khong dung mat khau
                }
                else if(objectUser != null && objectUser.Password == password && objectUser.TrangThai_Account != "Hoạt động")
                {
                    result = -2; // Trang thai khong hop le
                }
                else if(objectUser != null && objectUser.Password == password && objectUser.TrangThai_Account == "Hoạt động")
                {
                    result = 1; // Hop le
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public AccountObject_Model GetSingleItem(string account, string password)
        {
            try
            {
                AccountObject_Model objSingle = new AccountObject_Model();
                var objectUser = Database.Account_Db.Find(account);
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

        public bool ModifyItem(AccountObject_Model parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.Account_Db.Find(parameter.Account);
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
