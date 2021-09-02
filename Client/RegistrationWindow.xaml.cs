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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string surname = textBoxSurname.Text.Trim();
            string login = textBoxLogin.Text.Trim();
            string password1 = passwordBox1.Password;
            string password2 = passwordBox2.Password;
            string email = textBoxEmail.Text.Trim().ToLower();
            bool? confirm = radioButtonConfirm.IsChecked;
            bool check = true;

            if (name == null || name.Length < 2)
            {
                textBoxName.ToolTip = "Это поле введено не корректно!";
                textBoxName.Foreground = Brushes.Red;
                check = false;
            } 
            else
            {
                textBoxName.ToolTip = null;
                textBoxName.Foreground = Brushes.Black;
                
            }

            if (surname == null || surname.Length < 2)
            {
                textBoxSurname.ToolTip = "Это поле введено не корректно!";
                textBoxSurname.Foreground = Brushes.Red;
                check = false;
            }
            else
            {
                textBoxSurname.ToolTip = null;
                textBoxSurname.Foreground = Brushes.Black;

            }

            if (login == null || login.Length < 6)
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

            if (password1 == null || password1.Length < 6)
            {
                passwordBox1.ToolTip = "Это поле введено не корректно!";
                passwordBox1.Foreground = Brushes.Red;
                check = false;
            }
            else
            {
                passwordBox1.ToolTip = null;
                passwordBox1.Foreground = Brushes.Black;

            }

            if (password2 == null || password2.Length < 6 || password2 != password1)
            {
                passwordBox2.ToolTip = "Это поле введено не корректно!";
                passwordBox2.Foreground = Brushes.Red;
                check = false;
            }
            else
            {
                passwordBox2.ToolTip = null;
                passwordBox2.Foreground = Brushes.Black;

            }

            if (email == null || email.Length < 5 || !email.Contains('@') || !email.Contains('.'))
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
                name = name.Trim();
                surname = surname.Trim();
                name = name.Substring(0, 1).ToUpper() + name.Substring(1);
                surname = surname.Substring(0, 1).ToUpper() + surname.Substring(1);
                email.ToLower();
                MessageBox.Show("OK!");
                Connection.SentData("reg");
                Connection.SentData(login + '$' + password1 + '$' + name + '$' + surname + '$' + email + '$');
            }

        }
    }
}
