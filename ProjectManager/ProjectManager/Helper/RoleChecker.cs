using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BLL;
using ProjectManager.Models;
using ProjectManager.Helper;
namespace ProjectManager.Helper
{
    public class RoleChecker
    {
        RoleBLL clsRole = new RoleBLL();
        ModuleBLL clsModule = new ModuleBLL();
        public bool checkAccess(string Modules, List<int> ActionTypeCustoms)
        {
            try
            {
                DataTable AllRole = clsRole.LoadModule();
                DataTable AllModule = clsModule.LoadModule();
                ModuleModel module = null;
                for (int i = 0; i < AllModule.Rows.Count; i++)
                {
                    if (AllModule.Rows[i]["ModuleName"].ToString().ToLower().Equals(Modules.ToLower()))
                    {
                        module = new ModuleModel()
                        {
                            ID = Int32.Parse(AllModule.Rows[i]["ID"].ToString()),
                            Name = AllModule.Rows[i]["Name"].ToString(),
                            ModuleName = AllModule.Rows[i]["ModuleName"].ToString()
                        };
                    }
                }
                if (module == null)
                {
                    return false;
                }
                RoleModel rolemodule = null;
                for (int i = 0; i < AllRole.Rows.Count; i++)
                {
                    if (Int32.Parse(AllRole.Rows[i]["ModuleId"].ToString()) == module.ID && Int32.Parse(AllRole.Rows[i]["GroupId"].ToString()) == BienToanCuc.Role)
                    {
                        rolemodule = new RoleModel()
                        {
                            ID = Int32.Parse(AllRole.Rows[i]["ID"].ToString()),
                            GroupId = Int32.Parse(AllRole.Rows[i]["GroupId"].ToString()),
                            ModuleId = Int32.Parse(AllRole.Rows[i]["ModuleId"].ToString()),
                            Add = bool.Parse(AllRole.Rows[i]["Add"].ToString()),
                            Edit = bool.Parse(AllRole.Rows[i]["Edit"].ToString()),
                            View = bool.Parse(AllRole.Rows[i]["View"].ToString()),
                            Delete = bool.Parse(AllRole.Rows[i]["Delete"].ToString()),
                            Import = bool.Parse(AllRole.Rows[i]["Import"].ToString()),
                            Export = bool.Parse(AllRole.Rows[i]["Export"].ToString()),
                        };
                    }
                }
                if (rolemodule == null)
                {
                    return false;
                }
                var checkAccess = false;
                foreach (var actionType in ActionTypeCustoms)
                {
                    switch (actionType)
                    {
                        case 1:
                            checkAccess = rolemodule.Add;
                            break;
                        case 2:
                            checkAccess = rolemodule.Edit;
                            break;
                        case 3:
                            checkAccess = rolemodule.View;
                            break;
                        case 4:
                            checkAccess = rolemodule.Delete;
                            break;
                        case 5:
                            checkAccess = rolemodule.Import;
                            break;
                        case 6:
                            checkAccess = rolemodule.Export;
                            break;
                        default:
                            checkAccess = false;
                            break;
                    }
                    if (checkAccess == true)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
    public enum ActionTypeCustom
    {
        Add = 1,
        Edit = 2,
        View = 3,
        Delete = 4,
        Import = 5,
        Export = 6
    }
}
