using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Threading;

namespace Minion
{
    class Socket
    {
        private readonly ClientWebSocket socket = new ClientWebSocket();
        private readonly Uri uri;
        private readonly ConcurrentDictionary<string, Action<dynamic>> handlers =
            new ConcurrentDictionary<string, Action<dynamic>>();

        public Socket(string uri)
        {
            this.uri = new Uri(uri);
        }

        private Uri Uri
        {
            get 
            { 
                return new Uri(string.Format(
                    "ws://{0}:{1}/socket.io/1/websocket/{2}", 
                    uri.Host, uri.Port, HandShake.With(uri)));
            }
        }

        public void Connect()
        {
            socket.ConnectAsync(Uri, CancellationToken.None).Wait();
        }

        public void On(string eventName, Action<dynamic> action)
        {
            handlers[eventName] = action;
        }

        public void Emit(string eventName, dynamic payload)
        {
        }
    }
}
