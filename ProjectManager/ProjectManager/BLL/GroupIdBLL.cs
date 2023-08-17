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
    public class GroupIdBLL
    {
        GroupIdController cls = new GroupIdController();
        public DataTable LoadGroupId()
        {
            return cls.LoadGroupId();
        }
    }
}
