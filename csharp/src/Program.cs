namespace Minion {

    using System;
    using SocketIOClient;

    class Program {

        static void Main()
        {
            var socket = new Client("http://localhost:8888");
            socket.On("connect", fn => Console.WriteLine("yes master"));
            socket.Connect();
            Console.Read();
        }
    }
}
