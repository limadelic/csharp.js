using System;

namespace Minion
{
    public class ArgsParser
    {
        public object Parse(string arg, Type type)
        {
            try
            {
                return CSharp.Call(new Call
                {
                    Type = type,
                    Method = "Parse",
                    Args = new object[] { arg }
                });
            }
            catch { return arg; }
        }
    }
}