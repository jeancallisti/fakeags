using AGS.API;
using FakeAGS.API;
using FakeAGS.Engine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeAGS.Engine
{
    public class AssetDefsFactory : IAssetDefsFactory
    {
        public List<IAssetDef> assetsDefs = new List<IAssetDef>();

        private IGame _game;
        private List<IResource> _resources;

        public AssetDefsFactory(IGame game, List<IResource> resources)
        {
            _game = game;
            _resources = resources;
        }
        public List<IAssetDef> Process(string wildcard)
        {
            var subset = _resources.Where(x => Wildcard.Matches(wildcard, x.ID));

            foreach (IResource r in subset)
            {
                IAssetDef assetDef = null;
                
                if (r.ID.Contains("Assets/Game")) assetDef = new GameAssetDef(_game, r);
                else if (r.ID.Contains("Assets/Rooms")) assetDef = new RoomAssetDef(_game, r);
                else
                {
                    throw new NotImplementedException($"Could not infere the asset type from the wildcard '{wildcard}'");
                }

                //TODO! IMPORTANT! Check (CPU-efficiently) if not already processed before with another wildcard!
                assetsDefs.Add(assetDef);
            }

            foreach(IAssetDef assetDef in assetsDefs)
            {
                assetDef.Parse();
            }

            return assetsDefs;
        }

    }
}
