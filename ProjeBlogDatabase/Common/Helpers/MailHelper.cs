using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class MailHelper
    {
        public static bool SendMail(string body, string to, string subject, bool ishtml = true)
        {
            return SendMail(body, new List<string> { to }, subject, ishtml);
        }
        public static bool SendMail(string body, List<string> to, string subject, bool ishtml = true)
        {
            bool result = false;
            try
            {
                SmtpClient mailcleint=new SmtpClient(ConfigHelper.Get<string>("Mailhost"), ConfigHelper.Get<int>("MailPort"));
                NetworkCredential cred = new NetworkCredential(ConfigHelper.Get<string>("MailUser"), ConfigHelper.Get<string>("MailPass"));
                mailcleint.Credentials = cred;
                MailMessage mmsj = new MailMessage();
                mmsj.From=new MailAddress(ConfigHelper.Get<string>("MailUser"));
                mmsj.Subject = subject;
                mmsj.Body = body;
                //mailcleint.UseDefaultCredentials = false;
                mailcleint.EnableSsl = true;
                foreach (string item in to)
                {
                    mmsj.To.Add(item);
                    mailcleint.Send(mmsj);
                    mmsj.To.Clear();
                }               
                    

               
                
            }
            catch (Exception)
            {
                //Console.WriteLine("hata var");
                throw;
            }
            return result;

        }
    }
}
