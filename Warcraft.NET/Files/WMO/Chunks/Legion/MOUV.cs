using System.Collections.Generic;
using System.IO;
using Warcraft.NET.Files.Interfaces;
using Warcraft.NET.Files.WMO.Entries.Legion;

namespace Warcraft.NET.Files.WMO.Chunks.Legion
{
    public class MOUV : IIFFChunk, IBinarySerializable
    {
        /// <summary>
        /// Holds the binary chunk signature.
        /// </summary>
        public const string Signature = "MOUV";

        /// <summary>
        /// Gets or sets <see cref="MOUVEntry"s />
        /// </summary>
        public List<MOUVEntry> MOUVEntries { get; set; } = new List<MOUVEntry>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MOUV"/> class.
        /// </summary>
        public MOUV()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MOUV"/> class.
        /// </summary>
        /// <param name="inData">ExtendedData.</param>
        public MOUV(byte[] inData)
        {
            LoadBinaryData(inData);
        }

        /// <inheritdoc/>
        public void LoadBinaryData(byte[] inData)
        {
            using (var ms = new MemoryStream(inData))
            using (var br = new BinaryReader(ms))
            {
                var materialCount = br.BaseStream.Length / MOUVEntry.GetSize();
                for (var i = 0; i < materialCount; ++i)
                    MOUVEntries.Add(new MOUVEntry(br.ReadBytes(MOUVEntry.GetSize())));
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
        public byte[] Serialize()
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                foreach (var material in MOUVEntries)
                    bw.Write(material.Serialize());

                return ms.ToArray();
            }
        }
    }
}
