using Newtonsoft.Json.Linq;
using SocketIOClient;
using SocketIOClient.Messages;

namespace Minion {

    using System;

    class Program {

        private static Client socket;

        static void Main()
        {
            socket = new Client("http://localhost:8888");
            socket.On("create", Create);
            socket.Connect();
            Console.Read();
        }

        private static void Create(IMessage message)
        {
            var msg = JObject.Parse(message.MessageText);
            msg["methods"] = new JArray { "add" };
            socket.Emit("created", msg.ToString());
        }
    }
}
