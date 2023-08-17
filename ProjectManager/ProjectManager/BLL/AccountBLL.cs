using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ProjectManager.Models;
using ProjectManager.Controller;
namespace ProjectManager.BLL
{
    public class AccountBLL
    {
        AccountController cls = new AccountController();
        public DataTable LoadAccount()
        {
            return cls.LoadAccount();
        }
        public DataTable LoadAccount_ById(AccountModel Public)
        {
            return cls.LoadAccount_ById(Public);
        }
        public int AddAccount(AccountModel Public)
        {
            return cls.AddAccount(Public);
        }
        public int EditAccount(AccountModel Public)
        {
            return cls.EditAccount(Public);
        }
        public int ChangePassword(AccountModel Public)
        {
            return cls.ChangePassword(Public);
        }
        public int DeleteAccount(AccountModel Public)
        {
            return cls.DeleteAccount(Public);
        }

    }
}
