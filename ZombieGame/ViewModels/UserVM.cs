using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZombieGame.ViewModels.Base;

namespace ZombieGame.ViewModels
{
    internal class UserVM : ViewModel
    {
        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }
        private Point _Position;
        public Point Position
        {
            get => _Position;
            set => Set(ref _Position, value);
        }
        private Direction _Direction = Direction.LEFT;
        public Direction Direction
        {
            get => _Direction;
            set => Set(ref _Direction, value);
        }

        private int _HealsPoint;
        public int HealsPoint
        {
            get => _HealsPoint;
            set => Set(ref _HealsPoint, value);
        }
    }

    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
}
