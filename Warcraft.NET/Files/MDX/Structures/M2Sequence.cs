using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Warcraft.NET.Files.MDX.Structures
{
    public class M2Sequence
    {

       public UInt16 AnimationID { get; set; }
       public UInt16 SubAnimationID { get; set; }
       public UInt32 Length { get; set; }
       public float MovingSpeed { get; set; }
       public UInt32 Flags { get; set; }
       public Int16 Probability { get; set; }
       public UInt16 Padding { get; set; }
       public UInt32 MinimumRepetitions { get; set; }
       public UInt32 MaximumRepetitions { get; set; }
       public UInt32 BlendTime { get; set; }
       public C3Vector BoundsMinimumExtend { get; set; }
       public C3Vector BoundsMaximumExtend { get; set; }
       public float BoundRadius { get; set; }
       public Int16 NextAnimation { get; set; }
       public UInt16 aliasNext { get; set; }
    }
}
