using System;
using System.Collections.Generic;
using System.Text;

namespace Warcraft.NET.Files.MDX.Structures
{
    class M2Vertex
    {


        public C3Vector Pos {get; set;}
        public List<byte> BoneWeights { get; set; } = new List<byte>();
        public List<byte> BoneIndices { get; set; } = new List<byte>();
        public C3Vector Normal { get; set; }
        public List<C2Vector> TexCords { get; set; } = new List<C2Vector>();


    }
}
