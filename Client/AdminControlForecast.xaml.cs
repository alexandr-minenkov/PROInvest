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
    /// Логика взаимодействия для AdminControlForecast.xaml
    /// </summary>
    public partial class AdminControlForecast : UserControl
    {
        public int index = 0;
        public ObservableCollection<Project> projects { get; set; }
        public AdminControlForecast()
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
                project.Title += (k + 1).ToString() + ". " + name;
                project.ShareCost = int.Parse(cost) / int.Parse(shares); 

                projects.Add(project);

            }
            projectsList.ItemsSource = projects;
        }

        private void calculateForecast_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                float increase = (float.Parse(textBoxIncrease.Text.ToString().Trim()) / 100);
                float dencrease = (float.Parse(textBoxDecrease.Text.ToString().Trim()) / 100);
                float[] startCost = new float[projectsList.Items.Count];
                int i = 0;
                List<Project> project = new List<Project>();
                while (i < projectsList.Items.Count)
                {
                    project.Add(projectsList.Items[i] as Project);
                    startCost[i] = float.Parse(project[i].ShareCost.ToString());
                    i++;
                }

                float[] finalCostOptm = new float[projectsList.Items.Count];
                float[] finalCostPsmm = new float[projectsList.Items.Count];
                i = 0;
                while (i < startCost.Length - 1)
                {
                    finalCostOptm[i] = startCost[i] + startCost[i] * increase;
                    finalCostPsmm[i] = startCost[i] - startCost[i] * dencrease;
                    i++;
                }
                int maxIndex = 0;
                float max = 0;
                for (int j = 0; j < finalCostOptm.Length; j++)
                {
                    if (finalCostOptm[j] > max)
                    {
                        max = finalCostOptm[j];
                        maxIndex = j;
                    }
                }
                int minIndex = 0;
                float min = 0;
                for (int j = 0; j < finalCostPsmm.Length; j++)
                {
                    if (finalCostOptm[j] > min)
                    {
                        min = finalCostPsmm[j];
                        minIndex = j;
                    }
                }
                index = maxIndex;
                result.Text = "В данный момент наиболее выгодны акции компании: " + project[maxIndex].Title.ToString();
                result.Visibility = Visibility.Visible;
                buttonBuy.Visibility = Visibility.Visible;
            }
            catch (Exception ex) {
                MessageBox.Show("Неверный ввод!");
            }
        }

        private void buttonBuy_Click(object sender, RoutedEventArgs e)
        {
            Project project = projectsList.Items[index] as Project;
            project.Title = project.Title.Substring(3);
            AddSharesWindow addSharesWindow = new AddSharesWindow(project);
            addSharesWindow.Show();
        }
    }
}
