using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.WMO.Chunks.BfA
{
    [TestClass]
    public class MOMTTests
    {
        [TestMethod]
        public void LoadBinaryData()
        {
            CollectionAssert.AreEqual(Tests.BfAWMO.Materials.MOMTEntries, Tests.BfAWrittenWMO.Materials.MOMTEntries);
            
        }

        [TestMethod]
        public void GetSignature()
        {
            Assert.AreEqual(Tests.BfAWMO.Materials.GetSignature(), Tests.BfAWrittenWMO.Materials.GetSignature());
        }

        [TestMethod]
        public void GetSize()
        {
            Assert.AreEqual(Tests.BfAWMO.Materials.GetSize(), Tests.BfAWrittenWMO.Materials.GetSize());
        }
    }
}
