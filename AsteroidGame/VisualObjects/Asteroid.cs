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
        public int Power { get; set; } = 3;
        public Asteroid(Point Position, Point Direction, int Size)
            : base(Position, Direction, new Size(Size, Size), Properties.Resources.Asteroid)
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

        public static List<Asteroid> NewAsteroidCollection(Random random, int Width, int Height, int asteroid_max_speed, int asteroid_count, int asteroid_max_size)
        {
            var result = new List<Asteroid>();
            for (var i = 0; i < asteroid_count; i++)
            {
                result.Add(new Asteroid(
                                    new Point(random.Next(0, Width), random.Next(0, Height)),
                                    new Point(-1 * random.Next(1, asteroid_max_speed), 0),
                                    random.Next(5, asteroid_max_size)));
            }
            return result;
        }
    }
}
