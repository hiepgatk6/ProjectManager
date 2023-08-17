using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManager.BLL;
using ProjectManager.Models;
using ProjectManager.Helper;
namespace ProjectManager.View.form
{
    public partial class ForgotPassword : Form
    {
        EmailTemplateBLL clsEmail = new EmailTemplateBLL();
        AccountBLL clsAccount = new AccountBLL();
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            Resize += MyForm_Resize;
            CenterToScreen();

        }
        private void MyForm_Resize(object sender, EventArgs e)
        {
            UpdateGroupBoxPosition();
        }

        private void UpdateGroupBoxPosition()
        {
            int newY = (this.ClientSize.Height - groupBox1.Height) / 2;
            groupBox1.Location = new System.Drawing.Point(groupBox1.Location.X, newY);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //pass random
            int passwordLength = 8;
            string randomPassword = GenerateRandomPassword(passwordLength);


            //get mail
            EmailTemplateModel Email = getEmailModelbyType(1);


            string toEmail = "";
            var idAccount = 0;
            DataTable dt = clsAccount.LoadAccount();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["AccountName"].ToString().Trim().CompareTo(txtTaiKhoan.Text.Trim()) == 0)
                    {
                        idAccount = Int32.Parse(dt.Rows[i]["ID"].ToString());
                        toEmail = dt.Rows[i]["Email"].ToString();
                        break;
                    }
                }
            }
            if (toEmail != "")
            {
                try
                {

                    MailMessage mail = new MailMessage();
                    SmtpClient sc = new SmtpClient(Email.Service);
                    mail.From = new MailAddress(Email.EmailAddress, "Forgot Password");
                    mail.To.Add(toEmail);
                    mail.Subject = "Quên mật khẩu";
                    mail.Body = "Ai đó vừa dùng mật khẩu của bạn để cố đăng nhập vào tài khoản của bạn. Chúng tôi đã chặn họ," +
                            " nhưng bạn nên kiểm tra xem điều gì đã xảy ra. Họ đã gửi yêu cầu resest mật khẩu . Để tăng tính bảo mật ," +
                            "chúng tôi đã đổi mật khẩu của bạn thành :" + randomPassword + " .Vui dòng dùng mật khẩu này để đăng nhập";
                    sc.Port = Int32.Parse(Email.Port);
                    sc.Credentials = new System.Net.NetworkCredential(Email.EmailAddress, Email.Password);
                    sc.EnableSsl = Email.SSL;
                    sc.Send(mail);

                    AccountModel Public = new AccountModel()
                    {
                        ID = idAccount,
                        password = Helper.HasPassword.HashPass(randomPassword)
                    };
                    clsAccount.ChangePassword(Public);
                    MessageBox.Show("Đã gửi mail resest mật khẩu");
                    btnhide_Click(sender, e);
                }
                catch
                {
                    MessageBox.Show("Có lỗi trong quá trình gửi mail", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không chính xác", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
        public string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+[]{}|;:,.<>?";
            Random random = new Random();
            string password = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private EmailTemplateModel getEmailModelbyType(int type)
        {
            EmailTemplateModel Email = null;
            DataTable dt = clsEmail.LoadEmail();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Int32.Parse(dt.Rows[i]["Type"].ToString()).Equals(type))
                    {
                        Email = new EmailTemplateModel()
                        {
                            ID = Int32.Parse(dt.Rows[i]["Type"].ToString()),
                            FromName = dt.Rows[i]["FromName"].ToString(),
                            EmailAddress = dt.Rows[i]["EmailAddress"].ToString(),
                            Password = dt.Rows[i]["Password"].ToString(),
                            Service = dt.Rows[i]["Service"].ToString(),
                            Port = dt.Rows[i]["Port"].ToString(),
                            SSL = bool.Parse(dt.Rows[i]["SSL"].ToString()),
                            TotalMailSend = Int32.Parse(dt.Rows[i]["TotalMailSend"].ToString()),
                            Type = Int32.Parse(dt.Rows[i]["Type"].ToString()),
                            TemplateName = dt.Rows[i]["Type"].ToString()
                        };
                        break;
                    }
                }
            }
            return Email;
        }
    }
}
