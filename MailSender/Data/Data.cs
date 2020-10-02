using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MailSender.Models;

namespace MailSender.Data
{
    static class Data
    {
        public static ObservableCollection<Sender> Senders { get; set; }

        public static ObservableCollection<Recipient> Recipients { get; set; }

        public static ObservableCollection<Server> Servers { get; set; }

        public static ObservableCollection<Message> Messages { get; set; }

        public static void AddSender(Sender _sender)
        {
            Senders.Add(_sender);
        }

        public static void AddRecipient(Recipient _recipient)
        {
            Recipients.Add(_recipient);
        }
    }
}
