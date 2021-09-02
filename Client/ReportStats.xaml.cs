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
using LiveCharts;
using LiveCharts.Defaults; //Contains the already defined types
using LiveCharts.Wpf;
using LiveCharts.SeriesAlgorithms;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для ReportStats.xaml
    /// </summary>
    /// 
    public partial class ReportStats : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public ReportStats()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection();
            Connection.SentData("getStats");
            Thread.Sleep(500);
            string tmpMessage = Connection.ReceiveData();
            int count = int.Parse(tmpMessage.Substring(0, 1));
            //int count = int.Parse(tmpMessage);
            //tmpMessage = Connection.ReceiveData();

            tmpMessage = tmpMessage.Substring(1);
            int i = -1;
            for (int k = 0; k < count; k++)
            {
                string title = null, value = null; int j = 0;
                ProjectStat project = new ProjectStat();
                while (tmpMessage[++i] != '$')
                {
                    title += tmpMessage[i];
                }
            read:
                value = null;
                while (tmpMessage[++i] != '$')
                {
                    if (tmpMessage[i] == '~')
                        break;
                    value += tmpMessage[i];
                }
                project.vals[j] = double.Parse(value);
                j++;
                while (tmpMessage[i] != '~')
                    goto read;
                project.title = title;
                SeriesCollection.Add(new LineSeries
                {
                    Title = project.title,
                    Values = new ChartValues<double> {
                project.vals[0], project.vals[1], project.vals[2], project.vals[3], project.vals[4], project.vals[5],}
                });

            }
            Labels = new[] { "Декабрь", "Январь", "Февраль", "Март", "Апрель", "Май" };
            YFormatter = value => value.ToString("C");
            DataContext = this;
            user.Text = "Пользователь: " + DefaultWindow.user.login;
            date.Text = "Дата: " + DateTime.Now.ToString();
        }

        private void buttonReport_Click(object sender, RoutedEventArgs e)
        {

            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(this.reportContent, "Статистика динамики цен акций");
            }
        }
    }
}
