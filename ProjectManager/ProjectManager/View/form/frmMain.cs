using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManager.BLL;

namespace ProjectManager.View.form
{
    public partial class frmMain : Form
    {
        ProjectBLL clsProject = new ProjectBLL(); 

        public frmMain()
        {
            InitializeComponent();
           
        }

        


        private void frmMain_Load(object sender, EventArgs e)
        {
            DataTable dt = clsProject.LoadProjectExpireDate();
            gridProject.DataSource = clsProject.LoadProjectAll();
            gridProject1.DataSource = dt;
            List<String> tenhethan = new List<string>();

            int dem = 0;
            string message="Bạn có {dem} dự án sắp hết hạn: ";
            if(dt.Rows.Count>0)
            {
                for(int i=0;i< dt.Rows.Count; i++)
                {
                    tenhethan.Add(dt.Rows[i]["ProjectName"].ToString());
                    dem += 1;
                }    
            }    
            if (dem > 0)
            {
                foreach(string item in tenhethan)
                {
                    message += item + ",";
                }
                Regex regex = new Regex(",\\s*$");
                string result = regex.Replace(message, ".");
                result = result.Replace("{dem}", dem.ToString());
                MessageBox.Show(result, "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChangePassword().ShowDialog();
        }

        private void emailGửiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EmailTemplate().ShowDialog();
        }

        private void trạngTháiDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProjectStatus().ShowDialog();
        }

        private void loạiHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SystemType().ShowDialog();
        }

        private void danhSáchDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Project().ShowDialog();
        }

        private void gridProject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
