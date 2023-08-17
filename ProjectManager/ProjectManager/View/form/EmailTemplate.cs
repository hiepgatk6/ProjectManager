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
using System.IO;
using System.Text.RegularExpressions;

namespace ProjectManager.View.form
{
    public partial class EmailTemplate : Form
    {
        EmailTemplateBLL clsEmail = new EmailTemplateBLL();
        public EmailTemplate()
        {
            InitializeComponent();
        }

        private void EmailTemplate_Load(object sender, EventArgs e)
        {
            gridEmail.DataSource = clsEmail.LoadEmail();
            gridEmail.CellMouseDown += gridEmail_CellMouseDown;
            loadCBType();

        }
        public void loadCBType()
        {
            List<KeyValuePair<string, string>> lstType = new List<KeyValuePair<string, string>>();
            Array types = Enum.GetValues(typeof(EnumEmail));
            foreach (EnumEmail type in types)
            {
                lstType.Add(new KeyValuePair<string, string>(type.ToString(), ((int)type).ToString()));
            }
            cbType.DataSource = lstType;
            cbType.DisplayMember = "Key";
            cbType.ValueMember = "Value";
        }
        private void gridEmail_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Tạo menu ngữ cảnh cho ô cụ thể
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Thêm mới");
                ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Sửa");
                ToolStripMenuItem menuItem3 = new ToolStripMenuItem("Xóa");

                // Đăng ký sự kiện Click cho menuItem1
                menuItem1.Click += ThemEmail_Click;
                menuItem2.Click += SuaTrangThai_Click;
                menuItem3.Click += XoaTrangThai_Click;
                contextMenuStrip.Items.Add(menuItem1);
                contextMenuStrip.Items.Add(menuItem2);
                contextMenuStrip.Items.Add(menuItem3);

                // Hiển thị menu ngữ cảnh tại vị trí chuột
                contextMenuStrip.Show(gridEmail, e.Location);
            }
            else
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Thêm mới");

                // Đăng ký sự kiện Click cho menuItem1
                menuItem1.Click += ThemEmail_Click;
                contextMenuStrip.Items.Add(menuItem1);

                // Hiển thị menu ngữ cảnh tại vị trí chuột
                contextMenuStrip.Show(gridEmail, e.Location);
            }
        }
        private void ThemEmail_Click(object sender, EventArgs e)
        {
            lbId.Text = "-1";
            btnLamMoi_Click(sender, e);
            btnXacNhan.Enabled = true;
        }
        private void SuaTrangThai_Click(object sender, EventArgs e)
        {
            var id = int.Parse(gridEmail.CurrentRow.Cells["ID"].Value.ToString());
            var tenNguoiGui = gridEmail.CurrentRow.Cells["FromName"].Value.ToString();
            var EmailSua = gridEmail.CurrentRow.Cells["EmailAddress"].Value.ToString();
            var pass = gridEmail.CurrentRow.Cells["Password"].Value.ToString();
            var Port = gridEmail.CurrentRow.Cells["Port"].Value.ToString();
            var Service = gridEmail.CurrentRow.Cells["Service"].Value.ToString();
            var SSL = bool.Parse(gridEmail.CurrentRow.Cells["SSL"].Value.ToString());
            var Type = /*Int32.Parse(*/gridEmail.CurrentRow.Cells["Type"].Value.ToString();
            lbId.Text = id.ToString();
            txtTenNguoiGui.Text = tenNguoiGui;
            txtEmail.Text = EmailSua;
            txtMatKhau.Text = pass;
            txtCong.Text = Port;
            txtSmtp.Text = Service;
            cbType.SelectedValue = Type;
            txtFileName.Text = gridEmail.CurrentRow.Cells["TemplateName"].Value.ToString();
            if (SSL == true)
            {
                ckbSSL.Checked = true;
            }
            else
            {
                ckbSSL.Checked = false;
            }
            btnXacNhan.Enabled = true;
        }
        private void XoaTrangThai_Click(object sender, EventArgs e)
        {
            var id = int.Parse(gridEmail.CurrentRow.Cells["ID"].Value.ToString());
            EmailTemplateModel Public = new EmailTemplateModel()
            {
                ID = id
            };

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                clsEmail.DeleteEmail(Public);
                btnLamMoi_Click(sender, e);
                gridEmail.DataSource = clsEmail.LoadEmail();
            }
        }


        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailTemplate_Load(sender, e);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var chon = gridEmail.CurrentRow;
            if (chon != null)
            {
                var id = int.Parse(gridEmail.CurrentRow.Cells[0].Value.ToString());
                var email = gridEmail.CurrentRow.Cells[1].Value.ToString();
                var header = gridEmail.CurrentRow.Cells[1].Value.ToString();
                new EmailAdd(id, header, email, "Edit").ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void theemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EmailAdd(0, "", "", "Add").ShowDialog();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 4 };
            bool check = roleCheck.checkAccess("Email Gửi", listAction);
            if (check)
            {

                var chon = gridEmail.CurrentRow;
                if (chon != null)
                {
                    var id = int.Parse(gridEmail.CurrentRow.Cells[0].Value.ToString());

                    EmailTemplateModel Public = new EmailTemplateModel()
                    {
                        ID = id
                    };
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        clsEmail.DeleteEmail(Public);
                        EmailTemplate_Load(sender, e);
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

        private void gridEmail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenNguoiGui.Text = "";
            txtEmail.Text = "";
            txtMatKhau.Text = "";
            txtCong.Text = "";
            txtSmtp.Text = "";
            ckbSSL.Checked = false;
            txtFileName.Text = "";
            cbType.SelectedIndex = 0;
            ckbSuDungMacDinh.Checked = false;
            lbId.Text = "-1";
        }

        private void ckbSuDungMacDinh_CheckedChanged(object sender, EventArgs e)
        {
            txtSmtp.Text = "";
            txtTenNguoiGui.Text = "";
            txtEmail.Text = "";
            txtMatKhau.Text = "";
            txtCong.Text = "";
            txtFileName.Text = "";
            cbType.SelectedIndex = 0;
            ckbSSL.Checked = false;
            txtTenNguoiGui.Text = BienToanCuc.Email;
            txtEmail.Text = BienToanCuc.Email;

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 1, 2 };
            bool check = roleCheck.checkAccess("Email Gửi", listAction);
            if (check)
            {


                var RegexEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                if (!Regex.Match(txtTenNguoiGui.Text, RegexEmail).Success)
                {
                    MessageBox.Show("Vui lòng nhập Email hợp lệ", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtTenNguoiGui.Text == "" || txtEmail.Text == "" || txtMatKhau.Text == "" || txtCong.Text == "" || txtSmtp.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ các trường", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (lbId.Text == "-1")
                {
                    EmailTemplateModel Public = new EmailTemplateModel()
                    {
                        Service = txtSmtp.Text,
                        FromName = txtTenNguoiGui.Text,
                        EmailAddress = txtTenNguoiGui.Text,
                        Password = txtMatKhau.Text,
                        Port = txtCong.Text,
                        SSL = ckbSSL.Checked,
                        TemplateName = txtFileName.Text,
                        Type = Int32.Parse(cbType.SelectedValue.ToString())
                    };

                    DataTable datacheck = clsEmail.LoadEmail();
                    if (datacheck.Rows.Count > 0 && datacheck != null)
                    {
                        for (int i = 0; i < datacheck.Rows.Count; i++)
                        {
                            if(datacheck.Rows[i]["Type"].ToString() == Public.Type.ToString())
                            {
                                MessageBox.Show("Mỗi loại chỉ được thêm 1 email", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    if (clsEmail.AddEmail(Public) > 0)
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnLamMoi_Click(sender, e);
                        btnXacNhan.Enabled = false;
                        gridEmail.DataSource = clsEmail.LoadEmail();
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
                    EmailTemplateModel Public = new EmailTemplateModel()
                    {
                        Service = txtSmtp.Text,
                        FromName = txtTenNguoiGui.Text,
                        EmailAddress = txtTenNguoiGui.Text,
                        Password = txtMatKhau.Text,
                        Port = txtCong.Text,
                        SSL = ckbSSL.Checked,
                        TemplateName = txtFileName.Text,
                        Type = Int32.Parse(cbType.SelectedValue.ToString())
                    };
                    Public.ID = Int32.Parse(lbId.Text);

                    DataTable datacheck = clsEmail.LoadEmail();
                    if (datacheck.Rows.Count > 0 && datacheck != null)
                    {
                        for (int i = 0; i < datacheck.Rows.Count; i++)
                        {
                            if (datacheck.Rows[i]["Type"].ToString() == Public.Type.ToString() && datacheck.Rows[i]["ID"].ToString() == Public.ID.ToString())
                            {
                                MessageBox.Show("Mỗi loại chỉ được có 1 email", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }


                    if (clsEmail.EditEmail(Public) > 0)
                    {
                        btnLamMoi_Click(sender, e);
                        btnXacNhan.Enabled = false;
                        MessageBox.Show("Chỉnh sửa thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                        gridEmail.DataSource = clsEmail.LoadEmail();
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

        private void txtSmtp_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "HTML Files (*.html)|*.html";

            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog1.FileName);
                string filePath = openFileDialog1.FileName;
                txtFileName.Text = fileName;
                lbFileLink.Text = filePath;

                MessageBox.Show(fileName + "-" + filePath);
            }
        }

        private void txtCong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
