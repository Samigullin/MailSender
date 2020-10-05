using MailSender.Models.Base;

namespace MailSender.Models
{
    class Recipient : BaseModel
    {
        private string _name;
        private string _address;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Address
        {
            get => _address;
            set => Set(ref _address, value);
        }
    }
}