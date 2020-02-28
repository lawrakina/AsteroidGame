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

            var timer = new Timer { Interval = 100 };
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
        private static Star[] __Stars;
        public static void Load()
        {
            __Stars = new Star[100];
            for (var j = 0; j < __Stars.Length; j++)
            {
                __Stars[j] = new Star(
                    new Point(Game.Width, j * random.Next(5, 50)),
                    new Point(-1 * j * random.Next(1, 3), 0),
                    10,
                    AsteroidGame.Properties.Resources.star);
            }

            __GameObjects = new VisualObject[30];
            for (var i = 0; i < __GameObjects.Length; i++)
            {
                __GameObjects[i] = new VisualObject(
                    new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(20, 20));
            }
        }

        public static void Draw()
        {
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            foreach (var star in __Stars)
                star.Draw(g);

            foreach (var visual_object in __GameObjects)
                visual_object.Draw(g);

            __Buffer.Render();
        }

        public static void Update()
        {
            foreach (var star in __Stars)
                star.Update();

            foreach (var visual_object in __GameObjects)
                visual_object.Update();

        }
    }
}
