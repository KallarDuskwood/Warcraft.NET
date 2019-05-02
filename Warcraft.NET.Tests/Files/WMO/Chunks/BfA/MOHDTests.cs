using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warcraft.NET.Tests.Files.WMO.WorldMapObject;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.BfA
{
    [TestClass]
    public class MOHDTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.Materials, WorldMapObjectRootTests.BfAWrittenWMO.Header.Materials);
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.Portals, WorldMapObjectRootTests.BfAWrittenWMO.Header.Portals);
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.Lights, WorldMapObjectRootTests.BfAWrittenWMO.Header.Lights);
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.DoodadNames, WorldMapObjectRootTests.BfAWrittenWMO.Header.DoodadNames);
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.DoodadDefinitions, WorldMapObjectRootTests.BfAWrittenWMO.Header.DoodadDefinitions);
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.DoodadSets, WorldMapObjectRootTests.BfAWrittenWMO.Header.DoodadSets);
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.Color, WorldMapObjectRootTests.BfAWrittenWMO.Header.Color);
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.WMOId, WorldMapObjectRootTests.BfAWrittenWMO.Header.WMOId);
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.BoundingBox, WorldMapObjectRootTests.BfAWrittenWMO.Header.BoundingBox);
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.Flags, WorldMapObjectRootTests.BfAWrittenWMO.Header.Flags);
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.Groups, WorldMapObjectRootTests.BfAWrittenWMO.Header.Groups);
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.GetSignature(), WorldMapObjectRootTests.BfAWrittenWMO.Header.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(WorldMapObjectRootTests.BfAWMO.Header.GetSize(), WorldMapObjectRootTests.BfAWrittenWMO.Header.GetSize());
        }
    }
}
