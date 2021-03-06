﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class Star : ImageObject
    {
        private Image _Image;

        public Star(Point Position, Point Direction, int Size) 
            : base(Position, Direction, new Size(Size, Size), Properties.Resources.star)
        {
            _Image = Properties.Resources.star;
        }

        public override void Draw(Graphics g)
        {
            /*//Костыль, который показывает путь до картинки которая находится в проекте, а не в папке с исполняемым файлом
            string fileName = @"star.png";
            string pathToFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "");
            var indexOfStr = pathToFile.IndexOf("bin\\Debug");
            pathToFile = pathToFile.Substring(0, indexOfStr)+ fileName;

            g.DrawImage(Image.FromFile(pathToFile),_Position);*/

            g.DrawImage(_Image,_Position.X,_Position.Y,_Size.Width,_Size.Height);
        }

        public override void Update()
        {
            _Position = new Point(
                _Position.X + _Direction.X,
                _Position.Y + _Direction.Y);

            if (_Position.X < 0)
                _Position = new Point(Game.Width, _Position.Y);
        }
    }

    
}
