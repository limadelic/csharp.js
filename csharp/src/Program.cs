using System.Linq;
using System.Reflection;
using Math;
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

        private static readonly Assembly Assembly =
            AppDomain.CurrentDomain.GetAssemblies()
                .First(x => x.FullName.StartsWith("Minion"));

        private static void Create(IMessage message)
        {
            var msg = JObject.Parse(message.Json.Args[0].ToString());
            var type = Assembly.GetTypes()
                .First(x => x.FullName.Equals(msg["full_name"].ToString())); 
            var obj = Activator.CreateInstance(type);
            
            msg = JObject.FromObject(obj);
            msg["methods"] = new JArray { "add" };
            socket.Emit("created", msg.ToString());
        }
    }
}
