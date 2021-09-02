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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для UserControlSettings.xaml
    /// </summary>
    public partial class UserControlAccount : UserControl
    {
        public UserControlAccount(bool mode)
        {
            InitializeComponent();
            if (mode)
            {
                this.DataContext = AdminWindow.user;
                this.editButton.Visibility = Visibility.Hidden;
            }
            else
                this.DataContext = DefaultWindow.user;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow editUserWindow = new EditUserWindow();
            editUserWindow.Show();


        }

        public void UpdateUserAccount(bool mode, User user)
        {
            if (mode)
            {
                AdminWindow.user = user;
                DataContext = AdminWindow.user;
            }
            else
            {
                DefaultWindow.user = user;
                DataContext = DefaultWindow.user;
            }
        }
    }
}
