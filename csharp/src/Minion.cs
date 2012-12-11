using System;
using System.Collections.Generic;
using SocketIOClient;
using SocketIOClient.Messages;

namespace Minion
{
    public class Minion
    {
        private Client Socket;
//        private Dictionary<string, object> Cache;

        public void Connect(int port)
        {
            Socket = new Client("http://localhost:" + port);
            Socket.On("create", Create);
            Socket.On("run", Run);
            Socket.Connect();
        }

        private void Create(IMessage message)
        {
            var type = CSharp.Type(message.Get("type"));
            var id = Guid.NewGuid().ToString();
//            Cache[id] = CSharp.New(type);

            Socket.Emit("created", 
            "{" +
                "\"id\": \"" + id + "\"," +
                "\"methods\": " + type.Methods() +
            "}");
        }

        private void Run(IMessage message)
        {
            var msg = message.Obj();
/*
            var obj = Cache[msg["id"].ToString()];
            var method = msg["method"].ToString();
            var result = CSharp.Call(obj, method)
*/

            Socket.Emit("result", msg.ToString());
        }
    }
}