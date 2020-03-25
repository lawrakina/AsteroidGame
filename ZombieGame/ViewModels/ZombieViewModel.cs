using System;
using System.Windows;
using ZombieGame.ViewModels.Base;

namespace ZombieGame.ViewModels
{
    class ZombieViewModel : BaseGameObjectViewModel
    {
        public Type Type = Type.Zombie;

        public void RandomStep()
        {
            var v = rnd.Next(0,4);
            switch (v)
            {
                case 0: Direction = Direction.UP; break;
                case 1: Direction = Direction.RIGHT; break;
                case 2: Direction = Direction.DOWN; break;
                case 3: Direction = Direction.LEFT; break;
            }
            Step();
        }
       
    }
}
