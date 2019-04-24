using System;

namespace Warcraft.NET.Files.ADT.Flags
{
    [Flags]
    public enum MCNKHeaderFlags : uint
    {
        /// <summary>
        /// Has MCSH chunk
        /// </summary>
        MCSH = 0x1,

        /// <summary>
        /// Impassable
        /// </summary>
        IMPASS = 0x2,

        /// <summary>
        /// Liquid type river
        /// </summary>
        LQ_RIVER = 0x4,

        /// <summary>
        /// Liquid type ocean
        /// </summary>
        LQ_OCEAN = 0x8,

        /// <summary>
        /// Liquid type magma
        /// </summary>
        LQ_MAGMA = 0x10,

        /// <summary>
        /// Liquid type slime
        /// </summary>
        LQ_SLIME = 0x20,

        /// <summary>
        /// Has MCCV Chunk
        /// </summary>
        MCCV = 0x40,

        /// <summary>
        /// "fix" alpha maps in MCAL (4 bit alpha maps are 63*63 instead of 64*64).
        /// If this flag is not set, the MCAL format *has* to be unfixed4444, otherwise UnpackAlphaShadowBits will assert.
        /// </summary>
        do_not_fix_alpha_map = 0x8000,

        /// <summary>
        /// Since ~5.3 WoW uses full 64-bit to store holes for each tile if this flag is set.
        /// </summary>
        high_res_holes = 0x10000
    }
}
