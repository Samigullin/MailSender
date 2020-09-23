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
        private readonly MailAddress _from, _to;
        private readonly SmtpClient _client;
        private readonly MailMessage _message;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="srv">Адрес сервера</param>
        /// <param name="login">Логин</param>
        /// <param name="pswd">Пароль</param>
        /// <param name="to">Кому</param>
        /// <param name="subj">Тема письма</param>
        /// <param name="body">Текст письма</param>
        /// <param name="port">Порт сервера</param>
        /// <param name="enableSsl">Использовать SSL шифрование</param>
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

        /// <summary>
        /// Отправить письмо
        /// </summary>
        public void SendMail()
        {
            _client.Send(_message);
        }
    }
}
