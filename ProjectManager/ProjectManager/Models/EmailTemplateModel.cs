using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class EmailTemplateModel
    {
        public int ID { get; set; }
        public int TotalMailSend { get; set; }
        public int Type { get; set; }
        public string FromName { get; set; }
        public string TemplateName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Service { get; set; }
        public string Port { get; set; }
        public bool SSL { get; set; }
    }
    public enum EnumEmail
    {
        Quên_mật_khẩu = 1,
        Dự_án_hết_hạn = 2
    }
}
