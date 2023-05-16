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
                var temp = new BangGia_Db();
                temp.Id_BangGia = parameter.BaseObject.IdObject;
                temp.Id_LoaiSan = parameter.IdLoaiSan;
                temp.Ten_LoaiSan = parameter.BaseObject.TenObject;
                temp.ThoiGianBatDau = parameter.ThoiGianBatDau.ToString();
                temp.ThoiGianKetThuc = parameter.ThoiGianKetThuc.ToString();
                temp.GiaTien = parameter.GiaTienObject;
                temp.TrangThai_BangGia = parameter.BaseObject.TrangThaiObject;
                temp.NgayTao = parameter.NgayTao;
                Database.BangGia_Db.Add(temp);
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
            ObservableCollection<BangGiaObject_Model> objList = new ObservableCollection<BangGiaObject_Model>();
            try
            {
                var objQuery = from KhachHang in Database.BangGia_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                        var temp = new BangGiaObject_Model();
                        temp.BaseObject.IdObject = item.Id_BangGia;
                        temp.IdLoaiSan = Convert.ToInt32(item.Id_LoaiSan);
                        temp.BaseObject.TrangThaiObject = item.TrangThai_BangGia;
                        temp.BaseObject.TenObject = item.Ten_LoaiSan;
                        temp.ThoiGianBatDau = item.ThoiGianBatDau;
                        temp.ThoiGianKetThuc = item.ThoiGianKetThuc;
                        temp.GiaTienObject = Convert.ToDecimal(item.GiaTien);
                        temp.NgayTao = item.NgayTao;
                        objList.Add(temp);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public ObservableCollection<BangGiaObject_Model> GetWithCondition()
        {
            ObservableCollection<BangGiaObject_Model> objList = new ObservableCollection<BangGiaObject_Model>();
            try
            {
                var objQuery = from KhachHang in Database.BangGia_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    if(item.TrangThai_BangGia == "Không hoạt động")
                    {
                        continue;
                    }
                    else
                    {
                        var temp = new BangGiaObject_Model();
                        temp.BaseObject.IdObject = item.Id_BangGia;
                        temp.IdLoaiSan = Convert.ToInt32(item.Id_LoaiSan);
                        temp.BaseObject.TrangThaiObject = item.TrangThai_BangGia;
                        temp.BaseObject.TenObject = item.Ten_LoaiSan;
                        temp.ThoiGianBatDau = item.ThoiGianBatDau;
                        temp.ThoiGianKetThuc = item.ThoiGianKetThuc;
                        temp.GiaTienObject = Convert.ToDecimal(item.GiaTien);
                        temp.NgayTao = item.NgayTao;
                        objList.Add(temp);
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public override bool UpdateItem(BangGiaObject_Model parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.BangGia_Db.Find(parameter.BaseObject.IdObject);
                if(item != null)
                {
                    item.TrangThai_BangGia = parameter.BaseObject.TrangThaiObject;
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
