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
    /// Логика взаимодействия для UserControlFeedback.xaml
    /// </summary>
    public partial class UserControlFeedback : UserControl
    {
        public ObservableCollection<Feedback> questions { get; set; }
        public UserControlFeedback()
        {
            InitializeComponent();
            UpdateFeedbacks();
        }


        public void UpdateFeedbacks()
        {

            questionsList.ItemsSource = null;

            questions = new ObservableCollection<Feedback>();
            Connection.SentData("getFeedbacksForUser");
            Thread.Sleep(500);
            Connection.SentData(DefaultWindow.user.id.ToString());
            string tmpMessage = Connection.ReceiveData();
            if (tmpMessage == "null")
            {
                nullMessage.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                nullMessage.Visibility = Visibility.Hidden;
            }
            int count = int.Parse(tmpMessage.Substring(0, 1));
            tmpMessage = tmpMessage.Substring(2);
            int i = -1;
            for (int k = 0; k < count; k++)
            {
                string id = null, question = null, date = null, answer = null;

                while (tmpMessage[++i] != '$')
                {
                    id += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    question += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    date += tmpMessage[i];
                }
                while (tmpMessage[++i] != '~')
                {
                    answer += tmpMessage[i];
                }
                Feedback feedback = new Feedback { Name = DefaultWindow.user.login, Question = question, Date = date, Answer = answer, Id = id };
                questions.Add(feedback);


            }
            questionsList.ItemsSource = questions;

        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateFeedbacks();
            questionsList.Items.Refresh();
        }

        private void questionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            UserFeedbackWindow userFeedbackWindow = new UserFeedbackWindow();
            userFeedbackWindow.Show();
        }
    }
}
