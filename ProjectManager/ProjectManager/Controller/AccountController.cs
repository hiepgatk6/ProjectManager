using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManager.Models;

namespace ProjectManager.Controller
{
    public class AccountController
    {
        Connection con = new Connection();
        public DataTable LoadAccount()
        {
            return con.LayDuLieu("SP_Account_Select_All");
        }
        public DataTable LoadAccount_ById(AccountModel Public)
        {
            int index = 1;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@id";
            value[0] = Public.ID;
            return con.LayDuLieu("SP_Account_Select_All_ById", para, value, index);
        }
        public int EditAccount(AccountModel Public)
        {
            int index = 9;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Password";
            value[0] = Public.password;
            para[1] = "@Role";
            value[1] = Public.role;
            para[2] = "@Email";
            value[2] = Public.email;
            para[3] = "@Active";
            value[3] = Public.active;
            para[4] = "@FullName";
            value[4] = Public.fullName;
            para[5] = "@Phone";
            value[5] = Public.phone;
            para[6] = "@ImagePath";
            value[6] = Public.imagePath;
            para[7] = "@Isdel";
            value[7] = Public.IsDel;
            para[8] = "@ID";
            value[8] = Public.ID;
            return con.Update("SP_Account_Edit", para, value, index);
        
        
        }
        public int AddAccount(AccountModel Public)
        {
            int index = 9;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Password";
            value[0] = Public.password;
            para[1] = "@Role";
            value[1] = Public.role;
            para[2] = "@Email";
            value[2] = Public.email;
            para[3] = "@Active";
            value[3] = Public.active;
            para[4] = "@FullName";
            value[4] = Public.fullName;
            para[5] = "@Phone";
            value[5] = Public.phone;
            para[6] = "@ImagePath";
            value[6] = Public.imagePath;
            para[7] = "@Isdel";
            value[7] = Public.IsDel;
            para[8] = "@AccountName";
            value[8] = Public.AccountName;
            return con.Update("SP_Account_Add", para, value, index);
        }

        public int ChangePassword(AccountModel Public)
        {
            int index = 2;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Password";
            value[0] = Public.password;
            para[1] = "@Id";
            value[1] = Public.ID;
            return con.Update("SP_Account_Edit_Password", para, value, index);
        }
        public int DeleteAccount(AccountModel Public)
        {
            int index = 1;
            string[] para = new string[index];
            object[] value = new object[index];
            para[0] = "@Original_ID";
            value[0] = Public.ID;
            return con.Update("SP_Account_Delete", para, value, index);
        }
    }
}
