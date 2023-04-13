using KLTN.Model;
using KLTN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.Service
{
    public class BangGia_Service : MainService<BangGiaObject_Model>
    {
        KLTN_DatabaseEntities Database;
        public BangGia_Service()
        {
            Database = new KLTN_DatabaseEntities();
        }
        public override bool Add(BangGiaObject_Model parameter)
        {
            bool _IsAdd = false;
            try
            {
                var temp = new BangGia();
                temp.Id_BangGia = parameter.BaseObject.IdObject;
                temp.Id_LoaiSan = parameter.IdLoaiSan;
                temp.Ten_LoaiSan = parameter.BaseObject.TenObject;
                temp.GioBatDau = parameter.ThoiGianBatDau.ToString();
                temp.GioKetThuc = parameter.ThoiGianKetThuc.ToString();
                temp.Tien = parameter.GiaTienObject;
                temp.TrangThai = parameter.BaseObject.TrangThaiObject;
                temp.NgayTao = parameter.NgayTao;
                Database.BangGias.Add(temp);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public override ObservableCollection<BangGiaObject_Model> GetAll()
        {
            throw new NotImplementedException();
        }

        public override bool UpdateItem(BangGiaObject_Model parameter)
        {
            throw new NotImplementedException();
        }
    }
}
