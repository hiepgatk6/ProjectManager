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
    public class ProjectStatusBLL
    {
        ProjectStatusController cls = new ProjectStatusController();
        public DataTable LoadProjectStatus()
        {
            return cls.LoadProjectStatus();
        }
        public int EditStatusProject(ProjectStatusModel Public)
        {
            return cls.EditStatusProject(Public);
        }
        public int AddStatusProject(ProjectStatusModel Public)
        {
            return cls.AddStatusProject(Public);
        }
        public int DeleteStatusProject(ProjectStatusModel Public)
        {
            return cls.DeleteStatusProject(Public);
        }
    }
}
