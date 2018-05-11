using AGS.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FakeAGS.Engine
{
    public static class AssetsPathDetector
    {
        private static string _assetsFolder = null;

        public static string detectAssetsFolder(IFileSystem fileSystem)
        {
            string rootPath = fileSystem.StorageFolder;

            if (_assetsFolder != null) return _assetsFolder;
            
            string path = "./Assets";
            for (int i=0; i<3; i++)
            {
                Debug.WriteLine("Detecting assets folder : trying "+Path.Combine(rootPath,path));
                var d = fileSystem.GetDirectories(path);
                if (fileSystem.DirectoryExists(path)) {
                    //path = fileSystem.GetFiles(path).First;
                    //_assetsFolder = Path.Combine(rootPath, path);
                    _assetsFolder = path;
                    return _assetsFolder;
                }
                path = "../"+path;
            }
            throw new Exception("Failed to automatically locate Assets subfolder."); 

        }
    }
}
