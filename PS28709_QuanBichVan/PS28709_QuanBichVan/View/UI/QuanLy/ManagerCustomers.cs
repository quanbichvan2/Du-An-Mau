using PS28709_QuanBichVan.Bus;
using PS28709_QuanBichVan.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS28709_QuanBichVan.View.UI.QuanLy
{
    public partial class ManagerCustomers : Form
    {

        public ManagerCustomers()
        {
            InitializeComponent();
            ManagerCustomers_Load(false);
            LoadDataGridView();
        }

        private void initGridView()
        {
            dataGridView1.Columns[0].HeaderText = "Phone number";
            dataGridView1.Columns[1].HeaderText = "Full name";
            dataGridView1.Columns[2].HeaderText = "Address";
            dataGridView1.Columns[3].HeaderText = "Gender";
            dataGridView1.Columns[0].Width = 180;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].Width = 100;
            /*
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            */
            dataGridView1.Columns["NhanVien"].Visible = false;
            dataGridView1.Columns["MaNV"].Visible = false;
        }                                                        
        private void btnDong_Click(object sender, EventArgs e)   
        {
            DialogResult x = MessageBox.Show("Bạn có thật sự muốn thoát ứng dụng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void ManagerCustomers_Load(bool onOrOff)
        {
            txtDiaChi.Enabled = onOrOff;
            txtSDT.Enabled = onOrOff;
            txtHoVaTen.Enabled = onOrOff;
            rdioNam.Enabled = onOrOff;
            rdioNu.Enabled = onOrOff;
            btnXoa.Enabled = onOrOff;
            btnSua.Enabled = onOrOff;
            btnLuu.Enabled = onOrOff;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            ManagerCustomers_Load(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DuAnMauEntities db = new DuAnMauEntities();
            KhachHang kh = getFromForm();
            kh.MaNV = StaticAuth.auth.MaNV;
            db.KhachHang.Add(kh);
            db.SaveChanges();
            ManagerCustomers_Load(false);
            LoadDataGridView();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin khách hàng từ cơ sở dữ liệu
            KhachHang kh = getFromForm();
            kh.MaNV = StaticAuth.auth.MaNV;
            DuAnMauEntities db = new DuAnMauEntities();
            db.KhachHang.AddOrUpdate(kh); //nếu trùng khóa chính thì update, còn không thì thêm mới
            db.SaveChanges();
            LoadDataGridView();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DuAnMauEntities db = new DuAnMauEntities();
                var removeObject = db.KhachHang.FirstOrDefault(p => p.Dienthoai == txtSDT.Text);
                db.KhachHang.Remove(removeObject);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng khách hàng cần xóa","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            DuAnMauEntities db = new DuAnMauEntities();
            dataGridView1.DataSource = db.KhachHang.ToList();
            initGridView();
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            setForm(new KhachHang());
            rdioNu.Checked = false;
        }
        private KhachHang getFromForm()
        {
            KhachHang kh = new KhachHang();
            kh.TenKhach = txtHoVaTen.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.Dienthoai = txtSDT.Text;
            kh.Phai = rdioNam.Checked ? "male" : "female";
            return kh;
        }
        private void setForm(KhachHang kh)
        {
            txtHoVaTen.Text = kh.TenKhach;
            txtDiaChi.Text = kh.DiaChi;
            txtSDT.Text = kh.Dienthoai;

            if (string.Compare(kh.Phai, "male") == 0)
            {
                rdioNam.Checked = true;
            }
            else
            {
                rdioNu.Checked = true;    
            }

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DuAnMauEntities db = new DuAnMauEntities();
            KhachHang kh = db.KhachHang.FirstOrDefault(p => p.Dienthoai == txtNhapSDT.Text);
            if (kh != null)
            {
                setForm(kh);
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBoQua_Click(sender, e);

            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow gridViewRow = new DataGridViewRow();
            gridViewRow = dataGridView1.Rows[e.RowIndex];
            txtSDT.Text = gridViewRow.Cells[0].Value.ToString();
            txtHoVaTen.Text = gridViewRow.Cells[1].Value.ToString();
            txtDiaChi.Text = gridViewRow.Cells[2].Value.ToString();
            string gioiTinhValue = gridViewRow.Cells[3].Value.ToString();
            if (string.Compare(gioiTinhValue, "male") == 0)
            {
                rdioNam.Checked = true;
            } 
            else
            {
                rdioNu.Checked = true;
            }
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        
    }
    
}
