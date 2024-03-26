using PS28709_QuanBichVan.Bus;
using PS28709_QuanBichVan.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS28709_QuanBichVan.View.UI.QuanLy
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            Products_Load(false);
            LoadDataGridView();
        }
        private void initGridView()
        {
            dataGridView1.Columns[0].HeaderText = "Mã Sản Phẩm";
            dataGridView1.Columns[2].HeaderText = "Tên Sản Phẩm";
            dataGridView1.Columns[3].HeaderText = "Số Lượng";
            dataGridView1.Columns[4].HeaderText = "Đơn Giá Nhập";
            dataGridView1.Columns[5].HeaderText = "Đơn Giá Bán";
            dataGridView1.Columns[6].HeaderText = "Hình Ảnh";
            dataGridView1.Columns[7].HeaderText = "Ghi Chú";
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
        
        private void LoadDataGridView()
        {
            using (DuAnMauEntities db = new DuAnMauEntities())
            {
                dataGridView1.DataSource = db.Hang.ToList();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                initGridView();
            }
        }
        private Hang getFromForm()
        {
            Hang sp = new Hang();
            sp.TenHang = txtTenSP.Text;
            sp.SoLuong = int.TryParse(txtSoLuong.Text, out int soLuong) ? soLuong : 0;
            sp.DonGiaNhap = int.TryParse(txtDonGiaNhap.Text, out int donGiaNhap) ? donGiaNhap : 0;
            sp.DonGiaBan = int.TryParse(txtDonGiaBan.Text, out int donGiaBan) ? donGiaBan : 0;
            sp.HinhAnh = txtHinhAnh.Text;
            sp.GhiChu = txtGhiChu.Text;
            return sp;
        }
        private void setForm(Hang sp)
        {
            txtMaSP.Text = sp.MaHang.ToString();
            txtTenSP.Text = sp.TenHang;
            txtSoLuong.Text = sp.SoLuong.ToString();
            txtDonGiaNhap.Text = sp.DonGiaNhap.ToString();
            txtDonGiaBan.Text = sp.DonGiaBan.ToString();
            txtHinhAnh.Text = sp.HinhAnh;
            txtGhiChu.Text = sp.GhiChu;

            // Kiểm tra xem đường dẫn đến hình ảnh có hợp lệ không
            if (!string.IsNullOrEmpty(sp.HinhAnh) && System.IO.File.Exists(sp.HinhAnh))
            {
                pictureBox1.Image = Image.FromFile(sp.HinhAnh);
            }
            else
            {
                // Nếu đường dẫn không hợp lệ hoặc không tồn tại, hiển thị hình mặc định hoặc thông báo lỗi
                pictureBox1.Image = null; // Hoặc có thể gán hình mặc định vào đây.
                                          // Hoặc hiển thị thông báo lỗi:
                                          // MessageBox.Show("Không tìm thấy hình ảnh hoặc đường dẫn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow gridViewRow = dataGridView1.Rows[e.RowIndex];
            txtMaSP.Text = gridViewRow.Cells[0].Value.ToString();
            txtTenSP.Text = gridViewRow.Cells[2].Value.ToString();
            txtSoLuong.Text = gridViewRow.Cells[3].Value.ToString();
            txtDonGiaNhap.Text = gridViewRow.Cells[4].Value.ToString();
            txtDonGiaBan.Text = gridViewRow.Cells[5].Value.ToString();
            txtHinhAnh.Text = gridViewRow.Cells[6].Value.ToString();

            string imagePath = gridViewRow.Cells[6].Value.ToString();
            if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
            }
            else
            {
                // Handle case where the image path is not valid
                pictureBox1.Image = null;
            }

            txtGhiChu.Text = gridViewRow.Cells[7].Value.ToString();
        }


        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void Products_Load(bool onOrOff)
        {
            txtMaSP.Enabled = onOrOff;
            txtTenSP.Enabled = onOrOff;
            txtSoLuong.Enabled = onOrOff;
            txtDonGiaNhap.Enabled = onOrOff;
            txtDonGiaBan.Enabled = onOrOff;
            txtHinhAnh.Enabled = onOrOff;
            txtGhiChu.Enabled = onOrOff;
            btnXoa.Enabled = onOrOff;
            btnSua.Enabled = onOrOff;
            btnLuu.Enabled = onOrOff;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Products_Load(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DuAnMauEntities db = new DuAnMauEntities();
            Hang sanPham = GetForm();
            sanPham.MaNV = StaticAuth.auth.MaNV;

            try
            {
                db.Hang.Add(sanPham);
                db.SaveChanges();
                Products_Load(false);
                LoadDataGridView();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                if (ex.InnerException is System.Data.SqlClient.SqlException sqlException && sqlException.Number == 2601)
                {
                    MessageBox.Show("Mã sản phẩm bị trùng. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi lưu dữ liệu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            Hang sp = GetForm();
            sp.MaNV = StaticAuth.auth.MaNV;
            DuAnMauEntities db = new DuAnMauEntities();
            db.Hang.AddOrUpdate(sp);
            db.SaveChanges();
            LoadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maHangToDelete = Convert.ToInt32(txtNhapMaSP.Text);
                using (DuAnMauEntities db = new DuAnMauEntities())
                {
                    var sanPhamToRemove = db.Hang.FirstOrDefault(sp => sp.MaHang == maHangToDelete);
                    if (sanPhamToRemove != null)
                    {
                        db.Hang.Remove(sanPhamToRemove);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập mã hàng hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadDataGridView();
        }


        private void btnBoQua_Click(object sender, EventArgs e)
        {
            SetForm(new Hang());
        }

        private Hang GetForm()
        {
            Hang sp = new Hang();
            sp.MaHang = Convert.ToInt32(txtMaSP.Text);
            sp.TenHang = txtTenSP.Text;
            sp.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            sp.DonGiaNhap = float.Parse(txtDonGiaNhap.Text);
            sp.DonGiaBan = float.Parse(txtDonGiaBan.Text);
            sp.HinhAnh = txtHinhAnh.Text;
            sp.GhiChu = txtGhiChu.Text;
            return sp;
        }


        private void SetForm(Hang sanPham)
        {
            txtMaSP.Text = sanPham.MaHang.ToString();
            txtTenSP.Text = sanPham.TenHang;
            txtSoLuong.Text = sanPham.SoLuong.ToString();
            txtDonGiaNhap.Text = sanPham.DonGiaNhap.ToString();
            txtDonGiaBan.Text = sanPham.DonGiaBan.ToString();
            txtHinhAnh.Text = sanPham.HinhAnh;
            if (!string.IsNullOrEmpty(sanPham.HinhAnh) && System.IO.File.Exists(sanPham.HinhAnh))
            {
                pictureBox1.Image = Image.FromFile(sanPham.HinhAnh);
            }
            txtGhiChu.Text = sanPham.GhiChu;
        }
        private void btnThemHinh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string duongDanHinhAnh = openFileDialog.FileName;

                    // Lưu đường dẫn hình ảnh vào textbox hoặc chuỗi trong cơ sở dữ liệu.
                    // Ví dụ: txtHinhAnh.Text = duongDanHinhAnh;

                    // Hiển thị hình ảnh trên PictureBox.
                    pictureBox1.Image = new Bitmap(duongDanHinhAnh);
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
                txtHinhAnh.Text = open.FileName;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DuAnMauEntities db = new DuAnMauEntities();
            if (int.TryParse(txtNhapMaSP.Text, out int maHang))
            {
                Hang sp = db.Hang.FirstOrDefault(p => p.MaHang == maHang);
                if (sp != null)
                {
                    setForm(sp);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBoQua_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
