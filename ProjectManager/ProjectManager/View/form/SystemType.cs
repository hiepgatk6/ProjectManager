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
using ProjectManager.Helper;
using ProjectManager.Models;

namespace ProjectManager.View.form
{
    public partial class SystemType : Form
    {
        ProjectBLL clsProject = new ProjectBLL();
        SystemTypeBLL clsSystem = new SystemTypeBLL();
        ProjectStatusBLL clsProjectStatus = new ProjectStatusBLL();
        public SystemType()
        {
            InitializeComponent();
        }

        private void SystemType_Load(object sender, EventArgs e)
        {
            gridSystemType.DataSource = clsSystem.LoadSystemType();
            GridTrangThaiDuAn.DataSource = clsProjectStatus.LoadProjectStatus();

            gridSystemType.CellMouseDown += DataGridView1_CellMouseDown;
            GridTrangThaiDuAn.CellMouseDown += GridTrangThaiDuAn_CellMouseDown;
        }
        private void GridTrangThaiDuAn_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Tạo menu ngữ cảnh cho ô cụ thể
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Thêm mới");
                ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Sửa");
                ToolStripMenuItem menuItem3 = new ToolStripMenuItem("Xóa");

                // Đăng ký sự kiện Click cho menuItem1
                menuItem1.Click += ThemTrangThai_Click;
                menuItem2.Click += SuaTrangThai_Click;
                menuItem3.Click += XoaTrangThai_Click;
                contextMenuStrip.Items.Add(menuItem1);
                contextMenuStrip.Items.Add(menuItem2);
                contextMenuStrip.Items.Add(menuItem3);

                // Hiển thị menu ngữ cảnh tại vị trí chuột
                contextMenuStrip.Show(GridTrangThaiDuAn, e.Location);
            }
            else
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Thêm mới");
                // Đăng ký sự kiện Click cho menuItem1
                menuItem1.Click += ThemTrangThai_Click;
                contextMenuStrip.Items.Add(menuItem1);
                contextMenuStrip.Show(GridTrangThaiDuAn, e.Location);
            }
        }
        private void ThemTrangThai_Click(object sender, EventArgs e)
        {
            lbIDTrangThai.Text = "-1";
            txtTrangThaiTaiKhoan.Text = "";
            btnLuuTrangThai.Enabled = true;
        }
        private void SuaTrangThai_Click(object sender, EventArgs e)
        {
            var id = int.Parse(GridTrangThaiDuAn.CurrentRow.Cells[0].Value.ToString());
            var status = GridTrangThaiDuAn.CurrentRow.Cells[1].Value.ToString();
            lbIDTrangThai.Text = id.ToString();
            btnLuuTrangThai.Enabled = true;
            txtTrangThaiTaiKhoan.Text = status;
        }
        private void XoaTrangThai_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 4 };
            bool check = roleCheck.checkAccess("Trạng thái dự án", listAction);
            if (check)
            {

                var id = int.Parse(GridTrangThaiDuAn.CurrentRow.Cells[0].Value.ToString());
                ProjectStatusModel Public = new ProjectStatusModel()
                {
                    ID = id
                };

                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    DataTable dtproject = clsProject.LoadProjectAll();
                    if (dtproject != null && dtproject.Rows.Count > 0)
                    {

                        for (int i = 0; i < dtproject.Rows.Count; i++)
                        {
                            if (Int32.Parse(dtproject.Rows[i]["Status"].ToString()).Equals(Public.ID))
                            {
                                MessageBox.Show("Bạn không được xóa vì dự án đang ở trạng thái này", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    clsProjectStatus.DeleteStatusProject(Public);
                    GridTrangThaiDuAn.DataSource = clsProjectStatus.LoadProjectStatus();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Tạo menu ngữ cảnh cho ô cụ thể
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Thêm mới");
                ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Sửa");
                ToolStripMenuItem menuItem3 = new ToolStripMenuItem("Xóa");

                // Đăng ký sự kiện Click cho menuItem1
                menuItem1.Click += ThemHeThong_Click;
                menuItem2.Click += ChinhSuaHeThongClick;
                menuItem3.Click += XoaHeThongClick;
                contextMenuStrip.Items.Add(menuItem1);
                contextMenuStrip.Items.Add(menuItem2);
                contextMenuStrip.Items.Add(menuItem3);

                // Hiển thị menu ngữ cảnh tại vị trí chuột
                contextMenuStrip.Show(gridSystemType, e.Location);
            }
            else
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Thêm mới");

                // Đăng ký sự kiện Click cho menuItem1
                menuItem1.Click += ThemHeThong_Click;
                contextMenuStrip.Items.Add(menuItem1);

                // Hiển thị menu ngữ cảnh tại vị trí chuột
                contextMenuStrip.Show(gridSystemType, e.Location);
            }
        }
        private void ThemHeThong_Click(object sender, EventArgs e)
        {
            txtLoaiHeThong.Text = "";
            lbHeThongId.Text = "-1";
            btnLuuHeThong.Enabled = true;
        }
        private void XoaHeThongClick(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 4 };
            bool check = roleCheck.checkAccess("Loại hệ thống", listAction);
            if (check)
            {

                var chon = gridSystemType.CurrentRow;
                if (chon != null)
                {
                    var id = int.Parse(gridSystemType.CurrentRow.Cells[0].Value.ToString());
                    var type = gridSystemType.CurrentRow.Cells[1].Value.ToString();
                    SystemTypeModel Public = new SystemTypeModel()
                    {
                        ID = id
                    };

                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá loại : " + type + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        DataTable dtproject = clsProject.LoadProjectAll();
                        if (dtproject != null && dtproject.Rows.Count > 0)
                        {

                            for (int i = 0; i < dtproject.Rows.Count; i++)
                            {
                                if (Int32.Parse(dtproject.Rows[i]["Type"].ToString()).Equals(Public.ID))
                                {
                                    MessageBox.Show("Bạn không được xóa vì dự án đang có loại hệ thống này", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                        clsSystem.DeleteSystemType(Public);
                        gridSystemType.DataSource = clsSystem.LoadSystemType();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ChinhSuaHeThongClick(object sender, EventArgs e)
        {
            txtLoaiHeThong.Text = gridSystemType.CurrentRow.Cells[1].Value.ToString();
            var id = int.Parse(gridSystemType.CurrentRow.Cells[0].Value.ToString());
            lbHeThongId.Text = id.ToString();
            btnLuuHeThong.Enabled = true;
        }
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemType_Load(sender, e);
        }

        private void theemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SystemTypeAdd(0, "", "Add").ShowDialog();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var chon = gridSystemType.CurrentRow;
            if (chon != null)
            {
                var id = int.Parse(gridSystemType.CurrentRow.Cells[0].Value.ToString());
                var type = gridSystemType.CurrentRow.Cells[1].Value.ToString();
                new SystemTypeAdd(id, type, "Edit").ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 4 };
            bool check = roleCheck.checkAccess("Loại hệ thống", listAction);
            if (check)
            {
                var chon = gridSystemType.CurrentRow;

                if (chon != null)
                {
                    var id = int.Parse(gridSystemType.CurrentRow.Cells[0].Value.ToString());
                    var status = gridSystemType.CurrentRow.Cells[1].Value.ToString();
                    SystemTypeModel Public = new SystemTypeModel()
                    {
                        ID = id
                    };

                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá trạng thái " + status + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        clsSystem.DeleteSystemType(Public);
                        SystemType_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLuuHeThong_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 1, 2 };
            bool check = roleCheck.checkAccess("Loại hệ thống", listAction);
            if (check)
            {
                if (txtLoaiHeThong.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ các trường", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Int32.Parse(lbHeThongId.Text) == -1)
                {
                    SystemTypeModel Public = new SystemTypeModel()
                    {
                        Type = txtLoaiHeThong.Text
                    };
                    if (clsSystem.AddSystemType(Public) > 0)
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtLoaiHeThong.Text = "";
                        btnLuuHeThong.Enabled = false;
                        gridSystemType.DataSource = clsSystem.LoadSystemType();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    SystemTypeModel Public = new SystemTypeModel()
                    {
                        Type = txtLoaiHeThong.Text
                    };
                    Public.ID = Int32.Parse(lbHeThongId.Text);
                    if (clsSystem.EditSystemType(Public) > 0)
                    {
                        lbHeThongId.Text = "-1";
                        txtLoaiHeThong.Text = "";
                        btnLuuHeThong.Visible = false;
                        MessageBox.Show("Chỉnh sửa thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                        gridSystemType.DataSource = clsSystem.LoadSystemType();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa thất bại", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuTrangThai_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 1, 2 };
            bool check = roleCheck.checkAccess("Trạng thái dự án", listAction);
            if (check)
            {

                if (txtTrangThaiTaiKhoan.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ các trường", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Int32.Parse(lbIDTrangThai.Text) == -1)
                {
                    ProjectStatusModel Public = new ProjectStatusModel()
                    {
                        Status = txtTrangThaiTaiKhoan.Text
                    };
                    if (clsProjectStatus.AddStatusProject(Public) > 0)
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtTrangThaiTaiKhoan.Text = "";
                        btnLuuTrangThai.Enabled = false;
                        GridTrangThaiDuAn.DataSource = clsProjectStatus.LoadProjectStatus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    ProjectStatusModel Public = new ProjectStatusModel()
                    {
                        Status = txtTrangThaiTaiKhoan.Text
                    };
                    Public.ID = Int32.Parse(lbIDTrangThai.Text);
                    if (clsProjectStatus.EditStatusProject(Public) > 0)
                    {
                        txtTrangThaiTaiKhoan.Text = "";
                        btnLuuTrangThai.Enabled = false;
                        MessageBox.Show("Chỉnh sửa thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                        GridTrangThaiDuAn.DataSource = clsProjectStatus.LoadProjectStatus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa thất bại", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLoaiHeThong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnLuuHeThong.Enabled)
                {
                    btnLuuHeThong_Click(sender, e);
                }
            }
        }

        private void txtTrangThaiTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnLuuTrangThai.Enabled)
                {
                    btnLuuTrangThai_Click(sender, e);
                }
            }
        }
    }
}
