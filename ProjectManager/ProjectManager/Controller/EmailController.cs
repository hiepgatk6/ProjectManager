using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManager.Models;
namespace ProjectManager.Controller
{
    public class EmailController
    {
        Connection con = new Connection();
        public DataTable LoadEmail()
        {
            return con.LayDuLieu("SP_EmailTemplate_Select_All");
        }
        public int AddEmail(EmailTemplateModel Public)
        {
            int index = 9;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@FromName";
            value[0] = Public.FromName;
            para[1] = "@EmailAddress";
            value[1] = Public.EmailAddress;
            para[2] = "@Password";
            value[2] = Public.Password;
            para[3] = "@Service";
            value[3] = Public.Service;
            para[4] = "@Port";
            value[4] = Public.Port;
            para[5] = "@SSL";
            value[5] = Public.SSL;
            para[6] = "@TotalMailSend";
            value[6] = Public.TotalMailSend;
            para[7] = "@Type";
            value[7] = Public.Type;
            para[8] = "@TemplateName";
            value[8] = Public.TemplateName;
            return con.Update("SP_EmailTemplate_Add", para, value, index);
        }
        public int EditEmail(EmailTemplateModel Public)
        {
            int index = 10;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@FromName";
            value[0] = Public.FromName;
            para[1] = "@EmailAddress";
            value[1] = Public.EmailAddress;
            para[2] = "@Password";
            value[2] = Public.Password;
            para[3] = "@Service";
            value[3] = Public.Service;
            para[4] = "@Port";
            value[4] = Public.Port;
            para[5] = "@SSL";
            value[5] = Public.SSL;
            para[6] = "@TotalMailSend";
            value[6] = Public.TotalMailSend;
            para[7] = "@ID";
            value[7] = Public.ID;
            para[8] = "@Type";
            value[8] = Public.Type; 
            para[9] = "@TemplateName";
            value[9] = Public.TemplateName;
            return con.Update("SP_EmailTemplate_Edit", para, value, index);
        }
        public int DeleteEmail(EmailTemplateModel Public)
        {
            int index = 1;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Original_ID";
            value[0] = Public.ID;
            return con.Update("SP_EmailTemplate_Delete", para, value, index);
        }
    }
}
