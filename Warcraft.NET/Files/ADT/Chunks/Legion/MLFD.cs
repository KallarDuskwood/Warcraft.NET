using Warcraft.NET.Files.Interfaces;
using System.IO;

namespace Warcraft.NET.Files.ADT.Chunks.Legion
{
    /// <summary>
    /// MLFD Chunk - Contains a lod information about m2 and wmo
    /// </summary>
    public class MLFD : IIFFChunk, IBinarySerializable
    {
        /// <summary>
        /// Holds the binary chunk signature.
        /// </summary>
        public const string Signature = "MLFD";

        /// <summary>
        /// Gets or sets a M2 lod offsets.
        /// </summary>
        public float[] M2LodOffset { get; set; } = new float[3];

        /// <summary>
        /// Gets or sets a M2 lod length.
        /// </summary>
        public float[] M2LodLength { get; set; } = new float[3];

        /// <summary>
        /// Gets or sets a WMO lod offsets.
        /// </summary>
        public float[] WmoLodOffset { get; set; } = new float[3];

        /// <summary>
        /// Gets or sets a WMO lod length.
        /// </summary>
        public float[] WmoLodLength { get; set; } = new float[3];

        /// <summary>
        /// Initializes a new instance of the <see cref="MLFD"/> class.
        /// </summary>
        public MLFD()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MLFD"/> class.
        /// </summary>
        /// <param name="inData">ExtendedData.</param>
        public MLFD(byte[] inData)
        {
            LoadBinaryData(inData);
        }

        /// <inheritdoc/>
        public void LoadBinaryData(byte[] inData)
        {
            using (var ms = new MemoryStream(inData))
            using (var br = new BinaryReader(ms))
            {
                // M2 offsets
                M2LodOffset[0] = br.ReadSingle();
                M2LodOffset[1] = br.ReadSingle();
                M2LodOffset[2] = br.ReadSingle();

                // M2 length
                M2LodLength[0] = br.ReadSingle();
                M2LodLength[1] = br.ReadSingle();
                M2LodLength[2] = br.ReadSingle();

                // Wmo offsets
                WmoLodOffset[0] = br.ReadSingle();
                WmoLodOffset[1] = br.ReadSingle();
                WmoLodOffset[2] = br.ReadSingle();

                // Wmo length
                WmoLodLength[0] = br.ReadSingle();
                WmoLodLength[1] = br.ReadSingle();
                WmoLodLength[2] = br.ReadSingle();
            }
        }

        /// <inheritdoc/>
        public string GetSignature()
        {
            return Signature;
        }

        /// <inheritdoc/>
        public uint GetSize()
        {
            return (uint)Serialize().Length;
        }

        /// <inheritdoc/>
        public byte[] Serialize(long offset = 0)
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                // M2 offsets
                bw.Write(M2LodOffset[0]);
                bw.Write(M2LodOffset[1]);
                bw.Write(M2LodOffset[2]);

                // M2 length
                bw.Write(M2LodLength[0]);
                bw.Write(M2LodLength[1]);
                bw.Write(M2LodLength[2]);

                // Wmo offsets
                bw.Write(WmoLodOffset[0]);
                bw.Write(WmoLodOffset[1]);
                bw.Write(WmoLodOffset[2]);

                // Wmo length
                bw.Write(WmoLodLength[0]);
                bw.Write(WmoLodLength[1]);
                bw.Write(WmoLodLength[2]);

                return ms.ToArray();
            }
        }
    }
}