using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleApp1
{
    class Smtp
    {
        SmtpClient m_Client;
        MailMessage m_Message;

        public void define()
        {
            m_Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "icdnr10@gmail.com",
                    Password = "npldejfuidgkkiib"
                }

                
            };
            MailAddress FromEmail = new MailAddress("icdnr10@gmail.com", "testMailSender");
            MailAddress ToEmail = new MailAddress("itayco@trunovate.com", "testMailReciver");
            m_Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "test mail try",
                Body = "this is the text message"
            };
            m_Message.To.Add(ToEmail);

        }

        public void sendMail()
        {
            try
            {
                 m_Client.Send(m_Message);
               // m_Client.SendCompleted += M_Client_SendCompleted;
                //m_Client.SendMailAsync(m_Message);
                Console.WriteLine(@"send successful ! ");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message );
            }
        }

        private void M_Client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error!=null)
            {
                Console.WriteLine("problem async");
                return;
            }
            else
            {
                Console.WriteLine("all went well!!!");
            }
        }
    }
}
