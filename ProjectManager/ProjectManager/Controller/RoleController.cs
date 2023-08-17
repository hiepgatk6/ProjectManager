using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Models;
namespace ProjectManager.Controller
{
    public class RoleController
    {
        Connection con = new Connection();
        public DataTable LoadModule()
        {
            return con.LayDuLieu("SP_Role_Select_All");
        }
        public int EditRole(RoleModel Public)
        {
            int index = 9;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@GroupId";
            value[0] = Public.GroupId;
            para[1] = "@Add";
            value[1] = Public.Add;
            para[2] = "@ModuleId";
            value[2] = Public.ModuleId;
            para[3] = "@Edit";
            value[3] = Public.Edit;
            para[4] = "@View";
            value[4] = Public.View;
            para[5] = "@Delete";
            value[5] = Public.Delete;
            para[6] = "@Import";
            value[6] = Public.Import;
            para[7] = "@Export";
            value[7] = Public.Export;
            para[8] = "@ID";
            value[8] = Public.ID;
            return con.Update("SP_Role_Edit", para, value, index);
        }
        public DataTable getRoleBy2(RoleModel Public)
        {
            int index = 2;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@groupid";
            value[0] = Public.GroupId;
            para[1] = "@moduleid";
            value[1] = Public.ModuleId;
            return con.LayDuLieu("SP_Role_Select_By2", para, value, index);
        }
        public int AddRole(RoleModel Public)
        {
            int index = 8;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@GroupId";
            value[0] = Public.GroupId;
            para[1] = "@Add";
            value[1] = Public.Add;
            para[2] = "@ModuleId";
            value[2] = Public.ModuleId;
            para[3] = "@Edit";
            value[3] = Public.Edit;
            para[4] = "@View";
            value[4] = Public.View;
            para[5] = "@Delete";
            value[5] = Public.Delete;
            para[6] = "@Import";
            value[6] = Public.Import;
            para[7] = "@Export";
            value[7] = Public.Export;
            return con.Update("SP_Role_Add", para, value, index);
        }
        public int DeleteRole(RoleModel Public)
        {
            int index = 1;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Original_ID";
            value[0] = Public.ID;
            return con.Update("SP_Role_Delete", para, value, index);
        }
    }
}
