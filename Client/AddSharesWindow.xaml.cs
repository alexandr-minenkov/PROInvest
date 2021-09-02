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
    /// Логика взаимодействия для addSharesWindow.xaml
    /// </summary>
    public partial class AddSharesWindow : Window
    {
        private Project currentProject = new Project();
        public AddSharesWindow(Project project)
        {
            InitializeComponent();
            project.Login = DefaultWindow.user.login;
            this.DataContext = project;
            currentProject = project;

        }

        private void addShare_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                int count = int.Parse(textBoxCount.Text.ToString());
                if ((DefaultWindow.user.balance - currentProject.ShareCost * count) > 0)
                {
                    Connection.SentData("addShare");
                    Thread.Sleep(500);
                    Connection.SentData(currentProject.Login + "$" + currentProject.Title + "$" + count.ToString() +
                        "$" + currentProject.ShareCost + "~");
                    Thread.Sleep(1000);
                    Connection.SentData("addShareHistory");
                    Connection.SentData(DefaultWindow.user.login + "$" + DateTime.Now.ToString() + "$" + currentProject.Title + "$" + currentProject.ShareCost +
                        "$" + count.ToString() + "$" + currentProject.ShareCost*count + "~");
                    result.Visibility = Visibility.Visible;
                    this.Show();
                    result.Visibility = Visibility.Hidden;
                    DefaultWindow.user.balance -= currentProject.ShareCost * count;
                    
                } else
                {
                    MessageBox.Show("У Вас недостаточно средств!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный ввод!");
            }
        }
    }
}
