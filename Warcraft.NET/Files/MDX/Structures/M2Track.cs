using System;
using System.Collections.Generic;
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
    }
}
