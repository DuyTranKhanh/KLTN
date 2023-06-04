using KLTN.Model;
using KLTN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.Service
{
    public class HoaDon_Service : MainService<HoaDon_Model>
    {
        KLTN_DatabaseEntities Database;
        DanhSachHoaDon_NuocUong_Service DanhSachNuocUong;
        public HoaDon_Service()
        {
            Database = new KLTN_DatabaseEntities();
            DanhSachNuocUong = new DanhSachHoaDon_NuocUong_Service();
        }
        public override bool Add(HoaDon_Model parameter)
        {
            bool _IsAdd = false;
            try
            {
                var temp = new HoaDon_Db();
                //temp.Id_HoaDon = parameter.IdHoaDon;
                temp.Id_HoaDon = 0;

                //Get Id for Id_Hoa Don
                var objQuery = from HoaDon in Database.HoaDon_Db
                               select HoaDon;
                if (objQuery.Count() > 0)
                {
                    temp.Id_HoaDon = objQuery.Count() + 1;
                }
                temp.Id_San = parameter.San.BaseObject.IdObject;
                temp.Ten_San = parameter.San.BaseObject.TenObject;
                temp.Id_LoaiSan = parameter.San.IdLoaiSan;
                temp.Ten_LoaiSan = parameter.San.TenLoaiSan;
                temp.TongTien = parameter.TongTien;
                temp.TienKhachDua = parameter.TienKhachDua;
                temp.TienThua = parameter.TienThoi;
                temp.SoGioThue = parameter.SoGioThue;
                temp.NgayThucHien = DateTime.Today.ToShortDateString().Trim();
                temp.GhiChu = parameter.GhiChu;

                var l_GioVaoSan = new HoaDon_GioVaoSan();
                l_GioVaoSan.Id_HoaDon = temp.Id_HoaDon;
                l_GioVaoSan.Id_San = temp.Id_San;
                l_GioVaoSan.Phut = parameter.GioVaoSan.Minute;
                l_GioVaoSan.Gio = parameter.GioVaoSan.Hour;

                var l_GioKetThuc = new HoaDon_GioKetThuc();
                l_GioKetThuc.Id_HoaDon = temp.Id_HoaDon;
                l_GioKetThuc.Id_San = temp.Id_San;
                l_GioKetThuc.Phut = parameter.GioKetThuc.Minute;
                l_GioKetThuc.Gio = parameter.GioKetThuc.Hour;

                //Nhan Vien phu trach

                AccountObject_Model objSingle = new AccountObject_Model();
                var objectUser = Database.CurrentUser_Db.Find(0);
                temp.Account_NhanVien = objectUser.Account;
                temp.HoVaTen_NhanVien = objectUser.HoVaTen;

                //Khach hang using
                //var itemKhachHang = Database.KhachHang_Db.Find(parameter.KhachHang.BaseObject.TenObject);
                var itemKhachHang = from KhachHang in Database.KhachHang_Db
                                    where KhachHang.Ten_KhachHang == parameter.KhachHang.BaseObject.TenObject
                                    select KhachHang;
                if(itemKhachHang.Count() > 0)
                {
                    foreach(var item in itemKhachHang)
                    {
                        temp.Id_KhachHang = item.Id_KhachHang;
                        temp.Ten_KhachHang = item.Ten_KhachHang;
                        temp.Sdt_KhachHang = item.Sdt_KhachHang;
                    }
                }
                else
                {
                    temp.Id_KhachHang = 0;
                    temp.Ten_KhachHang = "Khách vãng lai";
                    temp.Sdt_KhachHang = string.Empty;
                }

                Database.HoaDon_Db.Add(temp);
                Database.HoaDon_GioKetThuc.Add(l_GioKetThuc);
                Database.HoaDon_GioVaoSan.Add(l_GioVaoSan);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public override System.Collections.ObjectModel.ObservableCollection<HoaDon_Model> GetAll()
        {
            ObservableCollection<HoaDon_Model> objList = new ObservableCollection<HoaDon_Model>();
            try
            {
                var objQuery = from KhachHang in Database.HoaDon_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    var temp = new HoaDon_Model();
                    temp.IdHoaDon = item.Id_HoaDon;
                    temp.San.IdLoaiSan = Convert.ToInt32(item.Id_LoaiSan);
                    temp.San.BaseObject.IdObject = Convert.ToInt32(item.Id_San);
                    temp.San.BaseObject.TenObject = item.Ten_San;
                    temp.San.TenLoaiSan = item.Ten_LoaiSan;
                    temp.KhachHang.BaseObject.IdObject = (int)item.Id_KhachHang;
                    temp.KhachHang.BaseObject.TenObject = item.Ten_KhachHang;
                    temp.KhachHang.SdtObject = item.Sdt_KhachHang;
                    temp.DanhSachNuocUong = new ObservableCollection<HoatDongNuocUong_Model>();
                    if (DanhSachNuocUong.GetByIdHoaDon(item.Id_HoaDon).Count > 0)
                    {
                        foreach (var itemNuocUong in DanhSachNuocUong.GetByIdHoaDon(item.Id_HoaDon))
                        {
                            temp.DanhSachNuocUong.Add(itemNuocUong.Clone());
                        }
                    }
                    temp.SoGioThue = Convert.ToDouble(item.SoGioThue);
                    temp.TongTien = (Decimal)item.TongTien;
                    temp.TienKhachDua = (Decimal)item.TienKhachDua;
                    temp.TienThoi = (Decimal)item.TienThua;
                    temp.Ngay.Day = item.NgayThucHien;
                    temp.GhiChu = item.GhiChu;
                    temp.NhanVien.Account = item.Account_NhanVien;
                    temp.NhanVien.HoVaTen = item.HoVaTen_NhanVien;


                    var l_GioVaoSan = (from GioVaoSan in Database.HoaDon_GioVaoSan
                                      where GioVaoSan.Id_HoaDon == temp.IdHoaDon
                                      select GioVaoSan).SingleOrDefault();

                    var l_GioKetThuc = (from GioKetThuc in Database.HoaDon_GioKetThuc
                                       where GioKetThuc.Id_HoaDon == temp.IdHoaDon
                                       select GioKetThuc).SingleOrDefault();

                    temp.GioVaoSan.Minute = (l_GioVaoSan == null) ? "0" : l_GioVaoSan.Phut;
                    temp.GioVaoSan.Hour = (l_GioVaoSan == null) ? "0" : l_GioVaoSan.Gio;

                    temp.GioKetThuc.Minute = (l_GioKetThuc == null) ? "0" : l_GioKetThuc.Phut;
                    temp.GioKetThuc.Hour = (l_GioKetThuc == null) ? "0" : l_GioKetThuc.Gio;

                    objList.Add(temp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public override bool UpdateItem(HoaDon_Model parameter)
        {
            throw new NotImplementedException();
        }
    }
}
