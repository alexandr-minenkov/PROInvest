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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Client
{

    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string access { get; set; }
        public int balance { get; set; }
        public Project project;

        public static User getUser(string tmpMessage)
        {
            int i = -1;
            string id = null, login = null, pass = null, name = null, surname = null, email = null, access = null, balance =null;
            while (tmpMessage[++i] != '$')
            {
                id += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                login += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                pass += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                name += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                surname += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                email += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                access += tmpMessage[i];
            }
            while (tmpMessage[++i] != '~')
            {
                balance += tmpMessage[i];
            }
            if (access == "1")
            {
                access = "Администратор";
            }
            else access = "Пользователь";

            return new User { id = id, name = name, surname = surname, login = login, password = pass, email = email, access = access, balance = int.Parse(balance) };
        }
    }
    /// <summary>
    /// Логика взаимодействия для UserControlDesktop.xaml
    /// </summary>
    public partial class AdminControlUsersList : UserControl
    {
        public AdminControlUsersList()
        {
            InitializeComponent();
            UpdateDataGrid();
            
        }

        public void UpdateDataGrid()
        {
            usersGrid.Items.Clear();
            Connection.SentData("getUsers");
            Thread.Sleep(500);
            string tmpMessage = Connection.ReceiveData();
            int count = int.Parse(tmpMessage.Substring(0, 1));
            tmpMessage = tmpMessage.Substring(1);
            int i = -1;
            for (int k = 0; k < count; k++)
            {
                string login = null, pass = null, name = null, surname = null, email = null, access = null;

                while (tmpMessage[++i] != '$')
                {
                    login += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    pass += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    name += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    surname += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    email += tmpMessage[i];
                }
                while (tmpMessage[++i] != '~')
                {
                    access += tmpMessage[i];
                }
                if (access == "1")
                {
                    access = "Администратор";
                }
                else access = "Пользователь";
                usersGrid.Items.Add(new User { name = name, surname = surname, login = login, password = pass, email = email, access = access });
            }
        }

        private void ButtonChangeRole_Click(object sender, RoutedEventArgs e)
        {
            if (usersGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя!");
            }
            else
            {
                User user = usersGrid.SelectedItem as User;
                ChangeUserRoleWindow userRoleWindow = new ChangeUserRoleWindow(user);
                userRoleWindow.Show();
            }
            
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void ButtonDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if(usersGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя!");
            } else
            {
                User user = usersGrid.SelectedItem as User;
                Connection.SentData("deleteUser");
                Thread.Sleep(500);
                Connection.SentData(user.login);

            }
           
        }
    }
}
