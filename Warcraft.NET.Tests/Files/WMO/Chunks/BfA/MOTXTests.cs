using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warcraft.NET.Attribute;
using Warcraft.NET.Files.WMO.WorldMapObject.BfA;
using System.Linq;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.BfA
{
    [TestClass]
    public class MOTXTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            var isOptional = typeof(WorldMapObjectRoot).GetProperty(nameof(WorldMapObjectRoot.Textures)).GetCustomAttributes(typeof(ChunkOptionalAttribute), false).Any();
            if (isOptional && Tests.BfAWMO.Textures != null)
                Assert.AreEqual(Tests.BfAWMO.Textures.Textures, Tests.BfAWrittenWMO.Textures.Textures);
        }

        [TestMethod]
        public void GetSignature()
        {
            var isOptional = typeof(WorldMapObjectRoot).GetProperty(nameof(WorldMapObjectRoot.Textures)).GetCustomAttributes(typeof(ChunkOptionalAttribute), false).Any();
            if (isOptional && Tests.BfAWMO.Textures != null)
                Assert.AreEqual(Tests.BfAWMO.Textures.GetSignature(), Tests.BfAWrittenWMO.Textures.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            var isOptional = typeof(WorldMapObjectRoot).GetProperty(nameof(WorldMapObjectRoot.Textures)).GetCustomAttributes(typeof(ChunkOptionalAttribute), false).Any();
            if (isOptional && Tests.BfAWMO.Textures != null)
                Assert.AreEqual(Tests.BfAWMO.Textures.GetSize(), Tests.BfAWrittenWMO.Textures.GetSize());
        }
    }
}
