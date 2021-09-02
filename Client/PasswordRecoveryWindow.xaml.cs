using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для PasswordRecoveryWindow.xaml
    /// </summary>
    public partial class PasswordRecoveryWindow : Window
    {
        public PasswordRecoveryWindow()
        {
            InitializeComponent();

            


        }


        private void ButtonRecoverPassword_Click(object sender, RoutedEventArgs e)
        {
            string login = this.textBoxLogin.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            bool check = true;
            if (login == null || login.Length < 1)
            {
                textBoxLogin.ToolTip = "Это поле введено не корректно!";
                textBoxLogin.Foreground = Brushes.Red;
                check = false;
            }
            else
            {
                textBoxLogin.ToolTip = null;
                textBoxLogin.Foreground = Brushes.Black;

            }

            if (email == null || email.Length < 1)
            {
                textBoxEmail.ToolTip = "Это поле введено не корректно!";
                textBoxEmail.Foreground = Brushes.Red;
                check = false;
            }
            else
            {
                textBoxEmail.ToolTip = null;
                textBoxEmail.Foreground = Brushes.Black;

            }

            if (check)
            {
                Connection.SentData("passwordRecovery");
                Thread.Sleep(1000);
                Connection.SentData(login + '$' + email + '$');
                Thread.Sleep(500);
                string answer = Connection.ReceiveData();
                Thread.Sleep(500);
                if (answer == "true")
                {
                    MessageBox.Show("Пароль успешно восстановлен!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }
    }


}
