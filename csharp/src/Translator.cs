using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using SocketIOClient.Messages;

namespace Minion
{
    public static class Translator
    {
        public static string Get(this IMessage message, string property)
        {
            var msg = JObject.Parse(message.Json.Args[0].ToString());
            return msg[property].ToString();
        }

        public static JObject ToJson(this object obj)
        {
            return JObject.FromObject(obj);
        }

        public static JObject WithMethodsFrom(this JObject obj, Type type)
        {
            obj["methods"] = new JArray(type
                .GetMethods()
                .Select(x => x.Name)
                .ToList());

            return obj;
        }
    }
}