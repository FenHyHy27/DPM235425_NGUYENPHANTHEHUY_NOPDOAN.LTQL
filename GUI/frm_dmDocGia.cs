using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_dmDocGia : Form
    {
        public frm_dmDocGia()
        {
            InitializeComponent();
            this.Load += frm_dmDocGia_Load;
            dgv.CellClick += dgv_CellClick;

            txtMaDocGia.Enabled = false;
        }

        private void frm_dmDocGia_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        void LoadDanhSach()
        {
            try
            {
                dgv.DataSource = null;
                dgv.DataSource = DocGia_BUS.LayDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        void LamMoiForm()
        {
            txtMaDocGia.Text = "";
            txtHoTen.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            dtpNgayLapThe.Value = DateTime.Today;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgv.Rows[e.RowIndex];

            txtMaDocGia.Text = row.Cells["MaDocGia"].Value?.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();

            if (row.Cells["NgayLapThe"].Value != null &&
                row.Cells["NgayLapThe"].Value != DBNull.Value)
            {
                dtpNgayLapThe.Value = DateTime.Parse(
                    row.Cells["NgayLapThe"].Value.ToString());
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                return;
            }

            DocGia_DTO dg = new DocGia_DTO
            {
                HoTen = txtHoTen.Text,
                SoDienThoai = txtSoDienThoai.Text,
                DiaChi = txtDiaChi.Text,
                NgayLapThe = dtpNgayLapThe.Value
            };

            if (DocGia_BUS.Them(dg))
            {
                MessageBox.Show("Thêm thành công!");
                LoadDanhSach();
                LamMoiForm();
            }
            else MessageBox.Show("Thêm thất bại!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDocGia.Text))
            {
                MessageBox.Show("Vui lòng chọn đọc giả cần sửa!");
                return;
            }

            DocGia_DTO dg = new DocGia_DTO
            {
                MaDocGia = int.Parse(txtMaDocGia.Text),
                HoTen = txtHoTen.Text,
                SoDienThoai = txtSoDienThoai.Text,
                DiaChi = txtDiaChi.Text,
                NgayLapThe = dtpNgayLapThe.Value
            };

            if (DocGia_BUS.Sua(dg))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadDanhSach();
            }
            else MessageBox.Show("Cập nhật thất bại!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDocGia.Text))
            {
                MessageBox.Show("Vui lòng chọn đọc giả cần xóa!");
                return;
            }

            if (MessageBox.Show(
                "Xác nhận xóa đọc giả: " + txtHoTen.Text + "?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (DocGia_BUS.Xoa(int.Parse(txtMaDocGia.Text)))
                {
                    MessageBox.Show("Đã xóa!");
                    LoadDanhSach();
                    LamMoiForm();
                }
                else MessageBox.Show("Xóa thất bại! Có thể đọc giả đang có phiếu mượn.");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadDanhSach();
                return;
            }

            List<DocGia_DTO> ketQua = DocGia_BUS.TimKiemDocGia(tuKhoa);
            dgv.DataSource = ketQua;

            if (ketQua == null || ketQua.Count == 0)
                MessageBox.Show("Không tìm thấy kết quả!");
        }
    }
}