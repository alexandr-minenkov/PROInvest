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
    /// Логика взаимодействия для ChangeUserRoleWindow.xaml
    /// </summary>
    public partial class ChangeUserRoleWindow : Window
    {
        public ChangeUserRoleWindow(User user)
        {
            InitializeComponent();
            userName.Text = user.login.ToString();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            Connection.SentData("changeUserRole");
            if (Role.SelectedItem.ToString() == "System.Windows.Controls.ComboBoxItem: Администратор")
            {
                Connection.SentData(userName.Text.ToString() + "1");
                //Parent.SetValue(Parent, new User());
               
                
            } else 
            {
                Connection.SentData(userName.Text.ToString() + "0");
            }
            this.Hide();
        }
    }
}
