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
namespace ProjectManager.View.form
{
    public partial class ProjectStatus : Form
    {
        ProjectStatusBLL clsProjectStatus = new ProjectStatusBLL();
        public ProjectStatus()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProjectStatus_Load(object sender, EventArgs e)
        {
            GridTrangThaiDuAn.DataSource = clsProjectStatus.LoadProjectStatus();
        }

        private void làmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectStatus_Load(sender, e);
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProjectStatusAdd(0, "", "Add").ShowDialog();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var chon = GridTrangThaiDuAn.CurrentRow;
            if (chon != null)
            {
                var id = int.Parse(GridTrangThaiDuAn.CurrentRow.Cells[0].Value.ToString());
                var status = GridTrangThaiDuAn.CurrentRow.Cells[1].Value.ToString();
                new ProjectStatusAdd(id, status, "Edit").ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var id = int.Parse(GridTrangThaiDuAn.CurrentRow.Cells[0].Value.ToString());
            ProjectStatusModel Public = new ProjectStatusModel()
            {
                ID = id
            };

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                clsProjectStatus.DeleteStatusProject(Public);
                ProjectStatus_Load(sender, e);
            }
        }
    }
}
