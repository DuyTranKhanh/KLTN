using KLTN.Model;
using KLTN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.Service
{
    public class HoatDongHienTai_Service : MainService<HoatDongHienTaiModel>
    {
        KLTN_DatabaseEntities Database;
        DanhSachHienTai_NuocUong_Service DanhSachNuocUong;
        public HoatDongHienTai_Service()
        {
            Database = new KLTN_DatabaseEntities();
            DanhSachNuocUong = new DanhSachHienTai_NuocUong_Service();
        }
        public override bool Add(HoatDongHienTaiModel parameter)
        {
            bool _IsAdd = false;
            try
            {
                var temp = new HoatDongHienTai_Db();
                temp.Id_San = parameter.HoatDongCuaSan.San.BaseObject.IdObject;
                temp.Ten_San = parameter.HoatDongCuaSan.San.BaseObject.TenObject;
                temp.Id_LoaiSan = parameter.HoatDongCuaSan.San.IdLoaiSan;
                temp.Ten_LoaiSan = parameter.HoatDongCuaSan.San.TenLoaiSan;
                //temp.GioVaoSan = parameter.HoatDongCuaSan.GioVaoSan;
                //temp.GioRaSan = parameter.HoatDongCuaSan.GioKetThuc;
                temp.TongTien = parameter.HoatDongCuaSan.TongTien;
                temp.TienKhachDua = parameter.HoatDongCuaSan.TienKhachDua;
                temp.TienThua = parameter.HoatDongCuaSan.TienThoi;
                temp.SoGioThue = parameter.HoatDongCuaSan.SoGioThue;
                //temp.NgayThucHien = parameter.HoatDongCuaSan.Ngay;
                temp.GhiChu = parameter.HoatDongCuaSan.GhiChu;
                temp.Account_NhanVien = parameter.HoatDongCuaSan.NhanVien.Account;
                temp.HoVaTen_NhanVien = parameter.HoatDongCuaSan.NhanVien.HoVaTen;
                temp.TrangThai_San_HienTai = parameter.TrangThaiSan;
                temp.Id_KhachHang = parameter.HoatDongCuaSan.KhachHang.BaseObject.IdObject;
                temp.Ten_KhachHang = parameter.HoatDongCuaSan.KhachHang.BaseObject.TenObject;
                temp.Sdt_KhachHang = parameter.HoatDongCuaSan.KhachHang.SdtObject;

                var l_GioVaoSan = new HoatDongHienTai_GioVaoSan();
                l_GioVaoSan.Id_HoatDongGioVaoSan = temp.Id_San;
                l_GioVaoSan.Id_San = temp.Id_San;
                l_GioVaoSan.Phut = parameter.HoatDongCuaSan.GioVaoSan.Minute;
                l_GioVaoSan.Gio = parameter.HoatDongCuaSan.GioVaoSan.Hour;

                var l_GioKetThuc = new HoatDongHienTai_GioKetThuc();
                l_GioKetThuc.Id_HoatDongGioKetThuc = temp.Id_San;
                l_GioKetThuc.Id_San = temp.Id_San;
                l_GioKetThuc.Phut = parameter.HoatDongCuaSan.GioKetThuc.Minute;
                l_GioKetThuc.Gio = parameter.HoatDongCuaSan.GioKetThuc.Hour;

                Database.HoatDongHienTai_Db.Add(temp);
                Database.HoatDongHienTai_GioVaoSan.Add(l_GioVaoSan);
                Database.HoatDongHienTai_GioKetThuc.Add(l_GioKetThuc);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public override System.Collections.ObjectModel.ObservableCollection<HoatDongHienTaiModel> GetAll()
        {
            ObservableCollection<HoatDongHienTaiModel> objList = new ObservableCollection<HoatDongHienTaiModel>();
            try
            {
                var objQuery = from KhachHang in Database.HoatDongHienTai_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    var temp = new HoatDongHienTaiModel();
                    temp.TrangThaiSan = item.TrangThai_San_HienTai;
                    temp.HoatDongCuaSan.San.IdLoaiSan = Convert.ToInt32(item.Id_LoaiSan);
                    temp.HoatDongCuaSan.San.BaseObject.IdObject = Convert.ToInt32(item.Id_San);
                    temp.HoatDongCuaSan.San.BaseObject.TenObject = item.Ten_San;
                    temp.HoatDongCuaSan.San.TenLoaiSan = item.Ten_LoaiSan;
                    temp.HoatDongCuaSan.KhachHang.BaseObject.IdObject = (item.Id_KhachHang == null) ? -1 : (int)item.Id_KhachHang;
                    temp.HoatDongCuaSan.KhachHang.BaseObject.TenObject = item.Ten_KhachHang;
                    temp.HoatDongCuaSan.KhachHang.SdtObject = item.Sdt_KhachHang;
                    temp.HoatDongCuaSan.DanhSachNuocUong = new ObservableCollection<HoatDongNuocUong_Model>();
                    if(DanhSachNuocUong.GetByIdSan(item.Id_San).Count > 0)
                    {
                        foreach (var itemNuocUong in DanhSachNuocUong.GetByIdSan(item.Id_San))
                        {
                            temp.HoatDongCuaSan.DanhSachNuocUong.Add(itemNuocUong.Clone());
                        }
                    }
                    //temp.HoatDongCuaSan.GioVaoSan = item.GioVaoSan;
                    //temp.HoatDongCuaSan.GioKetThuc = item.GioRaSan;
                    temp.HoatDongCuaSan.SoGioThue = (item.SoGioThue == null) ? 0 : (Convert.ToDouble(item.SoGioThue));
                    temp.HoatDongCuaSan.TongTien = (item.TongTien == null) ? 0 : (Decimal)item.TongTien;
                    temp.HoatDongCuaSan.TienKhachDua = (item.TienKhachDua == null) ? 0 : (Decimal)item.TienKhachDua;
                    temp.HoatDongCuaSan.TienThoi = (item.TienThua == null) ? 0 : (Decimal)item.TienThua;
                    //temp.HoatDongCuaSan.Ngay = item.NgayThucHien;
                    temp.HoatDongCuaSan.GhiChu = item.GhiChu;
                    temp.HoatDongCuaSan.NhanVien.Account = item.Account_NhanVien;
                    temp.HoatDongCuaSan.NhanVien.HoVaTen = item.HoVaTen_NhanVien;

                    var l_GioVaoSan = (from GioVaoSan in Database.HoatDongHienTai_GioVaoSan
                                       where GioVaoSan.Id_San == temp.HoatDongCuaSan.San.BaseObject.IdObject
                                       select GioVaoSan).SingleOrDefault();

                    var l_GioKetThuc = (from GioKetThuc in Database.HoatDongHienTai_GioKetThuc
                                        where GioKetThuc.Id_San == temp.HoatDongCuaSan.San.BaseObject.IdObject
                                        select GioKetThuc).SingleOrDefault();

                    temp.HoatDongCuaSan.GioVaoSan.Minute = (l_GioVaoSan == null) ? "0" : l_GioVaoSan.Phut;
                    temp.HoatDongCuaSan.GioVaoSan.Hour = (l_GioVaoSan == null) ? "0" : l_GioVaoSan.Gio;

                    temp.HoatDongCuaSan.GioKetThuc.Minute = (l_GioKetThuc == null) ? "0" : l_GioKetThuc.Phut;
                    temp.HoatDongCuaSan.GioKetThuc.Hour = (l_GioKetThuc == null) ? "0" : l_GioKetThuc.Gio;
                    objList.Add(temp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public ObservableCollection<HoatDongHienTaiModel> GetWithCondition()
        {
            ObservableCollection<HoatDongHienTaiModel> objList = new ObservableCollection<HoatDongHienTaiModel>();
            try
            {
                var objQuery = from KhachHang in Database.HoatDongHienTai_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    var objTrangThaiSan = from DanhSachSan in Database.San_Db
                                          select DanhSachSan;
                    foreach (var itemSan in objTrangThaiSan)
                    {
                        if (itemSan.Id_San == item.Id_San && itemSan.TrangThai_San == "Hoạt động")
                        {
                            var temp = new HoatDongHienTaiModel();
                            temp.TrangThaiSan = (item.TrangThai_San_HienTai.Length > 1) ? item.TrangThai_San_HienTai : "Sẵn sàng sử dụng";
                            temp.HoatDongCuaSan.San.IdLoaiSan = Convert.ToInt32(item.Id_LoaiSan);
                            temp.HoatDongCuaSan.San.BaseObject.IdObject = Convert.ToInt32(item.Id_San);
                            temp.HoatDongCuaSan.San.BaseObject.TenObject = item.Ten_San;
                            temp.HoatDongCuaSan.San.TenLoaiSan = item.Ten_LoaiSan;
                            temp.HoatDongCuaSan.KhachHang.BaseObject.IdObject = (item.Id_KhachHang == null) ? -1 : (int)item.Id_KhachHang;
                            temp.HoatDongCuaSan.KhachHang.BaseObject.TenObject = item.Ten_KhachHang;
                            temp.HoatDongCuaSan.KhachHang.SdtObject = item.Sdt_KhachHang;
                            temp.HoatDongCuaSan.DanhSachNuocUong = new ObservableCollection<HoatDongNuocUong_Model>();
                            if (DanhSachNuocUong.GetByIdSan(item.Id_San).Count > 0)
                            {
                                foreach (var itemNuocUong in DanhSachNuocUong.GetByIdSan(item.Id_San))
                                {
                                    temp.HoatDongCuaSan.DanhSachNuocUong.Add(itemNuocUong.Clone());
                                }
                            }
                            //temp.HoatDongCuaSan.GioVaoSan = item.GioVaoSan;
                            //temp.HoatDongCuaSan.GioKetThuc = item.GioRaSan;
                            temp.HoatDongCuaSan.SoGioThue = (item.SoGioThue == null) ? 0 : (Convert.ToDouble(item.SoGioThue));
                            temp.HoatDongCuaSan.TongTien = (item.TongTien == null) ? 0 : (Decimal)item.TongTien;
                            temp.HoatDongCuaSan.TienKhachDua = (item.TienKhachDua == null) ? 0 : (Decimal)item.TienKhachDua;
                            temp.HoatDongCuaSan.TienThoi = (item.TienThua == null) ? 0 : (Decimal)item.TienThua;
                            //temp.HoatDongCuaSan.Ngay = item.NgayThucHien;
                            temp.HoatDongCuaSan.GhiChu = item.GhiChu;
                            temp.HoatDongCuaSan.NhanVien.Account = item.Account_NhanVien;
                            temp.HoatDongCuaSan.NhanVien.HoVaTen = item.HoVaTen_NhanVien;

                            var l_GioVaoSan = (from GioVaoSan in Database.HoatDongHienTai_GioVaoSan
                                               where GioVaoSan.Id_San == temp.HoatDongCuaSan.San.BaseObject.IdObject
                                               select GioVaoSan).SingleOrDefault();

                            var l_GioKetThuc = (from GioKetThuc in Database.HoatDongHienTai_GioKetThuc
                                                where GioKetThuc.Id_San == temp.HoatDongCuaSan.San.BaseObject.IdObject
                                                select GioKetThuc).SingleOrDefault();

                            temp.HoatDongCuaSan.GioVaoSan.Minute = (l_GioVaoSan == null) ? "0" : l_GioVaoSan.Phut;
                            temp.HoatDongCuaSan.GioVaoSan.Hour = (l_GioVaoSan == null) ? "0" : l_GioVaoSan.Gio;

                            temp.HoatDongCuaSan.GioKetThuc.Minute = (l_GioKetThuc == null) ? "0" : l_GioKetThuc.Phut;
                            temp.HoatDongCuaSan.GioKetThuc.Hour = (l_GioKetThuc == null) ? "0" : l_GioKetThuc.Gio;
                            objList.Add(temp);
                        }

                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objList;
        }

        public override bool UpdateItem(HoatDongHienTaiModel parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.HoatDongHienTai_Db.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                //var l_GioVaoSan = (from GioVaoSan in Database.HoatDongHienTai_GioVaoSan
                //                   where GioVaoSan.Id_San == parameter.HoatDongCuaSan.San.BaseObject.IdObject
                //                   select GioVaoSan).SingleOrDefault();

                //var l_GioKetThuc = (from GioKetThuc in Database.HoatDongHienTai_GioKetThuc
                //                    where GioKetThuc.Id_San == parameter.HoatDongCuaSan.San.BaseObject.IdObject
                //                    select GioKetThuc).SingleOrDefault();

                var l_GioVaoSan = Database.HoatDongHienTai_GioVaoSan.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                var l_GioKetThuc = Database.HoatDongHienTai_GioKetThuc.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                if (item != null)
                {
                    //item.GioVaoSan = parameter.HoatDongCuaSan.GioVaoSan;
                    //item.GioRaSan = parameter.HoatDongCuaSan.GioKetThuc;
                    item.SoGioThue = parameter.HoatDongCuaSan.SoGioThue;
                    item.TongTien = parameter.HoatDongCuaSan.TongTien;
                    item.TienKhachDua = parameter.HoatDongCuaSan.TienKhachDua;
                    item.TienThua = parameter.HoatDongCuaSan.TienThoi;
                    item.GhiChu = parameter.HoatDongCuaSan.GhiChu;
                    item.TrangThai_San_HienTai = parameter.TrangThaiSan;
                    item.Sdt_KhachHang = parameter.HoatDongCuaSan.KhachHang.SdtObject;
                    item.Ten_KhachHang = parameter.HoatDongCuaSan.KhachHang.BaseObject.TenObject;
                    item.Id_KhachHang = parameter.HoatDongCuaSan.KhachHang.BaseObject.IdObject;

                    //l_GioVaoSan.Gio = parameter.HoatDongCuaSan.GioVaoSan.Hour;
                    //l_GioVaoSan.Phut = parameter.HoatDongCuaSan.GioVaoSan.Minute;

                    //l_GioKetThuc.Gio = parameter.HoatDongCuaSan.GioKetThuc.Hour;
                    //l_GioKetThuc.Phut = parameter.HoatDongCuaSan.GioKetThuc.Minute;
                    //Neu chinh sua item Nuoc Uong thi da co Service rieng
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }

        public bool UpdateTenKhachHang(HoatDongHienTaiModel parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.HoatDongHienTai_Db.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                if (item != null)
                {

                    item.Sdt_KhachHang = parameter.HoatDongCuaSan.KhachHang.SdtObject;
                    item.Ten_KhachHang = parameter.HoatDongCuaSan.KhachHang.BaseObject.TenObject;
                    item.Id_KhachHang = parameter.HoatDongCuaSan.KhachHang.BaseObject.IdObject;

                    //Neu chinh sua item Nuoc Uong thi da co Service rieng
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }

        public bool UpdateSoGioThue(HoatDongHienTaiModel parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.HoatDongHienTai_Db.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                if (item != null)
                {

                    item.SoGioThue = parameter.HoatDongCuaSan.SoGioThue;

                    //Neu chinh sua item Nuoc Uong thi da co Service rieng
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }

        public bool UpdateTongTien(HoatDongHienTaiModel parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.HoatDongHienTai_Db.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                if (item != null)
                {

                    item.TongTien = parameter.HoatDongCuaSan.TongTien;

                    //Neu chinh sua item Nuoc Uong thi da co Service rieng
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }

        public bool UpdateTienKhachDua(HoatDongHienTaiModel parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.HoatDongHienTai_Db.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                if (item != null)
                {

                    item.TienKhachDua = parameter.HoatDongCuaSan.TienKhachDua;

                    //Neu chinh sua item Nuoc Uong thi da co Service rieng
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }

        public bool UpdateTienThua(HoatDongHienTaiModel parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.HoatDongHienTai_Db.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                if (item != null)
                {

                    item.TienThua = parameter.HoatDongCuaSan.TienThoi;

                    //Neu chinh sua item Nuoc Uong thi da co Service rieng
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }

        public bool UpdateGhiChu(HoatDongHienTaiModel parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.HoatDongHienTai_Db.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                if (item != null)
                {

                    item.GhiChu = parameter.HoatDongCuaSan.GhiChu;

                    //Neu chinh sua item Nuoc Uong thi da co Service rieng
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
        public bool UpdateTrangThai(HoatDongHienTaiModel parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.HoatDongHienTai_Db.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                if (item != null)
                {

                    item.TrangThai_San_HienTai = parameter.TrangThaiSan;

                    //Neu chinh sua item Nuoc Uong thi da co Service rieng
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }

        public bool UpdateGioVaoSan(HoatDongHienTaiModel parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.HoatDongHienTai_Db.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                var l_GioVaoSan = Database.HoatDongHienTai_GioVaoSan.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                var l_GioKetThuc = Database.HoatDongHienTai_GioKetThuc.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                if (item != null)
                {

                    l_GioVaoSan.Gio = parameter.HoatDongCuaSan.GioVaoSan.Hour.Trim();
                    l_GioVaoSan.Phut = parameter.HoatDongCuaSan.GioVaoSan.Minute.Trim();

                    //Neu chinh sua item Nuoc Uong thi da co Service rieng
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }

        public bool UpdateGioKetThuc(HoatDongHienTaiModel parameter)
        {
            bool l_IsUpdate = false;
            try
            {
                var item = Database.HoatDongHienTai_Db.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                var l_GioVaoSan = Database.HoatDongHienTai_GioVaoSan.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                var l_GioKetThuc = Database.HoatDongHienTai_GioKetThuc.Find(parameter.HoatDongCuaSan.San.BaseObject.IdObject);
                if (item != null)
                {

                    l_GioKetThuc.Gio = parameter.HoatDongCuaSan.GioKetThuc.Hour.Trim();
                    l_GioKetThuc.Phut = parameter.HoatDongCuaSan.GioKetThuc.Minute.Trim();

                    //Neu chinh sua item Nuoc Uong thi da co Service rieng
                    var NoOfRowsAffected = Database.SaveChanges();
                    l_IsUpdate = NoOfRowsAffected > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            return l_IsUpdate;
        }
    }
}
