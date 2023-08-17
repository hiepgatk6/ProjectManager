using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManager.BLL;
using ProjectManager.Models;
using ProjectManager.Helper;

namespace ProjectManager.View.form
{
    public partial class Project : Form
    {
        ProjectBLL clsProject = new ProjectBLL();
        SystemTypeBLL clsSystem = new SystemTypeBLL();
        ProjectStatusBLL clsStatus = new ProjectStatusBLL();
        DateTime NgayHetHan;
        DateTime NgayBatDauBaoTri;
        DateTime NgayDiVaoHoatDong;
        BindingSource bindingSource = new BindingSource();
        private const int pageSize = 1; // Kích thước trang
        public Project()
        {
            InitializeComponent();
        }

        public void LoadDropdownLoaiHeThong()
        {
            DataTable dt = clsSystem.LoadSystemType();
            List<DropdownItem> Items = new List<DropdownItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DropdownItem item = new DropdownItem()
                {
                    Text = dt.Rows[i]["Type"].ToString(),
                    Value = Int32.Parse(dt.Rows[i]["ID"].ToString())
                };
                Items.Add(item);
            }
            ddLoaiHeThong.DataSource = Items;
            ddLoaiHeThong.DisplayMember = "Text";
            ddLoaiHeThong.ValueMember = "Value";
        }
        public void LoadDropdownTrangThai()
        {
            List<DropdownItem> Items = new List<DropdownItem>();
            DataTable dt = clsStatus.LoadProjectStatus();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DropdownItem item = new DropdownItem()
                {
                    Text = dt.Rows[i]["Status"].ToString(),
                    Value = Int32.Parse(dt.Rows[i]["ID"].ToString())
                };
                Items.Add(item);
            }
            ddTrangThai.DataSource = Items;
            ddTrangThai.DisplayMember = "Text";
            ddTrangThai.ValueMember = "Value";
        }
        private void Project_Load(object sender, EventArgs e)
        {
            LoadDropdownLoaiHeThong();
            LoadDropdownTrangThai();
            gridProject.DataSource = clsProject.LoadProjectAll();
            gridProject.CellMouseDown += gridProject_CellMouseDown;


            LBTGBT.Visible = false;
            LBNBT.Visible = false;
            LBNHH.Visible = false;
            nTHBT.Visible = false;
            dtpNgayBaoTri.Visible = false;
            dtpNgayHetHanBaoTri.Visible = false;
            lbtb.Visible = true;

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            bindingSource1.DataSource = new PageOffsetList();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            DataTable dt = clsProject.LoadProjectAll();
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            int offset = (int)bindingSource1.Current;
            var records = new List<ProjectModel>();
            for (int i = offset; i < offset + pageSize && i < dt.Rows.Count; i++)
            {
                ProjectModel Public = new ProjectModel();
                if (dt.Rows[i]["MaintenanceEndDate"].ToString() == "")
                {
                    Public = new ProjectModel()
                    {
                        ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                        ContractNumber = dt.Rows[i]["ContractNumber"].ToString(),
                        GoLiveDate = DateTime.Parse(dt.Rows[i]["GoLiveDate"].ToString()),
                        DateEdit = DateTime.Parse(dt.Rows[i]["DateEdit"].ToString()),
                        ExpirationDate = DateTime.Parse(dt.Rows[i]["ExpirationDate"].ToString()),
                        DateCreate = DateTime.Parse(dt.Rows[i]["DateCreate"].ToString()),
                        WarrantyTime = Int32.Parse(dt.Rows[i]["WarrantyTime"].ToString()),
                        MaintenanceTime = Int32.Parse(dt.Rows[i]["MaintenanceTime"].ToString()),
                        Active = bool.Parse(dt.Rows[i]["Active"].ToString()),
                        ProjectName = dt.Rows[i]["ProjectName"].ToString(),
                        //IsDel = bool.Parse(dt.Rows[i]["IsDel"].ToString()),
                        Status = int.Parse(dt.Rows[i]["StatusId"].ToString()),
                        Type = int.Parse(dt.Rows[i]["TypeId"].ToString()),
                        UserCreate = dt.Rows[i]["UserCreate"].ToString(),
                        UserEdit = dt.Rows[i]["UserEdit"].ToString(),

                    };
                }
                else
                {

                    Public = new ProjectModel()
                    {
                        ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                        ContractNumber = dt.Rows[i]["ContractNumber"].ToString(),
                        GoLiveDate = DateTime.Parse(dt.Rows[i]["GoLiveDate"].ToString()),
                        MaintenanceEndDate = DateTime.Parse(dt.Rows[i]["MaintenanceEndDate"].ToString()),
                        MaintenanceDateStart = DateTime.Parse(dt.Rows[i]["MaintenanceDateStart"].ToString()),
                        DateEdit = DateTime.Parse(dt.Rows[i]["DateEdit"].ToString()),
                        ExpirationDate = DateTime.Parse(dt.Rows[i]["ExpirationDate"].ToString()),
                        DateCreate = DateTime.Parse(dt.Rows[i]["DateCreate"].ToString()),
                        WarrantyTime = Int32.Parse(dt.Rows[i]["WarrantyTime"].ToString()),
                        MaintenanceTime = Int32.Parse(dt.Rows[i]["MaintenanceTime"].ToString()),
                        Active = bool.Parse(dt.Rows[i]["Active"].ToString()),
                        ProjectName = dt.Rows[i]["ProjectName"].ToString(),
                        //IsDel = bool.Parse(dt.Rows[i]["IsDel"].ToString()),
                        Status = int.Parse(dt.Rows[i]["StatusId"].ToString()),
                        Type = int.Parse(dt.Rows[i]["TypeId"].ToString()),
                        UserCreate = dt.Rows[i]["UserCreate"].ToString(),
                        UserEdit = dt.Rows[i]["UserEdit"].ToString(),
                    };
                };
                records.Add(Public);
            }
            gridProject.DataSource = records;
        }

        class PageOffsetList : System.ComponentModel.IListSource
        {
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                ProjectBLL clsp = new ProjectBLL();
                DataTable dt = clsp.LoadProjectAll();
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < dt.Rows.Count; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        private void gridProject_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Tạo menu ngữ cảnh cho ô cụ thể
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Thêm mới");
                ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Sửa");
                ToolStripMenuItem menuItem3 = new ToolStripMenuItem("Xóa");

                // Đăng ký sự kiện Click cho menuItem1
                menuItem1.Click += ThemProject_Click;
                menuItem2.Click += SuaProject_Click;
                menuItem3.Click += XoaProject_Click;
                contextMenuStrip.Items.Add(menuItem1);
                contextMenuStrip.Items.Add(menuItem2);
                contextMenuStrip.Items.Add(menuItem3);

                // Hiển thị menu ngữ cảnh tại vị trí chuột
                contextMenuStrip.Show(gridProject, e.Location);
            }
            else
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Thêm mới");

                // Đăng ký sự kiện Click cho menuItem1
                menuItem1.Click += ThemProject_Click;
                contextMenuStrip.Items.Add(menuItem1);

                // Hiển thị menu ngữ cảnh tại vị trí chuột
                contextMenuStrip.Show(gridProject, e.Location);
            }
        }
        private void ThemProject_Click(object sender, EventArgs e)
        {
            LBTGBT.Visible = false;
            LBNBT.Visible = false;
            LBNHH.Visible = false;
            nTHBT.Visible = false;
            dtpNgayBaoTri.Visible = false;
            dtpNgayHetHanBaoTri.Visible = false;
            lbtb.Visible = true;

            txtSoHopDong.Text = "";
            txtTenDuAn.Text = "";
            ddTrangThai.SelectedIndex = 0;
            nTHBH.Value = 0;
            ddLoaiHeThong.SelectedIndex = 0;
            ckbKichHoat.Checked = false;
            lbHopDongId.Text = "-1";
            btnSave.Enabled = true;
            nTHBT.Value = 0;
        }
        private void SuaProject_Click(object sender, EventArgs e)
        {
            var chon = gridProject.CurrentRow;
            if (chon != null)
            {
                var id = Int32.Parse(gridProject.CurrentRow.Cells["ID"].Value.ToString());
                //lbIDTrangThai.Text = id.ToString();
                //btnLuuTrangThai.Enabled = true;
                //txtTrangThaiTaiKhoan.Text = status;
                ProjectModel Public = new ProjectModel()
                {
                    ID = id
                };
                DataTable dt = clsProject.LoadProjectById(Public);
                if (dt.Rows.Count > 0)
                {
                    txtNameUserCreate.Text = dt.Rows[0]["UserCreate"].ToString();
                    hiddenDateCreate.Value = DateTime.Parse(dt.Rows[0]["DateCreate"].ToString());
                    txtTenDuAn.Text = dt.Rows[0]["ProjectName"].ToString();
                    lbHopDongId.Text = dt.Rows[0]["ID"].ToString();
                    txtSoHopDong.Text = dt.Rows[0]["ContractNumber"].ToString();
                    nTHBH.Text = dt.Rows[0]["WarrantyTime"].ToString();
                    nTHBT.Text = dt.Rows[0]["MaintenanceTime"].ToString();
                    if (bool.Parse(dt.Rows[0]["Active"].ToString()) == true)
                    {
                        ckbKichHoat.Checked = true;
                    }
                    dtpNgayDVHD.Value = DateTime.Parse(dt.Rows[0]["GoLiveDate"].ToString());
                    NgayDiVaoHoatDong = dtpNgayDVHD.Value;
                    dtpNHH.Value = DateTime.Parse(dt.Rows[0]["ExpirationDate"].ToString());
                    var x = dt.Rows[0]["MaintenanceDateStart"].ToString();
                    if (dt.Rows[0]["MaintenanceDateStart"].ToString() != "")
                        dtpNgayBaoTri.Value = DateTime.Parse(dt.Rows[0]["MaintenanceDateStart"].ToString());
                    NgayBatDauBaoTri = dtpNgayBaoTri.Value;
                    if (dt.Rows[0]["MaintenanceEndDate"].ToString() != "")
                        dtpNgayHetHanBaoTri.Value = DateTime.Parse(dt.Rows[0]["MaintenanceEndDate"].ToString());
                    NgayHetHan = dtpNHH.Value;
                    ddTrangThai.SelectedValue = Int32.Parse(dt.Rows[0]["StatusId"].ToString());
                    ddLoaiHeThong.SelectedValue = Int32.Parse(dt.Rows[0]["TypeId"].ToString());
                    if (DateTime.Parse(dt.Rows[0]["ExpirationDate"].ToString()) > DateTime.Now)
                    {
                        LBTGBT.Visible = false;
                        LBNBT.Visible = false;
                        LBNHH.Visible = false;
                        nTHBT.Visible = false;
                        dtpNgayBaoTri.Visible = false;
                        dtpNgayHetHanBaoTri.Visible = false;
                        lbtb.Visible = true;
                    }
                    btnSave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Lỗi", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void XoaProject_Click(object sender, EventArgs e)
        {
            var id = int.Parse(gridProject.CurrentRow.Cells["ID"].Value.ToString());
            ProjectModel Public = new ProjectModel()
            {
                ID = id
            };

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                clsProject.DeleteProject(Public);
                gridProject.DataSource = clsProject.LoadProjectAll();
            }
        }



        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project_Load(sender, e);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var chon = gridProject.CurrentRow;
            if (chon != null)
            {
                var x = gridProject.CurrentRow;
                if (x != null)
                {
                    var id = int.Parse(gridProject.CurrentRow.Cells["ID"].Value.ToString());
                    //new ProjectAdd(id, "Edit").ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void theemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new ProjectAdd(0, "Add").ShowDialog();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var chon = gridProject.CurrentRow;
            if (chon != null)
            {
                var id = int.Parse(gridProject.CurrentRow.Cells["ID"].Value.ToString());
                ProjectModel Public = new ProjectModel()
                {
                    ID = id
                };

                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    clsProject.DeleteProject(Public);
                    Project_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTenDuAn.Text == "" || txtSoHopDong.Text == ""
              || nTHBH.Value <= 0
              || ddTrangThai.SelectedIndex == -1 || ddLoaiHeThong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //dtpNgayDVHD.Value.AddMonths(Int32.Parse(nTHBH.Value.ToString()));
                ProjectModel Public = new ProjectModel()
                {
                    ProjectName = txtTenDuAn.Text,
                    ContractNumber = txtSoHopDong.Text,
                    GoLiveDate = dtpNgayDVHD.Value,
                    ExpirationDate = dtpNHH.Value,
                    WarrantyTime = Int32.Parse(nTHBH.Value.ToString()),
                    Status = Int32.Parse(ddTrangThai.SelectedValue.ToString()),
                    Type = Int32.Parse(ddLoaiHeThong.SelectedValue.ToString()),
                    Active = ckbKichHoat.Checked,
                    IsDel = false
                };
                if (nTHBT.Value > 0)
                {
                    Public.MaintenanceTime = Int32.Parse(nTHBT.Value.ToString());
                    Public.MaintenanceDateStart = DateTime.Parse(dtpNgayBaoTri.Value.ToString());
                    Public.MaintenanceEndDate = DateTime.Parse(dtpNgayHetHanBaoTri.Value.ToString());
                }
                if (Int32.Parse(lbHopDongId.Text) > 0)
                {
                    Public.ID = Int32.Parse(lbHopDongId.Text);
                    Public.DateEdit = DateTime.Now;
                    Public.UserEdit = BienToanCuc.FullName;
                    Public.DateCreate = hiddenDateCreate.Value;
                    Public.UserCreate = txtNameUserCreate.Text;
                    if (clsProject.EditProject(Public) > 0)
                    {
                        MessageBox.Show("Chỉnh sửa thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                        gridProject.DataSource = clsProject.LoadProjectAll();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa không thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    Public.DateEdit = DateTime.Now;
                    Public.UserEdit = BienToanCuc.FullName;
                    Public.DateCreate = DateTime.Now;
                    Public.UserCreate = BienToanCuc.FullName;
                    if (clsProject.AddProject(Public) > 0)
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                        gridProject.DataSource = clsProject.LoadProjectAll();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới không thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void dtpNgayDVHD_ValueChanged(object sender, EventArgs e)
        {
            if (nTHBH.Value > 0)
            {
                dtpNHH.Value = dtpNgayDVHD.Value.AddMonths(Int32.Parse(nTHBH.Value.ToString()));
            }
        }

        private void nTHBH_ValueChanged(object sender, EventArgs e)
        {
            dtpNHH.Value = dtpNgayDVHD.Value.AddMonths(Int32.Parse(nTHBH.Value.ToString()));
        }

        private void dtpNgayBaoTri_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgayBaoTri.Value < NgayHetHan)
            {
                MessageBox.Show("Bạn không thể bảo trì khi chưa hết bảo hành", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayBaoTri.Value = NgayBatDauBaoTri;
                return;
            }
            if (nTHBT.Value != 0)
                dtpNgayHetHanBaoTri.Value = dtpNgayBaoTri.Value.AddMonths(Int32.Parse(nTHBT.Value.ToString()));
        }

        private void nTHBT_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayHetHanBaoTri.Value = dtpNgayBaoTri.Value.AddMonths(Int32.Parse(nTHBT.Value.ToString()));
        }
    }
}
