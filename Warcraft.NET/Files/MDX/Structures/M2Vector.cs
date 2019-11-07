using System;
using System.Collections.Generic;
using System.Text;

namespace Warcraft.NET.Files.MDX.Structures
{
    public class M2Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public M2Vector(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public M2Vector() { }

    }
}
