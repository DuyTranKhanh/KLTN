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
                temp.GioVaoSan = parameter.HoatDongCuaSan.GioVaoSan;
                temp.GioRaSan = parameter.HoatDongCuaSan.GioKetThuc;
                temp.TongTien = parameter.HoatDongCuaSan.TongTien;
                temp.TienKhachDua = parameter.HoatDongCuaSan.TienKhachDua;
                temp.TienThua = parameter.HoatDongCuaSan.TienThoi;
                temp.SoGioThue = parameter.HoatDongCuaSan.SoGioThue;
                temp.NgayThucHien = parameter.HoatDongCuaSan.Ngay;
                temp.GhiChu = parameter.HoatDongCuaSan.GhiChu;
                temp.Account_NhanVien = parameter.HoatDongCuaSan.NhanVien.Account;
                temp.HoVaTen_NhanVien = parameter.HoatDongCuaSan.NhanVien.HoVaTen;
                temp.TrangThai_San_HienTai = parameter.TrangThaiSan;
                temp.Id_KhachHang = parameter.HoatDongCuaSan.KhachHang.BaseObject.IdObject;
                temp.Ten_KhachHang = parameter.HoatDongCuaSan.KhachHang.BaseObject.TenObject;
                temp.Sdt_KhachHang = parameter.HoatDongCuaSan.KhachHang.SdtObject;
                Database.HoatDongHienTai_Db.Add(temp);
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
                    temp.HoatDongCuaSan.KhachHang.BaseObject.IdObject = (int)item.Id_KhachHang;
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
                    temp.HoatDongCuaSan.GioVaoSan = item.GioVaoSan;
                    temp.HoatDongCuaSan.GioKetThuc = item.GioRaSan;
                    temp.HoatDongCuaSan.SoGioThue = Convert.ToDouble(item.SoGioThue);
                    temp.HoatDongCuaSan.TongTien = (Decimal)item.TongTien;
                    temp.HoatDongCuaSan.TienKhachDua = (Decimal)item.TienKhachDua;
                    temp.HoatDongCuaSan.TienThoi = (Decimal)item.TienThua;
                    temp.HoatDongCuaSan.Ngay = item.NgayThucHien;
                    temp.HoatDongCuaSan.GhiChu = item.GhiChu;
                    temp.HoatDongCuaSan.NhanVien.Account = item.Account_NhanVien;
                    temp.HoatDongCuaSan.NhanVien.HoVaTen = item.HoVaTen_NhanVien;
                    objList.Add(temp);
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
                if (item != null)
                {
                    item.GioVaoSan = parameter.HoatDongCuaSan.GioVaoSan;
                    item.GioRaSan = parameter.HoatDongCuaSan.GioKetThuc;
                    item.SoGioThue = parameter.HoatDongCuaSan.SoGioThue;
                    item.TongTien = parameter.HoatDongCuaSan.TongTien;
                    item.TienKhachDua = parameter.HoatDongCuaSan.TienKhachDua;
                    item.TienKhachDua = parameter.HoatDongCuaSan.TienThoi;
                    item.GhiChu = parameter.HoatDongCuaSan.GhiChu;
                    item.TrangThai_San_HienTai = parameter.TrangThaiSan;
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
    }
}
