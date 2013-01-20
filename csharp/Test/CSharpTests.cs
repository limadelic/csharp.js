using Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minion;

namespace Test
{
    [TestClass]
    public class CSharpTests
    {
        [TestMethod]
        public void should_call_methods()
        {
            Assert.AreEqual(4, 
                CSharp.Call(new Calculator(), "Add"));
        }
    }
}