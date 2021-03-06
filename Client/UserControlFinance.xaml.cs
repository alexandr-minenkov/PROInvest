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
    /// <summary>
    /// Логика взаимодействия для UserControlFinance.xaml
    /// </summary>
    public partial class UserControlFinance : UserControl
    {
        public UserControlFinance(bool mode)
        {
            InitializeComponent();
            if (mode)
                this.DataContext = AdminWindow.user;
            else
                this.DataContext = DefaultWindow.user;
        }
    }
}
