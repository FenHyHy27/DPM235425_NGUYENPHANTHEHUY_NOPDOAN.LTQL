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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            prgLoading.Value += 2;

            if (prgLoading.Value >= 100)
            {
                timer1.Stop(); 

                
                frm_dmDangNhap fLogin = new frm_dmDangNhap();
                this.Hide(); 
                fLogin.ShowDialog();
                this.Close(); 
            }
        }
    }
}
