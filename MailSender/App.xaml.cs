using System;
using System.Windows;
using MailSender.lib.Interfaces;
using MailSender.lib.Service;
using MailSender.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MailSender
{
    public partial class App
    {
        interface IDialogService
        {
            void ShowInfo(string msg);
        }
        class WindowDialog : IDialogService
        {
            public void ShowInfo(string msg) => MessageBox.Show(msg);
        }


        private static IHost _Hosting;

        public static IHost Hosting => _Hosting
            ??= Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
                .ConfigureServices(ConfigureServices)
                .Build();

        public static IServiceProvider Services => Hosting.Services;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();

            services.AddTransient<IMailService, SmtpMailService>();

#if DEBUG
            //services.AddTransient<IMailService, DebugMailService>();
#else
            services.AddTransient<IMailService, SmtpMailService>();
#endif
            services.AddTransient<IDialogService, WindowDialog>();
            //services.AddScoped<>()

            // Так делать не надо:!!!
            //using (var scope = Services.CreateScope())
            //{
            //    var mail_service = scope.ServiceProvider.GetRequiredService<IMailService>();
            //    var sender = mail_service.GetSender("smtp.mail.ru", 25, true, "Login", "Password");
            //    sender.Send("sender@mail.ru", "recipient@gmail.com", "Title", "Body");
            //}



        }

    }
}