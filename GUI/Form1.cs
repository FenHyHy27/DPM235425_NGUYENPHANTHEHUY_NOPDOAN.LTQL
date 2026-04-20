using BUS;
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
    public partial class Form1 : Form
    {
        private TheLoaiBUS theLoaiBUS = new TheLoaiBUS();
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            dgvTheLoai.DataSource = theLoaiBUS.LayDanhSachTheLoai();
            dgvTheLoai.Columns["MaTheLoai"].HeaderText = "Mã Thể Loại";
            dgvTheLoai.Columns["TenTheLoai"].HeaderText = "Tên Thể Loại";
            dgvTheLoai.Columns["TenTheLoai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
