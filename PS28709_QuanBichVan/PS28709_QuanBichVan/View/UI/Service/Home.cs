using PS28709_QuanBichVan.Bus;
using PS28709_QuanBichVan.Data.Context;
using PS28709_QuanBichVan.View.UI.QuanLy;
using PS28709_QuanBichVan.View.UI.ThongKe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS28709_QuanBichVan.View.UI.Service
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Bạn có thật sự muốn log out", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(x == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                this.Close();
            }
        }

        private void DoiMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePass changePass = new ChangePass();
            changePass.ShowDialog();
            this.Close();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {

            NhanVien nguoiDung = StaticAuth.auth; // Lấy thông tin người dùng đang đăng nhập từ StaticAuth
            if (nguoiDung != null && nguoiDung.VaiTro == 1)
            {
                // Cho phép truy cập
                this.Hide();
                ManagerStaffs staffs = new ManagerStaffs();
                staffs.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            this.Hide();
            Products products = new Products();
            products.ShowDialog();
            this.Close();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerCustomers customers = new ManagerCustomers();
            customers.ShowDialog();
            this.Close();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            NhanVien nguoiDung = StaticAuth.auth; // Lấy thông tin người dùng đang đăng nhập từ StaticAuth
            if (nguoiDung != null && nguoiDung.VaiTro == 1)
            {
                // Cho phép truy cập
                this.Hide();
                Statistical stats = new Statistical();
                stats.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHa_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Bạn có thật sự muốn thoát ứng dụng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
