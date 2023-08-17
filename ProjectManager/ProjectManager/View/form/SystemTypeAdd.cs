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
    public partial class SystemTypeAdd : Form
    {
        SystemTypeBLL clsSystem = new SystemTypeBLL();
        public int id;
        public string type;
        public string action;
        public SystemTypeAdd(int Id = 0,string Type="",string Action="")
        {
            InitializeComponent();
            id = Id;
            type = Type;
            action = Action;
        }

        private void SystemTypeAdd_Load(object sender, EventArgs e)
        {
            if(action.CompareTo("Edit")==0)
            {
                txtId.Text = id.ToString();
                txtType.Text = type;
            }    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtType.Text==""||txtId.Text=="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SystemTypeModel Public = new SystemTypeModel()
            {
                Type = txtType.Text
            };
            if(action.CompareTo("Edit")==0)
            {
                Public.ID = Int32.Parse(txtId.Text);
                if(clsSystem.EditSystemType(Public)>0)
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
            else if(action.CompareTo("Add")==0)
            {
                if (clsSystem.AddSystemType(Public) > 0)
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
    }
}
