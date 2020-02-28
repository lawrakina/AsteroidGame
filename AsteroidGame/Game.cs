using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        /// <summary>
        /// Таймаут отрисовки одной сцены
        /// </summary>
        private const int __FrameTimeout = 10;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static Timer __Timer;

        private static Random random;
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            random = new Random();

            var timer = new Timer { Interval = __FrameTimeout };
            timer.Tick += OnTimerTick;
            timer.Start();

            __Timer = timer;
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        //private static Star[] __Stars;
        public static void Load()
        {
            var game_objects = new List<VisualObject>();

            const int start_count = 150;
            const int star_size = 20;
            const int star_max_speed = 20;
            for (var i = 0; i < start_count; i++)
            {
                game_objects.Add(new Star(
                    new Point(random.Next(0, Width), random.Next(0,Height)),
                    new Point(-1 * random.Next(1, star_max_speed), 0),
                    star_size));
            }

            const int ellipses_count = 20;
            const int ellipses_size_x = 20;
            const int ellipses_size_y = 30;

            for (var i = 0; i < ellipses_count; i++)
            {
                game_objects.Add( new EllipseObject(
                    new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(ellipses_size_x, ellipses_size_y)));
            }

            const int asteroid_count = 10;
            const int asteroid_max_size = 50;
            const int asteroid_max_speed = 20;
            for (var i = 0; i < asteroid_count; i++)
            {
                game_objects.Add(new Asteroid(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(-1 * random.Next(1, asteroid_max_speed), 0),
                    random.Next(5,asteroid_max_size)));
            }

            /*__Stars = new Star[100];
            for (var j = 0; j < __Stars.Length; j++)
            {
                __Stars[j] = new Star(
                    new Point(Game.Width, j * random.Next(5, 50)),
                    new Point(-1 * j * random.Next(1, 3), 0),
                    10,
                    AsteroidGame.Properties.Resources.star);
            }

            __GameObjects = new VisualObject[30];
            *//*for (var i = 0; i < __GameObjects.Length; i++)
            {
                __GameObjects[i] = new VisualObject(
                    new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(20, 20));
            }*/

            __GameObjects = game_objects.ToArray();
        }

        public static void Draw()
        {
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            /*foreach (var star in __Stars)
                star.Draw(g);*/

            foreach (var visual_object in __GameObjects)
                visual_object.Draw(g);

            __Buffer.Render();
        }

        public static void Update()
        {
            /*foreach (var star in __Stars)
                star.Update();
*/
            foreach (var visual_object in __GameObjects)
                visual_object.Update();

        }
    }
}
