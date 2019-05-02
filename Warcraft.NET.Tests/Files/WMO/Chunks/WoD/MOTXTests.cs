using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.WoD
{
    [TestClass]
    public class MOTXTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            CollectionAssert.AreEqual(Tests.WoDWMO.Textures.Textures, Tests.WoDWrittenWMO.Textures.Textures);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(Tests.WoDWMO.Textures.GetSignature(), Tests.WoDWrittenWMO.Textures.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(Tests.WoDWMO.Textures.GetSize(), Tests.WoDWrittenWMO.Textures.GetSize());
        }
    }
}
