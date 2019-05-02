using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.Legion
{
    [TestClass]
    public class MOMTTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            CollectionAssert.AreEqual(Tests.LegionWMO.Materials.MOMTEntries, Tests.LegionWrittenWMO.Materials.MOMTEntries);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(Tests.LegionWMO.Materials.GetSignature(), Tests.LegionWrittenWMO.Materials.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(Tests.LegionWMO.Materials.GetSize(), Tests.LegionWrittenWMO.Materials.GetSize());
        }
    }
}
