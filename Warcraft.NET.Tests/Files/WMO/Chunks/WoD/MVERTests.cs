using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.WoD
{
    [TestClass]
    public class MVERTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            Assert.AreEqual(Tests.WoDWMO.Version.Version, Tests.WoDWrittenWMO.Version.Version);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(Tests.WoDWMO.Version.GetSignature(), Tests.WoDWrittenWMO.Version.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(Tests.WoDWMO.Version.GetSize(), Tests.WoDWrittenWMO.Version.GetSize());
        }
    }
}
