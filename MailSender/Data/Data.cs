using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MailSender.Annotations;
using MailSender.Models;

namespace MailSender.Data
{
    class SendData : INotifyPropertyChanged
    {
        public ObservableCollection<Sender> Senders;
        public ObservableCollection<Recipient> Recipients;
        public ObservableCollection<Server> Servers;
        public ObservableCollection<Message> Messages;

        public SendData()
        {
            Senders = new ObservableCollection<Sender>();
            Recipients = new ObservableCollection<Recipient>();
            Servers = new ObservableCollection<Server>();
            Messages = new ObservableCollection<Message>();
        }

        public void AddSender(Sender _sender)
        {
            Senders.Add(_sender);
            OnPropertyChanged(nameof(Senders));
        }

        public void AddRecipient(Recipient _recipient)
        {
            Recipients.Add(_recipient);
            OnPropertyChanged(nameof(Recipients));
        }

        public void AddServer(Server _server)
        {
            Servers.Add(_server);
            OnPropertyChanged(nameof(Servers));
        }

        public void AddMessage(Message _message)
        {
            Messages.Add(_message);
            OnPropertyChanged(nameof(Messages));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
