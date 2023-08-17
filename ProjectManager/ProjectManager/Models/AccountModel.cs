using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class AccountModel
    {
        public int ID { get; set; }
        public string password { get; set; }
        public string AccountName { get; set; }
        public int role { get; set; }
        public string email { get; set; }
        public bool active { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public string imagePath { get; set; }
        public bool IsDel { get; set; }
    }
}
