﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class Asteroid : ImageObject
    {
        public Asteroid(Point Position, Point Direction, int Size) 
            : base(Position, Direction, new Size(Size,Size), Properties.Resources.Asteroid)
        {
            
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
