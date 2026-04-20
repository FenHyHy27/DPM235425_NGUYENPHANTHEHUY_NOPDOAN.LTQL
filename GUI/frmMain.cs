using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain : Form
    {
        TaiKhoan_DTO loginUser;
        public frmMain(TaiKhoan_DTO user)
        {
            InitializeComponent();
            this.loginUser = user;

            if (loginUser != null)
            {
                this.Text = "Hệ thống Quản lý Thư viện - Xin chào: " + loginUser.HoTen;

                if (loginUser.Quyen == "Thủ thư")
                {
                    // Vô hiệu hóa các tính năng quản trị
                    hệThốngToolStripMenuItem.Enabled = false;
                    quảnLýSáchToolStripMenuItem.Enabled = false;
                }
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.Name == "frm_dmQuanLySach")
                {
                    child.Activate();
                    return;
                }
            }
            frm_dmQuanLySach f = new frm_dmQuanLySach();
            f.MdiParent = this;
            f.Show();
        }

        private void quảnLýĐọcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.Name == "frm_dmDocGia")
                {
                    child.Activate();
                    return;
                }
            }
            frm_dmDocGia f = new frm_dmDocGia();
            f.MdiParent = this;
            f.Show();
        }

        private void quảnLýPhiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.Name == "frmPhieuMuon")
                {
                    child.Activate();
                    return;
                }
            }
            frmPhieuMuon f = new frmPhieuMuon();
            f.MdiParent = this;
            f.Show();
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string linkHuongDan = "https://docs.google.com/document/d/1q9kDoo5EgGSDMQnyTgvaHNKrJ4AUrAmygO5BZsMSh3I/edit?usp=sharing";
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = linkHuongDan,
                    UseShellExecute = true
                });
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể mở trình duyệt web. Vui lòng kiểm tra lại kết nối mạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.Name == "frmThongKe")
                {
                    child.Activate();
                    return;
                }
            }
            frmThongKe f = new frmThongKe();
            f.MdiParent = this;
            f.Show();
        }

        private void saoLưuDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Backup Files (*.bak)|*.bak"; 
            sfd.FileName = "QuanLyThuVien_Backup_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".bak";
            sfd.Title = "Chọn nơi lưu file Sao lưu";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (BUS.HeThong_BUS.SaoLuuDuLieu(sfd.FileName))
                {
                    MessageBox.Show("Đã sao lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sao lưu thất bại! Vui lòng lưu file sang ổ đĩa khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void phụcHồiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Backup Files (*.bak)|*.bak";
            ofd.Title = "Chọn file Phục hồi dữ liệu";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DialogResult xacNhan = MessageBox.Show("Bạn có chắc chắn muốn phục hồi? Toàn bộ dữ liệu hiện tại sẽ bị xóa và ghi đè bằng file backup!", "Cảnh báo nguy hiểm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (xacNhan == DialogResult.Yes)
                {
                    if (BUS.HeThong_BUS.PhucHoiDuLieu(ofd.FileName))
                    {
                        MessageBox.Show("Phục hồi dữ liệu thành công! Phần mềm sẽ tự động khởi động lại để cập nhật dữ liệu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Khởi động lại ứng dụng để tải lại toàn bộ form và số liệu
                        Application.Restart();
                    }
                    else
                    {
                        MessageBox.Show("Phục hồi thất bại! Vui lòng kiểm tra lại file backup.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult xacNhan = MessageBox.Show("Bạn có chắc chắn muốn thoát phần mềm không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (xacNhan == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
