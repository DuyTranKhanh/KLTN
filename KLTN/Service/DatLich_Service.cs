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
                temp.NgayDat = DateTime.Today.ToShortDateString();
                //temp.GioBatDau = parameter.GioBatDau;
                //temp.GioKetThuc = parameter.GioKetThuc;
                temp.TrangThai_LichDat = parameter.TrangThai;


                var l_GioVaoSan = new LichDat_GioVaoSan();
                l_GioVaoSan.Id_LichDatGioVaoSan = temp.Id_LichDat;
                l_GioVaoSan.Id_LichDat = temp.Id_LichDat;
                l_GioVaoSan.Phut = parameter.GioBatDau.Minute;
                l_GioVaoSan.Gio = parameter.GioBatDau.Hour;

                var l_GioKetThuc = new LichDat_GioKetThuc();
                l_GioKetThuc.Id_LichDatGioKetThuc = temp.Id_LichDat;
                l_GioKetThuc.Id_LichDat = temp.Id_LichDat;
                l_GioKetThuc.Phut = parameter.GioKetThuc.Minute;
                l_GioKetThuc.Gio = parameter.GioKetThuc.Hour;

                var l_NgaySuDung = new LichDat_NgaySuDung();
                l_NgaySuDung.Id = temp.Id_LichDat;
                l_NgaySuDung.Id_LichDat = temp.Id_LichDat;
                l_NgaySuDung.Nam = parameter.GioKetThuc.Year;
                l_NgaySuDung.Thang = parameter.GioKetThuc.Month;
                l_NgaySuDung.Ngay = parameter.GioKetThuc.Day;

                Database.LichDat_Db.Add(temp);
                Database.LichDat_GioKetThuc.Add(l_GioKetThuc);
                Database.LichDat_GioVaoSan.Add(l_GioVaoSan);
                Database.LichDat_NgaySuDung.Add(l_NgaySuDung);
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
                    temp.KhachHang.BaseObject.IdObject = (int)item.Id_KhachHang;
                    temp.KhachHang.BaseObject.TenObject = item.Ten_KhachHang;
                    temp.KhachHang.SdtObject = item.Sdt_KhachHang;
                    temp.San.IdLoaiSan = (int)item.Id_LoaiSan;
                    temp.San.BaseObject.IdObject = (int)item.Id_San;
                    temp.San.BaseObject.TenObject = item.Ten_San;
                    temp.San.TenLoaiSan = item.Ten_LoaiSan;
                    temp.TrangThai = item.TrangThai_LichDat;
                    temp.NgayDatSan = item.NgayDat;

                    var l_GioBatDau = (from GioVaoSan in Database.LichDat_GioVaoSan
                                       where GioVaoSan.Id_LichDat == temp.IdLichDat
                                       select GioVaoSan).SingleOrDefault();

                    var l_GioKetThuc = (from GioKetThuc in Database.LichDat_GioKetThuc
                                       where GioKetThuc.Id_LichDat == temp.IdLichDat
                                       select GioKetThuc).SingleOrDefault();

                    var l_NgaySuDung = (from NgaySuDung in Database.LichDat_NgaySuDung
                                       where NgaySuDung.Id_LichDat == temp.IdLichDat
                                       select NgaySuDung).SingleOrDefault();

                    temp.GioKetThuc.Minute = (l_GioKetThuc == null) ? "0" : l_GioKetThuc.Phut;
                    temp.GioKetThuc.Hour = (l_GioKetThuc == null) ? "0" : l_GioKetThuc.Gio;

                    temp.GioBatDau.Minute = (l_GioBatDau == null) ? "0" : l_GioBatDau.Phut;
                    temp.GioBatDau.Hour = (l_GioBatDau == null) ? "0" : l_GioBatDau.Gio;

                    temp.NgaySuDung.Day = (l_NgaySuDung == null) ? "UnKnown" : l_NgaySuDung.Ngay;
                    temp.NgaySuDung.Month = (l_NgaySuDung == null) ? "UnKnown" : l_NgaySuDung.Thang;
                    temp.NgaySuDung.Year = (l_NgaySuDung == null) ? "Unknown" : l_NgaySuDung.Nam;
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

                    var l_GioBatDau = (from GioVaoSan in Database.LichDat_GioVaoSan
                                       where GioVaoSan.Id_LichDat == item.Id_LichDat
                                       select GioVaoSan).SingleOrDefault();

                    var l_GioKetThuc = (from GioKetThuc in Database.LichDat_GioKetThuc
                                        where GioKetThuc.Id_LichDat == item.Id_LichDat
                                        select GioKetThuc).SingleOrDefault();

                    var l_NgaySuDung = (from NgaySuDung in Database.LichDat_NgaySuDung
                                        where NgaySuDung.Id_LichDat == item.Id_LichDat
                                        select NgaySuDung).SingleOrDefault();

                    l_GioBatDau.Phut = parameter.GioBatDau.Minute;
                    l_GioBatDau.Gio = parameter.GioBatDau.Hour;
                    l_GioKetThuc.Phut = parameter.GioKetThuc.Minute;
                    l_GioKetThuc.Gio = parameter.GioKetThuc.Hour;
                    l_NgaySuDung.Ngay = parameter.NgaySuDung.Day;
                    l_NgaySuDung.Thang = parameter.NgaySuDung.Month;
                    l_NgaySuDung.Nam = parameter.NgaySuDung.Year;
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
