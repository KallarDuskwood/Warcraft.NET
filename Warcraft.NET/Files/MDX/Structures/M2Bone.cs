using System;
using System.Collections.Generic;
using System.Text;

namespace Warcraft.NET.Files.MDX.Structures
{
    public class M2Bone
    {

        public Int32 KeyBoneID { get; set; }
        public UInt32 Flags { get; set; }
        public Int16 ParentBone { get; set; }
        public UInt16 SubmeshID { get; set; }
        public UInt16[] CompressData  { get; set; }
        public M2Track translation { get; set; }
        public M2Track rotation { get; set; }
        public M2Track scale { get; set; }
        public M2Vector pivot { get; set; }

        public M2Bone()
        {
            CompressData = new UInt16[2];


        }

    }
}
