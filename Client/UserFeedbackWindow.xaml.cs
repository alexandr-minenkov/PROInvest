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
using System.Threading;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для UserFeedbackWindow.xaml
    /// </summary>
    public partial class UserFeedbackWindow : Window
    {
        public UserFeedbackWindow()
        {
            InitializeComponent();
            from.Text = "От: " + DefaultWindow.user.login;
            date.Text = "Дата: " + DateTime.Today.Date.ToString();
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            Connection.SentData("addFeedback");
            Thread.Sleep(500);
            var textRange = new TextRange(question.Document.ContentStart, question.Document.ContentEnd);
            Connection.SentData(DefaultWindow.user.id.ToString() + "$" + textRange.Text.ToString() + "~");

            this.Close();
        }
    }
}
