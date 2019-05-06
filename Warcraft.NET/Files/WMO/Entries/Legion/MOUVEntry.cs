using System.IO;
using SharpDX;
using Warcraft.NET.Extensions;

namespace Warcraft.NET.Files.WMO.Entries.Legion
{
    /// <summary>
    /// An entry struct containing informations about texture animation
    /// </summary>
    public class MOUVEntry
    {

        public Vector2[] TranslationSpeed { get; set; } = new Vector2[2];

        /// <summary>
        /// Initializes a new instance of the <see cref="MOUVEntry"/> class.
        /// </summary>
        public MOUVEntry()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MOUVEntry"/> class.
        /// </summary>
        /// <param name="inData">ExtendedData.</param>
        public MOUVEntry(byte[] inData)
        {
            LoadBinaryData(inData);
        }

        /// <inheritdoc/>
        public static int GetSize()
        {
            return 16;
        }

        /// <inheritdoc/>
        public void LoadBinaryData(byte[] inData)
        {
            using (var ms = new MemoryStream(inData))
            using (var br = new BinaryReader(ms))
            {
                TranslationSpeed[0] = br.ReadVector2();
                TranslationSpeed[1] = br.ReadVector2();
            }
        }

        /// <inheritdoc/>
        public byte[] Serialize()
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                bw.WriteVector2(TranslationSpeed[0]);
                bw.WriteVector2(TranslationSpeed[1]);

                return ms.ToArray();
            }
        }
    }
}
