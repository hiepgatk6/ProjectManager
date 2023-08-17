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
    public class ModuleBLL
    {
        ModuleController cls = new ModuleController();
        public DataTable LoadModule()
        {
            return cls.LoadModule();
        }
    }
}
