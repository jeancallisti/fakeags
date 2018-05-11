using AGS.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAGS.API
{
    public interface IAssetDef
    {
        void Parse();
        void CustomParse();
        string GetValue(string key);
    }
}
