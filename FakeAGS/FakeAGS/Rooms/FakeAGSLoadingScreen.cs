using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AGS.API;
using FakeAGS.API;

namespace FakeAGS.Engine
{
    public class FakeAGSLoadingScreen
    {
        protected string _id;
        protected IRoom _room;
        public IRoom Room
        {
            get { return _room; }
        }
        //private ICharacter _player;
        protected IGame _game;
        protected IAssetDef _def;


        protected Stopwatch _stopwatch;



        protected FakeAGSLoadingScreen(IGame game, string id, IAssetDef def)
        {
            _id = id;
            _game = game;
            _def = def;

            _room = _game.Factory.Room.GetRoom(_id);
        }


        //This method must be overridden
        protected virtual void CustomLoad()
        {
            //Put here all the custom things that must happen during load
        }

        public void Load()
        {

            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            CustomLoad();

            //Unlike a standard room, here we initiate and handle the "repeatedly execute" manually!
            //This is the first of an infinite number of recursive calls.
            onRepeatedlyExecute_internal();

            //Make sure that the engine takes everthing we've just inititliazed in consideration (i.e. displays it)
            _game.State.Rooms.Add(this._room);

        }

        //This method must be overridden
        public virtual void onRepeatedlyExecute()
        {
            //Put here all the custom things that must happen during each repeatedly execute
        }

        private async void onRepeatedlyExecute_internal()
        {
            if (notInRoom()) return;

            //When we're loading assets, FPS is all over the place, so we need to compensate
            const int speed = 60;
            long elapsed = _stopwatch.ElapsedMilliseconds;
            if (elapsed > speed)
            {
                int times = (int)elapsed / speed;

                for (int i = 0; i < times; i++)
                {
                    onRepeatedlyExecute(); //Let the end-user do their things
                }

                _stopwatch.Restart();
            }

            await Task.Delay(5);
            onRepeatedlyExecute_internal();
        }

        protected bool notInRoom()
        {
            return _game.State.Room != null && _game.State.Room != _room;
        }
    }
}

