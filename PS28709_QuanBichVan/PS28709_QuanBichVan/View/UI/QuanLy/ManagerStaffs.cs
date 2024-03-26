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
    public partial class ManagerStaffs : Form
    {
        public ManagerStaffs()
        {
            InitializeComponent();
            ManagerStaffs_Load(false);
            LoadDataGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Bạn có thật sự muốn thoát ứng dụng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ManagerStaffs_Load(bool onOrOff)
        {
            txtEmail.Enabled = onOrOff;
            txtTenNV.Enabled = onOrOff;
            txtDiaChi.Enabled = onOrOff;
            txtNhapMaNV.Enabled = onOrOff;
            rdioNV.Enabled = onOrOff;
            rdioQuanTriVien.Enabled = onOrOff;
            rdioHoatDong.Enabled = onOrOff;
            rdioNgungHoatDong.Enabled = onOrOff;
            btnSua.Enabled = onOrOff;
            btnLuu.Enabled = onOrOff;
            btnXoa.Enabled = onOrOff;
        }
        private void initGridView()
        {
            dataGridView1.Columns[1].HeaderText = "Mã Nhân Viên";
            dataGridView1.Columns[2].HeaderText = "Email";
            dataGridView1.Columns[3].HeaderText = "Họ Và Tên";
            dataGridView1.Columns[4].HeaderText = "Địa chỉ";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 500;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["VaiTro"].Visible = false;
            dataGridView1.Columns["TinhTrang"].Visible = false;
            dataGridView1.Columns["MatKhau"].Visible = false;
            dataGridView1.Columns["Hang"].Visible = false;
            dataGridView1.Columns["KhachHang"].Visible = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ManagerStaffs_Load(true);
        }

        private NhanVien getFromForm()
        {
            NhanVien nv = new NhanVien();
            nv.Email = txtEmail.Text;
            nv.HoVaTen = txtTenNV.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.VaiTro = (byte)(rdioNV.Checked ? 0 : 1);
            if (rdioQuanTriVien.Checked)
            {
                // Tạo mã nhân viên cho quản trị viên
                nv.MaNV = "admin" + GetNextNhanVienNumber().ToString();
            }
            else
            {
                // Tạo mã nhân viên cho nhân viên
                nv.MaNV = "nv" + GetNextNhanVienNumber().ToString("D3");
            }
            // Gán mật khẩu mặc định là "123"
            nv.MatKhau = "123";
            return nv;
        }

        private int GetNextNhanVienNumber()
        {
            DuAnMauEntities db = new DuAnMauEntities();
            var nhanViens = db.NhanVien.ToList();

            int maxNumber = 0;

            foreach (var nhanVien in nhanViens)
            {
                if (int.TryParse(nhanVien.MaNV.Substring(2), out int number))
                {
                    maxNumber = Math.Max(maxNumber, number);
                }
            }

            return maxNumber + 1;
        }


        private void setForm(NhanVien nv)
        {
            txtEmail.Text = nv.Email;
            txtTenNV.Text = nv.HoVaTen;
            txtDiaChi.Text = nv.DiaChi;

            if (nv.VaiTro == 0)
            {
                rdioNV.Checked = true;
            }
            else
            {
                rdioQuanTriVien.Checked = true;
            }
            if(nv.TinhTrang == 1)
            {
                rdioHoatDong.Checked = true;
            }
            else
            {
                rdioNgungHoatDong.Checked = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DuAnMauEntities db = new DuAnMauEntities();
                var removeObject = db.NhanVien.FirstOrDefault(p => p.HoVaTen == txtNhapMaNV.Text);

                if (removeObject != null)
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên có mã: " + removeObject.MaNV + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            db.NhanVien.Remove(removeObject);
                            db.SaveChanges();
                            MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Xóa không thành công. Vui lòng kiểm tra lại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên có tên: " + txtNhapMaNV.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa không thành công. Vui lòng kiểm tra lại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadDataGridView();
        }



        private void LoadDataGridView()
        {
            DuAnMauEntities db = new DuAnMauEntities();
            dataGridView1.DataSource = db.NhanVien.ToList();
            initGridView();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy mã nhân viên cần sửa
            string maNhanVien = txtNhapMaNV.Text;

            // Lấy thông tin nhân viên từ cơ sở dữ liệu
            DuAnMauEntities db = new DuAnMauEntities();
            NhanVien existingNv = db.NhanVien.FirstOrDefault(n => n.MaNV == maNhanVien);

            if (existingNv != null)
            {
                // Lưu trạng thái ban đầu của thông tin nhân viên
                string hoVaTenBanDau = existingNv.HoVaTen;
                string emailBanDau = existingNv.Email;
                string diaChiBanDau = existingNv.DiaChi;
                byte vaiTroBanDau = existingNv.VaiTro;

                // Kiểm tra xem các giá trị trên form có thay đổi hay không
                if (txtTenNV.Text != hoVaTenBanDau || txtEmail.Text != emailBanDau || txtDiaChi.Text != diaChiBanDau ||
                    (rdioNV.Checked ? 0 : 1) != vaiTroBanDau)
                {
                    // Có sự thay đổi, cập nhật thông tin nhân viên từ form
                    existingNv.HoVaTen = txtTenNV.Text;
                    existingNv.Email = txtEmail.Text;
                    existingNv.DiaChi = txtDiaChi.Text;
                    existingNv.VaiTro = (byte)(rdioNV.Checked ? 0 : 1);

                    db.SaveChanges();
                    LoadDataGridView();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có thông tin mới để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên có mã: " + maNhanVien, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            DuAnMauEntities db = new DuAnMauEntities();
            NhanVien nv = getFromForm();

            // Kiểm tra xem mã nhân viên đã tồn tại trong cơ sở dữ liệu hay chưa
            if (db.NhanVien.Any(n => n.MaNV == nv.MaNV))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                db.NhanVien.Add(nv);
                db.SaveChanges();
                ManagerStaffs_Load(false);
                LoadDataGridView();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo chỉ xử lý khi một dòng hợp lệ được chọn.
            {
                DataGridViewRow gridViewRow = dataGridView1.Rows[e.RowIndex];
                txtEmail.Text = gridViewRow.Cells[2].Value.ToString();
                txtTenNV.Text = gridViewRow.Cells[3].Value.ToString();
                txtDiaChi.Text = gridViewRow.Cells[7].Value.ToString();

                // Xử lý giá trị cho VaiTro
                string vaiTroValue = gridViewRow.Cells[5].Value.ToString();
                if (string.Compare(vaiTroValue, "0") == 0)
                {
                    rdioNV.Checked = true;
                    rdioQuanTriVien.Checked = false;
                }
                else if (string.Compare(vaiTroValue, "1") == 0)
                {
                    rdioNV.Checked = false;
                    rdioQuanTriVien.Checked = true;
                }
                // Xử lý giá trị cho TinhTrang
                string tinhTrangValue = gridViewRow.Cells[6].Value.ToString();
                if (string.Compare(tinhTrangValue, "1") == 0)
                {
                    rdioHoatDong.Checked = true;
                    rdioNgungHoatDong.Checked = false;
                }
                else if (string.Compare(tinhTrangValue, "0") == 0)
                {
                    rdioHoatDong.Checked = false;
                    rdioNgungHoatDong.Checked = true;
                }
            }
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DuAnMauEntities db = new DuAnMauEntities();
            NhanVien nv = db.NhanVien.FirstOrDefault(p => p.MaNV == txtNhapMaNV.Text);
            if (nv != null)
            {
                setForm(nv);
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBoQua_Click(sender, e);

            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            setForm(new NhanVien());
            rdioHoatDong.Checked = false;
            rdioNgungHoatDong.Checked= false;
            rdioNV.Checked = false;
            rdioQuanTriVien.Checked = false;
        }

    }
}
