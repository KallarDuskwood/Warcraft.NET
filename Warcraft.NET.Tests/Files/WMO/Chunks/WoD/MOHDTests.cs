using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warcraft.NET.Tests.Files.WMO.WorldMapObject;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.WoD
{
    [TestClass]
    public class MOHDTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.Materials, WorldMapObjectRootTests.WoDWrittenWMO.Header.Materials);
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.Portals, WorldMapObjectRootTests.WoDWrittenWMO.Header.Portals);
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.Lights, WorldMapObjectRootTests.WoDWrittenWMO.Header.Lights);
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.DoodadNames, WorldMapObjectRootTests.WoDWrittenWMO.Header.DoodadNames);
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.DoodadDefinitions, WorldMapObjectRootTests.WoDWrittenWMO.Header.DoodadDefinitions);
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.DoodadSets, WorldMapObjectRootTests.WoDWrittenWMO.Header.DoodadSets);
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.Color, WorldMapObjectRootTests.WoDWrittenWMO.Header.Color);
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.WMOId, WorldMapObjectRootTests.WoDWrittenWMO.Header.WMOId);
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.BoundingBox, WorldMapObjectRootTests.WoDWrittenWMO.Header.BoundingBox);
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.Flags, WorldMapObjectRootTests.WoDWrittenWMO.Header.Flags);
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.Groups, WorldMapObjectRootTests.WoDWrittenWMO.Header.Groups);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.GetSignature(), WorldMapObjectRootTests.WoDWrittenWMO.Header.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(WorldMapObjectRootTests.WoDWMO.Header.GetSize(), WorldMapObjectRootTests.WoDWrittenWMO.Header.GetSize());
        }
    }
}
