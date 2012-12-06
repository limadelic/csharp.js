using Newtonsoft.Json.Linq;
using SocketIOClient;
using SocketIOClient.Messages;

namespace Minion
{
    public class Minion
    {
        private Client socket;

        public void Connect(int port)
        {
            socket = new Client("http://localhost:" + port);
            socket.On("create", Create);
            socket.Connect();
        }

        private void Create(IMessage message)
        {
            var msg = JObject.Parse(message.Json.Args[0].ToString());
            var fullName = msg["full_name"].ToString();

            msg = JObject.FromObject(CSharp.New(fullName));
            msg["methods"] = new JArray { "add" };
            socket.Emit("created", msg.ToString());
        }
    }
}