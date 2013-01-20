using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minion;

namespace Test
{
    [TestClass]
    public class ArgsParserTests
    {
        readonly ArgsParser args = new ArgsParser();

        [TestMethod]
        public void should_default_to_strings()
        {
            Assert.AreEqual("hello there", args.Parse("hello there", typeof(object)));
        }

        [TestMethod]
        public void should_parse_int()
        {
            Assert.AreEqual(42, args.Parse("42", typeof(int)));
        }

        [TestMethod]
        public void should_parse_doubles()
        {
            Assert.AreEqual(42d, args.Parse("42", typeof(double)));
        }
    }
}