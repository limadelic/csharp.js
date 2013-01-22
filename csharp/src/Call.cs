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
        public string Method { get; set; }
        public Type Type { get; set; }

        private bool Match(MethodInfo method)
        {
            return method.DeclaringType == Type
                && method.Name == Method
                && method.GetParameters().Count() == Args.Count();
        }

        public object Result
        {
            get
            {
                var method = CSharp.Method(Type, Match);
                ParseArgs(method);
                return method.Invoke(Instance, Args);
            }
        }

        private void ParseArgs(MethodInfo method)
        {
            var parser = new ArgsParser();

            var types = method.GetParameters()
                .Select(x => x.ParameterType)
                .ToArray();

            Args = Args.Select((arg, i) =>
                parser.Parse(arg.ToString(), types[i]))
                .ToArray();
        }
    }
}