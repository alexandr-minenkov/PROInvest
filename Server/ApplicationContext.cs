using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Sockets;
using System.Net.Mail;
using System.Net;


namespace Server
{


    class ApplicationContext
    {
        public static string userMessage = null;

        private static async Task SendEmailAsync(string email)
        {
            try
            {
                Random rnd = new Random();
                string password = rnd.Next(100000, 999999).ToString();

                MailAddress from = new MailAddress("work.minenkov.a@gmail.com");
                MailAddress to = new MailAddress(email);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "PROInvest - Восстановление пароля";
                m.Body = "Ваш новый пароль: " + password;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("work.minenkov.a@gmail.com", "00114115");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(m);
                Console.WriteLine("Message sent");


                MySqlConnection db = DatabaseConnection.GetConnection();
                db.Open();
                MySqlCommand command = new MySqlCommand("UPDATE `user` SET `password` = @password WHERE `email` = @email", DatabaseConnection.GetConnection());
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                command.Parameters.Add("email", MySqlDbType.VarChar).Value = email;

                if (command.ExecuteNonQuery() == 1)
                    Console.WriteLine("Update done successfuly");
                else
                    Console.WriteLine("Update failed");
                db.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ProcedureRegMessage(string tmpMessage)
        {
            string login = null, pass = null, name = null, surname = null, email = null;
            int i = -1;
            while (tmpMessage[++i] != '$')
            {
                login += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                pass += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                name += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                surname += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                email += tmpMessage[i];
            }
            User user = new User(login, pass, name, surname, email);
            //Console.WriteLine(tmpMessage);
            //Console.WriteLine(user.Login + user.Password + user.Name + user.Surname + user.Email);
            MySqlCommand command = new MySqlCommand("INSERT INTO `user` (`login`, `password`, `name`, `surname`, `email`, `isAdmin`, `balance`) " +
                "VALUES (@login, @pass, @name, @surname, @email, @access, @balance)", DatabaseConnection.GetConnection());
            command.Parameters.Add("@idUser", MySqlDbType.Int32).Value = 1;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@access", MySqlDbType.Int16).Value = (Int16)0;
            command.Parameters.Add("@balance", MySqlDbType.Int32).Value = 200;

            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();

            if (command.ExecuteNonQuery() == 1)
                Console.WriteLine("Registration done successfuly");
            else
                Console.WriteLine("Registration failed");
            db.Close();
        }

        public static string ProcedureAuthMessage(string tmpMessage)
        {
            string login = null, pass = null;
            int i = -1;
            while (tmpMessage[++i] != '$')
            {
                login += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                pass += tmpMessage[i];
            }
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @login AND `password` = @pass", DatabaseConnection.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                userMessage = table.Rows[0][0].ToString() + "$" + table.Rows[0][1].ToString() + "$" +
                    table.Rows[0][2].ToString() + "$" + table.Rows[0][3].ToString() + "$" + table.Rows[0][4].ToString() +
                    "$" + table.Rows[0][5].ToString() + "$" + table.Rows[0][6].ToString() + "$" + table.Rows[0][7].ToString() + "~";
                Console.WriteLine("Authorization: Yes");
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    if (table.Rows[j]["isAdmin"].ToString() == "1")
                    {
                        db.Close();
                        return "trueAdmin";
                    }

                }
                db.Close();
                return "true";
            }
            else
            {
                Console.WriteLine("Authorization: No");
                db.Close();
                return "false";
            }

        }

        public static string ProcedureGetUsersMessage(NetworkStream stream)
        {
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user`", DatabaseConnection.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            List<User> users = new List<User>();
            string message = null;
            ClientObject.SentData(stream, table.Rows.Count.ToString());
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //message = null;
                message += table.Rows[i][1].ToString() + "$";
                message += table.Rows[i][2].ToString() + "$";
                message += table.Rows[i][3].ToString() + "$";
                message += table.Rows[i][4].ToString() + "$";
                message += table.Rows[i][5].ToString() + "$";
                message += table.Rows[i][6].ToString() + "~";

            }

            Console.WriteLine("users sent");
            db.Close();
            return message;

        }

        public static void ProcedureChangeUserRoleMessage(string message)
        {

            string user = message.Substring(0, message.Length - 1);
            string role = message.Substring(message.Length - 1);
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            MySqlCommand command = new MySqlCommand("UPDATE `user` SET `isAdmin` = @role WHERE `login` = @login", DatabaseConnection.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = user;
            command.Parameters.Add("@role", MySqlDbType.Int32).Value = role;

            if (command.ExecuteNonQuery() == 1)
                Console.WriteLine("Update done successfuly");
            else
                Console.WriteLine("Update failed");
            db.Close();
        }

        public static string ProcedureGetProjectsMessage(NetworkStream stream)
        {
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `project`", DatabaseConnection.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            List<User> projects = new List<User>();
            string message = null;
            ClientObject.SentData(stream, table.Rows.Count.ToString());
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //message = null;
                message += table.Rows[i][1].ToString() + "$";
                message += table.Rows[i][2].ToString() + "$";
                message += table.Rows[i][3].ToString() + "$";
                message += table.Rows[i][4].ToString() + "~";


            }
            Console.WriteLine("projects sent");
            db.Close();
            return message;

        }

        public static string ProcedureGetFeedbacksMessage(NetworkStream stream)
        {
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `feedback`", DatabaseConnection.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.Close();
            db.Open();
            List<string> logins = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataTable tableLogins = new DataTable();
                MySqlDataAdapter newAdapter = new MySqlDataAdapter();
                MySqlCommand command2 = new MySqlCommand("SELECT `login` FROM `user` WHERE `idUser` = @idUser", DatabaseConnection.GetConnection());
                command2.Parameters.Add("@idUser", MySqlDbType.Int32).Value = table.Rows[i][1];
                int a = int.Parse(table.Rows[i][1].ToString());
                newAdapter.SelectCommand = command2;

                newAdapter.Fill(tableLogins);
                logins.Add(tableLogins.Rows[0][0].ToString());
            }
            string message = logins.Count.ToString();
            for (int i = 0; i < logins.Count; i++)
            {
                //message = null;
                message += table.Rows[i][0].ToString() + "$";
                message += logins[i] + "$";
                message += table.Rows[i][2].ToString() + "$";
                message += table.Rows[i][3].ToString() + "$";
                message += table.Rows[i][4].ToString() + "~";


            }
            Console.WriteLine("feedbacks sent");

            db.Close();
            return message;

        }

        public static string ProcedureGetFeedbacksForUserMessage(string tmpMessage)
        {
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `feedback` WHERE idUser = @idUser", DatabaseConnection.GetConnection());
            command.Parameters.Add("@idUser", MySqlDbType.Int32).Value = tmpMessage;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            string message = null;
            if (table.Rows.Count == 0)
            {
                db.Close();
                return "null";
            }
            message += table.Rows.Count.ToString() + "$";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //message = null;
                message += table.Rows[i][0].ToString() + "$";
                message += table.Rows[i][2].ToString() + "$";
                message += table.Rows[i][3].ToString() + "$";
                message += table.Rows[i][4].ToString() + "~";

            }
            Console.WriteLine("feedbacks sent");

            db.Close();
            return message;
        }

        public static void ProcedureAddFeedbackAnswerMessage(string tmpMessage)
        {
            string id = null, answer = null;
            int i = -1;
            while (tmpMessage[++i] != '$')
            {
                id += tmpMessage[i];
            }
            while (tmpMessage[++i] != '~')
            {
                answer += tmpMessage[i];
            }
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            MySqlCommand command = new MySqlCommand("UPDATE `feedback` SET `answer` = @answer WHERE `idFeedback` = @id", DatabaseConnection.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@answer", MySqlDbType.VarChar).Value = answer;

            if (command.ExecuteNonQuery() == 1)
                Console.WriteLine("Update done successfuly");
            else
                Console.WriteLine("Update failed");
            db.Close();
        }

        public static void ProcedureDeleteProjectMessage(string tmpMessage)
        {
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            MySqlCommand command = new MySqlCommand("DELETE FROM `project` WHERE `name` = @name", DatabaseConnection.GetConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = tmpMessage;

            if (command.ExecuteNonQuery() == 1)
                Console.WriteLine("Delete done successfuly");
            else
                Console.WriteLine("Delete failed");
            db.Close();
        }

        public static void ProcedureAddShareMessage(string tmpMessage)
        {
            string login = null, nameProject = null, count = null;
            string cost = null;
            int i = -1;
            while (tmpMessage[++i] != '$')
            {
                login += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                nameProject += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                count += tmpMessage[i];
            }
            while (tmpMessage[++i] != '~')
            {
                cost += tmpMessage[i];
            }
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `share` WHERE `loginUser` = @loginUserShares AND `nameProject` = @name", DatabaseConnection.GetConnection());
            command.Parameters.Add("@loginUserShares", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = nameProject;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                int currentCount = int.Parse(table.Rows[0][3].ToString());
                currentCount += int.Parse(count);
                MySqlCommand commandUpdate = new MySqlCommand("UPDATE `share` SET `count` = @count WHERE `loginUser` = @loginUserShares AND `nameProject` = @name", DatabaseConnection.GetConnection());
                commandUpdate.Parameters.Add("@count", MySqlDbType.Int32).Value = currentCount;
                commandUpdate.Parameters.Add("@loginUserShares", MySqlDbType.VarChar).Value = login;
                commandUpdate.Parameters.Add("@name", MySqlDbType.VarChar).Value = nameProject;

                if (commandUpdate.ExecuteNonQuery() == 1)
                    Console.WriteLine("Update done successfuly");
                else
                    Console.WriteLine("Update failed");
            } 
            else
            {
                
                MySqlCommand commandAdd = new MySqlCommand("INSERT INTO `share` (`loginUser`, `nameProject`, `count`, `costShare`) " +
                "VALUES (@loginUserShares, @nameProject, @count, @cost)", DatabaseConnection.GetConnection());
                commandAdd.Parameters.Add("@loginUserShares", MySqlDbType.VarChar).Value = login;
                commandAdd.Parameters.Add("@nameProject", MySqlDbType.VarChar).Value = nameProject;
                commandAdd.Parameters.Add("@count", MySqlDbType.Int32).Value = int.Parse(count);
                commandAdd.Parameters.Add("@cost", MySqlDbType.Int32).Value = int.Parse(cost);


                if (commandAdd.ExecuteNonQuery() == 1)
                    Console.WriteLine("Adding done successfuly");
                else
                    Console.WriteLine("Adding failed");
                
            }
            db.Close();
        }

        public static string ProcedureGetSharesForUserMessage(NetworkStream stream, string tmpMessage)
        {
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `share` WHERE `loginUser` = @loginUser", DatabaseConnection.GetConnection());
            command.Parameters.Add("@loginUser", MySqlDbType.VarChar).Value = tmpMessage;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            string message = null;
            message += table.Rows.Count.ToString() + '$';
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //message = null;
                message += table.Rows[i][0].ToString() + "$";
                message += table.Rows[i][1].ToString() + "$";
                message += table.Rows[i][2].ToString() + "$";
                message += table.Rows[i][3].ToString() + "$";
                message += table.Rows[i][4].ToString() + "~";

                
            }
            Console.WriteLine("shares sent");
            db.Close();
            return message;
        }

        public static string ProcedurePasswordRecoveryMessage(string tmpMessage)
        {
            string login = null, email = null;
            int i = -1;
            while (tmpMessage[++i] != '$')
            {
                login += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                email += tmpMessage[i];
            }

            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @login AND `email` = @email", DatabaseConnection.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.Close();
            if (table.Rows.Count > 0)
            {
                SendEmailAsync(email).GetAwaiter();
                return "true";
            }
            else
                return "false";
        }

        public static string ProcedureGetStatsMessage(NetworkStream stream)
        {
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `stat`", DatabaseConnection.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            string message = null;

            ClientObject.SentData(stream, table.Rows.Count.ToString());
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //message = null;
                message += table.Rows[i][1].ToString() + "$";
                message += table.Rows[i][2].ToString() + "$";
                message += table.Rows[i][3].ToString() + "$";
                message += table.Rows[i][4].ToString() + "$";
                message += table.Rows[i][5].ToString() + "$";
                message += table.Rows[i][6].ToString() + "$";
                message += table.Rows[i][7].ToString() + "~";

                
            }
            Console.WriteLine("stats sent");
            db.Close();
            return message;
        }

        public static void ProcedureDeleteUserMessage(string tmpMessage)
        {
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @login AND `email` = @email", DatabaseConnection.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = tmpMessage;

            if (command.ExecuteNonQuery() == 1)
                Console.WriteLine("Delete done successfuly");
            else
                Console.WriteLine("Delete failed");
            db.Close();
        }

        public static void ProcedureEditUserMessage(string tmpMessage)
        {
            string id = null, login = null, password = null, name = null, surname = null, email = null;
            
            int i = -1;
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
                password += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                name += tmpMessage[i];
            } while (tmpMessage[++i] != '$')
            {
                surname += tmpMessage[i];
            }
            while (tmpMessage[++i] != '~')
            {
                email += tmpMessage[i];
            }

            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            MySqlCommand command = new MySqlCommand("UPDATE `user` SET `login` = @login, `password` = @password, `name` = @name, `surname` = @surname, `email` = @email WHERE `idUser` = @idUser", DatabaseConnection.GetConnection());
            command.Parameters.Add("@idUser", MySqlDbType.Int32).Value = int.Parse(id);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            if (command.ExecuteNonQuery() == 1)
                Console.WriteLine("Update done successfuly");
            else
                Console.WriteLine("Update failed");
        }

        public static void ProcedureUpdateBalanceMessage(string tmpMessage)
        {
            string id = null, balance = null;

            int i = -1;
            while (tmpMessage[++i] != '$')
            {
                id += tmpMessage[i];
            }
            while (tmpMessage[++i] != '~')
            {
                balance += tmpMessage[i];
            }

            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            MySqlCommand command = new MySqlCommand("UPDATE `user` SET `balance` = @balance WHERE `idUser` = @idUser", DatabaseConnection.GetConnection());
            command.Parameters.Add("@idUser", MySqlDbType.Int32).Value = int.Parse(id);
            command.Parameters.Add("@balance", MySqlDbType.VarChar).Value = balance;

            if (command.ExecuteNonQuery() == 1)
                Console.WriteLine("Update done successfuly");
            else
                Console.WriteLine("Update failed");
            db.Close();
        }

        public static void ProcedureAddShareHistoryMessage(string tmpMessage)
        {
            string login = null, date = null, project = null, count = null, cost = null, sum = null;
            
            int i = -1;
            while (tmpMessage[++i] != '$')
            {
                login += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                date += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                project += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                cost += tmpMessage[i];
            }
            while (tmpMessage[++i] != '$')
            {
                count += tmpMessage[i];
            }
            while (tmpMessage[++i] != '~')
            {
                sum += tmpMessage[i];
            }
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            
            MySqlCommand commandAdd = new MySqlCommand("INSERT INTO `history` (`loginUser`, `date`, `project`, `cost`, `count`, `sum`) " +
                "VALUES (@login, @date, @project, @cost, @count, @sum)", DatabaseConnection.GetConnection());
            commandAdd.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            commandAdd.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;
            commandAdd.Parameters.Add("@project", MySqlDbType.VarChar).Value = project;
            commandAdd.Parameters.Add("@cost", MySqlDbType.Int32).Value = int.Parse(cost);
            commandAdd.Parameters.Add("@count", MySqlDbType.Int32).Value = int.Parse(count);
            commandAdd.Parameters.Add("@sum", MySqlDbType.Int32).Value = int.Parse(sum);

            if (commandAdd.ExecuteNonQuery() == 1)
                    Console.WriteLine("Adding done successfuly");
                else
                    Console.WriteLine("Adding failed");

            db.Close();
        }

        public static string ProcedureGetHistoryMessage()
        {
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `history`", DatabaseConnection.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            string message = null;
            message += table.Rows.Count.ToString() + "$";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                message += table.Rows[i][1].ToString() + "$";
                message += table.Rows[i][2].ToString() + "$";
                message += table.Rows[i][3].ToString() + "$";
                message += table.Rows[i][4].ToString() + "$";
                message += table.Rows[i][5].ToString() + "$";
                message += table.Rows[i][6].ToString() + "~";

            }
            Console.WriteLine("send history...");
            db.Close();
            return message;
        }

        public static void ProcedureDeleteHistoryMessage()
        {
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            MySqlCommand command = new MySqlCommand("DELETE FROM `history`", DatabaseConnection.GetConnection());

            if (command.ExecuteNonQuery() == 1)
                Console.WriteLine("Delete done successfuly");
            else
                Console.WriteLine("Delete failed");
            db.Close();
        }

        public static void ProcedureAddFeedbackMessage(string tmpMessage)
        {
            string id = null, question = null;
            int i = -1;
            while (tmpMessage[++i] != '$')
            {
                id += tmpMessage[i];
            }
            while (tmpMessage[++i] != '~')
            {
                question += tmpMessage[i];
            }
            MySqlConnection db = DatabaseConnection.GetConnection();
            db.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO `feedback` (`idUser`, `question`, `date`, `answer`) " +
                "VALUES (@id, @question, @date, @answer)", DatabaseConnection.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = int.Parse(id);
            command.Parameters.Add("@question", MySqlDbType.VarChar).Value = question;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = DateTime.Now.ToString();
            command.Parameters.Add("@answer", MySqlDbType.VarChar).Value = "Нет ответа";

            if (command.ExecuteNonQuery() == 1)
                Console.WriteLine("Adding done successfuly");
            else
                Console.WriteLine("Adding failed");
            db.Close();
        }

    }
}
