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
            throw new NotImplementedException();
        }

        public override ObservableCollection<AccountObject_Model> GetAll()
        {
            throw new NotImplementedException();
        }

        public override bool UpdateItem(AccountObject_Model parameter)
        {
            throw new NotImplementedException();
        }

        public bool Search(string account,string password)
        {
            bool result = false;
            try
            {
                var objectUser = Database.AccountNhanViens.Find(account);
                if(objectUser != null && objectUser.Password == password)
                {
                    result = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
