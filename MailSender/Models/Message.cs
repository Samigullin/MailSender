using MailSender.Models.Base;

namespace MailSender.Models
{
    class Message : BaseModel
    {
        private string _subject;
        private string _body;

        public string Subject
        {
            get => _subject;
            set => Set(ref _subject, value);
        }

        public string Body
        {
            get => _body;
            set => Set(ref _body, value);
        }
    }
}