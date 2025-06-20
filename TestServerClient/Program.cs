// Server.cs
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        // Устанавливаем IP-адрес и порт для сервера
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 12345;

        // Создаем конечную точку (endpoint)
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

        // Создаем сокет для TCP/IP
        Socket listener = new Socket(ipAddress.AddressFamily,
                                    SocketType.Stream,
                                    ProtocolType.Tcp);

        try
        {
            // Связываем сокет с endpoint
            listener.Bind(localEndPoint);

            // Начинаем слушать входящие соединения (максимум 10 в очереди)
            listener.Listen(10);

            Console.WriteLine("Сервер запущен. Ожидание подключений...");

            // Принимаем входящее соединение
            Socket handler = listener.Accept();

            // Данные от клиента
            string data = null;
            byte[] bytes = new byte[1024];

            // Получаем данные от клиента
            int bytesRec = handler.Receive(bytes);
            data = Encoding.UTF8.GetString(bytes, 0, bytesRec);

            Console.WriteLine($"Получено от клиента: {data}");

            // Отправляем ответ клиенту
            string response = $"Сервер получил ваше сообщение: {data}";
            byte[] msg = Encoding.UTF8.GetBytes(response);
            handler.Send(msg);

            // Закрываем соединение
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            Console.WriteLine("Сервер завершает работу.");
            Console.ReadLine();
        }
    }
}