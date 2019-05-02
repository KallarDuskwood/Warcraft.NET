using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.BfA
{
    [TestClass]
    public class MVERTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            Assert.AreEqual(Tests.BfAWMO.Version.Version, Tests.BfAWrittenWMO.Version.Version);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(Tests.BfAWMO.Version.GetSignature(), Tests.BfAWrittenWMO.Version.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(Tests.BfAWMO.Version.GetSize(), Tests.BfAWrittenWMO.Version.GetSize());
        }
    }
}
