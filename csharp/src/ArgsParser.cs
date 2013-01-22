using System;
using System.Linq;

namespace Minion
{
    public class ArgsParser
    {
        public static void Parse(Call call)
        {
            var parser = new ArgsParser();

            for (int i = 0; i < call.Args.Count(); i++)
            {
                var parameterType = call.MethodInfo.GetParameters()[i].ParameterType;
                call.Args[i] = parser.Parse(call.Args[i].ToString(), parameterType);
            }
        }

        public object Parse(string arg, Type type)
        {
            try
            {
                return new Call
                {
                    Type = type,
                    Method = "Parse",
                    Args = new object[] { arg }
                }.Execute();
            }
            catch { return arg; }
        }
    }
}