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
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        private void btnTurnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.ShowDialog();
            this.Close();
        }
        private void check()
        {
            using (DuAnMauEntities db = new DuAnMauEntities())
            {
                var acc = (db.NhanVien.FirstOrDefault(u => u.Email == txtEmail.Text && u.MatKhau == txtMatKhauCu.Text));
                if (acc != null)
                {
                    if(string.Compare(txtMatKhauMoi.Text,txtConfirmMatKhauMoi.Text) == 0) 
                    /* 
                     nếu 2 chuỗi bằng nhau sẽ trả về 0
                     còn nếu chuỗi khác 0 thì ko bằng nhau. 
                     Nếu chuỗi A > B thì là -1, ngược lại thì 1
                    */
                    {
                        acc.MatKhau = txtMatKhauMoi.Text;
                        db.SaveChanges();
                        MessageBox.Show("Thay đổi mật khẩu thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("không thể thay đổi mật khẩu do thông tin tài khoản bị sai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
