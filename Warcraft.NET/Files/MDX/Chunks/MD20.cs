using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Warcraft.NET.Extensions;
using Warcraft.NET.Files.Interfaces;
using Warcraft.NET.Files.MDX.Structures;

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

        public List<UInt32> GlobalSequences { get; set; } = new List<UInt32>();

        public List<M2Sequence> Sequences { get; set; } = new List<M2Sequence>();
        public List<Int16> SequencesLookups { get; set; } = new List<Int16>();

        public List<M2Bone> Bones { get; set; } = new List<M2Bone>();


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


                // Global Sequences
                UInt32 count = br.ReadUInt32();
                UInt32 offset = br.ReadUInt32();
                long headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++) {


                    UInt32 value = br.ReadUInt32();
                    GlobalSequences.Add(value);
                }
                br.BaseStream.Position = headerpos;

                // Sequences
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    M2Sequence seq = new M2Sequence();

                    seq.AnimationID = br.ReadUInt16();
                    seq.SubAnimationID = br.ReadUInt16();
                    seq.Length = br.ReadUInt32();
                    seq.MovingSpeed = br.ReadSingle();
                    seq.Flags = br.ReadUInt32();
                    seq.Probability = br.ReadInt16();
                    seq.Padding = br.ReadUInt16();
                    seq.MinimumRepetitions = br.ReadUInt32();
                    seq.MaximumRepetitions = br.ReadUInt32();
                    seq.BlendTime = br.ReadUInt32();
                    seq.BoundsMinimumExtend = new M2Vector(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                    seq.BoundsMaximumExtend = new M2Vector(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                    seq.BoundRadius = br.ReadSingle();
                    seq.NextAnimation = br.ReadInt16();
                    seq.aliasNext = br.ReadUInt16();

                    Sequences.Add(seq);
                }
                br.BaseStream.Position = headerpos;

                //SequencesLookups
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for(int i = 0; i < count; i++)
                {
                    SequencesLookups.Add(br.ReadInt16());
                }
                br.BaseStream.Position = headerpos;

                // Bones
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    M2Bone bone = new M2Bone();

                    bone.KeyBoneID = br.ReadInt32();
                    bone.Flags = br.ReadUInt32();
                    bone.ParentBone = br.ReadInt16();
                    bone.SubmeshID = br.ReadUInt16();

                    bone.CompressData[0] = br.ReadUInt16();
                    bone.CompressData[1] = br.ReadUInt16();

                    //translation

                    M2Track translation = new M2Track();

                    translation.InterpolationType = br.ReadUInt16();
                    translation.GlobalSequence = br.ReadInt16();

                    UInt32 tCount = br.ReadUInt32();
                    UInt32 tOffset = br.ReadUInt32();
                    long tHeaderpos = br.BaseStream.Position;
                    br.BaseStream.Position = tOffset;

                    
                    for (int a = 0; a < tCount; a++)
                    {
                        List<UInt32> timestamps = new List<UInt32>();

                        UInt32 ttCount = br.ReadUInt32();
                        UInt32 ttOffset = br.ReadUInt32();
                        long ttHeaderpos = br.BaseStream.Position;
                        br.BaseStream.Position = ttOffset;
                        for (int b = 0; b < ttCount; b++)
                        {
                            timestamps.Add(br.ReadUInt32());
                        }
                        br.BaseStream.Position = ttHeaderpos;

                        translation.Timestamps.Add(timestamps);
                    }
                    br.BaseStream.Position = tHeaderpos;

                    tCount = br.ReadUInt32();
                    tOffset = br.ReadUInt32();
                    tHeaderpos = br.BaseStream.Position;
                    br.BaseStream.Position = tOffset;

                    for (int a = 0; a < tCount; a++)
                    {
                        List<UInt32> keys = new List<UInt32>();

                        UInt32 ttCount = br.ReadUInt32();
                        UInt32 ttOffset = br.ReadUInt32();
                        long ttHeaderpos = br.BaseStream.Position;
                        br.BaseStream.Position = ttOffset;
                        for (int b = 0; b < ttCount; b++)
                        {
                            keys.Add(br.ReadUInt32());
                        }
                        br.BaseStream.Position = ttHeaderpos;

                        translation.Keys.Add(keys);
                    }
                    br.BaseStream.Position = tHeaderpos;

                    bone.translation = translation;

                    // rotation

                    M2Track rotation = new M2Track();

                    rotation.InterpolationType = br.ReadUInt16();
                    rotation.GlobalSequence = br.ReadInt16();

                    tCount = br.ReadUInt32();
                    tOffset = br.ReadUInt32();
                    tHeaderpos = br.BaseStream.Position;
                    br.BaseStream.Position = tOffset;


                    for (int a = 0; a < tCount; a++)
                    {
                        List<UInt32> timestamps = new List<UInt32>();

                        UInt32 ttCount = br.ReadUInt32();
                        UInt32 ttOffset = br.ReadUInt32();
                        long ttHeaderpos = br.BaseStream.Position;
                        br.BaseStream.Position = ttOffset;
                        for (int b = 0; b < ttCount; b++)
                        {
                            timestamps.Add(br.ReadUInt32());
                        }
                        br.BaseStream.Position = ttHeaderpos;

                        rotation.Timestamps.Add(timestamps);
                    }
                    br.BaseStream.Position = tHeaderpos;

                    tCount = br.ReadUInt32();
                    tOffset = br.ReadUInt32();
                    tHeaderpos = br.BaseStream.Position;
                    br.BaseStream.Position = tOffset;

                    for (int a = 0; a < tCount; a++)
                    {
                        List<UInt32> keys = new List<UInt32>();

                        UInt32 ttCount = br.ReadUInt32();
                        UInt32 ttOffset = br.ReadUInt32();
                        long ttHeaderpos = br.BaseStream.Position;
                        br.BaseStream.Position = ttOffset;
                        for (int b = 0; b < ttCount; b++)
                        {
                            keys.Add(br.ReadUInt32());
                        }
                        br.BaseStream.Position = ttHeaderpos;

                        translation.Keys.Add(keys);
                    }
                    br.BaseStream.Position = tHeaderpos;

                    bone.rotation = rotation;

                    // Scale

                    M2Track scale = new M2Track();

                    scale.InterpolationType = br.ReadUInt16();
                    scale.GlobalSequence = br.ReadInt16();

                    tCount = br.ReadUInt32();
                    tOffset = br.ReadUInt32();
                    tHeaderpos = br.BaseStream.Position;
                    br.BaseStream.Position = offset;


                    for (int a = 0; a < tCount; a++)
                    {
                        List<UInt32> timestamps = new List<UInt32>();

                        UInt32 ttCount = br.ReadUInt32();
                        UInt32 ttOffset = br.ReadUInt32();
                        long ttHeaderpos = br.BaseStream.Position;
                        br.BaseStream.Position = ttOffset;
                        for (int b = 0; b < ttCount; b++)
                        {
                            timestamps.Add(br.ReadUInt32());
                        }
                        br.BaseStream.Position = ttHeaderpos;

                        scale.Timestamps.Add(timestamps);
                    }
                    br.BaseStream.Position = tHeaderpos;

                    tCount = br.ReadUInt32();
                    tOffset = br.ReadUInt32();
                    tHeaderpos = br.BaseStream.Position;
                    br.BaseStream.Position = tOffset;

                    for (int a = 0; a < tCount; a++)
                    {
                        List<UInt32> keys = new List<UInt32>();

                        UInt32 ttCount = br.ReadUInt32();
                        UInt32 ttOffset = br.ReadUInt32();
                        long ttHeaderpos = br.BaseStream.Position;
                        br.BaseStream.Position = ttOffset;
                        for (int b = 0; b < ttCount; b++)
                        {
                            keys.Add(br.ReadUInt32());
                        }
                        br.BaseStream.Position = ttHeaderpos;

                        scale.Keys.Add(keys);
                    }
                    br.BaseStream.Position = tHeaderpos;

                    bone.scale = scale;

                    bone.pivot = new M2Vector(br.ReadUInt32(), br.ReadUInt32(), br.ReadUInt32());

                    Bones.Add(bone);

                }
                br.BaseStream.Position = headerpos;

            }
        }

        /// <inheritdoc/>
        public byte[] Serialize(long offset = 0)
        {
            throw new NotImplementedException();
        }
    }
}
