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

namespace Client
{

    public class Feedback
    {
        public string Name { get; set; }
        public string Question { get; set; }
        public string Date { get; set; }
        public string Answer { get; set; }
        public string Id { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для AdminControlFeedback.xaml
    /// </summary>
    public partial class AdminControlFeedback : UserControl
    {
        public ObservableCollection<Feedback> questions { get; set; }
        public AdminControlFeedback()
        {
            InitializeComponent();
            UpdateFeedbacks();
         
        }

        public void UpdateFeedbacks()
        {
            
            questionsList.ItemsSource = null;
            
            questions = new ObservableCollection<Feedback>();
            Connection.SentData("getFeedbacks");
            string tmpMessage = Connection.ReceiveData();
            int count = int.Parse(tmpMessage.Substring(0, 1));
            tmpMessage = tmpMessage.Substring(1);
            int i = -1;
            for (int k = 0; k < count; k++)
            {
                string id = null, login = null, question = null, date = null, answer = null;

                while (tmpMessage[++i] != '$')
                {
                    id += tmpMessage[i];
                }
                while (tmpMessage[++i] != '$')
                {
                    login += tmpMessage[i];
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
                Feedback feedback = new Feedback { Name = login, Question = question, Date = date, Answer = answer, Id = id };
                questions.Add(feedback);
                

            }
            questionsList.ItemsSource = questions;

        }

        private void questionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Feedback p = (Feedback)questionsList.SelectedItem;
            if (p != null)
            {


                AdminFeedbackWindow adminFeedbackWindow = new AdminFeedbackWindow(p);
                adminFeedbackWindow.Show();
            }
              
        }

        private void TextBlock_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            //questionsList.Items  
            UpdateFeedbacks();
            questionsList.Items.Refresh();
        }
    }


}
