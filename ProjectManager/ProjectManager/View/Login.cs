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
using ProjectManager.View.form;
using ProjectManager.Helper;
namespace ProjectManager.View
{
    public partial class Login : Form
    {
        AccountBLL clsAccount = new AccountBLL();
        public Login()
        {
            InitializeComponent();
            if(Properties.Settings.Default.UserName != "")
            {
                ckSavePass.Checked = true;
            }
            txtTaiKhoan.Text = Properties.Settings.Default.UserName;
            txtMatKhau.Text = Properties.Settings.Default.Password;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = clsAccount.LoadAccount();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Đăng nhập thất bại");
                return;
            }
            else
            {
                if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không được rỗng");
                    return;
                }
                var Account = txtTaiKhoan.Text.Trim();
                var Pass = HasPassword.HashPass(txtMatKhau.Text.Trim());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var a = dt.Rows[i]["AccountName"].ToString();
                    var b = dt.Rows[i]["Password"].ToString();
                    if (Account.CompareTo(dt.Rows[i]["AccountName"].ToString()) == 0 && Pass.CompareTo(dt.Rows[i]["Password"].ToString()) == 0)
                    {

                        if(ckSavePass.Checked)
                        {
                            Properties.Settings.Default.UserName = txtTaiKhoan.Text;
                            Properties.Settings.Default.Password = txtMatKhau.Text;
                        }
                        else
                        {
                            Properties.Settings.Default.Reset();
                        }

                        BienToanCuc.ID = Int32.Parse(dt.Rows[i]["ID"].ToString());
                        BienToanCuc.AccountName = dt.Rows[i]["AccountName"].ToString();
                        BienToanCuc.Password = dt.Rows[i]["Password"].ToString();
                        BienToanCuc.Role = Int32.Parse(dt.Rows[i]["Role"].ToString());
                        BienToanCuc.Email = dt.Rows[i]["Email"].ToString();
                        BienToanCuc.FullName = dt.Rows[i]["FullName"].ToString();
                        BienToanCuc.Phone = dt.Rows[i]["Phone"].ToString();
                        this.Hide();
                        new MainForm().ShowDialog();
                        return;
                    }
                }
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                return;
            }


        }

        private void Login_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0')
            {
                txtMatKhau.PasswordChar = '*';
            }
            else
            {
                txtMatKhau.PasswordChar = '\0';
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new ForgotPassword().ShowDialog();
        }
    }
}
