using KLTN.Model;
using KLTN.Models;
using KLTN.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.Service
{
    public class DanhSachHoaDon_NuocUong_Service : MainService<HoatDongNuocUong_Model>
    {
        KLTN_DatabaseEntities Database;
        public DanhSachHoaDon_NuocUong_Service()
        {
            Database = new KLTN_DatabaseEntities();
        }
        public override bool Add(HoatDongNuocUong_Model parameter)
        {
            bool _IsAdd = false;
            try
            {
                var temp = new DanhSachHoaDon_NuocUong_Db();
                temp.Id_NuocUong = parameter.IdNuocUong;
                temp.Id_HoaDon = parameter.IdHoaDon;
                temp.Ten_NuocUong = parameter.TenNuocUong;
                temp.SoLuong = parameter.SoLuong;
                temp.GiaTien = parameter.GiaTien;
                Database.DanhSachHoaDon_NuocUong_Db.Add(temp);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public override ObservableCollection<HoatDongNuocUong_Model> GetAll()
        {
            ObservableCollection<HoatDongNuocUong_Model> objList = new ObservableCollection<HoatDongNuocUong_Model>();
            try
            {
                var objQuery = from KhachHang in Database.DanhSachHoaDon_NuocUong_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    var temp = new HoatDongNuocUong_Model();
                    temp.IdHoaDon = item.Id_HoaDon;
                    temp.IdNuocUong = Convert.ToInt32(item.Id_NuocUong);
                    temp.TenNuocUong = item.Ten_NuocUong;
                    temp.SoLuong = Convert.ToInt32(item.SoLuong);
                    temp.GiaTien = Convert.ToInt32(item.GiaTien);
                    objList.Add(temp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public ObservableCollection<HoatDongNuocUong_Model> GetByIdHoaDon(int idHoaDon)
        {
            ObservableCollection<HoatDongNuocUong_Model> objList = new ObservableCollection<HoatDongNuocUong_Model>();
            try
            {
                var objQuery = from KhachHang in Database.DanhSachHoaDon_NuocUong_Db
                               where KhachHang.Id_HoaDon == idHoaDon
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    var temp = new HoatDongNuocUong_Model();
                    temp.IdHoaDon = item.Id_HoaDon;
                    temp.IdNuocUong = Convert.ToInt32(item.Id_NuocUong);
                    temp.TenNuocUong = item.Ten_NuocUong;
                    temp.SoLuong = Convert.ToInt32(item.SoLuong);
                    temp.GiaTien = Convert.ToInt32(item.GiaTien);
                    objList.Add(temp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public override bool UpdateItem(HoatDongNuocUong_Model parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.DanhSachHoaDon_NuocUong_Db.Where(m => m.Id_HoaDon == parameter.IdHoaDon && m.Id_NuocUong == parameter.IdNuocUong).First();
                if (item != null)
                {
                    item.SoLuong = parameter.SoLuong;
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
