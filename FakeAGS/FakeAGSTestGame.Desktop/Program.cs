using System;
using AGS.Engine.Desktop;
using FakeAGSTestGame;

namespace FakeAGSTestGame.Desktop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            AGSEngineDesktop.Init();
            FakeAGSTestGameStarter.Run();
        }
    }
}
