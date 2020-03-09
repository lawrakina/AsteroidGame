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

        const int asteroid_count = 10;
        const int asteroid_max_size = 50;
        const int asteroid_max_speed = 10;
        private static int Score { get; set; } = 0;

        private delegate void Logger(string str);
        private static Logger __Logger;
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


        private static int __CtrlKeyPressed;
        private static int __UpKeyPressed;
        private static int __DownKeyPressed;
        private static void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    //__Bullet = new Bullet(__Ship.Position.Y);
                    //__Bullets.Add(new Bullet(__Ship.Position.Y));
                    __CtrlKeyPressed++;
                    break;
                case Keys.Up:
                    //__Ship.MoveUp();
                    __UpKeyPressed++;
                    break;
                case Keys.Down:
                    //__Ship.MoveDown();
                    __DownKeyPressed++;
                    break;
            }
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            while(__CtrlKeyPressed > 0)
            {
                __Bullets.Add(new Bullet(__Ship.Position.Y));
                __CtrlKeyPressed--;
            }
            while (__UpKeyPressed > 0)
            {
                __Ship.MoveUp();
                __UpKeyPressed--;
            }
            while (__DownKeyPressed > 0)
            {
                __Ship.MoveDown();
                __DownKeyPressed--;
            }
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        //private static Bullet __Bullet;
        private static SpaceShip __Ship;
        private static List<Bullet> __Bullets = new List<Bullet>();
        private static List<Asteroid> __Asteroids = new List<Asteroid>();
        private static List<Apteka> __Aptekas = new List<Apteka>();


        public static void Load()
        {
            var game_objects = new List<VisualObject>();

            //рисуем задний фон
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

            //добавляем астероиды
            __Asteroids = Asteroid.NewAsteroidCollection(
                new Random(), 
                Game.Width, Game.Height, 
                asteroid_max_speed, 
                asteroid_count, 
                asteroid_max_size);
            
            const int apteka_count = 10;
            for (var i = 0; i < apteka_count; i++)
            {
                __Aptekas.Add(new Apteka(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(-1 * random.Next(1, asteroid_max_speed), 0),
                    new Size(30, 30)));
            }
            
            __GameObjects = game_objects.ToArray();
            
            __Ship = new SpaceShip(new Point(10, 200), new Point(5, 5), new Size(10, 10));
            __Ship.ShipDestroyed += OnShipDestroyed;

            __Logger += LoggerConsole;
            __Logger += LoggerFile;
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

            //__Bullet?.Draw(g);
            foreach (var bullet in __Bullets) bullet?.Draw(g);
            //рисуем астероиды
            foreach (var asteroid in __Asteroids) asteroid?.Draw(g);
            //рисуем аптечки
            foreach (var apteka in __Aptekas) apteka?.Draw(g);


            __Ship.Draw(g);

            g.DrawString(
                $"Energy: {__Ship.Energy}, Score: {Score}",
                new Font(FontFamily.GenericSerif, 14, FontStyle.Italic),
                Brushes.White,
                10,
                Game.Height - 70);

            __Buffer.Render();
        }

        public static void Update()
        {
            //рисуем звезды
            foreach (var visual_object in __GameObjects)
                visual_object?.Update();

            //массивы на удаление
            var asteroid_to_remove = new List<Asteroid>();
            var bullets_to_remove = new List<Bullet>();
            var aptekas_to_remove = new List<Apteka>();

            //рисуем и обрабатываем столкновения с пулями
            foreach (var bullet in __Bullets)
            {
                bullet?.Update();

                if (bullet.Position.X > Game.Width)
                    bullets_to_remove.Add(bullet);
            }

            //если поизошло столкновение астероида с кораблем - удаляем астероид
            for (var i = 0; i < __Asteroids.Count; i++)
            {
                __Asteroids[i].Update();
                //проверка столкновения с астероидом
                __Ship.CheckCollision(__Asteroids[i]);
                if (__Asteroids[i].CheckCollision(__Ship))
                {
                    asteroid_to_remove.Add(__Asteroids[i]);
                    Score++;
                    __Logger($"Астероид уничтожен");
                }

                foreach (var bullet in __Bullets.ToArray())
                {
                    if (bullet.CheckCollision(__Asteroids[i]))
                    {
                        bullets_to_remove.Add(bullet);
                        asteroid_to_remove.Add(__Asteroids[i]);
                        Score++;
                        __Logger($"Астероид уничтожен");
                    }
                }
            }

            //обработка столкновения с аптечкой
            foreach (var apteka in __Aptekas)
            {
                apteka.Update();
                if (__Ship.CheckCollision(apteka))
                    aptekas_to_remove.Add(apteka);
            }

            //удаление ненужных объектов
            foreach (var asteriod in asteroid_to_remove)
            {
                __Asteroids.Remove(asteriod);
            }
            //если астероиды закончились до добавляем еще, на один больше
            if (__Asteroids.Count == 0)
                __Asteroids = Asteroid.NewAsteroidCollection(new Random(), Game.Width, Game.Height, asteroid_max_speed, asteroid_count + 1, asteroid_max_size);

            foreach (var bullet in bullets_to_remove)
            {
                __Bullets.Remove(bullet);
            }
        }


        private static void LoggerConsole(string v)
        {
            Console.WriteLine($">>>>>>>> {v}");
        }
        private static void LoggerFile(string message)
        {
            System.IO.File.AppendAllText("console.txt", $"{message}\r\n");
        }
    }
}
