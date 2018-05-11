using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGS.API;

namespace FakeAGS.API
{
    //This adds methods that I thought were missing in MonoAGS's IResourcePack
    public interface IFakeAGSResourcePack : IResourcePack
    {
        List<IResource> LoadAllDefinitionsRecursively();
        void LoadAllDefinitionsRecursively(string path, List<IResource> resources);
    }
}
