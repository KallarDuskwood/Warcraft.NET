using Warcraft.NET.Attribute;
using Warcraft.NET.Files.WMO.Chunks.Legion;

namespace Warcraft.NET.Files.WMO.WorldMapObject.Legion
{
    public class WorldMapObjectRoot : WorldMapObjectRootBase
    {
        [ChunkOrder(2)]
        public MOHD Header { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Legion.WorldMapObjectRoot"/> class.
        /// </summary>
        /// <param name="inData">The binary data.</param>
        public WorldMapObjectRoot(byte[] inData) : base(inData)
        {
        }
    }
}
