using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManager.Models;
namespace ProjectManager.Controller
{
    public class ProjectController
    {
        Connection con = new Connection();
        public DataTable LoadProjectAll()
        {
            return con.LayDuLieu("SP_Project_Select_All");
        }
        public DataTable LoadProjectExpireDate()
        {
            return con.LayDuLieu("SP_Project_Select_expirationDate");
        }
        public DataTable LoadProjectById(ProjectModel Public)
        {
            int index = 1;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Id";
            value[0] = Public.ID;
            return con.LayDuLieu("SP_Project_Select_ById", para, value, index);
        }
        public int EditProject(ProjectModel Public)
        {
            int index = 17;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@ContractNumber";
            value[0] = Public.ContractNumber;
            para[1] = "@GoLiveDate";
            value[1] = Public.GoLiveDate;
            para[2] = "@ExpirationDate";
            value[2] = Public.ExpirationDate;
            para[3] = "@WarrantyTime";
            value[3] = Public.WarrantyTime;
            para[4] = "@MaintenanceTime";
            value[4] = Public.MaintenanceTime;
            para[5] = "@Active";
            value[5] = Public.Active;
            para[6] = "@ProjectName";
            value[6] = Public.ProjectName;
            para[7] = "@IsDel";
            value[7] = Public.IsDel;
            para[8] = "@Status";
            value[8] = Public.Status;
            para[9] = "@Type";
            value[9] = Public.Type;
            para[10] = "@UserEdit";
            value[10] = Public.UserEdit;
            para[11] = "@DateEdit";
            value[11] = Public.DateEdit;
            para[12] = "@UserCreate";
            value[12] = Public.UserCreate;
            para[13] = "@DateCreate";
            value[13] = Public.DateCreate;
            para[14] = "@ID";
            value[14] = Public.ID;
            para[15] = "@MaintenanceEndDate";
            value[15] = Public.MaintenanceEndDate;
            para[16] = "@MaintenanceDateStart";
            value[16] = Public.MaintenanceDateStart;
            return con.Update("SP_Project_Edit", para, value, index);
        }
        public int AddProject(ProjectModel Public)
        {
            int index = 16;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@ContractNumber";
            value[0] = Public.ContractNumber;
            para[1] = "@GoLiveDate";
            value[1] = Public.GoLiveDate;
            para[2] = "@ExpirationDate";
            value[2] = Public.ExpirationDate;
            para[3] = "@WarrantyTime";
            value[3] = Public.WarrantyTime;
            para[4] = "@MaintenanceTime";
            value[4] = Public.MaintenanceTime;
            para[5] = "@Active";
            value[5] = Public.Active;
            para[6] = "@ProjectName";
            value[6] = Public.ProjectName;
            para[7] = "@IsDel";
            value[7] = Public.IsDel;
            para[8] = "@Status";
            value[8] = Public.Status;
            para[9] = "@Type";
            value[9] = Public.Type;
            para[10] = "@UserEdit";
            value[10] = Public.UserEdit;
            para[11] = "@DateEdit";
            value[11] = Public.DateEdit;
            para[12] = "@UserCreate";
            value[12] = Public.UserCreate;
            para[13] = "@DateCreate";
            value[13] = Public.DateCreate;
            para[14] = "@MaintenanceEndDate";
            value[14] = Public.MaintenanceEndDate;
            para[15] = "@MaintenanceDateStart";
            value[15] = Public.MaintenanceDateStart;
            return con.Update("SP_Project_Add", para, value, index);
        }
        public int DeleteProject(ProjectModel Public)
        {
            int index = 1;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Original_ID";
            value[0] = Public.ID;
            return con.Update("SP_Project_Delete", para, value, index);
        }
    }
}
