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
        public SpaceShip(Point Position, Point Direction, Size Size) 
            : base(Position, Direction, Size)
        {
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
