using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManager.Models;
using ProjectManager.Controller;
namespace ProjectManager.BLL
{
    public class SystemTypeBLL
    {
        SystemTypeController cls = new SystemTypeController();
        public DataTable LoadSystemType()
        {
            return cls.LoadSystemType();
        }
        public int EditSystemType(SystemTypeModel Public)
        {
            return cls.EditSystemType(Public);
        }
        public int AddSystemType(SystemTypeModel Public)
        {
            return cls.AddSystemType(Public);
        }
        public int DeleteSystemType(SystemTypeModel Public)
        {
            return cls.DeleteSystemType(Public);
        }
    }
}
