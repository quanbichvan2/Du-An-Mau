using PS28709_QuanBichVan.Data.Context;
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
    public partial class ForgetPass : Form
    {
        public ForgetPass()
        {
            InitializeComponent();
        }
        
        private void btnTurnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
        private void check()
        {
            using (DuAnMauEntities db = new DuAnMauEntities())
            {
                var acc = (db.NhanVien.FirstOrDefault(u => u.MaNV == txtUserName.Text && u.Email == txtNhapEmail.Text));
                if (acc != null)
                {
                    if(txtMatKhauMoi.Text == txtConfirmMatKhau.Text)
                    {
                        acc.MatKhau = txtMatKhauMoi.Text;
                        db.SaveChanges();
                        MessageBox.Show("tài khoản " + acc.MaNV + "đã được cập nhật mật khẩu mới thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("2 mật khẩu nhập không khớp với nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("không thể thay đổi mật khẩu do thông tin tài khoản bị sai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            check();
        }
    }
}
