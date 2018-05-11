using AGS.API;
using AGS.Engine;
using FakeAGS.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FakeAGS
{
    public static class Extensions
    {
        /// <summary>
        /// Same as ResourceLoader::shouldIgnorePack. We would use the native one if it wasn't private instead of protected.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool shouldIgnoreFile(string path)
        {
            return path == null ||
                path.EndsWith(".DS_Store", StringComparison.Ordinal); //Mac OS file
        }


        /// <summary>
        /// Scans all subfolders of Assets and tries to read def.xml file in each of them
        /// </summary>
        /// <param name="r"></param>
        /// <param name="path">The path is relative to the Assets root folder! Not to the execution folder!</param>
        /// <returns></returns>
        public static List<IResource> LoadAllDefinitionsRecursively(this IResourceLoader r)
        {
            List<IResource> resources = new List<IResource>();

            //this list is private... We can't access it! Therefore we have to re-do the sorting job here (code duplication)
            List <IResourcePack> _sortedResourcePacks = new List<IResourcePack>(1);
            _sortedResourcePacks = r.ResourcePacks.OrderByDescending(p => p.Priority).Select(p => p.Pack).ToList();

            Debug.WriteLine("Load all assets recursively.");
            
            foreach (var pack in _sortedResourcePacks)
            {
                //Try to cast to our extended resource pack type. We do that in the last minute because we can't blend
                //IResourcePack and IFakeAGSResourcePack harmoniously, because important functions are 'private' in IResourceLoader
                //implementations. Therefore we force-insert IFakeAGSResourcePack items into the regular ResourceLoader
                //and gamble on the type that comes out later.
                try
                {
                    IFakeAGSResourcePack p = (IFakeAGSResourcePack)pack;
                    resources.AddRange(p.LoadAllDefinitionsRecursively());
                } catch (InvalidCastException ex)
                {
                    Debug.WriteLine($"WARNING : LoadAllAssetsRecursively not implemented for ResourcePacks of type {pack.GetType().ToString()}");
                }
            }
            return resources;
        }

        /*
        public static int ListFolders(this IResourceLoader r, string path)
        {
            return 666;
        }

        public static bool ListFolders(this FileSystemResourcePack r, string path)
        {
            return _fileSystem.DirectoryExists(path);
        }
        */

    }

}

