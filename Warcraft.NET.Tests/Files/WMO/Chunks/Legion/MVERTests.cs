using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.Legion
{
    [TestClass]
    public class MVERTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            Assert.AreEqual(Tests.LegionWMO.Version.Version, Tests.LegionWrittenWMO.Version.Version);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(Tests.LegionWMO.Version.GetSignature(), Tests.LegionWrittenWMO.Version.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(Tests.LegionWMO.Version.GetSize(), Tests.LegionWrittenWMO.Version.GetSize());
        }
    }
}
