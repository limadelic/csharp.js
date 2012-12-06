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

        public static object New(string fullName)
        {
            var type = Assembly.GetTypes()
                .First(x => x.FullName.Equals(fullName));

            return Activator.CreateInstance(type);
        }
    }
}