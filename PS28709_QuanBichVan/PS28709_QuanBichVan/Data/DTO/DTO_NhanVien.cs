using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS28709_QuanBichVan.Data.DTO
{
    public class DTO_NhanVien
    {
        private string tenNhanVien;
        private string diaChi;
        private int vaiTro;
        private string emailNV;
        private string matKhau;
        private int tinhTrang;

        public string TenNhanVien { get { return tenNhanVien; } set { tenNhanVien = value; } }
        public string DiaChi { get { return diaChi; } set { diaChi = value; } }
        public int VaiTro { get { return vaiTro; } set { vaiTro = value; } }
        public string EmailNV { get { return emailNV; } set { emailNV = value; } }
        public string MatKhau { get { return matKhau; } set { matKhau = value; } }
        public int TinhTrang { get { return tinhTrang; } set { tinhTrang = value; } }
        public DTO_NhanVien (string emailNv, string tenNv, string diaChi, int vaiTro, int tinhTrang)
        {
            this.tenNhanVien = tenNv;
            this.diaChi = diaChi;
            this.vaiTro = vaiTro;
            this.emailNV = emailNv;
            this.tinhTrang = tinhTrang;
        }
        public DTO_NhanVien() { }
    }
    
}
