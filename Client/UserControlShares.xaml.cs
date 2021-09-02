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
    public class Share
    {
        public int idShare { get; set; }
        public string loginUser { get; set; }
        public string nameProject { get; set; }
        public string countShare { get; set; }
        public string сostShares { get; set; }

        public int  valueShare { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для UserControlShares.xaml
    /// </summary>
    public partial class UserControlShares : UserControl
    {
        public UserControlShares()
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
            //tmpMessage = null;
            //tmpMessage = Connection.ReceiveData();
            List<Share> shares = new List<Share>();
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
                
                sharesGrid.Items.Add(new Share { idShare = int.Parse(idShare), loginUser = loginUser, nameProject = nameProject, countShare = countShares,
                    сostShares = costShare, valueShare = int.Parse(countShares) * int.Parse(costShare) });
                
                sum += int.Parse(countShares) * int.Parse(costShare);
            }
            sharesGrid.Items.Add(new Share { valueShare = sum, nameProject = "Общая стоимость:" });
            //sharesGrid.ItemsSource = shares;
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateSharesTable();
        }

        private void buttonSell_Click(object sender, RoutedEventArgs e)
        {
            if (sharesGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите поле в таблице!");
            } else
            {
                MessageBox.Show("В данный момент операция на торгах недоступна! Свяжитесь со своим менеджером для согласования.");
            }
        }
    }
}
