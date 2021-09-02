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
    public class Project
    {
        public string Login { get; set; }
        public string Title { get; set; } 
        public string Capital { get; set; }  
        public string Count { get; set; } 
        public int ShareCost { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для AdminControlProjects.xaml
    /// </summary>
    public partial class AdminControlProjects : UserControl
    {
        public ObservableCollection<Project> projects { get; set; }
        public AdminControlProjects()
        {
            InitializeComponent();
            UpdateProjects();


        }

        public void UpdateProjects()
        {
            projectsList.ItemsSource = null;
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

        private void deleteProject_Click(object sender, RoutedEventArgs e)
        {
            Connection.SentData("deleteProject");
            Thread.Sleep(500);
            Project project = projectsList.SelectedItem as Project;
            if (projectsList.SelectedItem == null)
                MessageBox.Show("Выберите проект!");
            else
                Connection.SentData(project.Title);
            Thread.Sleep(500);
            UpdateProjects();
        }
    }
}
