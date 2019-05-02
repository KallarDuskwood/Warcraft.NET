using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.Wotlk
{
    [TestClass]
    public class MOMTTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            CollectionAssert.AreEqual(Tests.WotlkWMO.Materials.MOMTEntries, Tests.WotlkWrittenWMO.Materials.MOMTEntries);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(Tests.WotlkWMO.Materials.GetSignature(), Tests.WotlkWrittenWMO.Materials.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(Tests.WotlkWMO.Materials.GetSize(), Tests.WotlkWrittenWMO.Materials.GetSize());
        }
    }
}
