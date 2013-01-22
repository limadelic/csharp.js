using System;

namespace Minion
{
    public class ArgsParser
    {
        public object Parse(object arg, Type type)
        {
            arg = arg.ToString();
            if (type == typeof(string)) return arg;

            try
            {
                return new Call 
                {
                    Type = type,
                    Method = "Parse",
                    Args = new[] { arg }
                }
                .Result;
            }
            catch { return arg; }
        }
    }
}