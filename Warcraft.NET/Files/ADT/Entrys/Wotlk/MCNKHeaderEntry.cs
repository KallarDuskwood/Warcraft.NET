using System;
using SharpDX;
using System.IO;
using Warcraft.NET.Extensions;
using Warcraft.NET.Files.ADT.Flags;

namespace Warcraft.NET.Files.ADT.Entrys.Wotlk
{
    /// <summary>
    /// MCNK header
    /// </summary>
    public class MCNKHeaderEntry
    {
        /// <summary>
        /// MCNK header flags
        /// </summary>
        public MCNKHeaderFlags Flags { get; set; }

        /// <summary>
        /// x position of map chunk
        /// </summary>
        public UInt32 IndexX { get; set; }

        /// <summary>
        /// y position of map chunk
        /// </summary>
        public UInt32 IndexY { get; set; }

        /// <summary>
        /// n Layers, maximum 4
        /// </summary>
        public UInt32 Layers { get; set; }

        /// <summary>
        /// Doodad references on map chunk
        /// </summary>
        public UInt32 DoodadRefs { get; set; }

        /// <summary>
        /// MCVT Offset
        /// </summary>
        public UInt32 MCVTOffset { get; set; }

        /// <summary>
        /// MCNR Offset
        /// </summary>
        public UInt32 MCNROffset { get; set; }

        /// <summary>
        /// MCLY Offset
        /// </summary>
        public UInt32 MCLYOffset { get; set; }

        /// <summary>
        /// MCNR Offset
        /// </summary>
        public UInt32 MCRFOffset { get; set; }

        /// <summary>
        /// MCAL Offset
        /// </summary>
        public UInt32 MCALOffset { get; set; }

        /// <summary>
        /// MCAL Size
        /// </summary>
        public UInt32 MCALSize { get; set; }

        /// <summary>
        /// MCSH Offset
        /// </summary>
        public UInt32 MCSHOffset { get; set; }

        /// <summary>
        /// MCSH Size
        /// </summary>
        public UInt32 MCSHSize { get; set; }

        /// <summary>
        /// Area ID refernces in AreaTable.db2
        /// </summary>
        public UInt32 AreaID { get; set; }

        /// <summary>
        /// Object references on map chunk
        /// </summary>
        public UInt32 MapObjRefs { get; set; }

        /// <summary>
        /// Low res holes
        /// </summary>
        public UInt16 HolesLowRes { get; set; }

        /// <summary>
        /// Unknown but used
        /// </summary>
        public UInt16 UnknownButUsed { get; set; }

        /// <summary>
        /// "predTex", It is used to determine which detail doodads to show. Values are an array of two bit unsigned integers, naming the layer.
        /// </summary>
        public Byte[] ReallyLowQualityTextureingMap { get; set; }
        
        /// <summary>
        /// doodads disabled if 1; WoD: may be an explicit MCDD chunk
        /// </summary>
        public Byte[] NoEffectDoodad { get; set; }

        /// <summary>
        /// MCSE Offset
        /// </summary>
        public UInt32 MCSEOffset { get; set; }

        /// <summary>
        /// nSoundEmitters in MCSE Chunk
        /// </summary>
        public UInt32 SndEmitters { get; set; }

        /// <summary>
        /// MCLQ Offset
        /// </summary>
        public UInt32 MCLQOffset { get; set; }

        /// <summary>
        /// Liquid size
        /// </summary>
        public UInt32 SizeLiquid { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// MCCV Offset, only with flags.has_mccv, had uint32_t textureId; in ObscuR's structure.
        /// </summary>
        public UInt32 MCCVOffset { get; set; }

        /// <summary>
        /// MCLV Offset
        /// </summary>
        public UInt32 MCLVOffset { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public UInt32 Unused { get; set; }

        public MCNKHeaderEntry(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            using (var br = new BinaryReader(ms))
            {
                Flags = (MCNKHeaderFlags)br.ReadUInt32();
                IndexX = br.ReadUInt32();
                IndexY = br.ReadUInt32();
                Layers = br.ReadUInt32();
                DoodadRefs = br.ReadUInt32();
                MCVTOffset = br.ReadUInt32();
                MCNROffset = br.ReadUInt32();
                MCLYOffset = br.ReadUInt32();
                MCRFOffset = br.ReadUInt32();
                MCALOffset = br.ReadUInt32();
                MCALSize = br.ReadUInt32();
                MCSHOffset = br.ReadUInt32();
                MCSHSize = br.ReadUInt32();
                AreaID = br.ReadUInt32();
                MapObjRefs = br.ReadUInt32();
                HolesLowRes = br.ReadUInt16();
                UnknownButUsed = br.ReadUInt16();
                ReallyLowQualityTextureingMap = br.ReadBytes(16);
                NoEffectDoodad = br.ReadBytes(8);
                MCSEOffset = br.ReadUInt32();
                SndEmitters = br.ReadUInt32();
                MCLQOffset = br.ReadUInt32();
                SizeLiquid = br.ReadUInt32();
                Position = br.ReadVector3(Structures.AxisConfiguration.Native);
                MCCVOffset = br.ReadUInt32();
                MCLVOffset = br.ReadUInt32();
                Unused = br.ReadUInt32();
            }
        }

        /// <inheritdoc/>
        public static int GetSize()
        {
            return 128;
        }

        /// <inheritdoc/>
        public byte[] Serialize()
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write((uint)Flags);
                bw.Write(IndexX);
                bw.Write(IndexY);
                bw.Write(Layers);
                bw.Write(DoodadRefs);
                bw.Write(MCVTOffset);
                bw.Write(MCNROffset);
                bw.Write(MCLYOffset);
                bw.Write(MCRFOffset);
                bw.Write(MCALOffset);
                bw.Write(MCALSize);
                bw.Write(MCSHOffset);
                bw.Write(MCSHSize);
                bw.Write(AreaID);
                bw.Write(MapObjRefs);
                bw.Write(HolesLowRes);
                bw.Write(UnknownButUsed);
                bw.Write(ReallyLowQualityTextureingMap);
                bw.Write(NoEffectDoodad);
                bw.Write(MCSEOffset);
                bw.Write(SndEmitters);
                bw.Write(MCLQOffset);
                bw.Write(SizeLiquid);
                bw.WriteVector3(Position);
                bw.Write(MCCVOffset);
                bw.Write(MCLVOffset);
                bw.Write(Unused);

                return ms.ToArray();
            }
        }
    }
}