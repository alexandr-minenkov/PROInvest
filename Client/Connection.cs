using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;

namespace Client
{
    class Connection : MainWindow
    {
        static int port = 8888; // порт сервера
        static string address = "127.0.0.1"; // адрес сервера
        static Socket socket;
        static byte[] data;

        public static void StartConnection()
        {
            try
            {
                //ConsoleManager.Show();
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);
                try
                {
                    string message = "start";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    socket.Send(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                ReceiveData();
                Thread.Sleep(1000);
                //ConsoleManager.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Соединение с сервером потеряно! Проверьте подключение к интернету.");
            }
        }

        public static void SentData(string newMessage)
        {
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(newMessage);
                socket.Send(data);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string ReceiveData()
        {
            try
            {
                // получаем ответ
                data = new byte[256]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                Console.WriteLine("ответ сервера: " + builder.ToString());
                return builder.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "-1";
            }
        }

        public static void EndConnection()
        {
            // закрываем сокет
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();

        }
    }
}
