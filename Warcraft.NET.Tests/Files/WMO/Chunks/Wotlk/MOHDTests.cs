using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warcraft.NET.Tests.Files.WMO.WorldMapObject;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.Wotlk
{
    [TestClass]
    public class MOHDTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.Materials, WorldMapObjectRootTests.WotlkWrittenWMO.Header.Materials);
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.Portals, WorldMapObjectRootTests.WotlkWrittenWMO.Header.Portals);
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.Lights, WorldMapObjectRootTests.WotlkWrittenWMO.Header.Lights);
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.DoodadNames, WorldMapObjectRootTests.WotlkWrittenWMO.Header.DoodadNames);
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.DoodadDefinitions, WorldMapObjectRootTests.WotlkWrittenWMO.Header.DoodadDefinitions);
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.DoodadSets, WorldMapObjectRootTests.WotlkWrittenWMO.Header.DoodadSets);
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.Color, WorldMapObjectRootTests.WotlkWrittenWMO.Header.Color);
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.WMOId, WorldMapObjectRootTests.WotlkWrittenWMO.Header.WMOId);
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.BoundingBox, WorldMapObjectRootTests.WotlkWrittenWMO.Header.BoundingBox);
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.Flags, WorldMapObjectRootTests.WotlkWrittenWMO.Header.Flags);
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.Groups, WorldMapObjectRootTests.WotlkWrittenWMO.Header.Groups);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.GetSignature(), WorldMapObjectRootTests.WotlkWrittenWMO.Header.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(WorldMapObjectRootTests.WotlkWMO.Header.GetSize(), WorldMapObjectRootTests.WotlkWrittenWMO.Header.GetSize());
        }
    }
}
