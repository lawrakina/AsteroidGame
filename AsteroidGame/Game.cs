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

        public static int Width { get; set; }
        public static int Heght { get; set; }
        /*static Game()
        {

        }
*/
        public static void Initialize(Form form)
        {
            Width = form.Width;
            Heght = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0,0,Width,Heght));

            var timer = new Timer { Interval = 1000 };
            timer.Tick += OnTimewTick;
            timer.Start();
        }

        private static void OnTimewTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        public static void Load()
        {
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

            /*g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200));
            g.FillEllipse(Brushes.Red, new Rectangle(100,50,70,120));
*/
            foreach (var visual_object in __GameObjects)
                visual_object.Draw(g);

            __Buffer.Render();
        }

        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
                visual_object.Update();
        }
    }
}
