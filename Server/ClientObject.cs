using System;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Data;
using System.Threading;

namespace Server
{
    public class ClientObject
    {
        public TcpClient client;
        public ClientObject(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        public string ReceiveMessage(NetworkStream stream, byte[] data)
        {
            StringBuilder builder = new StringBuilder();
            int tmpBytes = 0;
            do
            {
                tmpBytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, tmpBytes));
            }
            while (stream.DataAvailable);

            string tmpMessage = builder.ToString();
            return tmpMessage;
        }

        public static void SentData(NetworkStream stream, string newMessage)
        {
            try
            {
                byte[] data = new byte[64]; // буфер для отправляемых данных
                data = Encoding.Unicode.GetBytes(newMessage);
                stream.Write(data, 0, data.Length);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64]; // буфер для получаемых данных
                while (true)
                {
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();

                    Console.WriteLine(message);

                    switch(message)
                    {
                        case "start":
                            {
                                //отправляем обратно сообщение
                                data = Encoding.Unicode.GetBytes("Сообщение получено! Запуск проекта...");
                                stream.Write(data, 0, data.Length);
                            }
                            break;
                        case "reg":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                ApplicationContext.ProcedureRegMessage(tmpMessage);
                            }
                            break;
                        case "auth":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                string result = ApplicationContext.ProcedureAuthMessage(tmpMessage);
                                SentData(stream, result);
                                Thread.Sleep(1000);
                                if(result != "false")
                                    SentData(stream, ApplicationContext.userMessage);
                            }
                            break;
                        case "getUsers":
                            {
                                string users = ApplicationContext.ProcedureGetUsersMessage(stream);
                                SentData(stream, users);
                            }
                            break;
                        case "changeUserRole":
                            {
                                string newMessage = ReceiveMessage(stream, data);
                                ApplicationContext.ProcedureChangeUserRoleMessage(newMessage);
                                stream.Flush();
                            }
                            break;
                        case "getProjects":
                            {
                                string projects = ApplicationContext.ProcedureGetProjectsMessage(stream);
                                SentData(stream, projects);
                            }
                            break;
                        case "getFeedbacks":
                            {
                                string feedbacks = ApplicationContext.ProcedureGetFeedbacksMessage(stream);
                                SentData(stream, feedbacks);
                            }
                            break;
                        case "getFeedbacksForUser":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                string result = ApplicationContext.ProcedureGetFeedbacksForUserMessage(tmpMessage);
                                SentData(stream, result);
                            }
                            break;
                        case "addFeedbackAnswer":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                ApplicationContext.ProcedureAddFeedbackAnswerMessage(tmpMessage);
                            }
                            break;
                        case "deleteProject":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                ApplicationContext.ProcedureDeleteProjectMessage(tmpMessage);
                            }
                            break;
                        case "addShare":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                ApplicationContext.ProcedureAddShareMessage(tmpMessage);
                            }
                            break;
                        case "getSharesForUser":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                string result = ApplicationContext.ProcedureGetSharesForUserMessage(stream, tmpMessage);
                                SentData(stream, result);
                            }
                            break;
                        case "passwordRecovery":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                string result = ApplicationContext.ProcedurePasswordRecoveryMessage(tmpMessage);
                                Thread.Sleep(1000);
                                SentData(stream, result);
                                
                            }
                            break;
                        case "getStats":
                            {
                                string result = ApplicationContext.ProcedureGetStatsMessage(stream);
                                SentData(stream, result);
                            }
                            break;
                        case "deleteUser":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                ApplicationContext.ProcedureDeleteUserMessage(tmpMessage);
                            }
                            break;
                        case "editUser":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                Console.WriteLine(tmpMessage);
                                ApplicationContext.ProcedureEditUserMessage(tmpMessage);
                            }
                            break;
                        case "updateBalance":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                Console.WriteLine(tmpMessage);
                                ApplicationContext.ProcedureUpdateBalanceMessage(tmpMessage);
                            }
                            break;
                        case "addShareHistory":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                Console.WriteLine(tmpMessage);
                                ApplicationContext.ProcedureAddShareHistoryMessage(tmpMessage);
                            }
                            break;
                        case "getHistory":
                            {
                                string result = ApplicationContext.ProcedureGetHistoryMessage();
                                SentData(stream, result);
                            }
                            break;
                        case "deleteHistory":
                            {
                                ApplicationContext.ProcedureDeleteHistoryMessage();
                            }
                            break;
                        case "addFeedback":
                            {
                                string tmpMessage = ReceiveMessage(stream, data);
                                ApplicationContext.ProcedureAddFeedbackMessage(tmpMessage);
                            }
                            break;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (DatabaseConnection.GetConnection().State == ConnectionState.Open)
                {
                    DatabaseConnection.CloseConnection();
                }
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
    }
}