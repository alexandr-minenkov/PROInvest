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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public static User user = null;
        public AdminWindow()
        {
            AdminControlUsersList usersList = new AdminControlUsersList();
            
            InitializeComponent();
            var menuUsers = new List<SubItem>();
            menuUsers.Add(new SubItem("Список пользователей", usersList));
            menuUsers.Add(new SubItem("Обратная связь", new AdminControlFeedback()));
            var itemUsers = new ItemMenu("Пользователи", menuUsers, PackIconKind.Home);

            //var itemUsers = new ItemMenu("Управление аккаунтами", new UserControl(), PackIconKind.User);
            AdminControlProjects controlProjects = new AdminControlProjects();

            var menuInvestments = new List<SubItem>();
            menuInvestments.Add(new SubItem("Проекты", controlProjects));
            menuInvestments.Add(new SubItem("Прогноз", new AdminControlForecast()));
            menuInvestments.Add(new SubItem("Статистика", new ChartControl()));
            var itemInvestments = new ItemMenu("Инвестиции", menuInvestments, PackIconKind.ChartLineStacked);

            var menuSettings = new List<SubItem>();
            menuSettings.Add(new SubItem("Аккаунт", new UserControlAccount(true)));
            menuSettings.Add(new SubItem("Финансы", new AdminControlPurchaseHistory()));
            //menuSettings.Add(new SubItem("Безопасность"));

            var itemSettings = new ItemMenu("Настройки", menuSettings, PackIconKind.Settings);

            //Menu.Children.Add(new UserControlMenuItem(itemHome, this));
            Menu.Children.Add(new UserControlMenuItem(itemUsers, this));
            Menu.Children.Add(new UserControlMenuItem(itemInvestments, this));
            Menu.Children.Add(new UserControlMenuItem(itemSettings, this));
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void Button_LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void buttonUsers_Click(object sender, RoutedEventArgs e)
        {
            Connection.SentData("getUsers");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
