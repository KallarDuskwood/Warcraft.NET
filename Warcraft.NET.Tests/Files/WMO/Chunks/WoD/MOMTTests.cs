using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.WoD
{
    [TestClass]
    public class MOMTTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            CollectionAssert.AreEqual(Tests.WoDWMO.Materials.MOMTEntries, Tests.WoDWrittenWMO.Materials.MOMTEntries);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(Tests.WoDWMO.Materials.GetSignature(), Tests.WoDWrittenWMO.Materials.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(Tests.WoDWMO.Materials.GetSize(), Tests.WoDWrittenWMO.Materials.GetSize());
        }
    }
}
