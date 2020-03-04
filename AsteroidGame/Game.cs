using AsteroidGame.VisualObjects;
using AsteroidGame.VisualObjects.Interfaces;
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

            form.KeyDown += OnFormKeyDown;
        }

        private static void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    __Bullet = new Bullet(__Ship.Position.Y);
                    break;
                case Keys.Up:
                    __Ship.MoveUp();
                    break;
                case Keys.Down:
                    __Ship.MoveDown();
                    break;
            }
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        private static Bullet __Bullet;
        private static SpaceShip __Ship;
        public static void Load()
        {
            var game_objects = new List<VisualObject>();

            const int start_count = 150;
            const int star_size = 20;
            const int star_max_speed = 20;
            for (var i = 0; i < start_count; i++)
            {
                game_objects.Add(new Star(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(-1 * random.Next(1, star_max_speed), 0),
                    star_size));
            }

            //const int ellipses_count = 20;
            //const int ellipses_size_x = 20;
            //const int ellipses_size_y = 30;

            //for (var i = 0; i < ellipses_count; i++)
            //{
            //    game_objects.Add(new EllipseObject(
            //        new Point(600, i * 20),
            //        new Point(15 - i, 20 - i),
            //        new Size(ellipses_size_x, ellipses_size_y)));
            //}

            const int asteroid_count = 10;
            const int asteroid_max_size = 50;
            const int asteroid_max_speed = 10;
            for (var i = 0; i < asteroid_count; i++)
            {
                game_objects.Add(new Asteroid(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(-1 * random.Next(1, asteroid_max_speed), 0),
                    random.Next(5, asteroid_max_size)));
            }

            __GameObjects = game_objects.ToArray();
            __Bullet = new Bullet(200);
            __Ship = new SpaceShip(new Point(10, 200), new Point(5, 5), new Size(10, 10));
            __Ship.ShipDestroyed += OnShipDestroyed;
        }

        private static void OnShipDestroyed(object sender, EventArgs e)
        {
            __Timer.Stop();
            __Buffer.Graphics.Clear(Color.DarkBlue);
            __Buffer.Graphics.DrawString(
                "Корабль разрушен",
                new Font(FontFamily.GenericSerif, 30, FontStyle.Bold),
                Brushes.Red,
                200, 100);

            __Buffer.Render();
        }

        public static void Draw()
        {
            if (__Ship.Energy <= 0) return;
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            foreach (var visual_object in __GameObjects)
                visual_object?.Draw(g);

            __Bullet?.Draw(g);
            __Ship.Draw(g);

            g.DrawString(
                $"Energy: {__Ship.Energy}",
                new Font(FontFamily.GenericSerif, 14, FontStyle.Italic),
                Brushes.White,
                10,
                Game.Height - 70);

            __Buffer.Render();
        }

        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
                visual_object?.Update();

            __Bullet?.Update();

            for (var i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    __Ship.CheckCollision(collision_object);
                    if (__Bullet != null && __Bullet.CheckCollision(collision_object))
                    {
                        //__Bullet = new Bullet(new Random().Next(Width));
                        __Bullet = null;
                        __GameObjects[i] = null;
                        MessageBox.Show("Астероид закончился");
                    }
                }
            }
        }
    }
}
