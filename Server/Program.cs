using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Permissions;

namespace Server
{
    class Program
    {
        const int port = 8888;
        static TcpListener listener;
        
        static void StartServer()
        {
            try
            {

                DatabaseConnection.ConnectToDatabase();
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
                Console.WriteLine("Сервер запущен.\nПорт: " + port + "\tIP-адрес: 127.0.0.1");
                Console.WriteLine("Ожидание подключений...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client);
                    Console.WriteLine("Клиент успешно подключился!");
                    // создаем новый поток для обслуживания нового клиента
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }

        static void Main(string[] args)
        {


            StartServer();
            

            
        }
    }
}
