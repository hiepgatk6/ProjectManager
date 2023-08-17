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
using ProjectManager.Helper;
using ProjectManager.Models;
namespace ProjectManager.View.form
{
    public partial class Roles : Form
    {
        ModuleBLL clsModule = new ModuleBLL();
        GroupIdBLL clsGroupId = new GroupIdBLL();
        RoleBLL clsRole = new RoleBLL();
        public Roles()
        {
            InitializeComponent();
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            gridRole.DataSource = clsRole.LoadModule();
            LoadGroup();
            loadModule();
        }
        private void LoadGroup()
        {
            List<KeyValuePair<string, string>> lstGroup = new List<KeyValuePair<string, string>>();
            DataTable dt = clsGroupId.LoadGroupId();
            lstGroup.Add(new KeyValuePair<string, string>("0", "Chọn nhóm quyền"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var key = dt.Rows[i]["ID"].ToString();
                var value = dt.Rows[i]["Name"].ToString();
                lstGroup.Add(new KeyValuePair<string, string>(key, value));
            }
            cbbNhomQuyen.DataSource = lstGroup;
            cbbNhomQuyen.DisplayMember = "Value";
            cbbNhomQuyen.ValueMember = "Key";
        }
        private void loadModule()
        {
            List<KeyValuePair<string, string>> lstModule = new List<KeyValuePair<string, string>>();
            DataTable dt = clsModule.LoadModule();
            lstModule.Add(new KeyValuePair<string, string>("0", "Chọn mô đun"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var key = dt.Rows[i]["ID"].ToString();
                var value = dt.Rows[i]["ModuleName"].ToString();
                lstModule.Add(new KeyValuePair<string, string>(key, value));
            }
            cbbMoDun.DataSource = lstModule;
            cbbMoDun.DisplayMember = "Value";
            cbbMoDun.ValueMember = "Key";
        }

        private void cbbNhomQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNhomQuyen.SelectedIndex != 0 && cbbMoDun.SelectedIndex != 0)
            {
                RoleModel Public = new RoleModel()
                {
                    GroupId = Int32.Parse(cbbNhomQuyen.SelectedValue.ToString()),
                    ModuleId = Int32.Parse(cbbMoDun.SelectedValue.ToString())
                };
                DataTable dt = clsRole.getRoleBy2(Public);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    ckThem.Checked = bool.Parse(dt.Rows[0]["Add"].ToString());
                    ckSua.Checked = bool.Parse(dt.Rows[0]["Edit"].ToString());
                    ckXem.Checked = bool.Parse(dt.Rows[0]["View"].ToString());
                    ckXoa.Checked = bool.Parse(dt.Rows[0]["Delete"].ToString());
                    ckImport.Checked = bool.Parse(dt.Rows[0]["Import"].ToString());
                    ckExport.Checked = bool.Parse(dt.Rows[0]["Export"].ToString());
                }
                else
                {
                    ckThem.Checked = false;
                    ckSua.Checked = false;
                    ckXem.Checked = false;
                    ckXoa.Checked = false;
                    ckImport.Checked = false;
                    ckExport.Checked = false;
                }
            }
        }

        private void cbbMoDun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNhomQuyen.SelectedIndex != 0 && cbbMoDun.SelectedIndex != 0)
            {
                RoleModel Public = new RoleModel()
                {
                    GroupId = Int32.Parse(cbbNhomQuyen.SelectedValue.ToString()),
                    ModuleId = Int32.Parse(cbbMoDun.SelectedValue.ToString())
                };
                DataTable dt = clsRole.getRoleBy2(Public);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    ckThem.Checked = bool.Parse(dt.Rows[0]["Add"].ToString());
                    ckSua.Checked = bool.Parse(dt.Rows[0]["Edit"].ToString());
                    ckXem.Checked = bool.Parse(dt.Rows[0]["View"].ToString());
                    ckXoa.Checked = bool.Parse(dt.Rows[0]["Delete"].ToString());
                    ckImport.Checked = bool.Parse(dt.Rows[0]["Import"].ToString());
                    ckExport.Checked = bool.Parse(dt.Rows[0]["Export"].ToString());
                }
                else
                {
                    ckThem.Checked = false;
                    ckSua.Checked = false;
                    ckXem.Checked = false;
                    ckXoa.Checked = false;
                    ckImport.Checked = false;
                    ckExport.Checked = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RoleChecker roleCheck = new RoleChecker();
            List<int> listAction = new List<int>() { 1, 2 };
            bool check = roleCheck.checkAccess("Phân Quyền", listAction);
            if (check)
            {

                if (cbbNhomQuyen.SelectedIndex == 0 && cbbMoDun.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhóm quyền và mô đun", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    RoleModel Public = new RoleModel()
                    {
                        GroupId = Int32.Parse(cbbNhomQuyen.SelectedValue.ToString()),
                        ModuleId = Int32.Parse(cbbMoDun.SelectedValue.ToString()),
                        Add = ckThem.Checked,
                        Edit = ckSua.Checked,
                        Delete = ckXoa.Checked,
                        View = ckXem.Checked,
                        Import = ckImport.Checked,
                        Export = ckExport.Checked
                    };
                    DataTable dt = clsRole.getRoleBy2(Public);
                    if (dt.Rows.Count > 0 && dt != null)
                    {
                        Public.ID = Int32.Parse(dt.Rows[0]["ID"].ToString());
                        clsRole.EditRole(Public);
                        gridRole.DataSource = clsRole.LoadModule();
                        MessageBox.Show("Phân quyền thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);

                    }
                    else
                    {
                        clsRole.AddRole(Public);
                        gridRole.DataSource = clsRole.LoadModule();
                        MessageBox.Show("Phân quyền thành công", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
