using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class Asteroid : ImageObject, ICollision
    {
        public Asteroid(Point Position, Point Direction, int Size) 
            : base(Position, Direction, new Size(Size,Size), Properties.Resources.Asteroid)
        {
            
        }

        public bool CheckCollision(ICollision obj)
        {
            return Rect.IntersectsWith(obj.Rect);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
