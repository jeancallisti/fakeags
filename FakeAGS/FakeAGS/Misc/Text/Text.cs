using AGS.API;
using AGS.Engine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeAGS.API.Misc.Text
{
    public static class Text
    {

        public static ITextConfig getDefaultTextConfig()
        {
            return new AGSTextConfig(brush: AGSGame.Device.BrushLoader.LoadSolidBrush(Colors.WhiteSmoke),
                                      alignment: Alignment.MiddleCenter, autoFit: AutoFit.LabelShouldFitText);
        }

    }
}
