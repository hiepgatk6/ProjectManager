using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManager.Helper;
using ProjectManager.BLL;
using ProjectManager.Models;

namespace ProjectManager.View.form
{
    public partial class ChangePassword : Form
    {
        AccountBLL clsAccount = new AccountBLL();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(txtMatKhauCu.Text==""||txtMatKhauMoi.Text==""||txtMatKhauMoi1.Text=="")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ dữ liệu", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AccountModel acc = new AccountModel()
                {
                    ID = BienToanCuc.ID
                };
                DataTable dt = clsAccount.LoadAccount_ById(acc);
                if(dt.Rows.Count>0)
                {
                    if(HasPassword.HashPass(txtMatKhauCu.Text).CompareTo(dt.Rows[0]["Password"].ToString())!=0)
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                    else if(txtMatKhauMoi.Text.CompareTo(txtMatKhauMoi1.Text)!=0)
                    {
                        MessageBox.Show("Hai mật khẩu phải giống nhau", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        acc.password = HasPassword.HashPass(txtMatKhauMoi.Text);
                        clsAccount.ChangePassword(acc);
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                        BienToanCuc.Password = acc.password;
                        this.Hide();
                    }
                }
            }
        }

        private void ckbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMatKhauCu.PasswordChar == '\0')
            {
                txtMatKhauCu.PasswordChar = '*';
            }
            else
            {
                txtMatKhauCu.PasswordChar = '\0';
            }


            if (txtMatKhauMoi.PasswordChar == '\0')
            {
                txtMatKhauMoi.PasswordChar = '*';
            }
            else
            {
                txtMatKhauMoi.PasswordChar = '\0';
            }

            if (txtMatKhauMoi1.PasswordChar == '\0')
            {
                txtMatKhauMoi1.PasswordChar = '*';
            }
            else
            {
                txtMatKhauMoi1.PasswordChar = '\0';
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            Resize += MyForm_Resize;
        }
        private void MyForm_Resize(object sender, EventArgs e)
        {
            UpdateGroupBoxPosition();
        }

        private void UpdateGroupBoxPosition()
        {
            // Tính toán vị trí y mới cho GroupBox để nó ở giữa màn hình
            int newY = (this.ClientSize.Height - groupBox1.Height) / 2;
            groupBox1.Location = new System.Drawing.Point(groupBox1.Location.X, newY);
        }
    }
}
