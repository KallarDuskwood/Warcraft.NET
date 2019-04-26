using Warcraft.NET.Attribute;
using Warcraft.NET.Files.ADT.Chunks;

namespace Warcraft.NET.Files.ADT.Terrain.WoD
{
    public class TerrainObj2 : TerrainObj1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WoD.Terrain"/> class.
        /// </summary>
        /// <param name="file">The file path</param>
        public TerrainObj2(string file) : base(file)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WoD.TerrainObj2"/> class.
        /// </summary>
        /// <param name="inData">The binary data.</param>
        public TerrainObj2(byte[] inData) : base(inData)
        {
        }
    }
}
