namespace GUI
{
    partial class frmThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTongSach = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDangMuon = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTreHan = new System.Windows.Forms.Label();
            this.lblTitleSachMuon = new System.Windows.Forms.Label();
            this.dgvSachDangMuon = new System.Windows.Forms.DataGridView();
            this.lblTitleTreHan = new System.Windows.Forms.Label();
            this.dgvDocGiaTreHan = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachDangMuon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGiaTreHan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thống kê sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thống kê số sách đang mượn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(5, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đọc giả trễ hạn trả sách";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lblTongSach);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 69);
            this.panel1.TabIndex = 4;
            // 
            // lblTongSach
            // 
            this.lblTongSach.AutoSize = true;
            this.lblTongSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongSach.Location = new System.Drawing.Point(3, 31);
            this.lblTongSach.Name = "lblTongSach";
            this.lblTongSach.Size = new System.Drawing.Size(36, 38);
            this.lblTongSach.TabIndex = 0;
            this.lblTongSach.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.lblDangMuon);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(251, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(616, 69);
            this.panel2.TabIndex = 5;
            // 
            // lblDangMuon
            // 
            this.lblDangMuon.AutoSize = true;
            this.lblDangMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDangMuon.Location = new System.Drawing.Point(3, 31);
            this.lblDangMuon.Name = "lblDangMuon";
            this.lblDangMuon.Size = new System.Drawing.Size(36, 38);
            this.lblDangMuon.TabIndex = 0;
            this.lblDangMuon.Text = "0";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightCoral;
            this.panel3.Controls.Add(this.lblTreHan);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(15, 305);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(861, 68);
            this.panel3.TabIndex = 6;
            // 
            // lblTreHan
            // 
            this.lblTreHan.AutoSize = true;
            this.lblTreHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTreHan.Location = new System.Drawing.Point(3, 27);
            this.lblTreHan.Name = "lblTreHan";
            this.lblTreHan.Size = new System.Drawing.Size(36, 38);
            this.lblTreHan.TabIndex = 0;
            this.lblTreHan.Text = "0";
            // 
            // lblTitleSachMuon
            // 
            this.lblTitleSachMuon.AutoSize = true;
            this.lblTitleSachMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitleSachMuon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.lblTitleSachMuon.Location = new System.Drawing.Point(11, 89);
            this.lblTitleSachMuon.Name = "lblTitleSachMuon";
            this.lblTitleSachMuon.Size = new System.Drawing.Size(335, 22);
            this.lblTitleSachMuon.TabIndex = 7;
            this.lblTitleSachMuon.Text = "📚 Danh sách sách đang được mượn";
            // 
            // dgvSachDangMuon
            // 
            this.dgvSachDangMuon.AllowUserToAddRows = false;
            this.dgvSachDangMuon.AllowUserToDeleteRows = false;
            this.dgvSachDangMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSachDangMuon.BackgroundColor = System.Drawing.Color.White;
            this.dgvSachDangMuon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSachDangMuon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSachDangMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachDangMuon.EnableHeadersVisualStyles = false;
            this.dgvSachDangMuon.Location = new System.Drawing.Point(15, 113);
            this.dgvSachDangMuon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSachDangMuon.Name = "dgvSachDangMuon";
            this.dgvSachDangMuon.ReadOnly = true;
            this.dgvSachDangMuon.RowHeadersWidth = 51;
            this.dgvSachDangMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSachDangMuon.Size = new System.Drawing.Size(861, 187);
            this.dgvSachDangMuon.TabIndex = 8;
            // 
            // lblTitleTreHan
            // 
            this.lblTitleTreHan.AutoSize = true;
            this.lblTitleTreHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitleTreHan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitleTreHan.Location = new System.Drawing.Point(11, 377);
            this.lblTitleTreHan.Name = "lblTitleTreHan";
            this.lblTitleTreHan.Size = new System.Drawing.Size(352, 22);
            this.lblTitleTreHan.TabIndex = 9;
            this.lblTitleTreHan.Text = "⚠️ Danh sách độc giả trễ hạn trả sách";
            // 
            // dgvDocGiaTreHan
            // 
            this.dgvDocGiaTreHan.AllowUserToAddRows = false;
            this.dgvDocGiaTreHan.AllowUserToDeleteRows = false;
            this.dgvDocGiaTreHan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocGiaTreHan.BackgroundColor = System.Drawing.Color.White;
            this.dgvDocGiaTreHan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocGiaTreHan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocGiaTreHan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGiaTreHan.EnableHeadersVisualStyles = false;
            this.dgvDocGiaTreHan.Location = new System.Drawing.Point(15, 401);
            this.dgvDocGiaTreHan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDocGiaTreHan.Name = "dgvDocGiaTreHan";
            this.dgvDocGiaTreHan.ReadOnly = true;
            this.dgvDocGiaTreHan.RowHeadersWidth = 51;
            this.dgvDocGiaTreHan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocGiaTreHan.Size = new System.Drawing.Size(852, 185);
            this.dgvDocGiaTreHan.TabIndex = 10;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(885, 601);
            this.Controls.Add(this.dgvDocGiaTreHan);
            this.Controls.Add(this.lblTitleTreHan);
            this.Controls.Add(this.dgvSachDangMuon);
            this.Controls.Add(this.lblTitleSachMuon);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachDangMuon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGiaTreHan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTongSach;
        private System.Windows.Forms.Label lblDangMuon;
        private System.Windows.Forms.Label lblTreHan;
        private System.Windows.Forms.Label lblTitleSachMuon;
        private System.Windows.Forms.DataGridView dgvSachDangMuon;
        private System.Windows.Forms.Label lblTitleTreHan;
        private System.Windows.Forms.DataGridView dgvDocGiaTreHan;
    }
}
