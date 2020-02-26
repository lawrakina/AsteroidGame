﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    struct Vector2D
    {
        /*        private double _X;
                private double _Y;

                public double X { get { return _X; } set { _X = value; } }
                public double Y { get => _Y; set => _Y = value; }
        */
        public double X { get; set; }
        public double Y { get; set; }

        public double Lenght => Math.Sqrt(X * X + Y * Y);

        public Vector2D(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
