using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warcraft.NET.Tests.Files.WMO.WorldMapObject;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.Legion
{
    [TestClass]
    public class MOHDTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.Materials, WorldMapObjectRootTests.LegionWrittenWMO.Header.Materials);
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.Portals, WorldMapObjectRootTests.LegionWrittenWMO.Header.Portals);
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.Lights, WorldMapObjectRootTests.LegionWrittenWMO.Header.Lights);
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.DoodadNames, WorldMapObjectRootTests.LegionWrittenWMO.Header.DoodadNames);
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.DoodadDefinitions, WorldMapObjectRootTests.LegionWrittenWMO.Header.DoodadDefinitions);
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.DoodadSets, WorldMapObjectRootTests.LegionWrittenWMO.Header.DoodadSets);
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.Color, WorldMapObjectRootTests.LegionWrittenWMO.Header.Color);
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.WMOId, WorldMapObjectRootTests.LegionWrittenWMO.Header.WMOId);
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.BoundingBox, WorldMapObjectRootTests.LegionWrittenWMO.Header.BoundingBox);
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.Flags, WorldMapObjectRootTests.LegionWrittenWMO.Header.Flags);
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.Groups, WorldMapObjectRootTests.LegionWrittenWMO.Header.Groups);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.GetSignature(), WorldMapObjectRootTests.LegionWrittenWMO.Header.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(WorldMapObjectRootTests.LegionWMO.Header.GetSize(), WorldMapObjectRootTests.LegionWrittenWMO.Header.GetSize());
        }
    }
}
