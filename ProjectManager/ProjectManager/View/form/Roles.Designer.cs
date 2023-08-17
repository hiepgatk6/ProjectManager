
namespace ProjectManager.View.form
{
    partial class Roles
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
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbbMoDun = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbbNhomQuyen = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.gridRole = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Import = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Export = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ckXoa = new System.Windows.Forms.CheckBox();
            this.ckExport = new System.Windows.Forms.CheckBox();
            this.ckXem = new System.Windows.Forms.CheckBox();
            this.ckSua = new System.Windows.Forms.CheckBox();
            this.ckImport = new System.Windows.Forms.CheckBox();
            this.ckThem = new System.Windows.Forms.CheckBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRole)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(206, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbbMoDun);
            this.groupBox4.Location = new System.Drawing.Point(261, 166);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(202, 63);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mô-đun";
            // 
            // cbbMoDun
            // 
            this.cbbMoDun.FormattingEnabled = true;
            this.cbbMoDun.Location = new System.Drawing.Point(9, 20);
            this.cbbMoDun.Name = "cbbMoDun";
            this.cbbMoDun.Size = new System.Drawing.Size(187, 21);
            this.cbbMoDun.TabIndex = 7;
            this.cbbMoDun.SelectedIndexChanged += new System.EventHandler(this.cbbMoDun_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbbNhomQuyen);
            this.groupBox3.Location = new System.Drawing.Point(22, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(211, 64);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nhóm quyền";
            // 
            // cbbNhomQuyen
            // 
            this.cbbNhomQuyen.FormattingEnabled = true;
            this.cbbNhomQuyen.Location = new System.Drawing.Point(7, 20);
            this.cbbNhomQuyen.Name = "cbbNhomQuyen";
            this.cbbNhomQuyen.Size = new System.Drawing.Size(187, 21);
            this.cbbNhomQuyen.TabIndex = 6;
            this.cbbNhomQuyen.SelectedIndexChanged += new System.EventHandler(this.cbbNhomQuyen_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1384, 450);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.gridRole);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(522, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(859, 431);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dữ liệu";
            // 
            // gridRole
            // 
            this.gridRole.AllowUserToAddRows = false;
            this.gridRole.AllowUserToDeleteRows = false;
            this.gridRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.GroupId,
            this.GroupName,
            this.ModuleId,
            this.ModuleName,
            this.Edit,
            this.Add,
            this.View,
            this.Delete,
            this.Import,
            this.Export});
            this.gridRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRole.Location = new System.Drawing.Point(3, 16);
            this.gridRole.Name = "gridRole";
            this.gridRole.ReadOnly = true;
            this.gridRole.Size = new System.Drawing.Size(853, 412);
            this.gridRole.TabIndex = 9;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // GroupId
            // 
            this.GroupId.DataPropertyName = "GroupId";
            this.GroupId.HeaderText = "GroupId";
            this.GroupId.Name = "GroupId";
            this.GroupId.ReadOnly = true;
            this.GroupId.Visible = false;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "Tên nhóm quyền";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // ModuleId
            // 
            this.ModuleId.DataPropertyName = "ModuleId";
            this.ModuleId.HeaderText = "ModuleId";
            this.ModuleId.Name = "ModuleId";
            this.ModuleId.ReadOnly = true;
            this.ModuleId.Visible = false;
            // 
            // ModuleName
            // 
            this.ModuleName.DataPropertyName = "ModuleName";
            this.ModuleName.HeaderText = "Tên mô đun";
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.DataPropertyName = "Edit";
            this.Edit.HeaderText = "Quyền sửa";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Add
            // 
            this.Add.DataPropertyName = "Add";
            this.Add.HeaderText = "Quyền thêm";
            this.Add.Name = "Add";
            this.Add.ReadOnly = true;
            this.Add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // View
            // 
            this.View.DataPropertyName = "View";
            this.View.HeaderText = "Quyền  xem";
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.View.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Delete";
            this.Delete.HeaderText = "Quyền Xóa";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Import
            // 
            this.Import.DataPropertyName = "Import";
            this.Import.HeaderText = "Quyền nhập file";
            this.Import.Name = "Import";
            this.Import.ReadOnly = true;
            this.Import.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Import.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Import.Visible = false;
            // 
            // Export
            // 
            this.Export.DataPropertyName = "Export";
            this.Export.HeaderText = "Quyền xuất file";
            this.Export.Name = "Export";
            this.Export.ReadOnly = true;
            this.Export.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Export.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Export.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Controls.Add(this.ckXoa);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.ckExport);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.ckXem);
            this.groupBox5.Controls.Add(this.ckSua);
            this.groupBox5.Controls.Add(this.ckImport);
            this.groupBox5.Controls.Add(this.ckThem);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(3, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(519, 431);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Phân quyền";
            // 
            // ckXoa
            // 
            this.ckXoa.AutoSize = true;
            this.ckXoa.Location = new System.Drawing.Point(297, 78);
            this.ckXoa.Name = "ckXoa";
            this.ckXoa.Size = new System.Drawing.Size(45, 17);
            this.ckXoa.TabIndex = 3;
            this.ckXoa.Text = "Xóa";
            this.ckXoa.UseVisualStyleBackColor = true;
            // 
            // ckExport
            // 
            this.ckExport.AutoSize = true;
            this.ckExport.Location = new System.Drawing.Point(297, 114);
            this.ckExport.Name = "ckExport";
            this.ckExport.Size = new System.Drawing.Size(56, 17);
            this.ckExport.TabIndex = 5;
            this.ckExport.Text = "Export";
            this.ckExport.UseVisualStyleBackColor = true;
            this.ckExport.Visible = false;
            // 
            // ckXem
            // 
            this.ckXem.AutoSize = true;
            this.ckXem.Location = new System.Drawing.Point(60, 78);
            this.ckXem.Name = "ckXem";
            this.ckXem.Size = new System.Drawing.Size(47, 17);
            this.ckXem.TabIndex = 2;
            this.ckXem.Text = "Xem";
            this.ckXem.UseVisualStyleBackColor = true;
            // 
            // ckSua
            // 
            this.ckSua.AutoSize = true;
            this.ckSua.Location = new System.Drawing.Point(297, 42);
            this.ckSua.Name = "ckSua";
            this.ckSua.Size = new System.Drawing.Size(45, 17);
            this.ckSua.TabIndex = 1;
            this.ckSua.Text = "Sửa";
            this.ckSua.UseVisualStyleBackColor = true;
            // 
            // ckImport
            // 
            this.ckImport.AutoSize = true;
            this.ckImport.Location = new System.Drawing.Point(60, 114);
            this.ckImport.Name = "ckImport";
            this.ckImport.Size = new System.Drawing.Size(55, 17);
            this.ckImport.TabIndex = 4;
            this.ckImport.Text = "Import";
            this.ckImport.UseVisualStyleBackColor = true;
            this.ckImport.Visible = false;
            // 
            // ckThem
            // 
            this.ckThem.AutoSize = true;
            this.ckThem.Location = new System.Drawing.Point(60, 42);
            this.ckThem.Name = "ckThem";
            this.ckThem.Size = new System.Drawing.Size(53, 17);
            this.ckThem.TabIndex = 0;
            this.ckThem.Text = "Thêm";
            this.ckThem.UseVisualStyleBackColor = true;
            // 
            // Roles
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 450);
            this.Controls.Add(this.groupBox2);
            this.Name = "Roles";
            this.Text = "Roles";
            this.Load += new System.EventHandler(this.Roles_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRole)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbbMoDun;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbbNhomQuyen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox ckXoa;
        private System.Windows.Forms.CheckBox ckExport;
        private System.Windows.Forms.CheckBox ckXem;
        private System.Windows.Forms.CheckBox ckSua;
        private System.Windows.Forms.CheckBox ckImport;
        private System.Windows.Forms.CheckBox ckThem;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView gridRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Edit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Add;
        private System.Windows.Forms.DataGridViewCheckBoxColumn View;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Import;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Export;
    }
}