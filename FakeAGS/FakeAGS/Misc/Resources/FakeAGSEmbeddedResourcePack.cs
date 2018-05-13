using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using AGS.API;
using AGS.Engine;
using FakeAGS.API;

namespace FakeAGS.Engine
{


    public class FakeAGSEmbeddedResourcePack : EmbeddedResourcesPack, IFakeAGSResourcePack
    {
        public static string defFileName = "def.xml";
        protected Assembly _assembly;
        //protected string _assetsPath = "";
        public string AssetsPath { get; set; }
        public FakeAGSEmbeddedResourcePack(Assembly assembly, string customAssemblyName = null) : base(assembly, customAssemblyName)
        {
            _assembly = assembly;
            //AssetsPath = AssetsPathDetector.detectAssetsFolder(_fileSystem); //Some lousy heuristics detection

        }



        public List<IResource> LoadAllDefinitionsRecursively()
        {
            List<IResource> resources = new List<IResource>();

            /* NOT IMPLEMENTED YET
            string path = AssetsPath;
            if (!_fileSystem.DirectoryExists(path))
                throw new Exception("Expected Assets path does not exist : " + path);

            LoadAllDefinitionsRecursively(path, resources);
            */
            return resources;
            
        }

        public void LoadAllDefinitionsRecursively(string path, List<IResource> resources)
        {

            /* NOT IMPLEMENTED YET
            //path = ResolvePath(path); //is it meaningful to do that on expected directories?
            if (path == null) return;

            //Load resource definition in current directory
            string file = Path.Combine(path, defFileName).Replace("\\", "/");
            if (_fileSystem.FileExists(file))
            {
                if (resources == null) resources = new List<IResource>();
                IResource r = LoadResource(file);
                if (r != null)
                    resources.Add(r);
            }

            //recursively load subdirs
            foreach (string d in _fileSystem.GetDirectories(path))
            {
                LoadAllDefinitionsRecursively(d, resources);
            }
            */
        }

    }
}
