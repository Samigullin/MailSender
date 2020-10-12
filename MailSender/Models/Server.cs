using System;
using MailSender.Models.Base;

namespace MailSender.Models
{
    class Server : BaseModel
    {
        private long? _id;
        private string _senderMail;
        private string _address;
        private int _port = 25;
        private bool _usessl;
        private string _login;
        private string _password;
        private string _description;

        public long? Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public string Address
        {
            get => _address;
            set => Set(ref _address, value);
        }

        public string SenderMail
        {
            get => _senderMail;
            set => Set(ref _senderMail, value);
        }



        public int Port
        {
            get => _port;
            set
            {
                if (value < 0 || value >= 65535)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Номер порта должен быть в диапазоне от 0 до 65534");
                Set(ref _port, value);
            }
        }

        public bool UseSSL
        {
            get => _usessl;
            set => Set(ref _usessl, value);
        }

        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public string Description { get => _description; set => Set(ref _description, value); }

        //private readonly string _Description;

        //public string Description { get { return _Description; } }

        //public override string ToString() => $"{Address}:{Port}";
    }
}