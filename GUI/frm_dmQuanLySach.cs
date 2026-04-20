using BUS;
using DTO;
using System;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data;
namespace GUI
{
    public partial class frm_dmQuanLySach : Form
    {

        public frm_dmQuanLySach()
        {
            InitializeComponent();
            this.Load += frm_dmQuanLySach_Load;
            dgv.CellClick += dgv_CellClick;
        }

        private void frm_dmQuanLySach_Load(object sender, EventArgs e)
        {
            LoadComboBoxTheLoai();
            LoadDanhSach();
        }

        void LoadComboBoxTheLoai()
        {
            cboTheLoai.DataSource = TheLoai_BUS.LayDanhSach();
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";
        }

        public void LoadDanhSach()
        {
            try
            {
                dgv.DataSource = Sach_BUS.LayDanhSach();
                if (dgv.Columns["MaTheLoai"] != null)
                {
                    dgv.Columns["MaTheLoai"].Visible = false;
                }

                dgv.Columns["MaSach"].HeaderText = "Mã sách";
                dgv.Columns["TenSach"].HeaderText = "Tên sách";
                dgv.Columns["TacGia"].HeaderText = "Tác giả";
                dgv.Columns["TenTheLoai"].HeaderText = "Thể loại";
                dgv.Columns["SoLuong"].HeaderText = "Số lượng";
                dgv.Columns["NamXuatBan"].HeaderText = "Năm xuất bản";

                dgv.Columns["TenSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgv.Rows[e.RowIndex];

            txtMaSach.Text = row.Cells["MaSach"].Value?.ToString();
            txtTenSach.Text = row.Cells["TenSach"].Value?.ToString();
            txtTacGia.Text = row.Cells["TacGia"].Value?.ToString();
            cboTheLoai.SelectedValue = int.Parse(row.Cells["MaTheLoai"].Value?.ToString() ?? "0");
            txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();

            int nam = int.Parse(row.Cells["NamXuatBan"].Value?.ToString() ?? "2000");
            dtpNamXuatBan.Value = new DateTime(nam, 1, 1);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoLuong.Text, out int soLuongDuocNhap) || soLuongDuocNhap < 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng là một con số hợp lệ và lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Sach_DTO s = new Sach_DTO
            {
                TenSach = txtTenSach.Text,
                TacGia = txtTacGia.Text,
                MaTheLoai = Convert.ToInt32(cboTheLoai.SelectedValue),
                SoLuong = int.Parse(txtSoLuong.Text),
                NamXuatBan = dtpNamXuatBan.Value.Year
            };
            if (Sach_BUS.Them(s))
            { MessageBox.Show("Thêm thành công!"); LoadDanhSach(); }
            else MessageBox.Show("Thêm thất bại!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoLuong.Text, out int soLuongDuocNhap) || soLuongDuocNhap < 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng là một con số hợp lệ và lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Sach_DTO s = new Sach_DTO
            {
                MaSach = int.Parse(txtMaSach.Text),
                TenSach = txtTenSach.Text,
                TacGia = txtTacGia.Text,
                MaTheLoai = Convert.ToInt32(cboTheLoai.SelectedValue),
                SoLuong = int.Parse(txtSoLuong.Text),
                NamXuatBan = dtpNamXuatBan.Value.Year
            };
            if (Sach_BUS.Sua(s))
            { MessageBox.Show("Cập nhật thành công!"); LoadDanhSach(); }
            else MessageBox.Show("Cập nhật thất bại!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text)) return;
            if (MessageBox.Show("Xác nhận xóa?", "", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                if (Sach_BUS.Xoa(int.Parse(txtMaSach.Text)))
                { MessageBox.Show("Đã xóa!"); LoadDanhSach(); }
                else MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = Sach_BUS.LayDataTableSach();
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "Danh mục Sách");
                ws.Columns().AdjustToContents();

                SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTacGia.Clear();
            txtSoLuong.Clear();

            if (cboTheLoai.Items.Count > 0)
                cboTheLoai.SelectedIndex = 0;
            dtpNamXuatBan.Value = DateTime.Now;
            LoadDanhSach();
            txtTenSach.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}