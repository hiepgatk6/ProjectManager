using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManager.Models;
using ProjectManager.BLL;

namespace ProjectManager.View.form
{
    public partial class ProjectStatusAdd : Form
    {
        public int Id;
        public string Status;
        public string Action;
        ProjectStatusBLL clsProjectStatus = new ProjectStatusBLL();
        public ProjectStatusAdd(int id = 0, string status = "", string action = "")
        {
            InitializeComponent();
            Id = id;
            Status = status;
            Action = action;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ProjectStatusAdd_Load(object sender, EventArgs e)
        {
            if (Action == "Edit")
            {
                txtId.Text = Id.ToString();
                txtStatus.Text = Status;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text == "" || txtId.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ProjectStatusModel Public = new ProjectStatusModel()
            {
                Status = txtStatus.Text
            };
            if (Action == "Edit")
            {
                Public.ID = Int32.Parse(txtId.Text);
                if(clsProjectStatus.EditStatusProject(Public)>0)
                {
                    MessageBox.Show("Chỉnh sửa thành công, làm mới để nhận kết quả!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa thất bại", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (Action == "Add")
            {
                if (clsProjectStatus.AddStatusProject(Public) > 0)
                {
                    MessageBox.Show("Thêm mới thành công, làm mới để nhận kết quả!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm mới thất bại", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
