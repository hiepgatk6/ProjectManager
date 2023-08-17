
namespace ProjectManager.View.form
{
    partial class SystemType
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbHeThongId = new System.Windows.Forms.Label();
            this.btnLuuHeThong = new System.Windows.Forms.Button();
            this.txtLoaiHeThong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridSystemType = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GridTrangThaiDuAn = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbIDTrangThai = new System.Windows.Forms.Label();
            this.btnLuuTrangThai = new System.Windows.Forms.Button();
            this.txtTrangThaiTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSystemType)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTrangThaiDuAn)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbHeThongId);
            this.groupBox1.Controls.Add(this.btnLuuHeThong);
            this.groupBox1.Controls.Add(this.txtLoaiHeThong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại hệ thống";
            // 
            // lbHeThongId
            // 
            this.lbHeThongId.AutoSize = true;
            this.lbHeThongId.Location = new System.Drawing.Point(315, 16);
            this.lbHeThongId.Name = "lbHeThongId";
            this.lbHeThongId.Size = new System.Drawing.Size(16, 13);
            this.lbHeThongId.TabIndex = 3;
            this.lbHeThongId.Text = "-1";
            this.lbHeThongId.Visible = false;
            // 
            // btnLuuHeThong
            // 
            this.btnLuuHeThong.Enabled = false;
            this.btnLuuHeThong.Location = new System.Drawing.Point(658, 40);
            this.btnLuuHeThong.Name = "btnLuuHeThong";
            this.btnLuuHeThong.Size = new System.Drawing.Size(89, 20);
            this.btnLuuHeThong.TabIndex = 2;
            this.btnLuuHeThong.Text = "Lưu";
            this.btnLuuHeThong.UseVisualStyleBackColor = true;
            this.btnLuuHeThong.Click += new System.EventHandler(this.btnLuuHeThong_Click);
            // 
            // txtLoaiHeThong
            // 
            this.txtLoaiHeThong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoaiHeThong.Location = new System.Drawing.Point(165, 40);
            this.txtLoaiHeThong.Name = "txtLoaiHeThong";
            this.txtLoaiHeThong.Size = new System.Drawing.Size(473, 20);
            this.txtLoaiHeThong.TabIndex = 1;
            this.txtLoaiHeThong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoaiHeThong_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại hệ thống";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.gridSystemType);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(814, 398);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dữ liệu";
            // 
            // gridSystemType
            // 
            this.gridSystemType.AllowUserToAddRows = false;
            this.gridSystemType.AllowUserToDeleteRows = false;
            this.gridSystemType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSystemType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Type});
            this.gridSystemType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSystemType.Location = new System.Drawing.Point(3, 16);
            this.gridSystemType.Name = "gridSystemType";
            this.gridSystemType.ReadOnly = true;
            this.gridSystemType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSystemType.Size = new System.Drawing.Size(808, 379);
            this.gridSystemType.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Loại hệ thống";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 500;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.GridTrangThaiDuAn);
            this.groupBox3.Location = new System.Drawing.Point(829, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(775, 395);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dữ liệu";
            // 
            // GridTrangThaiDuAn
            // 
            this.GridTrangThaiDuAn.AllowUserToAddRows = false;
            this.GridTrangThaiDuAn.AllowUserToDeleteRows = false;
            this.GridTrangThaiDuAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridTrangThaiDuAn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Status});
            this.GridTrangThaiDuAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridTrangThaiDuAn.Location = new System.Drawing.Point(3, 16);
            this.GridTrangThaiDuAn.Name = "GridTrangThaiDuAn";
            this.GridTrangThaiDuAn.ReadOnly = true;
            this.GridTrangThaiDuAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridTrangThaiDuAn.Size = new System.Drawing.Size(769, 376);
            this.GridTrangThaiDuAn.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Trạng thái";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 500;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lbIDTrangThai);
            this.groupBox4.Controls.Add(this.btnLuuTrangThai);
            this.groupBox4.Controls.Add(this.txtTrangThaiTaiKhoan);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(832, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(760, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trạng thái dự án";
            // 
            // lbIDTrangThai
            // 
            this.lbIDTrangThai.AutoSize = true;
            this.lbIDTrangThai.Location = new System.Drawing.Point(419, 16);
            this.lbIDTrangThai.Name = "lbIDTrangThai";
            this.lbIDTrangThai.Size = new System.Drawing.Size(16, 13);
            this.lbIDTrangThai.TabIndex = 3;
            this.lbIDTrangThai.Text = "-1";
            this.lbIDTrangThai.Visible = false;
            // 
            // btnLuuTrangThai
            // 
            this.btnLuuTrangThai.Enabled = false;
            this.btnLuuTrangThai.Location = new System.Drawing.Point(654, 40);
            this.btnLuuTrangThai.Name = "btnLuuTrangThai";
            this.btnLuuTrangThai.Size = new System.Drawing.Size(89, 20);
            this.btnLuuTrangThai.TabIndex = 2;
            this.btnLuuTrangThai.Text = "Lưu";
            this.btnLuuTrangThai.UseVisualStyleBackColor = true;
            this.btnLuuTrangThai.Click += new System.EventHandler(this.btnLuuTrangThai_Click);
            // 
            // txtTrangThaiTaiKhoan
            // 
            this.txtTrangThaiTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrangThaiTaiKhoan.Location = new System.Drawing.Point(168, 40);
            this.txtTrangThaiTaiKhoan.Name = "txtTrangThaiTaiKhoan";
            this.txtTrangThaiTaiKhoan.Size = new System.Drawing.Size(466, 20);
            this.txtTrangThaiTaiKhoan.TabIndex = 1;
            this.txtTrangThaiTaiKhoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTrangThaiTaiKhoan_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Trạng thái dự án";
            // 
            // SystemType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 528);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "SystemType";
            this.Text = "SystemType";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SystemType_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSystemType)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridTrangThaiDuAn)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLoaiHeThong;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView GridTrangThaiDuAn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTrangThaiTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridSystemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button btnLuuHeThong;
        private System.Windows.Forms.Button btnLuuTrangThai;
        private System.Windows.Forms.Label lbHeThongId;
        private System.Windows.Forms.Label lbIDTrangThai;
    }
}