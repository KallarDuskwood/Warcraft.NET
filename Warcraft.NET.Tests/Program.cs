using System.Diagnostics;
using System.IO;
using WMOBfA = Warcraft.NET.Files.WMO.WorldMapObject.BfA.WorldMapObjectRoot;
using WMOWotlk = Warcraft.NET.Files.WMO.WorldMapObject.Wotlk.WorldMapObjectRoot;

namespace Warcraft.NET.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            // BfA WMO Example
            var testWmoBfA = new WMOBfA(File.ReadAllBytes(@"Resources/WMO/8or_pvp_warsongbg_tower01.wmo"));
            File.WriteAllBytes(@"newBfA.wmo", testWmoBfA.Serialize());
            var writtenWmoBfA = new WMOBfA(File.ReadAllBytes(@"newBfA.wmo"));

            // WotLk WMO example
            var testWmoWotlk = new WMOWotlk(File.ReadAllBytes(@"Resources/WMO/prisonHQ_Redridge.wmo"));
            File.WriteAllBytes(@"newWotlk.wmo", testWmoWotlk.Serialize());
            var writtenWmoWotlk = new WMOWotlk(File.ReadAllBytes(@"newWotlk.wmo"));

            Debugger.Break();
        }
    }
}
