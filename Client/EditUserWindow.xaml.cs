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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        
        unsafe public EditUserWindow()
        {
            InitializeComponent();
            name.Text = DefaultWindow.user.name;
            surname.Text = DefaultWindow.user.surname;
            login.Text = DefaultWindow.user.login;
            password.Text = DefaultWindow.user.password;
            email.Text = DefaultWindow.user.email;
            access.Text = "Доступ: " + DefaultWindow.user.access;
        }
    
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            Connection.SentData("editUser");
            Thread.Sleep(500);
            MessageBox.Show(DefaultWindow.user.id);
            Connection.SentData(DefaultWindow.user.id + "$" + login.Text.Trim() + "$" + password.Text.Trim() +
                "$" + name.Text.Trim() + "$" + surname.Text.Trim() + "$" + email.Text.Trim() + "~");
            string info = "Запрос на изменение данных отправлен!\nИзменения вступят в силу после следующего входа в аккаунт.";
            MessageBox.Show(info);
        }
    }
}
