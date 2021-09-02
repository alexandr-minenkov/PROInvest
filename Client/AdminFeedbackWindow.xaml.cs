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
    /// Логика взаимодействия для AdminFeedbackWindow.xaml
    /// </summary>
    public partial class AdminFeedbackWindow : Window
    {
        string id;
        public AdminFeedbackWindow(Feedback feedback)
        {
            InitializeComponent();
            from.Text = "От: " + feedback.Name;
            question.Text = feedback.Question;
            date.Text = "Дата: " + feedback.Date;
            id = feedback.Id;
           
        }

        private void buttonAnswer_Click(object sender, RoutedEventArgs e)
        {
            Connection.SentData("addFeedbackAnswer");
            Thread.Sleep(500);
            var textRange = new TextRange(answer.Document.ContentStart, answer.Document.ContentEnd);
            Connection.SentData(id + "$" + textRange.Text.ToString() + "~");
            
            this.Close();
        }
    }
}
