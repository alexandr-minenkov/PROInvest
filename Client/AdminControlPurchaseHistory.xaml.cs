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
    public class HistoryObject {
        public string login { get; set; }
        public string date { get; set; }
        public string project { get; set; }
        public string count { get; set; }
        public string cost { get; set; }
        public string sum { get; set; }
    }


    /// <summary>
    /// Логика взаимодействия для AdminControlPurchaseHistory.xaml
    /// </summary>
    public partial class AdminControlPurchaseHistory : UserControl
    {
        public AdminControlPurchaseHistory()
        {
            InitializeComponent();
            Connection.SentData("getHistory");
            string tmpMessage = Connection.ReceiveData();
            int i = -1; string countString = null;
            while (tmpMessage[++i] != '$')
            {
                countString += tmpMessage[i];
            }
            int countRows = int.Parse(countString);
            for (int k = 0; k < countRows; k++)
            {
                string login = null, date = null, project = null, count = null, cost = null, sum = null;

                while (tmpMessage[++i] != '$')
                {
                    login += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    date += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    project += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    cost += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    count += tmpMessage[i];
                }
                while (tmpMessage[++i] != '~')
                {
                    sum += tmpMessage[i];
                }
                historyGrid.Items.Add(new HistoryObject { login = login, date = date, project = project, cost = cost, count = count, sum = sum });
            }
        }

        private void clearTableButton_Click(object sender, RoutedEventArgs e)
        {
            historyGrid.Items.Clear();
            Connection.SentData("deleteHistory");
        }
    }
}
