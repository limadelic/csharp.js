using System;
using System.Linq;
using System.Reflection;

namespace Minion
{
    public class Call
    {
        public Call()
        {
            Args = new object[0];
        }

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

        public object[] Args { get; set; }
        public string Method { get; set; }
        public Type Type { get; set; }

        public object Result
        {
            get
            {
                var method = CSharp.Method(Type, Match);

                return method.Invoke(Instance, ParseArgs(method));
            }
        }

        private bool Match(MethodInfo method)
        {
            return method.DeclaringType == Type
                && method.Name == Method
                && method.GetParameters().Count() == Args.Count();
        }

        private object[] ParseArgs(MethodInfo method)
        {
            var parser = new ArgsParser();

            var types = method.GetParameters()
                .Select(x => x.ParameterType);

            return Args
                .Zip(types, parser.Parse)
                .ToArray();
        }
    }
}