namespace Minion {

    using System;
    using SocketIOClient;
    using SocketIOClient.Messages;

    class Program {

        private static Client socket;

        static void Main()
        {
            socket = new Client("http://localhost:8888");
            socket.On("connect", fn => Console.WriteLine("yes master"));
            socket.On("create", Create);
            socket.Connect();
            Console.Read();
        }

        private static void Create(IMessage msg)
        {
            socket.Emit("created", msg);
        }
    }
}
