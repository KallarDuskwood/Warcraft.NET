using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WotlkWMO = Warcraft.NET.Files.WMO.WorldMapObject.Wotlk.WorldMapObjectRoot;
using WoDWMO = Warcraft.NET.Files.WMO.WorldMapObject.WoD.WorldMapObjectRoot;
using LegionWMO = Warcraft.NET.Files.WMO.WorldMapObject.Legion.WorldMapObjectRoot;
using BfAWMO = Warcraft.NET.Files.WMO.WorldMapObject.BfA.WorldMapObjectRoot;

namespace Warcraft.NET.Tests.Files.WMO.WorldMapObject
{
    [TestClass]
    public class WorldMapObjectRootTests
    {
        // Wotlk
        private static string WotlkWMOPath = @"Resources/WMO/prisonHQ_Redridge.wmo";
        private static string WotlkWrittenWMOPath = @"Resources/WMO/prisonHQ_Redridge.new.wmo";
        public static WotlkWMO WotlkWMO;
        public static WotlkWMO WotlkWrittenWMO;

        // WoD
        private static string WoDWMOPath = @"Resources/WMO/";
        private static string WoDWrittenWMOPath = @"Resources/WMO/";
        public static WoDWMO WoDWMO;
        public static WoDWMO WoDWrittenWMO;

        // Legion
        private static string LegionWMOPath = @"Resources/WMO/";
        private static string LegionWrittenWMOPath = @"Resources/WMO/";
        public static LegionWMO LegionWMO;
        public static LegionWMO LegionWrittenWMO;

        // BfA
        private static string BfAWMOPath = @"Resources/WMO/8or_pvp_warsongbg_tower01.wmo";
        private static string BfAWrittenWMOPath = @"Resources/WMO/8or_pvp_warsongbg_tower01.new.wmo";
        public static BfAWMO BfAWMO;
        public static BfAWMO BfAWrittenWMO;

        [AssemblyInitialize]
        public static void InitializeWorldMapObjectRootTests(TestContext tc)
        {
            // Wotlk
            var wmo1 = new WotlkWMO(File.ReadAllBytes(WotlkWMOPath));
            WotlkWMO = wmo1;
            File.WriteAllBytes(WotlkWrittenWMOPath, wmo1.Serialize());
            WotlkWrittenWMO = new WotlkWMO(File.ReadAllBytes(WotlkWrittenWMOPath));

            // WoD
            /*var wmo2 = new WoDWMO(File.ReadAllBytes(BfAWMOPath));
            WoDWMO = wmo2;
            File.WriteAllBytes(BfAWrittenWMOPath, wmo2.Serialize());
            WoDWrittenWMO = new WoDWMO(File.ReadAllBytes(BfAWrittenWMOPath));*/

            // Legion
            /*var wmo3 = new LegionWMO(File.ReadAllBytes(BfAWMOPath));
            LegionWMO = wmo3;
            File.WriteAllBytes(BfAWrittenWMOPath, wmo3.Serialize());
            LegionWrittenWMO = new LegionWMO(File.ReadAllBytes(BfAWrittenWMOPath));*/

            // BfA
            var wmo4 = new BfAWMO(File.ReadAllBytes(BfAWMOPath));
            BfAWMO = wmo4;
            File.WriteAllBytes(BfAWrittenWMOPath, wmo4.Serialize());
            BfAWrittenWMO = new BfAWMO(File.ReadAllBytes(BfAWrittenWMOPath));
        }
    }
}
