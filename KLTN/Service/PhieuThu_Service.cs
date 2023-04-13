using KLTN.Model;
using KLTN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KLTN.Service
{
    public class PhieuThu_Service : MainService<HoaDon_Model>
    {
        KLTN_DatabaseEntities Database;
        DanhSachHienTai_NuocUong_Service DanhSachNuocUong;
        public PhieuThu_Service()
        {
            Database = new KLTN_DatabaseEntities();
            DanhSachNuocUong = new DanhSachHienTai_NuocUong_Service();
        }

        public override bool Add(HoaDon_Model parameter)
        {
            bool _IsAdd = false;
            try
            {
                var temp = new PhieuThu_Db();
                temp.Id_PhieuThu = parameter.IdHoaDon;
                temp.Id_San = parameter.San.BaseObject.IdObject;
                temp.Ten_San = parameter.San.BaseObject.TenObject;
                temp.Id_LoaiSan = parameter.San.IdLoaiSan;
                temp.Ten_LoaiSan = parameter.San.TenLoaiSan;
                temp.GioVaoSan = parameter.GioVaoSan;
                temp.GioRaSan = parameter.GioKetThuc;
                temp.TongTien = parameter.TongTien;
                temp.TienKhachDua = parameter.TienKhachDua;
                temp.TienThua = parameter.TienThoi;
                temp.SoGioThue = parameter.SoGioThue;
                temp.NgayThucHien = parameter.Ngay;
                temp.GhiChu = parameter.GhiChu;
                temp.Account_NhanVien = parameter.NhanVien.Account;
                temp.HoVaTen_NhanVien = parameter.NhanVien.HoVaTen;
                temp.Id_KhachHang = parameter.KhachHang.BaseObject.IdObject;
                temp.Ten_KhachHang = parameter.KhachHang.BaseObject.TenObject;
                temp.Sdt_KhachHang = parameter.KhachHang.SdtObject;
                Database.PhieuThu_Db.Add(temp);
                var NoOfRowsAffected = Database.SaveChanges();
                _IsAdd = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _IsAdd;
        }

        public override ObservableCollection<HoaDon_Model> GetAll()
        {
            ObservableCollection<HoaDon_Model> objList = new ObservableCollection<HoaDon_Model>();
            try
            {
                var objQuery = from KhachHang in Database.PhieuThu_Db
                               select KhachHang;
                foreach (var item in objQuery)
                {
                    var temp = new HoaDon_Model();
                    temp.IdHoaDon = item.Id_PhieuThu;
                    temp.San.IdLoaiSan = Convert.ToInt32(item.Id_LoaiSan);
                    temp.San.BaseObject.IdObject = Convert.ToInt32(item.Id_San);
                    temp.San.BaseObject.TenObject = item.Ten_San;
                    temp.San.TenLoaiSan = item.Ten_LoaiSan;
                    temp.KhachHang.BaseObject.IdObject = (int)item.Id_KhachHang;
                    temp.KhachHang.BaseObject.TenObject = item.Ten_KhachHang;
                    temp.KhachHang.SdtObject = item.Sdt_KhachHang;
                    temp.DanhSachNuocUong = new ObservableCollection<HoatDongNuocUong_Model>();
                    if (DanhSachNuocUong.GetByIdSan(item.Id_San).Count > 0)
                    {
                        foreach (var itemNuocUong in DanhSachNuocUong.GetByIdSan(item.Id_San))
                        {
                            temp.DanhSachNuocUong.Add(itemNuocUong.Clone());
                        }
                    }
                    temp.GioVaoSan = item.GioVaoSan;
                    temp.GioKetThuc = item.GioRaSan;
                    temp.SoGioThue = Convert.ToDouble(item.SoGioThue);
                    temp.TongTien = (Decimal)item.TongTien;
                    temp.TienKhachDua = (Decimal)item.TienKhachDua;
                    temp.TienThoi = (Decimal)item.TienThua;
                    temp.Ngay = item.NgayThucHien;
                    temp.GhiChu = item.GhiChu;
                    temp.NhanVien.Account = item.Account_NhanVien;
                    temp.NhanVien.HoVaTen = item.HoVaTen_NhanVien;
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
