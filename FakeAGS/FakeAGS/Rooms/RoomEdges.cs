using AGS.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAGS.Engine
{
    public class RoomEdges
    {
        public float Top, Bottom, Left, Right;

        public static float defaultOffset = 20.0f;

        public static RoomEdges GetDefaultEdges(IGame game)
        {
            RoomEdges e = new RoomEdges();
           
            e.Top = defaultOffset;
            e.Left = defaultOffset;
            e.Bottom = game.Settings.WindowSize.Height - defaultOffset;
            e.Right = game.Settings.WindowSize.Width - defaultOffset;

            return e;
        }
    }
}
