using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AGS.API;
using AGS.Engine;
using FakeAGS.API;

namespace FakeAGS.Engine
{


    public class FakeAGSResourcePack : FileSystemResourcePack, IFakeAGSResourcePack
    {
        public static string defFileName = "def.xml";
        protected IFileSystem _fileSystem;
        //protected string _assetsPath = "";
        public string AssetsPath { get; set; }
        public FakeAGSResourcePack(IFileSystem fileSystem) : base(fileSystem)
        {
            _fileSystem = fileSystem;
            AssetsPath = AssetsPathDetector.detectAssetsFolder(_fileSystem); //Some lousy heuristics detection
        }

        public bool LoadAssetDefinition(string path)
        {
            return _fileSystem.DirectoryExists(path);
        }

        public List<IResource> LoadAllDefinitionsRecursively()
        {
            List<IResource> resources = new List<IResource>();
            string path = AssetsPath;
            if (!_fileSystem.DirectoryExists(path))
                throw new Exception("Expected Assets path does not exist : " + path);

            LoadAllDefinitionsRecursively(path, resources);
            return resources;
        }

        public void LoadAllDefinitionsRecursively(string path, List<IResource> resources)
        {
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

        }

    }
}
