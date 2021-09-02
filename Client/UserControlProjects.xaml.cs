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
using System.Collections.ObjectModel;
using System.Threading;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для UserControlProjects.xaml
    /// </summary>
    public partial class UserControlProjects : UserControl
    {
        public ObservableCollection<Project> projects { get; set; }
        public UserControlProjects()
        {
            InitializeComponent();
            Connection.SentData("getProjects");
            projects = new ObservableCollection<Project>();
            Thread.Sleep(500);
            string tmpMessage = Connection.ReceiveData();
            int count = int.Parse(tmpMessage.Substring(0, 1));
            tmpMessage = tmpMessage.Substring(1);
            int i = -1;
            for (int k = 0; k < count; k++)
            {
                string name = null, cost = null, costString = null, shares = null;

                while (tmpMessage[++i] != '$')
                {
                    name += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    cost += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    costString += tmpMessage[i];
                }
                while (tmpMessage[++i] != '~')
                {
                    shares += tmpMessage[i];
                }
                Project project = new Project();
                project.Title = name;
                project.Capital = costString;
                project.ShareCost = int.Parse(cost) / int.Parse(shares);
                project.Count = shares;
                projects.Add(project);

            }
            projectsList.ItemsSource = projects;
        }

        private void addShare_Click(object sender, RoutedEventArgs e)
        {
            Project project = projectsList.SelectedItem as Project;
            if (projectsList.SelectedItem == null)
                MessageBox.Show("Выберите проект!");
            else
            {
                AddSharesWindow addSharesWindow = new AddSharesWindow(project);
                addSharesWindow.Show();
                
            }
        }
    }
}
