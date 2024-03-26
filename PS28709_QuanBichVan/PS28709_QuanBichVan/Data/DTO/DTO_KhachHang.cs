using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS28709_QuanBichVan.Data.DTO
{
    public class DTO_KhachHang
    {
        public string Dienthoai { get; set; }
        public string TenKhach { get; set; }
        public string DiaChi { get; set; }
        public string Phai { get; set; }
        public string MaNV { get; set; }

        public DTO_KhachHang(string dienthoai, string tenKhach, string diaChi, string phai, string maNV)
        {
            Dienthoai = dienthoai;
            TenKhach = tenKhach;
            DiaChi = diaChi;
            Phai = phai;
            MaNV = maNV;
        }

        public DTO_KhachHang() { }
    }

}
