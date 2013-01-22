using System;
using System.Linq;
using System.Reflection;

namespace Minion
{
    public class Call
    {
        private object instance;
        public object Instance
        {
            get { return instance; }
            set
            {
                instance = value;
                Type = value.GetType();
            }
        }

        public Call()
        {
            Args = new object[0];
        }

        public object[] Args { get; set; }
        public MethodInfo MethodInfo { get; private set; }
        public string Method { get; set; }
        public Type Type { get; set; }

        public bool Matches(MethodInfo method)
        {
            return method.DeclaringType == Type
                   && method.Name == Method
                   && method.GetParameters().Count() == Args.Count();
        }

        public object Execute()
        {
            MethodInfo = CSharp.Method(this);
            ArgsParser.Parse(this);
            return MethodInfo.Invoke(Instance, Args);
        }
    }
}