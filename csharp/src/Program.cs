using Newtonsoft.Json.Linq;

namespace Minion {

    using System;

    class Program {

        private static Socket socket;

        static void Main()
        {
            socket = new Socket("http://localhost:8888");
            socket.On("connect", x => Console.WriteLine("yes master"));
            socket.On("create", Create);
            socket.Connect();
            Console.Read();
        }

        private static void Create(dynamic msg)
        {
            msg.methods = new JArray { "add" };
            socket.Emit("created", msg);
        }
    }
}
