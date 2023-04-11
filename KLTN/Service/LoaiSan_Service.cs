using KLTN.Models;
using KLTN.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.Service
{
    public class LoaiSan_Service : MainService<BaseObjectSingle>
    {
        KLTN_DatabaseEntities Database;
        public LoaiSan_Service()
        {
            Database = new KLTN_DatabaseEntities();
        }
        public override bool Add(BaseObjectSingle parameter)
        {
            throw new NotImplementedException();
        }

        public override ObservableCollection<BaseObjectSingle> GetAll()
        {
            throw new NotImplementedException();
        }

        public override bool UpdateItem(BaseObjectSingle parameter)
        {
            throw new NotImplementedException();
        }
    }
}
