using System;
using System.Collections.Generic;
using System.Text;

namespace Warcraft.NET.Files.MDX.Structures
{

    public enum Texturetype
    {

                TEX_GIVEN_IN_FILENAME           = 0,
            	TEX_COMPONENT_SKIN              = 1,    //  -- Skin -- Body + clothes
            	TEX_COMPONENT_OBJECT_SKIN       = 2,    // -- Object Skin -- Item, Capes ("Item\ObjectComponents\Cape\*.blp")
            	TEX_COMPONENT_WEAPON_BLADE      = 3,    // -- Weapon Blade -- Used on several models but not used in the client as far as I see.Armor Reflect?
            	TEX_COMPONENT_WEAPON_HANDLE     = 4,    // -- Weapon Handle
            	TEX_COMPONENT_ENVIRONMENT       = 5,    // -- (OBSOLETE) Environment (Please remove from source art)
            	TEX_COMPONENT_CHAR_HAIR         = 6,    // -- Character Hair
            	TEX_COMPONENT_CHAR_FACIAL_HAIR  = 7,    // -- (OBSOLETE) Character Facial Hair(Please remove from source art)
            	TEX_COMPONENT_SKIN_EXTRA        = 8,    // -- Skin Extra
            	TEX_COMPONENT_UI_SKIN           = 9,    // -- UI Skin -- Used on inventory art M2s(1) : inventoryartgeometry.m2 and inventoryartgeometryold.m2
            	TEX_COMPONENT_TAUREN_MANE       = 10,   // -- (OBSOLETE) Tauren Mane(Please remove from source art) -- Only used in quillboarpinata.m2.I can't even find something referencing that file. Oo Is it used?
            	TEX_COMPONENT_MONSTER_1         = 11,   // -- Monster Skin 1 -- Skin for creatures or gameobjects #1
            	TEX_COMPONENT_MONSTER_2         = 12,   // -- Monster Skin 2 -- Skin for creatures or gameobjects #2
            	TEX_COMPONENT_MONSTER_3         = 13,   // -- Monster Skin 3 -- Skin for creatures or gameobjects #3
            	TEX_COMPONENT_ITEM_ICON         = 14,   // -- Item Icon -- Used on inventory art M2s(2) : ui-button.m2 and forcedbackpackitem.m2(CSimpleModel_ReplaceIconTexture("texture"))
            	TEX_GUILD_BECKGROUND_COLOR      = 15,   // ≥ Cata
                TEX_GUILD_EMBLEM_COLOR          = 16,   // ≥ Cata
                TEX_GUILD_BORDER_COLOR          = 17,   // ≥ Cata
                TEX_GUILD_EMBLEM                = 18,   // ≥ Cata

    }
    public class M2Texture
    {

       public UInt32 Type { get; set; }
       public UInt32 Flags { get; set; }
       public string Filename { get; set; }


    }
}
