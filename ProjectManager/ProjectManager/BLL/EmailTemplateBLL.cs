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
    public class EmailTemplateBLL
    {
        EmailController cls = new EmailController();
        public DataTable LoadEmail()
        {
            return cls.LoadEmail();
        }
        public int EditEmail(EmailTemplateModel Public)
        {
            return cls.EditEmail(Public);
        }
        public int AddEmail(EmailTemplateModel Public)
        {
            return cls.AddEmail(Public);
        }
        public int DeleteEmail(EmailTemplateModel Public)
        {
            return cls.DeleteEmail(Public);
        }
    }
}
