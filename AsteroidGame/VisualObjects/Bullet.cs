using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class Bullet : CollisionObject
    {
        private const int __BulletSizeX = 20;
        private const int __BulletSizeY = 5;
        public Bullet(int Position)
            : base(new Point(0,Position), Point.Empty, new Size(__BulletSizeX, __BulletSizeY))
        {
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Red, Rect);
            g.DrawEllipse(Pens.White, Rect);
        }

        public override void Update()
        {
            _Position = new Point(_Position.X + 3, _Position.Y);
        }

        //public override bool CheckCollision(ICollision obj)
        //{
        //    var is_collision = Rect.IntersectsWith(obj.Rect);
        //    if (is_collision && obj is Asteroid asteroid)
        //    {
        //        ChangeEnergy(-asteroid.Power);
        //    }
        //    if (is_collision && obj is Apteka apteka)
        //    {
        //        ChangeEnergy(apteka.Power);
        //    }
        //    return is_collision;
        //}
    }
}
