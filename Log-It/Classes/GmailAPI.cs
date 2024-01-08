using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_It.Classes
{
    class GmailAPI
    {
        static string[] Scopes = { GmailService.Scope.GmailSend };
        static string ApplicationName = "GmailAPI";

        static string Base64UrlEncode(string input)
        {
            var data = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(data).Replace("+", "-").Replace("/", "_").Replace("=", "");
        }

        public static bool Send_Mail(MailMessage mail, List<string> attact)
        {
            try
            {
                // await Task.Run(() =>
                // {
                UserCredential credential;
                //read your credentials file
                using (FileStream stream = new FileStream(Application.StartupPath + @"/credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    path = Path.Combine(path, ".credentials/gmail-dotnet-quickstart.json");
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(path, true)).Result;
                }
                //string message = $"To: {TBReciever.Text}\r\nSubject: {TBSubject.Text}\r\nContent-Type: text/html;charset=utf-8\r\n\r\n<h1>{TBMessage.Text}</h1>";

                var service = new GmailService(new BaseClientService.Initializer() { HttpClientInitializer = credential, ApplicationName = ApplicationName });
                var msg = new Google.Apis.Gmail.v1.Data.Message();

                //MailMessage mail2 = new MailMessage();
                //mail.Subject = subject;
                //mail.Body = message;
                //mail.From = new MailAddress(from);
                //mail.IsBodyHtml = true;
                //mail.To.Add(new MailAddress(to));
                //mail.To.Add(new MailAddress("it@technoman.biz"));
                var bodyBuilder = new BodyBuilder();
                if (attact != null)
                {
                    if (attact.Count != 0)
                    {
                        foreach (var item in attact)
                        {
                            bodyBuilder.Attachments.Add(item);
                        }
                    }
                }


                bodyBuilder.HtmlBody = mail.Body;
                MimeMessage mimeMessage = MimeMessage.CreateFromMailMessage(mail);
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                msg.Raw = Base64UrlEncode(mimeMessage.ToString());
                service.Users.Messages.Send(msg, "me").Execute();

                //for (int i = 0; i <= 60; i++)
                //{
                //    Thread.Sleep(60000);
                //}
                //MessageBox.Show("Your email has been successfully sent !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // });
                return true;
            }
            catch (Exception ex)
            {
                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.WriteLogException("Message: " + ex.Message + "Method Name :" +currentMethodName.Name+ "Date Time: " + DateTime.Now);
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool Send_Mail(MailMessage mail, List<string> attact, string smtpAddress, int portNumber, string emailFromAddress, string password)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    try
                    {

                        smtp.EnableSsl = false;
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                        smtp.Host = smtpAddress;
                        smtp.Port = portNumber;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        if (attact != null && attact.Count > 0)
                        {
                            foreach (var item in attact)
                            {
                                mail.Attachments.Add(new Attachment(item));
                            }
                        }
                        smtp.Send(mail);
                        //MessageBox.Show("Email Successfully Sent.");

                    }
                    catch (Exception m)
                    {
                        return false;
                        //MessageBox.Show("Delivery failed." + " Message : " + m.Message);
                        //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
