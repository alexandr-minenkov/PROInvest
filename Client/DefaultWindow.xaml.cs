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
using BeautySolutions.View.ViewModel;
using MaterialDesignThemes.Wpf;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Threading;


namespace Client
{
    /// <summary>
    /// Логика взаимодействия для DefaultWindow.xaml
    /// </summary>
    public partial class DefaultWindow : Window
    {
        public static User user = null;
        public DefaultWindow()
        {
            InitializeComponent();

            
            //var menuUsers = new List<SubItem>();
            //menuUsers.Add(new SubItem("Список пользователей", usersList));
            //menuUsers.Add(new SubItem("Обратная связь", new AdminControlFeedback()));
            //var itemUsers = new ItemMenu("Пользователи", menuUsers, PackIconKind.Home);

            //var itemUsers = new ItemMenu("Управление аккаунтами", new UserControl(), PackIconKind.User);
            UserControlProjects controlProjects = new UserControlProjects();

            var menuInvestments = new List<SubItem>();
            menuInvestments.Add(new SubItem("Акции", new UserControlShares()));
            menuInvestments.Add(new SubItem("Проекты", controlProjects));
            menuInvestments.Add(new SubItem("Прогноз", new AdminControlForecast()));
            menuInvestments.Add(new SubItem("Cтатистика", new ChartControl()));
            menuInvestments.Add(new SubItem("Диаграмма", new PieChartControl()));
            var itemInvestments = new ItemMenu("Инвестиции", menuInvestments, PackIconKind.ChartLineStacked);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("Отчёт статистики", new ReportStats()));
            menuReports.Add(new SubItem("Отчёт активов", new ReportShares()));
            var itemReports = new ItemMenu("Отчёты", menuReports, PackIconKind.Report);

            var menuSettings = new List<SubItem>();
            menuSettings.Add(new SubItem("Аккаунт", new UserControlAccount(false)));
            menuSettings.Add(new SubItem("Финансы", new UserControlFinance(false)));
            menuSettings.Add(new SubItem("Служба поддержки", new UserControlFeedback()));

            var itemSettings = new ItemMenu("Настройки", menuSettings, PackIconKind.Settings);


            //Menu.Children.Add(new UserControlMenuItem(itemHome, this));
            //Menu.Children.Add(new UserControlMenuItem(itemUsers, this));
            Menu.Children.Add(new UserControlDefaultMenuItem(itemInvestments, this));
            Menu.Children.Add(new UserControlDefaultMenuItem(itemReports, this));
            Menu.Children.Add(new UserControlDefaultMenuItem(itemSettings, this));

            balance.Text = user.balance.ToString() + "$";
        }

        internal void SwitchScreen(object sender)
        {

            var screen = ((UserControl)sender);
            if (screen != null)
            {
                
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
                balance.Text = user.balance.ToString() + "$";
                Connection.SentData("updateBalance");
                Thread.Sleep(500);
                Connection.SentData(user.id + '$' + user.balance + '~');

            }
        }


        private void Button_LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Connection.EndConnection();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }


    }
}
