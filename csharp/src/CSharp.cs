using System;
using System.Linq;
using System.Reflection;

namespace Minion
{
    public static class CSharp
    {
        private static readonly Assembly Assembly =
            AppDomain.CurrentDomain.GetAssemblies()
                .First(x => x.FullName.StartsWith("Minion"));

        public static object New(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public static Type Type(string name)
        {
            return Assembly.GetTypes()
                .First(x => x.FullName.Equals(name));
        }

        private static MethodInfo Method(object o, string method)
        {
            return o.GetType().GetMethod(method);
        }

        public static object Call(Call call)
        {
            return Method(call.Instance, call.Method)
                .Invoke(call.Instance, call.Args);
        }
    }
}