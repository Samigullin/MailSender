using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using MailSender.lib.Service;
using MailSender.Models;
using System.IO;
using System;

namespace MailSender.Data
{
    static class TestData
    {
        public static List<Sender> Senders { get; } = Enumerable.Range(1, 10)
            .Select(i => new Sender
            {
                Name = $"Отправитель {i}",
                Address = $"sender_{i}@server.ru"
            })
            .ToList();

        public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 10)
            .Select(i => new Recipient
            {
                Name = $"Получатель {i}",
                Address = $"recipient_{i}@server.ru"
            })
            .ToList();

        public static List<Server> Servers { get; } = Enumerable.Range(1, 10)
            .Select(i => new Server
            {
                Address = $"smtp.server{i}.com",
                Login = $"Login-{i}",
                Password = TextEncoder.Encode($"Password-{i}"),
                UseSSL = i % 2 == 0
            })
            .ToList();

        public static List<Message> Messages { get; } = Enumerable.Range(1, 20)
            .Select(i => new Message
            {
                Subject = $"Сообщение {i}",
                Body = $"Текст сообщения {i}"
            })
            .ToList();

        //public static TestData LoadFromXML(string FileName)
        //{
        //    var serializer = new XmlSerializer(typeof(TestData));
        //    using var file = File.OpenText(FileName);
        //    return (TestData)serializer.Deserialize(file);
        //}
        //public void SaveToXML(string FileName)
        //{
        //    var serializer = new XmlSerializer(typeof(TestData));
        //    using var file = File.Create(FileName);
        //    serializer.Serialize(file, this);
        //}

    }
}