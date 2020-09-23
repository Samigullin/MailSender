using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MailSender.Models;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SenderModel mailer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mailer = new SenderModel(srv: tbSrvAddr.Text, login: tbLogin.Text, pswd: pbSrvPswd.SecurePassword, to: tbTo.Text, subj: tbSubj.Text, body: tbBody.Text, port: Int32.Parse(tbSrvPort.Text), enableSsl: cbUseSSL.IsChecked);
                mailer.SendMail();
                tbStatusBar.Text = "Письмо отправлено";
            }
            catch (Exception exception)
            {
                tbStatusBar.Text = exception.Message;
            }
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbBody.Text = "";
            tbSubj.Text = "";
            tbTo.Text = "";
            tbStatusBar.Text = "Готов!";
        }

        #region обработчики событий по фокусу

        //TODO: Переделать на триггеры и убрать обработчики из Code-Behind

        private void TbSubj_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (tbSubj.Text == "Тема письма" || tbSubj.Text == "")
            {
                tbSubj.Foreground = Brushes.Black;
                tbSubj.Text = "";
            }
        }

        private void TbSubj_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (tbSubj.Text == "Тема письма" || tbSubj.Text == "")
            {
                tbSubj.Foreground = Brushes.LightGray;
                tbSubj.Text = "Тема письма";
            }
        }

        private void TbTo_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (tbTo.Text == "Адрес получателя" || tbTo.Text == "")
            {
                tbTo.Foreground = Brushes.Black;
                tbTo.Text = "";
            }
        }

        private void TbTo_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (tbTo.Text == "Адрес получателя" || tbTo.Text == "")
            {
                tbTo.Foreground = Brushes.LightGray;
                tbTo.Text = "Адрес получателя";
            }
        }

        private void TbSrvAddr_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (tbSrvAddr.Text == "Адрес сервера" || tbSrvAddr.Text == "")
            {
                tbSrvAddr.Foreground = Brushes.Black;
                tbSrvAddr.Text = "";
            }
        }

        private void TbSrvAddr_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (tbSrvAddr.Text == "Адрес сервера" || tbSrvAddr.Text == "")
            {
                tbSrvAddr.Foreground = Brushes.LightGray;
                tbSrvAddr.Text = "Адрес сервера";
            }
        }

        private void TbLogin_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "Адрес отправителя" || tbLogin.Text == "")
            {
                tbLogin.Foreground = Brushes.Black;
                tbLogin.Text = "";
            }
        }

        private void TbLogin_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "Адрес отправителя" || tbLogin.Text == "")
            {
                tbLogin.Foreground = Brushes.LightGray;
                tbLogin.Text = "Адрес отправителя";
            }
        }







        #endregion


    }
}
