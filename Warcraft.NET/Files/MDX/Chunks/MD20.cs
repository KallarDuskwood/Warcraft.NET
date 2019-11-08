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

        public List<Int16> KeyBoneLookup { get; set; } = new List<Int16>();

        public UInt32 NumberSkinProfiles { get; set; }

        public List<M2Color> Color { get; set; } = new List<M2Color>();

        public List<M2Texture> Texture { get; set; } = new List<M2Texture>();
        public List<M2Track> TextureWeights { get; set; } = new List<M2Track>();
        public List<M2TextureTransform> UvAnimations { get; set; } = new List<M2TextureTransform>();
        public List<Int16> TextureReplacements { get; set; } = new List<Int16>();
        public List<M2Material> Materials { get; set; } = new List<M2Material>();
        public List<UInt16> BoneLookups { get; set; } = new List<UInt16>();
        public List<UInt16> TextureLookups { get; set; } = new List<UInt16>();
        public List<UInt16> TextureUnits { get; set; } = new List<UInt16>();
        public List<UInt16> TextureWeightsLookups { get; set; } = new List<UInt16>();
        public List<Int16> UvAnimationLookups { get; set; } = new List<Int16>();
        

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
                    seq.BoundsMinimumExtend = new C3Vector(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                    seq.BoundsMaximumExtend = new C3Vector(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
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
                    translation.readM2Track(br);
                    bone.translation = translation;

                    // rotation
                    M2Track rotation = new M2Track();
                    rotation.readM2Track(br);
                    bone.rotation = rotation;

                    // Scale
                    M2Track scale = new M2Track();
                    scale.readM2Track(br);
                    bone.scale = scale;

                    bone.pivot = new C3Vector(br.ReadUInt32(), br.ReadUInt32(), br.ReadUInt32());

                    Bones.Add(bone);

                }
                br.BaseStream.Position = headerpos;

                // key_bone_lookup
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for(int i = 0; i < count; i++)
                {
                    KeyBoneLookup.Add(br.ReadInt16());
                }
                br.BaseStream.Position = headerpos;

                // Vetices
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    M2Vertex temp = new M2Vertex();

                    temp.Pos = new C3Vector(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                    for(int a = 0; a < 4; a++)
                    {
                        temp.BoneWeights.Add(br.ReadByte());
                    }
                    for (int a = 0; a < 4; a++)
                    {
                        temp.BoneIndices.Add(br.ReadByte());
                    }
                    temp.Normal = new C3Vector(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                    temp.TexCords.Add(new C2Vector(br.ReadSingle(), br.ReadSingle()));
                    temp.TexCords.Add(new C2Vector(br.ReadSingle(), br.ReadSingle()));

                }
                br.BaseStream.Position = headerpos;

                // Number of Skin profiles
                NumberSkinProfiles = br.ReadUInt32();

                // Colors
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    M2Color temp = new M2Color();

                    // Color
                    M2Track color = new M2Track();
                    color.readM2Track(br);
                    temp.Color = color;

                    // Alpha
                    M2Track alpha = new M2Track();
                    alpha.readM2Track(br);
                    temp.Alpha = alpha;

                    Color.Add(temp);

                }
                br.BaseStream.Position = headerpos;

                // Textures
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    M2Texture temp = new M2Texture();

                    temp.Type = br.ReadUInt32();
                    temp.Flags = br.ReadUInt32();

                    UInt32 tCount = br.ReadUInt32();
                    UInt32 tOffset = br.ReadUInt32();
                    long tHeaderpos = br.BaseStream.Position;
                    br.BaseStream.Position = tOffset;

                    temp.Filename = "";
                    for (int a = 0; a < tCount; a++)
                    {
                        temp.Filename += br.ReadChar();
                    }
                    br.BaseStream.Position = tHeaderpos;

                    Texture.Add(temp);
                }
                br.BaseStream.Position = headerpos;

                // Texture Weights 
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                   
                    M2Track temp = new M2Track();
                    temp.readM2Track(br);
                    TextureWeights.Add(temp);

                }
                br.BaseStream.Position = headerpos;

                // UV Animations
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    M2TextureTransform temp = new M2TextureTransform();

                    M2Track translation = new M2Track();
                    translation.readM2Track(br);
                    temp.Translation = translation;

                    M2Track rotation = new M2Track();
                    rotation.readM2Track(br);
                    temp.Rotation = rotation;

                    M2Track scaling = new M2Track();
                    scaling.readM2Track(br);
                    temp.Scaling = scaling;

                    UvAnimations.Add(temp);
                }
                br.BaseStream.Position = headerpos;

                // Texture Replacements
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    TextureReplacements.Add(br.ReadInt16());
                }
                br.BaseStream.Position = headerpos;

                // Materials
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    M2Material temp = new M2Material();

                    temp.Flags = br.ReadUInt16();
                    temp.BlendMode = br.ReadUInt16();

                    Materials.Add(temp);
                }
                br.BaseStream.Position = headerpos;

                // Bone Lookups
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    BoneLookups.Add(br.ReadUInt16());
                }
                br.BaseStream.Position = headerpos;

                // Texture Units
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    TextureUnits.Add(br.ReadUInt16());
                }
                br.BaseStream.Position = headerpos;

                // Texture Weights Lookups
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    TextureWeightsLookups.Add(br.ReadUInt16());
                }
                br.BaseStream.Position = headerpos;

                // Animation Lookups
                count = br.ReadUInt32();
                offset = br.ReadUInt32();
                headerpos = br.BaseStream.Position;
                br.BaseStream.Position = offset;
                for (int i = 0; i < count; i++)
                {
                    UvAnimationLookups.Add(br.ReadInt16());
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
