using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.Wotlk
{
    [TestClass]
    public class MVERTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            Assert.AreEqual(Tests.WotlkWMO.Version.Version, Tests.WotlkWrittenWMO.Version.Version);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(Tests.WotlkWMO.Version.GetSignature(), Tests.WotlkWrittenWMO.Version.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(Tests.WotlkWMO.Version.GetSize(), Tests.WotlkWrittenWMO.Version.GetSize());
        }
    }
}
