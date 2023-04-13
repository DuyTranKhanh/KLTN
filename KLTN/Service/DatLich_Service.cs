using KLTN.Model;
using KLTN.Models;
using KLTN.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.Service
{
    //Chua thuc hien mapping Ngay dat san va Ngay su dung san
    public class DatLich_Service : MainService<LichDatObject_Model>
    {
        KLTN_DatabaseEntities Database;
        public DatLich_Service()
        {
            Database = new KLTN_DatabaseEntities();
        }
        public override bool Add(LichDatObject_Model parameter)
        {
            bool _IsAdd = false;
            try
            {
                var temp = new LichDat_Db();
                temp.Id_KhachHang = parameter.KhachHang.BaseObject.IdObject;
                temp.Ten_KhachHang = parameter.KhachHang.BaseObject.TenObject;
                temp.Sdt_KhachHang = parameter.KhachHang.SdtObject;
                temp.Id_San = parameter.San.BaseObject.IdObject;
                temp.Ten_San = parameter.San.BaseObject.TenObject;
                temp.Id_LoaiSan = parameter.San.IdLoaiSan;
                temp.Ten_LoaiSan = parameter.San.TenLoaiSan;
                temp.GioBatDau = parameter.GioBatDau;
                temp.GioKetThuc = parameter.GioKetThuc;
                temp.TrangThai_LichDat = parameter.TrangThai;
                Database.LichDat_Db.Add(temp);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public override ObservableCollection<LichDatObject_Model> GetAll()
        {
            ObservableCollection<LichDatObject_Model> objList = new ObservableCollection<LichDatObject_Model>();
            try
            {
                var objQuery = from KhachHang in Database.LichDat_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    var temp = new LichDatObject_Model();
                    temp.IdLichDat = item.Id_LichDat;
                    temp.GioKetThuc = item.GioKetThuc;
                    temp.GioBatDau = item.GioBatDau;
                    temp.GioBatDau = item.GioBatDau;
                    temp.KhachHang.BaseObject.IdObject = (int)item.Id_KhachHang;
                    temp.KhachHang.BaseObject.TenObject = item.Ten_KhachHang;
                    temp.KhachHang.SdtObject = item.Sdt_KhachHang;
                    temp.San.IdLoaiSan = (int)item.Id_LoaiSan;
                    temp.San.BaseObject.IdObject = (int)item.Id_San;
                    temp.San.BaseObject.TenObject = item.Ten_San;
                    temp.San.TenLoaiSan = item.Ten_LoaiSan;
                    temp.TrangThai = item.TrangThai_LichDat;
                    objList.Add(temp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public override bool UpdateItem(LichDatObject_Model parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.LichDat_Db.Find(parameter.IdLichDat.ToString());
                if (item != null)
                {
                    item.Sdt_KhachHang = parameter.KhachHang.SdtObject;
                    item.TrangThai_LichDat = parameter.TrangThai;
                    item.GioBatDau = parameter.GioBatDau;
                    item.GioKetThuc = parameter.GioKetThuc;
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
