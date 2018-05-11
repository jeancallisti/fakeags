using AGS.API;
using FakeAGS.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FakeAGS.Engine
{

    public class GameAssetDef : AssetDef
    {

        public GameAssetDef(IGame game, IResource resource) : base(game, resource)
        {

        }

        public override void CustomParse()
        {
            //TODO
            //XMLDef.Root.Descendants.ForEach() { };
        }


    }
}
