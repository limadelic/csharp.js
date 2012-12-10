using SocketIOClient;
using SocketIOClient.Messages;

namespace Minion
{
    public class Minion
    {
        private Client Socket;

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

            Socket.Emit("created", "{" +
                "\"object\": " + CSharp.New(type).ToJson() + "," +
                "\"methods\": " + type.Methods() +
            "}");
        }

        private void Run(IMessage message)
        {
            Socket.Emit("result", message.Obj().ToString());
        }
    }
}