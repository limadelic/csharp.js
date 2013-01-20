using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using SocketIOClient.Messages;

namespace Minion
{
    public static class Tweaker
    {
        public static string Get(this IMessage message, string property)
        {
            return message.Obj()[property].ToString();
        }

        public static JObject Obj(this IMessage message)
        {
            return JObject.Parse(
                message.Json.Args[0].ToString());
        }

        public static JObject ToJson(this object obj)
        {
            return JObject.FromObject(obj);
        }

        public static string ToJsonString(this object obj)
        {
            try { return obj.ToJson().ToString(); }
            catch { return obj.ToString(); }
        }

        public static string Methods(this Type type)
        {
            return new JArray(
                type
                .GetMethods()
                .Select(x => x.Name)
                .ToList()
            ).ToString();
        }

        public static Call ToCall(this IMessage message, Dictionary<string, object> instances)
        {
            var msg = message.Obj();
            
            return new Call
            {
                Instance = instances[msg["id"].ToString()],
                Method = msg["method"].ToString(),
                Args = new object[] { 2, 2 }
            };
        }
    }
}