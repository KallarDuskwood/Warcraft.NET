using System;
using System.Collections.Generic;
using System.Text;

namespace Warcraft.NET.Files.MDX.Structures
{
    public class C3Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public C3Vector(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public C3Vector() { }

    }
}
