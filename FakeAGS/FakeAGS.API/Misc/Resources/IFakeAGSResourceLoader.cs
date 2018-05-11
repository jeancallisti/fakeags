using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeAGS.API
{
    /// <summary>
    /// Same as IResourceLoader, but with additional folder-related methods.
    /// </summary>
    public interface IFakeAGSResourceLoader
    {
        bool ExploreFolders(string path);
    }
}
