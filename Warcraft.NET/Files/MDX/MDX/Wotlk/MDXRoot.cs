using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Warcraft.NET.Attribute;
using Warcraft.NET.Exceptions;
using Warcraft.NET.Extensions;
using Warcraft.NET.Files.Interfaces;
using Warcraft.NET.Files.MDX.Chunks;

namespace Warcraft.NET.Files.MDX.MDX.Wotlk
{
    public class MDXRoot : MDXRootBase
    {


        [ChunkOrder(1)]
        public MD20 MD20 { get; set; }


        public MDXRoot(byte[] inData) : base(inData) { }

        public override byte[] Serialize()
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                var terrainChunkProperties = GetType()
                    .GetProperties()
                    .OrderBy(p => ((ChunkOrderAttribute)p.GetCustomAttributes(typeof(ChunkOrderAttribute), false).Single()).Order);

                foreach (PropertyInfo chunkPropertie in terrainChunkProperties)
                {
                    IIFFChunk chunk = (IIFFChunk)chunkPropertie.GetValue(this);

                    if (chunk != null)
                    {
                        bw
                        .GetType()
                        .GetExtensionMethod(Assembly.GetExecutingAssembly(), "WriteIFFChunk")
                        .MakeGenericMethod(chunkPropertie.PropertyType)
                        .Invoke(null, new object[] { bw, chunkPropertie.GetValue(this), false });
                    }
                }

                return ms.ToArray();
            }
        }
    }
}
