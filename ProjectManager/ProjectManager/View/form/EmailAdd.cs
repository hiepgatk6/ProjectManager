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
    public partial class EmailAdd : Form
    {
        EmailTemplateBLL clsEmail = new EmailTemplateBLL();
        int id = 0;
        string header = "";
        string Email = "";
        string Action = "";
        public EmailAdd(int ID = 0, string HEADER = "", string EMAIL = "", string action = "")
        {
            InitializeComponent();
            id = ID;
            header = HEADER;
            Email = EMAIL;
            Action = action;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EmailAdd_Load(object sender, EventArgs e)
        {
            if (Action.CompareTo("Edit") == 0)
            {
                lbId.Text = id.ToString();
                txtTieuDe.Text = header;
                txtNoiDung.Text = Email;
            }


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtTieuDe.Text == "" || txtNoiDung.Text=="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ nội dung", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EmailTemplateModel Public = new EmailTemplateModel()
            {
                //Email = txtNoiDung.Text,
                //EmailHeader = txtTieuDe.Text
            };
            if(Action.CompareTo("Edit")==0)
            {
                Public.ID = Int32.Parse(lbId.Text);
                int kq = clsEmail.EditEmail(Public);
                if(kq>0)
                {
                    MessageBox.Show("Chỉnh sửa thành công, Làm mới để nhận kết quả !", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa thất bại", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Action.CompareTo("Add") == 0)
            {
                int kq = clsEmail.AddEmail(Public);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công, Làm mới để nhận kết quả !", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
