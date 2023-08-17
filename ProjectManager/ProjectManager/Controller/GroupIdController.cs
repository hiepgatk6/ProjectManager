using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Controller
{
    public class GroupIdController
    {
        Connection con = new Connection();
        public DataTable LoadGroupId()
        {
            return con.LayDuLieu("SP_GroupId_SelectAll");
        }
    }
}
