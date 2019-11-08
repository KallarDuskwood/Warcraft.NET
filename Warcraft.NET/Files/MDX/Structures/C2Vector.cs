using System;
using System.Collections.Generic;
using System.Text;

namespace Warcraft.NET.Files.MDX.Structures
{
    class C2Vector
    {
        public float X { get; set; }
        public float Y { get; set; }

        public C2Vector(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public C2Vector()
        {
        }
    }
}
