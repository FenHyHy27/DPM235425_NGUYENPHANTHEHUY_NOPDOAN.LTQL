using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmPhieuMuon : Form
    {
        private PhieuMuonBUS phieuMuonBUS = new PhieuMuonBUS();

        public frmPhieuMuon()
        {
            InitializeComponent();
            dgvDanhSach.Click += dgvDanhSach_Click;
        }


        void LoadComboBoxSach()
        {
            cboSach.DataSource = Sach_BUS.LayDanhSach();
            cboSach.DisplayMember = "TenSach"; 
            cboSach.ValueMember = "MaSach";    
        }

        private void GanAutoCompleteDocGia()
        {
            List<DocGia_DTO> danhSach = phieuMuonBUS.LayDanhSachDocGia();

            AutoCompleteStringCollection autoList = new AutoCompleteStringCollection();
            foreach (DocGia_DTO dg in danhSach)
                autoList.Add(dg.HoTen);

            txtTenDocGia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTenDocGia.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenDocGia.AutoCompleteCustomSource = autoList;
        }

        
        private void LoadDanhSachPhieuMuon()
        {
            List<PhieuMuonDTO> danhSach = phieuMuonBUS.LayDanhSachPhieuMuon();
            dgvDanhSach.DataSource = danhSach;

            if (dgvDanhSach.Columns.Count > 0)
            {
                dgvDanhSach.Columns["MaPhieu"].HeaderText = "Mã phiếu";
                dgvDanhSach.Columns["MaDocGia"].HeaderText = "Mã ĐG";
                dgvDanhSach.Columns["TenDocGia"].HeaderText = "Tên độc giả";
                dgvDanhSach.Columns["NgayMuon"].HeaderText = "Ngày mượn";
                dgvDanhSach.Columns["NgayHenTra"].HeaderText = "Ngày hẹn trả";
                dgvDanhSach.Columns["TinhTrang"].HeaderText = "Tình trạng";
                dgvDanhSach.Columns["MaDocGia"].Visible = false;
            }
        }

        private void dgvDanhSach_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count == 0) return;

            DataGridViewRow dr = dgvDanhSach.SelectedRows[0];

            txtMaPhieu.Text = dr.Cells["MaPhieu"].Value.ToString();
            txtMaDocGia.Text = dr.Cells["MaDocGia"].Value.ToString(); 
            txtTenDocGia.Text = dr.Cells["TenDocGia"].Value.ToString();

            dtpNgayMuon.Value = Convert.ToDateTime(dr.Cells["NgayMuon"].Value);
            dtpNgayHenTra.Value = Convert.ToDateTime(dr.Cells["NgayHenTra"].Value);

            string tinhTrang = dr.Cells["TinhTrang"].Value.ToString();
            int idx = cboTinhTrang.Items.IndexOf(tinhTrang);
            if (idx >= 0) cboTinhTrang.SelectedIndex = idx;

            int maPhieu = Convert.ToInt32(txtMaPhieu.Text);
            LoadChiTietPhieuMuon(maPhieu);
        }

        private void txtTenDocGia_Leave(object sender, EventArgs e)
        {
            string ten = txtTenDocGia.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                txtMaDocGia.Text = "";
                return;
            }

            int ma = phieuMuonBUS.TimMaDocGiaTheoTen(ten);
            if (ma > 0)
            {
                txtMaDocGia.Text = ma.ToString();
            }
            else
            {
                txtMaDocGia.Text = "";
                MessageBox.Show("Không tìm thấy độc giả \"" + ten + "\" trong hệ thống!\nVui lòng nhập đúng tên độc giả đã có.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDocGia.Focus();
            }
        }

        // Nút Thêm
        

        // Nút Sửa
        

        // Nút Xóa

        // Nút Tìm kiếm

        private void XoaForm()
        {
            txtMaPhieu.Text = "";
            txtMaDocGia.Text = "";
            txtTenDocGia.Text = "";
            dtpNgayMuon.Value = DateTime.Today;
            dtpNgayHenTra.Value = DateTime.Today.AddDays(14);
            cboTinhTrang.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDocGia.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên độc giả!");
                txtTenDocGia.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMaDocGia.Text))
            {
                txtTenDocGia_Leave(null, null);
                if (string.IsNullOrEmpty(txtMaDocGia.Text)) return;
            }

            PhieuMuonDTO pm = new PhieuMuonDTO();
            pm.MaDocGia = Convert.ToInt32(txtMaDocGia.Text);
            pm.TenDocGia = txtTenDocGia.Text.Trim();
            pm.NgayMuon = dtpNgayMuon.Value.Date;
            pm.NgayHenTra = dtpNgayHenTra.Value.Date;
            pm.TinhTrang = cboTinhTrang.SelectedItem.ToString();

            string thongBao;
            bool kq = phieuMuonBUS.ThemPhieuMuon(pm, out thongBao);
            MessageBox.Show(thongBao);

            if (kq)
            {
                LoadDanhSachPhieuMuon();
                XoaForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần sửa!");
                return;
            }
            if (string.IsNullOrEmpty(txtTenDocGia.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên độc giả!");
                txtTenDocGia.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMaDocGia.Text))
            {
                txtTenDocGia_Leave(null, null);
                if (string.IsNullOrEmpty(txtMaDocGia.Text)) return;
            }

            PhieuMuonDTO pm = new PhieuMuonDTO();
            pm.MaPhieu = Convert.ToInt32(txtMaPhieu.Text);
            pm.MaDocGia = Convert.ToInt32(txtMaDocGia.Text);
            pm.TenDocGia = txtTenDocGia.Text.Trim();
            pm.NgayMuon = dtpNgayMuon.Value.Date;
            pm.NgayHenTra = dtpNgayHenTra.Value.Date;
            pm.TinhTrang = cboTinhTrang.SelectedItem.ToString();

            string thongBao;
            bool kq = phieuMuonBUS.SuaPhieuMuon(pm, out thongBao);
            MessageBox.Show(thongBao);

            if (kq)
            {
                LoadDanhSachPhieuMuon();
                XoaForm();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần xóa!");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa phiếu mượn #" + txtMaPhieu.Text + " không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                int maPhieu = Convert.ToInt32(txtMaPhieu.Text);
                string thongBao;
                bool kq = phieuMuonBUS.XoaPhieuMuon(maPhieu, out thongBao);
                MessageBox.Show(thongBao);

                if (kq)
                {
                    LoadDanhSachPhieuMuon();
                    XoaForm();
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadDanhSachPhieuMuon();
                return;
            }

            List<PhieuMuonDTO> ketQua = phieuMuonBUS.TimKiemPhieuMuon(tuKhoa);
            dgvDanhSach.DataSource = ketQua;

            if (ketQua == null || ketQua.Count == 0)
                MessageBox.Show("Không tìm thấy kết quả!");
        }

        private void frmPhieuMuon_Load(object sender, EventArgs e)
        {
            GanAutoCompleteDocGia();

            LoadComboBoxSach();

            cboTinhTrang.Items.AddRange(new string[] { "Đang mượn", "Đã trả" });
            cboTinhTrang.SelectedIndex = 0;

            dtpNgayMuon.Value = DateTime.Today;
            dtpNgayHenTra.Value = DateTime.Today.AddDays(14);

            LoadDanhSachPhieuMuon();
        }

        void LoadChiTietPhieuMuon(int maPhieu)
        {
            dgvChiTiet.DataSource = ChiTietPhieuMuon_BUS.LayDanhSachTheoMaPhieu(maPhieu);

            if (dgvChiTiet.Columns.Count > 0)
            {
                dgvChiTiet.Columns["MaPhieu"].Visible = false;
                dgvChiTiet.Columns["MaSach"].Visible = false;
                dgvChiTiet.Columns["TenSach"].HeaderText = "Tên Sách";

                dgvChiTiet.Columns["NgayTraThucTe"].HeaderText = "Ngày Trả Thực Tế";
                dgvChiTiet.Columns["NgayTraThucTe"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvChiTiet.Columns["TienPhat"].HeaderText = "Tiền Phạt";
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text) || txtMaPhieu.Text == "0")
            {
                MessageBox.Show("Vui lòng LẬP PHIẾU MƯỢN mới (hoặc chọn 1 phiếu bên trên) trước khi thêm sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Sach_DTO sachDuocChon = (Sach_DTO)cboSach.SelectedItem;
            if (sachDuocChon == null) return;

            int soLuongTonKho = sachDuocChon.SoLuong;

            if (soLuongTonKho <= 0)
            {
                MessageBox.Show("Sách này đã hết trong kho, không thể mượn thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (dtpNgayHenTra.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Phiếu này đã trễ hạn, không thể cho mượn thêm sách vào phiếu này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChiTietPhieuMuon_DTO ct = new ChiTietPhieuMuon_DTO();
            ct.MaPhieu = Convert.ToInt32(txtMaPhieu.Text);
            ct.MaSach = sachDuocChon.MaSach;

            if (ChiTietPhieuMuon_BUS.Them(ct))
            {
                MessageBox.Show("Đã thêm sách vào phiếu mượn!");

                Sach_BUS.CapNhatSoLuong(ct.MaSach, -1);

                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is frm_dmQuanLySach formSach)
                    {
                        formSach.LoadDanhSach();
                        break;
                    }
                }

                LoadComboBoxSach();
                cboSach.SelectedValue = ct.MaSach;
                LoadChiTietPhieuMuon(ct.MaPhieu); 
            }
            else
            {
                MessageBox.Show("Thêm thất bại! (Sách này có thể đã được thêm vào phiếu rồi)");
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách trong danh sách chi tiết để xóa!");
                return;
            }

            DataGridViewRow row = dgvChiTiet.SelectedRows[0];
            int maPhieu = Convert.ToInt32(txtMaPhieu.Text);
            int maSach = Convert.ToInt32(row.Cells["MaSach"].Value);
            string tenSach = row.Cells["TenSach"].Value.ToString();

            bool daTraSach = row.Cells["NgayTraThucTe"].Value != null &&
                             !string.IsNullOrWhiteSpace(row.Cells["NgayTraThucTe"].Value.ToString());

            if (MessageBox.Show($"Bạn có chắc muốn xóa cuốn '{tenSach}' khỏi phiếu mượn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ChiTietPhieuMuon_BUS.Xoa(maPhieu, maSach))
                {
                    MessageBox.Show("Đã xóa sách khỏi phiếu!");

                    
                    if (daTraSach == false)
                    {
                        Sach_BUS.CapNhatSoLuong(maSach, 1);
                    }

                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm is frm_dmQuanLySach formSach)
                        {
                            formSach.LoadDanhSach();
                            break;
                        }
                    }
                    LoadChiTietPhieuMuon(maPhieu);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách bên dưới để trả!");
                return;
            }

            DataGridViewRow row = dgvChiTiet.SelectedRows[0];

            if (row.Cells["NgayTraThucTe"].Value != null && !string.IsNullOrEmpty(row.Cells["NgayTraThucTe"].Value.ToString()))
            {
                MessageBox.Show("Cuốn sách này đã được trả rồi, không thể trả lại!");
                return;
            }

            int maPhieu = Convert.ToInt32(txtMaPhieu.Text);
            int maSach = Convert.ToInt32(row.Cells["MaSach"].Value);
            string tenSach = row.Cells["TenSach"].Value.ToString();

            DateTime ngayHenTra = dtpNgayHenTra.Value.Date; 
            DateTime ngayTraThucTe = DateTime.Today;        
            decimal tienPhat = 0;

            if (ngayTraThucTe > ngayHenTra)
            {
                int soNgayTre = (ngayTraThucTe - ngayHenTra).Days;
                tienPhat = soNgayTre * 5000; 

                MessageBox.Show($"Cuốn '{tenSach}' trả trễ {soNgayTre} ngày.\nTiền phạt: {tienPhat:N0} VNĐ", "Thông báo nộp phạt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (ChiTietPhieuMuon_BUS.CapNhatTraSach(maPhieu, maSach, ngayTraThucTe, tienPhat))
            {
                MessageBox.Show($"Đã trả sách: {tenSach}!");

                Sach_BUS.CapNhatSoLuong(maSach, 1);

                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is frm_dmQuanLySach formSach)
                    {
                        formSach.LoadDanhSach();
                        break;
                    }
                }

                LoadChiTietPhieuMuon(maPhieu);
            }
            else
            {
                MessageBox.Show("Lỗi hệ thống, không thể trả sách!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            txtMaDocGia.Clear();
            txtTenDocGia.Clear();
            dtpNgayMuon.Value = DateTime.Today;
            dtpNgayHenTra.Value = DateTime.Today;
            if (cboTinhTrang.Items.Count > 0)
                cboTinhTrang.SelectedIndex = 0;
            if (cboSach.Items.Count > 0)
                cboSach.SelectedIndex = 0;
            LoadDanhSachPhieuMuon();
            LoadChiTietPhieuMuon(0);
            txtTenDocGia.Focus();
        }
    }
}
