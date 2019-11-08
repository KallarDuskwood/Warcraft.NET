using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Warcraft.NET.Files.MDX.Structures
{
    public class M2Track
    {
        
        public UInt16 InterpolationType { get; set; }
        public Int16 GlobalSequence { get; set; }
        public List<List<UInt32>> Timestamps { get; set; }
        public List<List<UInt32>> Keys { get; set; }


        public M2Track()
        {

            Timestamps = new List<List<UInt32>>();
            Keys = new List<List<UInt32>>();

        }

        public void readM2Track(BinaryReader br)
        {
            InterpolationType = br.ReadUInt16();
            GlobalSequence = br.ReadInt16();

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

                Timestamps.Add(timestamps);
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

                Keys.Add(keys);
            }
            br.BaseStream.Position = tHeaderpos;
        }
    }
}
