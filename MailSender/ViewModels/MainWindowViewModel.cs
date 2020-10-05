using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MailSender.Data;
using MailSender.Infrastructure.Commands;
using MailSender.lib.Interfaces;
using MailSender.Models;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly IMailService _MailService;

        //public StatisticViewModel Statistic { get; } = new StatisticViewModel();


        #region Props

        private string _Title = "MailSender App";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private ObservableCollection<Server> _Servers;
        private ObservableCollection<Sender> _Senders;
        private ObservableCollection<Recipient> _Recipients;
        private ObservableCollection<Message> _Messages;

        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            set => Set(ref _Servers, value);
        }

        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            set => Set(ref _Senders, value);
        }

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }

        public ObservableCollection<Message> Messages
        {
            get => _Messages;
            set => Set(ref _Messages, value);
        }

        private Server _SelectedServer;

        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }

        private Sender _SelectedSender;

        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }

        private Recipient _SelectedRecipient;

        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }

        private Message _SelectedMessage;

        public Message SelectedMessage
        {
            get => _SelectedMessage;
            set => Set(ref _SelectedMessage, value);
        }

        #endregion


        #region Команды

        #region CreateNewServerCommand

        private ICommand _CreateNewServerCommand;

        public ICommand CreateNewServerCommand => _CreateNewServerCommand
            ??= new LambdaCommand(OnCreateNewServerCommandExecuted, CanCreateNewServerCommandExecute);

        private bool CanCreateNewServerCommandExecute(object p) => true;

        private void OnCreateNewServerCommandExecuted(object p) {
            
            var server = p as Server ?? SelectedServer;
            if (server is null) return;
            Servers.Add(server);

        }

        #endregion

        #region EditServerCommand

        private ICommand _EditServerCommand;

        public ICommand EditServerCommand => _EditServerCommand
            ??= new LambdaCommand(OnEditServerCommandExecuted, CanEditServerCommandExecute);

        private bool CanEditServerCommandExecute(object p) => p is Server || SelectedServer != null;

        private void OnEditServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;

        }

        #endregion

        #region DeleteServerCommand

        private ICommand _DeleteServerCommand;

        public ICommand DeleteServerCommand => _DeleteServerCommand
            ??= new LambdaCommand(OnDeleteServerCommandExecuted, CanDeleteServerCommandExecute);

        private bool CanDeleteServerCommandExecute(object p) => p is Server || SelectedServer != null;

        private void OnDeleteServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;

            Servers.Remove(server);
            SelectedServer = Servers.FirstOrDefault();

            //MessageBox.Show($"Удаление сервера {server.Address}!", "Управление серверами");
        }

        #endregion

        #region Command SendMailCommand - Отправка почты


        private ICommand _SendMailCommand;


        public ICommand SendMailCommand => _SendMailCommand
            ??= new LambdaCommand(OnSendMailCommandExecuted, CanSendMailCommandExecute);

        private bool CanSendMailCommandExecute(object p)
        {
            if (SelectedServer is null) return false;
            if (SelectedSender is null) return false;
            if (SelectedRecipient is null) return false;
            if (SelectedMessage is null) return false;
            return true;
        }

        private void OnSendMailCommandExecuted(object p)
        {
            var server = SelectedServer;
            var sender = SelectedSender;
            var recipient = SelectedRecipient;
            var message = SelectedMessage;

            var mail_sender = _MailService.GetSender(server.Address, server.Port, server.UseSSL, server.Login, server.Password);
            mail_sender.Send(sender.Address, recipient.Address, message.Subject, message.Body);

            //Statistic.MessageSended();
        }

        #endregion

        #endregion

        public MainWindowViewModel(IMailService MailService)
        {
            _MailService = MailService;
            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messages);
        }

        //public MainWindowViewModel()
        //{
        //    Servers = new ObservableCollection<Server>(TestData.Servers);
        //    Senders = new ObservableCollection<Sender>(TestData.Senders);
        //    Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
        //    Messages = new ObservableCollection<Message>(TestData.Messages);
        //}

        //private void OnLoadDataCommandExecuted(object p)
        //{
        //    var data = File.Exists(__DataFileName)
        //        ? TestData.LoadFromXML(__DataFileName)
        //        : new TestData();
        //    Servers = new ObservableCollection<Server>(data.Servers);
        //    Senders = new ObservableCollection<Sender>(data.Senders);
        //    Recipients = new ObservableCollection<Recipient>(data.Recipients);
        //    Messages = new ObservableCollection<Message>(data.Messages);
        //}

        //private ICommand _SaveDataCommand;
        //public ICommand SaveDataCommand => _SaveDataCommand
        //    ??= new LambdaCommand(OnSaveDataCommandExecuted);
        //private void OnSaveDataCommandExecuted(object p)
        //{
        //    var data = new TestData
        //    {
        //        Servers = Servers,
        //        Senders = Senders,
        //        Recipients = Recipients,
        //        Messages = Messages
        //    };
        //    data.SaveToXML(__DataFileName);
        //}


    }
}