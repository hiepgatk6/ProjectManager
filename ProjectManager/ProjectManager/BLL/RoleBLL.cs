using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Controller;
using ProjectManager.Models;
namespace ProjectManager.BLL
{
    public class RoleBLL
    {
        RoleController cls = new RoleController();
        public DataTable LoadModule()
        {
            return cls.LoadModule();
        }
        public int EditRole(RoleModel Public)
        {
            return cls.EditRole(Public);
        }
        public int AddRole(RoleModel Public)
        {
            return cls.AddRole(Public);
        }
        public int DeleteRole(RoleModel Public)
        {
            return cls.DeleteRole(Public);
        }
        public DataTable getRoleBy2(RoleModel Public)
        {
            return cls.getRoleBy2(Public);
        }
    }
}
