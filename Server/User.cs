using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [Serializable]
    class User
    {
        private int id { get; set; }
        private string login, password, name, surname, email;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        User() { }
        public User(string login, string password, string name, string surname, string email)
        {
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.email = email;
        }
    }

    public class Project
    {
        public string Login { get; set; }
        public string Title { get; set; }
        public string Capital { get; set; }
        public string Count { get; set; }
        public int ShareCost { get; set; }
    }

    public class Feedback
    {
        public string Name { get; set; }
        public string Question { get; set; }
        public string Date { get; set; }
        public string Answer { get; set; }
        public string Id { get; set; }
    }

    public class HistoryObject
    {
        public string login { get; set; }
        public string date { get; set; }
        public string project { get; set; }
        public string count { get; set; }
        public string cost { get; set; }
        public string sum { get; set; }
    }

    public class Share
    {
        public int idShare { get; set; }
        public string loginUser { get; set; }
        public string nameProject { get; set; }
        public string countShare { get; set; }
        public string сostShares { get; set; }

        public int valueShare { get; set; }
    }

    public class ProjectStat
    {
        public int id { get; set; }
        public string title { get; set; }
        public double[] vals = new double[6];

    }
}
