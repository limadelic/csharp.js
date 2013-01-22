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

        public static MethodInfo Method(Type type, Func<MethodInfo, bool> match)
        {
            return type.GetMethods().Where(match).First();
        }
    }
}