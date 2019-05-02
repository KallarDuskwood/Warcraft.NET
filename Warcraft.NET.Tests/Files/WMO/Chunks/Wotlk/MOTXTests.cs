using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.Wotlk
{
    [TestClass]
    public class MOTXTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            CollectionAssert.AreEqual(Tests.WotlkWMO.Textures.Textures, Tests.WotlkWrittenWMO.Textures.Textures);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(Tests.WotlkWMO.Textures.GetSignature(), Tests.WotlkWrittenWMO.Textures.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(Tests.WotlkWMO.Textures.GetSize(), Tests.WotlkWrittenWMO.Textures.GetSize());
        }
    }
}
