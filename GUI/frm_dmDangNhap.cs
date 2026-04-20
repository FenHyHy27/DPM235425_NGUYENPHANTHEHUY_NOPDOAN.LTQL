using BUS;
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
    public partial class frm_dmDangNhap : Form
    {
        public frm_dmDangNhap()
        {
            InitializeComponent();
        }


        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string user = txtTenLogin.Text;
            string pass = txtPass.Text;

            TaiKhoan_DTO tk = TaiKhoan_BUS.DangNhap(user, pass);

            if (tk != null)
            {
                MessageBox.Show($"Chào mừng {tk.HoTen} ({tk.Quyen}) ");

                frmMain f = new frmMain(tk);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
