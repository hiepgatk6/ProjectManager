using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManager.Models;
namespace ProjectManager.Controller
{
    public class ModuleController
    {
        Connection con = new Connection();
        public DataTable LoadModule()
        {
            return con.LayDuLieu("SP_Module_Select_All");
        }
        //public int EditModule(ModuleModel Public)
        //{
        //    int index = 3;
        //    string[] para = new string[index];
        //    object[] value = new object[index];
        //    para[0] = "@Name";
        //    value[0] = Public.Name;
        //    para[1] = "@ModuleName";
        //    value[1] = Public.ModuleName;
        //    para[2] = "@ID";
        //    value[2] = Public.ID;
        //    return con.Update("SP_Module_Edit", para, value, index);
        //}
    }
}
