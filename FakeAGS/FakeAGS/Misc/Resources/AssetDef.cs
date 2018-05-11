using AGS.API;
using FakeAGS.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace FakeAGS.Engine
{
    public class AssetDef : IAssetDef
    {
        private IResource _resource;
        private IGame _game;
        private XDocument _xmlDef;

        public XDocument XMLDef { get { return _xmlDef;  } }

        public AssetDef(IGame game, IResource resource)
        {
            _game = game;
            _resource = resource;
        }
        public void Parse()
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(_resource.Stream))
                {
                    _xmlDef = XDocument.Load(reader);
                }

                CustomParse(); //this is different for every definition type
            } catch (Exception ex)
            {
                Debug.WriteLine($"Failed to parse XML file '{_resource.ID}'.");
            }
        }

        public virtual void CustomParse()
        {
            throw new NotImplementedException("You need to override this function");
        }

        public string GetValue(string key)
        {
            XElement result = XMLDef.Root.Descendants().Where(d => d.Name.ToString().ToUpperInvariant().Equals(key.ToUpperInvariant())).FirstOrDefault();
            if (result != null && !string.IsNullOrEmpty(result.Name.ToString())) return result.Value.ToString();
            return "";
        }
    }
}
