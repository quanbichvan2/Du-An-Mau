using PS28709_QuanBichVan.Bus;
using PS28709_QuanBichVan.Data.Context;
using PS28709_QuanBichVan.View.UI.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS28709_QuanBichVan
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }
        /*
        public void Login_Load(object sender, EventArgs e)
        {
                // Đặt thuộc tính Checked của rememberCheckBox dựa trên giá trị RememberUsername.
                rememberCheckBox.Checked = Properties.Settings.Default.RememberUsername;

                // Nếu người dùng đã chọn ghi nhớ tên đăng nhập, đặt giá trị tên đăng nhập vào TextBox.
                if (rememberCheckBox.Checked)
                {
                    txtDangNhap.Text = Properties.Settings.Default.Username;
                }

        }
        */
        public void check()
        {
            using (DuAnMauEntities db = new DuAnMauEntities())
            {
                var acc = (db.NhanVien.FirstOrDefault(u => u.MaNV == txtDangNhap.Text && u.MatKhau == txtPassword.Text));
                if (acc != null)
                {
                    if(acc.VaiTro == 1)
                    {
                        if (acc.TinhTrang == 1)
                        {
                            MessageBox.Show("Đăng nhập dưới quyền admin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            StaticAuth.auth = acc;
                            this.Hide();
                            Home home = new Home();
                            home.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("tài khoản đã bị đình chỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        if(acc.TinhTrang == 1)
                        {
                            MessageBox.Show("Đăng nhập dưới quyền nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Hide();
                            Home home = new Home();
                            home.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("tài khoản đã bị đình chỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sai thông tin tài khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                    
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            check();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Bạn có thật sự muốn thoát ứng dụng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblQuenMK_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgetPass forgetPass = new ForgetPass();
            forgetPass.ShowDialog();
            this.Close();
        }
    }
}
