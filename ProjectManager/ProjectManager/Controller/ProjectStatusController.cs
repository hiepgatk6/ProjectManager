using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManager.Models;

namespace ProjectManager.Controller
{
    public class ProjectStatusController
    {
        Connection con = new Connection();
        public DataTable LoadProjectStatus()
        {
             return con.LayDuLieu("SP_ProjectStatus_Select_All");
        }
        public int EditStatusProject(ProjectStatusModel Public)
        {
            int index = 2;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Status";
            value[0] = Public.Status;
            para[1] = "@ID";
            value[1] = Public.ID;
            return con.Update("SP_ProjectStatus_Edit", para, value, index);
        }
        public int AddStatusProject(ProjectStatusModel Public)
        {
            int index = 1;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Status";
            value[0] = Public.Status;
            return con.Update("SP_ProjectStatus_Add", para, value, index);
        }
        public int DeleteStatusProject(ProjectStatusModel Public)
        {
            int index = 1;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Original_ID";
            value[0] = Public.ID;
            return con.Update("SP_ProjectStatus_Delete", para, value, index);
        }
    }
}
