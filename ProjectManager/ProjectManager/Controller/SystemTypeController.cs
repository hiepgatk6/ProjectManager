using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManager.Models;

namespace ProjectManager.Controller
{
    public class SystemTypeController

    {
        Connection con = new Connection();
        public DataTable LoadSystemType()
        {
            return con.LayDuLieu("SP_SystemType_Select_All");
        }
        public int EditSystemType(SystemTypeModel Public)
        {
            int index = 2;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Type";
            value[0] = Public.Type;
            para[1] = "@ID";
            value[1] = Public.ID;
            return con.Update("SP_SystemType_Edit", para, value, index);
        }
        public int AddSystemType(SystemTypeModel Public)
        {
            int index = 1;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Type";
            value[0] = Public.Type;
            return con.Update("SP_SystemType_Add", para, value, index);
        }
        public int DeleteSystemType(SystemTypeModel Public)
        {
            int index = 1;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Original_ID";
            value[0] = Public.ID;
            return con.Update("SP_SystemType_Delete", para, value, index);
        }
    }
}
