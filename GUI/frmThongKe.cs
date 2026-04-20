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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
            this.Load += frmThongKe_Load;
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {

            lblTongSach.Text   = BUS.ThongKe_BUS.TongSoSach().ToString();
            lblDangMuon.Text   = BUS.ThongKe_BUS.TongSachDangMuon().ToString();
            lblTreHan.Text     = BUS.ThongKe_BUS.TongDocGiaTreHan().ToString();

            dgvSachDangMuon.DataSource = BUS.ThongKe_BUS.DanhSachSachDangMuon();

            dgvDocGiaTreHan.DataSource = BUS.ThongKe_BUS.DanhSachDocGiaTreHan();
        }

        
    }
}
