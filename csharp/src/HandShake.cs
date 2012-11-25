using System;
using System.Net;
using SocketIOClient;

namespace Minion
{
    public static class HandShake
    {
        public static string With(Uri uri)
        {
            var handShakeUrl = string.Format(
                "{0}://{1}:{2}/socket.io/1", 
                uri.Scheme, uri.Host, uri.Port);

            using (var webClient = new WebClient())
                return SocketIOHandshake.LoadFromString(
                    webClient.DownloadString(handShakeUrl)).SID;

        }
    }
}