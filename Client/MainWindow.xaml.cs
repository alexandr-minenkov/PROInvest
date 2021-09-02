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
using System.Net;
using System.Net.Sockets;
using System.Threading;




namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RegistrationWindow registrationWindow;
        public MainWindow()
        {
            InitializeComponent();
            Connection.StartConnection();
            
            
            //this.Hide();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            //if (!registrationWindow.IsActive)
            //    registrationWindow.Show();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            
            string login = textBoxLogin.Text.Trim();
            string password = passwordBox.Password;
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

            if (password == null || password.Length < 1)
            {
                passwordBox.ToolTip = "Это поле введено не корректно!";
                passwordBox.Foreground = Brushes.Red;
                check = false;
            }
            else
            {
                passwordBox.ToolTip = null;
                passwordBox.Foreground = Brushes.Black;

            }

            if (check)
            {
                try
                {
                    Connection.SentData("auth");
                    Thread.Sleep(1000);
                    Connection.SentData(login + '$' + password + '$');
                    Thread.Sleep(500);
                    string answer = Connection.ReceiveData();
                    Thread.Sleep(500);
                    if (answer == "true")
                    {
                        string userMessage = Connection.ReceiveData();
                        User currentUser = User.getUser(userMessage);
                        DefaultWindow.user = currentUser;
                        DefaultWindow defaultWindow = new DefaultWindow();
                        this.Hide();
                        defaultWindow.Show();
                    }
                    else if (answer == "trueAdmin")
                    {
                        string userMessage = Connection.ReceiveData();
                        User currentUser = User.getUser(userMessage);
                        AdminWindow.user = currentUser;
                        AdminWindow adminWindow = new AdminWindow();
                        this.Hide();
                        adminWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }
                } 
                catch (Exception ex)
                {
                    MessageBox.Show("Соединение с сервером потеряно! Проверьте подключение к интернету.");
                }
                
            }

        }

        private void buttonForgottenPass_Click(object sender, RoutedEventArgs e)
        {
            PasswordRecoveryWindow passwordRecoveryWindow = new PasswordRecoveryWindow();
            passwordRecoveryWindow.Show();

            Console.Read();
        }

        
    }
}
