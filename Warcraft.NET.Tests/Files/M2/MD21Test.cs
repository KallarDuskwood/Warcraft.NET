using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warcraft.NET.Tests.Files.M2
{
    [TestClass]
    public class MD21Test
    {
        [TestMethod]
        public void ChunkExists()
        {
            Assert.IsNotNull(Tests.WotlkM2.MD20);

        }

    }
}
