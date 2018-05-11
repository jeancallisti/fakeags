using System.Collections.Generic;

namespace FakeAGS.API
{
    /// <summary>
    /// Represents a font which is used when drawing text.
    /// </summary>
	public interface IAssetDefsFactory
    {
        List<IAssetDef> Process(string wildcard);
    }
}

