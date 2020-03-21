using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZombieGame.ViewModels.Base
{
    class BaseGameObjectViewModel : ViewModel
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
        public int Angle
        {
            get
            {
                switch (Direction)
                {
                    case Direction.UP:
                        return 0;
                    case Direction.RIGHT:
                        return 90;
                    case Direction.DOWN:
                        return 180;
                    case Direction.LEFT:
                        return 270;
                }
                return 0;
            }
        }
        public void Step()
        {
            switch (Direction)
            {
                case Direction.UP:
                    Position = new Point(Position.X, Position.Y - 1);
                    break;
                case Direction.RIGHT:
                    Position = new Point(Position.X + 1, Position.Y);
                    break;
                case Direction.DOWN:
                    Position = new Point(Position.X, Position.Y + 1);
                    break;
                case Direction.LEFT:
                    Position = new Point(Position.X - 1, Position.Y);
                    break;
            }
        }

        internal static Direction GetRandomDirection()
        {
            var v = rnd.Next(0, 4);
            switch (v)
            {
                case 0: return Direction.UP;
                case 1: return Direction.RIGHT;
                case 2: return Direction.DOWN;
                case 3: return Direction.LEFT;
            }
            return Direction.RIGHT;
        }

        internal static Point GetRandomPosition(int width, int height)
        {
            return new Point(rnd.Next(0, width + 1), rnd.Next(0, height + 1));
        }

        public static Random rnd = new Random();

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
