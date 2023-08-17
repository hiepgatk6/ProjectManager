using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManager.BLL;
using ProjectManager.Models;
using ProjectManager.Helper;
using System.Web;
using System.Drawing.Imaging;

namespace ProjectManager.View.form
{
    public partial class Account : Form
    {
        AccountBLL clsAccount = new AccountBLL();
        GroupIdBLL clsGroupId = new GroupIdBLL();
        public Account()
        {
            InitializeComponent();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            gridAccount.DataSource = clsAccount.LoadAccount();
            gridAccount.CellMouseDown += gridAccount_CellMouseDown;
            loadCBRole();
        }
        private void loadCBRole()
        {
            List<KeyValuePair<string, string>> lstRole = new List<KeyValuePair<string, string>>();
            DataTable dt = clsGroupId.LoadGroupId();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var value1 = dt.Rows[i]["ID"].ToString();
                var value2 = dt.Rows[i]["Name"].ToString();
                lstRole.Add(new KeyValuePair<string, string>(value1, value2));
            }
            cbQuyen.DataSource = lstRole;
            cbQuyen.DisplayMember = "Value";
            cbQuyen.ValueMember = "Key";
        }
        private void gridAccount_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Tạo menu ngữ cảnh cho ô cụ thể
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Thêm mới");
                ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Sửa");
                ToolStripMenuItem menuItem3 = new ToolStripMenuItem("Xóa");

                // Đăng ký sự kiện Click cho menuItem1
                menuItem1.Click += ThemAccount_Click;
                menuItem2.Click += SuaAccount_Click;
                menuItem3.Click += XoaAccount_Click;
                contextMenuStrip.Items.Add(menuItem1);
                contextMenuStrip.Items.Add(menuItem2);
                contextMenuStrip.Items.Add(menuItem3);

                // Hiển thị menu ngữ cảnh tại vị trí chuột
                contextMenuStrip.Show(gridAccount, e.Location);
            }
            else
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Thêm mới");

                // Đăng ký sự kiện Click cho menuItem1
                menuItem1.Click += ThemAccount_Click;
                contextMenuStrip.Items.Add(menuItem1);

                // Hiển thị menu ngữ cảnh tại vị trí chuột
                contextMenuStrip.Show(gridAccount, e.Location);
            }
        }
        private void ThemAccount_Click(object sender, EventArgs e)
        {
            lbID.Text = "-1";
            btnLamMoi_Click(sender, e);
            btnLuu.Enabled = true;
        }
        private void SuaAccount_Click(object sender, EventArgs e)
        {
            txtTenTaiKhoan.Enabled = false;
            txtMatKhau.Enabled = false;
            var id = int.Parse(gridAccount.CurrentRow.Cells["ID"].Value.ToString());
            var tenTaiKhoan = gridAccount.CurrentRow.Cells["AccountName"].Value.ToString();
            var Quyen = gridAccount.CurrentRow.Cells["Role"].Value.ToString();
            var tenDayDu = gridAccount.CurrentRow.Cells["FullName"].Value.ToString();
            var MatKhau = gridAccount.CurrentRow.Cells["Password"].Value.ToString();
            var Phone = gridAccount.CurrentRow.Cells["Phone"].Value.ToString();
            var ImagePath = gridAccount.CurrentRow.Cells["ImagePath"].Value.ToString();
            var Active = bool.Parse(gridAccount.CurrentRow.Cells["Active"].Value.ToString());
            var IsDel = bool.Parse(gridAccount.CurrentRow.Cells["IsDel"].Value.ToString());
            var Email = gridAccount.CurrentRow.Cells["Email"].Value.ToString();
            lbID.Text = id.ToString();
            txtTenTaiKhoan.Text = tenTaiKhoan;
            txtTenDayDu.Text = tenDayDu;
            txtSoDienThoai.Text = Phone;
            txtEmail.Text = Email;
            cbQuyen.SelectedValue = Quyen;
            if (Active)
            {
                ckbKichHoat.Checked = true;
            }
            else
            {
                ckbKichHoat.Checked = false;
            }
            if (IsDel)
            {
                ckbDaXoa.Checked = true;
            }
            else
            {
                ckbDaXoa.Checked = false;
            }
            txtTenAnh.Text = ImagePath;
            txtMatKhau.Text = MatKhau;
            btnLuu.Enabled = true;
        }
        private void XoaAccount_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 4 };
            bool check = roleCheck.checkAccess("Tài Khoản", listAction);
            if (check)
            {

                var id = int.Parse(gridAccount.CurrentRow.Cells["ID"].Value.ToString());
                AccountModel Public = new AccountModel()
                {
                    ID = id
                };

                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    clsAccount.DeleteAccount(Public);
                    btnLamMoi_Click(sender, e);
                    gridAccount.DataSource = clsAccount.LoadAccount();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cbQuyen.SelectedIndex = 0;
            txtTenDayDu.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
            ckbKichHoat.Checked = false;
            ckbDaXoa.Checked = false;

        }

        private void txtTenAnh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbID.Text != "-1")
                {
                    string directoryPath = Path.Combine(Application.StartupPath, "images");
                    string filePath = Path.Combine(directoryPath, txtTenAnh.Text);
                    filePath.Replace("\\", "/");
                    lbPath.Text = directoryPath.Replace("\\", "/");
                    AnhDaiDien.Image = Image.FromFile(filePath);
                }
                else
                {
                    string directoryPath = Path.Combine(Application.StartupPath, "images");
                    string filePath = Path.Combine(directoryPath, txtTenAnh.Text);
                    //if (LuuAnh(directoryPath, txtTenAnh.Text))
                    //{
                    filePath.Replace("\\", "/");
                    lbPath.Text = directoryPath.Replace("\\", "/");
                    AnhDaiDien.Image = Image.FromFile(filePath);
                    //}
                    //MessageBox.Show("Tải ảnh lên thất bại", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                AnhDaiDien.Image = null;
            }
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";

            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog1.FileName);
                string filePath = openFileDialog1.FileName;
                txtTenAnh.Text = fileName;
                lbPath.Text = filePath;
                AnhDaiDien.Image = Image.FromFile(filePath);
            }
        }
        public bool LuuAnh(string Link, string namefile)
        {
            return false;
            //try
            //{
            //    if (!Directory.Exists(Link))
            //    {
            //        Directory.CreateDirectory(Link);
            //    }
            //    else
            //    {
            //        file.SaveAs(Path.Combine(Link, namefile));
            //    }
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 1, 2 };
            bool check = roleCheck.checkAccess("Tài Khoản", listAction);
            if (check)
            {

                var RegexEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                var RegexPhone = @"^(0)([1-9]{1})+([0-9]{8})$";
                if (txtTenTaiKhoan.Text == "" || txtMatKhau.Text == "" || txtTenDayDu.Text == "" || txtSoDienThoai.Text == "" || txtEmail.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ các trường", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.Match(txtEmail.Text, RegexEmail).Success)
                {
                    MessageBox.Show("Vui lòng nhập Email hợp lệ", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.Match(txtSoDienThoai.Text, RegexPhone).Success || txtSoDienThoai.Text.Length > 11)
                {
                    MessageBox.Show("Vui lòng nhập Số điện thoại hợp lệ", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (lbID.Text == "-1")
                {
                    AccountModel Public = new AccountModel()
                    {
                        AccountName = txtTenTaiKhoan.Text,
                        password = Helper.HasPassword.HashPass(txtMatKhau.Text),
                        role = Int32.Parse(cbQuyen.SelectedValue.ToString()),
                        fullName = txtTenDayDu.Text,
                        phone = txtSoDienThoai.Text,
                        email = txtEmail.Text,
                        active = ckbKichHoat.Checked
                    };
                    try
                    {
                        if (txtTenAnh.Text != "")
                        {
                            string directoryPath = Path.Combine(Application.StartupPath, "images");
                            directoryPath = directoryPath.Replace("\\", "/");
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            else
                            {
                                AnhDaiDien.Image.Save(Path.Combine(directoryPath, txtTenAnh.Text));
                                Public.imagePath = txtTenAnh.Text;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Lưu ảnh thất bại!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Public.imagePath = "";
                        return;
                    }
                    if (clsAccount.AddAccount(Public) > 0)
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnLamMoi_Click(sender, e);
                        btnLuu.Enabled = false;
                        gridAccount.DataSource = clsAccount.LoadAccount();
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
                    AccountModel Public = new AccountModel()
                    {
                        ID = Int32.Parse(lbID.Text),
                        AccountName = txtTenTaiKhoan.Text,
                        password = Helper.HasPassword.HashPass(txtMatKhau.Text),
                        role = Int32.Parse(cbQuyen.SelectedValue.ToString()),
                        fullName = txtTenDayDu.Text,
                        phone = txtSoDienThoai.Text,
                        email = txtEmail.Text,
                        active = ckbKichHoat.Checked
                    };
                    try
                    {
                        if (txtTenAnh.Text != "")
                        {
                            string directoryPath = Path.Combine(Application.StartupPath, "images");
                            directoryPath = directoryPath.Replace("\\", "/");
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            else
                            {
                                var y = Path.Combine(directoryPath, txtTenAnh.Text);
                                y = y.Replace("\\", "/");
                                if (!Directory.Exists(y))
                                {
                                    AnhDaiDien.Image.Save(y);
                                }
                                Public.imagePath = txtTenAnh.Text;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lưu ảnh thất bại! Lỗi : " + ex.Message, "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Public.imagePath = "";
                        return;
                    }
                    if (clsAccount.EditAccount(Public) > 0)
                    {
                        MessageBox.Show("Chỉnh sửa thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnLamMoi_Click(sender, e);
                        btnLuu.Enabled = false;
                        gridAccount.DataSource = clsAccount.LoadAccount();
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

        private void AnhDaiDien_Click(object sender, EventArgs e)
        {

        }
    }
}
