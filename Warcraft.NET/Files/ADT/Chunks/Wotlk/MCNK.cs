using Warcraft.NET.Attribute;
using Warcraft.NET.Exceptions;
using Warcraft.NET.Extensions;
using Warcraft.NET.Files.ADT.Chunks;
using Warcraft.NET.Files.Interfaces;
using Warcraft.NET.Files.ADT.Entrys.Wotlk;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Warcraft.NET.Files.ADT.Chunks.Wotlk
{
    public class MCNK : IIFFChunk, IBinarySerializable
    {
        /// <summary>
        /// Holds the binary chunk signature.
        /// </summary>
        public const string Signature = "MCNK";

        /// <summary>
        /// Gets or sets the the MCNK header.
        /// </summary>
        public MCNKHeaderEntry Header { get; set; }

        /* Subchunks

        [ChunkOrder(1)]
        private MCVT MCVTChunk { get; set; } = null;

        [ChunkOrder(2)]
        private MCNR MCNRChunk { get; set; } = null;

        [ChunkOrder(3)]
        private MCLY MCLYChunk { get; set; } = null;

        [ChunkOrder(4)]
        private MCRF MCRFChunk { get; set; } = null;

        [ChunkOrder(6), ChunkOptional]
        private MCSH MCSHChunk { get; set; } = null;

        [ChunkOrder(5)]
        private MCAL MCALChunk { get; set; } = null;

        [ChunkOrder(8), ChunkOptional]
        private MCLQ MCLQChunk { get; set; } = null;

        [ChunkOrder(7)]
        private MCSE MCSEChunk { get; set; } = null;

        [ChunkOrder(9), ChunkOptional]
        private MCCV MCCVChunk { get; set; } = null;
        */


        /// <summary>
        /// Initializes a new instance of the <see cref="MCNK"/> class.
        /// </summary>
        /// <param name="inData">The binary data.</param>
        public MCNK(byte[] inData)
        {
            LoadBinaryData(inData);
        }

        /// <summary>
        /// Deserialzes the provided binary data of the object. This is the full data block which follows the data
        /// signature and data block length.
        /// </summary>
        /// <param name="inData">The binary data containing the object.</param>
        public void LoadBinaryData(byte[] inData)
        {
            using (var ms = new MemoryStream(inData))
            using (var br = new BinaryReader(ms))
            {
                Header = new MCNKHeaderEntry(br.ReadBytes(MCNKHeaderEntry.GetSize()));

                var mcnkChunkProperties = GetType()
                    .GetProperties()
                    .OrderBy(p => ((ChunkOrderAttribute)p.GetCustomAttributes(typeof(ChunkOrderAttribute), false).Single()).Order);

                foreach (PropertyInfo chunkPropertie in mcnkChunkProperties)
                {
                    try
                    {
                        IIFFChunk chunk = (IIFFChunk)br
                        .GetType()
                        .GetExtensionMethod(Assembly.GetExecutingAssembly(), "ReadIFFChunk")
                        .MakeGenericMethod(chunkPropertie.PropertyType)
                        .Invoke(null, new[] { br });

                        chunkPropertie.SetValue(this, chunk);
                    }
                    catch (TargetInvocationException ex)
                    {
                        bool chuckIsOptional = ((ChunkOptionalAttribute)chunkPropertie.GetCustomAttribute(typeof(ChunkOptionalAttribute), false)).Optional;

                        // If chunk is not optional throw the exception
                        if (ex.InnerException.GetType() != typeof(ChunkSignatureNotFoundException) || !chuckIsOptional)
                        {
                            throw ex.InnerException;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the size of the data contained in this chunk.
        /// </summary>
        /// <returns>The size.</returns>
        public uint GetSize()
        {
            return (uint)Serialize().Length;
        }

        /// <summary>
        /// Serializes the current object into a byte array.
        /// </summary>
        /// <returns>The serialized object.</returns>
        public byte[] Serialize()
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write(Header.Serialize());

                var mcnkChunkProperties = GetType()
                    .GetProperties()
                    .OrderBy(p => ((ChunkOrderAttribute)p.GetCustomAttributes(typeof(ChunkOrderAttribute), false).Single()).Order);

                foreach (PropertyInfo chunkPropertie in mcnkChunkProperties)
                {
                    IIFFChunk chunk = (IIFFChunk)chunkPropertie.GetValue(this);

                    if (chunk != null)
                    {
                        bw
                        .GetType()
                        .GetExtensionMethod(Assembly.GetExecutingAssembly(), "WriteIFFChunk")
                        .MakeGenericMethod(chunkPropertie.PropertyType)
                        .Invoke(null, new[] { bw, chunkPropertie.GetValue(this) });
                    }

                }

                return ms.ToArray();
            }
        }

        /// <inheritdoc/>
        public string GetSignature()
        {
            return Signature;
        }
    }
}
