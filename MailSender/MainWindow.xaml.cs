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

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region обработчики событий по фокусу

        //TODO: Переделать на триггеры и убрать обработчики из Code-Behind

        private void TbFrom_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (tbFrom.Text == "Адрес отправителя" || tbFrom.Text == "")
            {
                tbFrom.Foreground = Brushes.Black;
                tbFrom.Text = "";
            }
        }

        private void TbFrom_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (tbFrom.Text == "Адрес отправителя" || tbFrom.Text == "")
            {
                tbFrom.Foreground = Brushes.LightGray;
                tbFrom.Text = "Адрес отправителя";
            }
        }


        #endregion

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

        private void TbSrvPort_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (tbSrvPort.Text == "25" || tbSrvPort.Text == "")
            {
                tbSrvPort.Foreground = Brushes.Black;
                tbSrvPort.Text = "";
            }
        }

        private void TbSrvPort_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (tbSrvPort.Text == "25" || tbSrvPort.Text == "")
            {
                tbSrvPort.Foreground = Brushes.LightGray;
                tbSrvPort.Text = "25";
            }
        }
    }
}
