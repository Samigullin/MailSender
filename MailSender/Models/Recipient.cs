using System;
using System.Text.RegularExpressions;
using MailSender.Models.Base;

namespace MailSender.Models
{
    class Recipient : BaseModel
    {
        private string _name;
        private string _address;
        private long _id;

        public long Id
        {
            get => _id;
            set => Set(ref _id, value);
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Имя не может быть пустым!");
                }

                Set(ref _name, value);
            } 
        }

        public string Address
        {
            get => _address;
            set
            {
                //string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                //                 @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                //if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                //{
                //    throw new ArgumentException("Не правильный формат почты!");
                //}
                Set(ref _address, value);
            }
        }
    }
}