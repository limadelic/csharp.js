using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minion;
using Newtonsoft.Json.Linq;

namespace Test
{
    [TestClass]
    public class Json
    {
        [TestMethod]
        public void data_types()
        {
            Assert.AreEqual(4.ToJsonString(), "4");
//            Assert.AreEqual("4", JObject.Parse("4").ToString());
        }
    }
}
