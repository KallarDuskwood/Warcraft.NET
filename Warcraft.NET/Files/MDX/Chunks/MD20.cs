using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Warcraft.NET.Extensions;
using Warcraft.NET.Files.Interfaces;

namespace Warcraft.NET.Files.MDX.Chunks
{
    public class MD20 : IIFFChunk, IBinarySerializable
    {

        /// <summary>
        /// Holds the binary chunk signature.
        /// </summary>
        public const string Signature = "02DM";

        /// <summary>
        /// 272-274	    Legion
        /// 272	        Warlords of Draenor
        /// 272	        Mists of Pandaria
        /// 265-272	    Cataclysm
        /// 264	        Wrath of the Lich King
        /// 260-263	    The Burning Crusade
        /// 256-257	    Classic
        /// 256	        Pre-Release
        /// </summary>
        public UInt32 Version;

        /// <summary>
        /// Should be globally unique, used to reload by name in internal clients
        /// </summary>
        public string Name;

        /// <summary>
        /// TODO: Actually implement as Flags
        /// </summary>
        public UInt32 Flags;

        public List<UInt32> GlobalSequences;


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

        public MD20() { }

        public MD20(byte[] inData)
        {
            LoadBinaryData(inData);
        }

        /// <inheritdoc/>
        public void LoadBinaryData(byte[] inData)
        {
            using (var ms = new MemoryStream(inData))
            using (var br = new BinaryReader(ms))
            {
                br.ReadUInt32(); // Signature
                Version = br.ReadUInt32();
                Name = br.ReadMD20String(br.ReadUInt32(), br.ReadUInt32());
                Flags = br.ReadUInt32(); // TODO: Implement Flags

                var globSequenceCount = br.ReadUInt32();
                var globSequenceStart = br.ReadUInt32();

                for (int i = 0; i < globSequenceCount; i++) { }



            }
        }

        /// <inheritdoc/>
        public byte[] Serialize(long offset = 0)
        {
            throw new NotImplementedException();
        }
    }
}
