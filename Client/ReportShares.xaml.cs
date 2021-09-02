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
    /// <summary>
    /// Логика взаимодействия для ReportShares.xaml
    /// </summary>
    public partial class ReportShares : UserControl
    {
        public ReportShares()
        {
            InitializeComponent();
            UpdateSharesTable();
        }
        public void UpdateSharesTable()
        {
            sharesGrid.Items.Clear();
            Connection.SentData("getSharesForUser");
            Thread.Sleep(500);
            Connection.SentData(DefaultWindow.user.login);
            Thread.Sleep(500);
            string tmpMessage = Connection.ReceiveData();
            int i = -1;
            string countString = null;
            while (tmpMessage[++i] != '$')
            {
                countString += tmpMessage[i];
            }
            int count = int.Parse(countString);
            int sum = 0;
            for (int k = 0; k < count; k++)
            {
                string idShare = null, loginUser = null, nameProject = null, countShares = null, costShare = null;

                while (tmpMessage[++i] != '$')
                {
                    idShare += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    loginUser += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    nameProject += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    countShares += tmpMessage[i];
                }
                while (tmpMessage[++i] != '~')
                {
                    costShare += tmpMessage[i];
                }

                sharesGrid.Items.Add(new Share
                {
                    idShare = int.Parse(idShare),
                    loginUser = loginUser,
                    nameProject = nameProject,
                    countShare = countShares,
                    сostShares = costShare,
                    valueShare = int.Parse(countShares) * int.Parse(costShare)
                });

                sum += int.Parse(countShares) * int.Parse(costShare);
            }
            sharesGrid.Items.Add(new Share { valueShare = sum, nameProject = "Общая стоимость:" });
            user.Text = "Пользователь: " + DefaultWindow.user.login;
            date.Text = "Дата: " + DateTime.Now.ToString();
        }

        private void buttonPrint_Click(object sender, RoutedEventArgs e)
        {
            UpdateSharesTable();
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(this.reportContent, "Статистика динамики цен акций");
            }
        }
    }
}
