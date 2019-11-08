using System;
using System.Collections.Generic;
using System.Text;

namespace Warcraft.NET.Files.MDX.Structures
{
    public class M2TextureTransform
    {

        public M2Track Translation { get; set; }
        public M2Track Rotation { get; set; }
        public M2Track Scaling { get; set; }
    }
}
