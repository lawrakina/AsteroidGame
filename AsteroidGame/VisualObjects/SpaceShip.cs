﻿using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class SpaceShip : VisualObject, ICollision
    {
        private int _Energy = 20;
        public int Energy => _Energy;
        public event EventHandler ShipDestroyed;
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

        public override void Update() { }

        public void ChangeEnergy(int delta)
        {
            _Energy += delta;
            if (_Energy < 0)
                ShipDestroyed?.Invoke(this, EventArgs.Empty);

        }

        public void MoveUp()
        {
            if (_Position.Y > 0)
                _Position = new Point(_Position.X, _Position.Y - _Direction.Y);

        }
        public void MoveDown()
        {
            if (_Position.Y - _Size.Height < Game.Height)
                _Position = new Point(_Position.X, _Position.Y + _Direction.Y);
        }

        public bool CheckCollision(ICollision obj)
        {
            var is_collision = Rect.IntersectsWith(obj.Rect);
            if (is_collision && obj  is Asteroid asteroid)
            {
                ChangeEnergy(-asteroid.Power);
            }
            if (obj is Apteka apteka)
            {
                ChangeEnergy(apteka.Power);
            }
            return is_collision;
        }
    }
}
