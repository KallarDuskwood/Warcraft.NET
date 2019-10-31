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

namespace Warcraft.NET.Files.MDX.MDX
{
    public abstract class MDXRootBase
    {


        public MDXRootBase(byte[] inData)
        {

            LoadBinaryData(inData);

        }

        public void LoadBinaryData(byte[] inData)
        {

            using (var ms = new MemoryStream(inData))
            using (var br = new BinaryReader(ms))
            {
                var terrainChunkProperties = GetType()
                .GetProperties()
                .OrderBy(p => ((ChunkOrderAttribute)p.GetCustomAttributes(typeof(ChunkOrderAttribute), false).Single()).Order);

                foreach (PropertyInfo chunkProperty in terrainChunkProperties)
                {
                    try
                    {
                        var chunk = (IIFFChunk)br
                        .GetType()
                        .GetExtensionMethod(Assembly.GetExecutingAssembly(), "ReadIFFChunk")
                        .MakeGenericMethod(chunkProperty.PropertyType)
                        .Invoke(null, new object[] { br, true });

                        chunkProperty.SetValue(this, chunk);
                    }
                    catch (TargetInvocationException ex)
                    {
                        var chuckIsOptional = (ChunkOptionalAttribute)chunkProperty.GetCustomAttribute(typeof(ChunkOptionalAttribute), false);

                        // If chunk is not optional throw the exception
                        if (ex.InnerException.GetType() != typeof(ChunkSignatureNotFoundException) || chuckIsOptional == null || !chuckIsOptional.Optional)
                        {
                            throw ex.InnerException;
                        }
                    }
                }
            }
        }

        public abstract byte[] Serialize();


    }
}
