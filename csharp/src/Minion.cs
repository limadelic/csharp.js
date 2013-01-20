using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using SocketIOClient;
using SocketIOClient.Messages;

namespace Minion
{
    public class Minion
    {
        private Client Socket;
        private readonly Dictionary<string, object> Cache = new Dictionary<string, object>();

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

            Socket.Emit("created", string.Format( 
            @"{{
                ""id"": ""{0}"",
                ""methods"": {1}
            }}"
            , Create(type), type.Methods()));
        }

        private string Create(Type type)
        {
            var id = Guid.NewGuid().ToString();
            Cache[id] = CSharp.New(type);
            return id;
        }

        private void Run(IMessage message)
        {
            Socket.Emit("result", CSharp.Call(message.ToCall(Cache)));
        }
    }
}