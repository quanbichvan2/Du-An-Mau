using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS28709_QuanBichVan.Data.DTO
{
    public class DTO_Hang
    {
        public int MaHang { get; set; }
        public string MaNV { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public float DonGiaNhap { get; set; }
        public float DonGiaBan { get; set; }
        public string HinhAnh { get; set; }
        public string GhiChu { get; set; }

        public DTO_Hang(int maHang, string maNV, string tenHang, int soLuong, float donGiaNhap, float donGiaBan, string hinhAnh, string ghiChu)
        {
            MaHang = maHang;
            MaNV = maNV;
            TenHang = tenHang;
            SoLuong = soLuong;
            DonGiaNhap = donGiaNhap;
            DonGiaBan = donGiaBan;
            HinhAnh = hinhAnh;
            GhiChu = ghiChu;
        }

        public DTO_Hang() { }
    }
}
