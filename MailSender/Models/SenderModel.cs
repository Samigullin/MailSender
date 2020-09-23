using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;

namespace MailSender.Models
{
    class SenderModel
    {
        private MailAddress _from, _to;
        private SmtpClient _client;
        private MailMessage _message;
        public SenderModel(string srv, string login, SecureString pswd, string to, string subj, string body, int port, bool? enableSsl)
        {
            _to = new MailAddress(to, to.Split("@")[0]);
            _from = new MailAddress(login, login.Split("@")[0]);

            _message = new MailMessage(_from, _to);

            _message.Subject = subj;
            _message.Body = body;

            _client = new SmtpClient(srv, port);
            _client.EnableSsl = enableSsl ?? false;

            _client.Credentials = new NetworkCredential
            {
                UserName = login,
                SecurePassword = pswd
            };
        }

        public void SendMail()
        {
            _client.Send(_message);
        }
    }
}
