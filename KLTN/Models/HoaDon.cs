//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KLTN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDon
    {
        public int Id_HoatDongHienTai { get; set; }
        public string Id_San { get; set; }
        public string Ten_San { get; set; }
        public string Ten_NhanVien { get; set; }
        public string Ten_KhachHang { get; set; }
        public string GioVaoSan { get; set; }
        public string GioRaSan { get; set; }
        public string NgayThucHien { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public Nullable<decimal> TienKhachDua { get; set; }
        public Nullable<decimal> TienDu { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> Id_DanhSachNuocUong { get; set; }
    }
}