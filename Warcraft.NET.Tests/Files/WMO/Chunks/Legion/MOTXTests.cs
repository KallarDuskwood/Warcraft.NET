using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.Legion
{
    [TestClass]
    public class MOTXTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            CollectionAssert.AreEqual(Tests.LegionWMO.Textures.Textures, Tests.LegionWrittenWMO.Textures.Textures);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(Tests.LegionWMO.Textures.GetSignature(), Tests.LegionWrittenWMO.Textures.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(Tests.LegionWMO.Textures.GetSize(), Tests.LegionWrittenWMO.Textures.GetSize());
        }
    }
}
