using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AutoMail
{
    class Program
    {
        static void Main(string[] args)
        {
            sendGmail();
        }


        private static void sendGmail()
        {
            MailMessage mail = new MailMessage();
            //前面是發信email後面是顯示的名稱
            mail.From = new MailAddress("信箱", "名稱");
            //收信者email
            mail.To.Add("收信人");
            //設定優先權
            mail.Priority = MailPriority.Normal;
            //標題
            mail.Subject = "AutoEmail";
            //內容
            mail.Body = "<h1>HIHI,Wellcome</h1>";
            //內容使用html
            mail.IsBodyHtml = true;
            //設定gmail的smtp (這是google的)
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);
            //您在gmail的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential("發信人", "密碼");
            //開啟ssl
            MySmtp.EnableSsl = true;
            //發送郵件
            MySmtp.Send(mail);
            //放掉宣告出來的MySmtp
            MySmtp = null;
            //放掉宣告出來的mail
            mail.Dispose();
        }
    }
}
