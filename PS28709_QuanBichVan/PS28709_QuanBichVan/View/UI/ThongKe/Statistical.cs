using PS28709_QuanBichVan.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS28709_QuanBichVan.Data.Context;

namespace PS28709_QuanBichVan.View.UI.ThongKe
{
    public partial class Statistical : Form
    {
        public Statistical()
        {
            InitializeComponent();
            db = new DuAnMauEntities();
            HienThi();
        }
        private DuAnMauEntities db;
        private void HienThi()
        {
            var nhapKhoQuery = from hang in db.Hang
                               select new
                               {
                                   TenSanPham = hang.TenHang,
                                   SoLuongTon = hang.SoLuong
                               };
            dataNhapKho.DataSource = nhapKhoQuery.ToList();

            var tonKhoQuery = from hang in db.Hang
                              join nhanVien in db.NhanVien on hang.MaNV equals nhanVien.MaNV
                              select new
                              {
                                  MaNhanVien = nhanVien.MaNV,
                                  TenNhanVien = nhanVien.HoVaTen,
                                  TenSanPham = hang.TenHang,
                                  SoLuongTon = hang.SoLuong
                              };

            dataTonKho.DataSource = tonKhoQuery.ToList();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            HienThi();
        }
    }
}
