using AGS.API;
using AGS.Engine;
using FakeAGS.API;
using FakeAGS.API.Misc.Text;
using FakeAGS.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAGSTestGame
{
    public class SplashScreen : FakeAGSLoadingScreen
    {


        private ILabel _label;
        private Action _visitTween;

        public string LoadingText = "Loading";
        public ITextConfig TextConfig = Text.getDefaultTextConfig();

        public SplashScreen(IGame game, string id, IAssetDef def) : base(game, id, def)
        {

        }

        public override void onRepeatedlyExecute()
        {
            _visitTween();
        }

        //This method called automatically when you call Load
        protected override void CustomLoad()
        {
            //_splashScreen = game.Factory.Room.GetRoom("Splash Screen");
            
            _label = _game.Factory.UI.GetLabel("Splash Label", LoadingText, 1f,
                                               1f, _game.Settings.VirtualResolution.Width / 2f,
                                               _game.Settings.VirtualResolution.Height / 2f,
                                               config: TextConfig, addToUi: false);
            _label.Pivot = new PointF(0.5f, 0.5f);

            _room.Objects.Add(_label);
            _room.ShowPlayer = false;

            tweenLabel();

        }

        private async void tweenLabel()
        {
            if (notInRoom()) return;

            //define bouncing outwards
            var tween = Tween.RunWithExternalVisit(_label.ScaleX, 1.5f, scale => _label.Scale = new PointF(scale, scale),
                                                   3f, Ease.BounceOut, out _visitTween);

            //wait until it has reached maximum expansion
            await tween.Task;

            //Now, bounce inwards
            tween = Tween.RunWithExternalVisit(_label.ScaleX, 1f, scale => _label.Scale = new PointF(scale, scale),
                                                   3f, Ease.BounceOut, out _visitTween);
            //Wait until it has shrinked
            await tween.Task;

            //Repeat
            tweenLabel();
        }



    }
}
