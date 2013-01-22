using System;

namespace Minion
{
    public class ArgsParser
    {
        public object Parse(string arg, Type type)
        {
            if (type == typeof(string)) return arg;

            try
            {
                return new Call 
                {
                    Type = type,
                    Method = "Parse",
                    Args = new object[] { arg }
                }
                .Result;
            }
            catch { return arg; }
        }
    }
}