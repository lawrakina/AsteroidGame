﻿using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class SpaceShip : VisualObject
    {
        private int _Energy = 100;
        public int Energy => _Energy;
        public SpaceShip(Point Position, Point Direction, Size Size)
            : base(Position, Direction, Size)
        {
        }

        public override void Draw(Graphics g)
        {
            var rect = Rect;
            g.FillEllipse(Brushes.Blue, rect);
            g.DrawEllipse(Pens.Yellow, rect);
        }

        public override void Update()
        {
        }

        public void ChangeEnergy(int delta)
        {
            _Energy += delta;
        }

        public void MoveUp(int offset = 1)
        {
            if (_Position.Y > 0)
                _Position = new Point(_Position.X, _Position.Y - _Direction.Y);

        }
        public void MoveDown(int offset = 1)
        {
            if (_Position.Y - _Size.Height > Game.Height)
                _Position = new Point(_Position.X, _Position.Y + _Direction.Y);
        }
    }
}
