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
    public class ProjectBLL
    {
        ProjectController cls = new ProjectController();
        public DataTable LoadProjectAll()
        {
            return cls.LoadProjectAll();
        }
        public DataTable LoadProjectExpireDate()
        {
            return cls.LoadProjectExpireDate();
        }
        public DataTable LoadProjectById(ProjectModel Public)
        {
            return cls.LoadProjectById(Public);
        }
        public int EditProject(ProjectModel Public)
        {
            return cls.EditProject(Public);
        }
        public int AddProject(ProjectModel Public)
        {
            return cls.AddProject(Public);
        }
        public int DeleteProject(ProjectModel Public)
        {
            return cls.DeleteProject(Public);
        }
    }
}
