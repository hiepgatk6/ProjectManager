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
namespace ProjectManager.View.form
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form_FormClosed);
        }
        void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            frmMain new_mdi_child = new frmMain();
            new_mdi_child.Text = "Quản lý dự án";
            new_mdi_child.MdiParent = this;
            new_mdi_child.Show();
            var timer = new Timer();
            timer.Tick += timer1_Tick_1;
            timer.Interval = 1000;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            lbChao.Text = "Xin chào " + BienToanCuc.FullName + " . Chúc bạn một ngày tốt lành!";
        }

        private void càiĐặtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 3 };
            bool check = roleCheck.checkAccess("Quản lý dự án", listAction);
            if (check)
            {
                Project new_mdi_child = new Project();
                new_mdi_child.Text = "Quản lý dự án";
                new_mdi_child.MdiParent = this;
                new_mdi_child.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword new_mdi_child = new ChangePassword();
            new_mdi_child.Text = "Đổi mật khẩu";
            new_mdi_child.MdiParent = this;
            new_mdi_child.Show();
        }

        private void cấuHìnhEmailGửiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 3 };
            bool check = roleCheck.checkAccess("Email Gửi", listAction);
            if (check)
            {
                EmailTemplate new_mdi_child = new EmailTemplate();
                new_mdi_child.Text = "Email";
                new_mdi_child.MdiParent = this;
                new_mdi_child.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trạngTháiDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 3 };
            bool check = roleCheck.checkAccess("Trạng thái dự án", listAction);
            if (check)
            {
                ProjectStatus new_mdi_child = new ProjectStatus();
                new_mdi_child.Text = "Trạng thái dự án";
                new_mdi_child.MdiParent = this;
                new_mdi_child.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loạiHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 3 };
            bool check = roleCheck.checkAccess("loại hệ thống", listAction);
            if (check)
            {

                SystemType new_mdi_child = new SystemType();
            new_mdi_child.Text = "Loại hệ thống";
            new_mdi_child.MdiParent = this;
            new_mdi_child.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BienToanCuc.AccountName = "";
            //resest bien toan cuc

            new Login().Show();
            this.Hide();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 3 };
            bool check = roleCheck.checkAccess("Tài Khoản", listAction);
            if (check)
            {
                Account new_mdi_child = new Account();
                new_mdi_child.Text = "Tài khoản";
                new_mdi_child.MdiParent = this;
                new_mdi_child.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 3 };
            bool check = roleCheck.checkAccess("Phân quyền", listAction);
            if (check)
            {
                Roles new_mdi_child = new Roles();
                new_mdi_child.Text = "Phân quyền";
                new_mdi_child.MdiParent = this;
                new_mdi_child.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
