﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Gamer gamer = new Gamer("Игрок 1", new DateTime(1990, 6, 16, 12, 5, 5));

            Gamer[] gamers = new Gamer[100];
            for (var i = 0; i < gamers.Length; i++)
            {
                var g = new Gamer($"Gamer {i + 1}", DateTime.Now.Subtract(TimeSpan.FromDays(365 * (i + 18))));
                gamers[i] = g;
            }

            gamer.SayYouName();

            Console.WriteLine();

            foreach (var g in gamers)
            { g.SayYouName(); }

            *//*gamer.SetName("Ffff");

            Console.WriteLine($"Your name {gamer.GetName()}");*//*


            gamer.Name = "123";


            Console.WriteLine($"Your name {gamer.Name}");
*/

            /*var space_ship = new SpaceShip(new Vector2D(5,7));
            var space_ship2 = space_ship;
            space_ship.Position = new Vector2D(150, -210);
            
*/
            var v1 = new Vector2D(1, 8);
            Console.WriteLine(v1);
            /*
            v1.X = 7;
            v1.Y = -14;

            var v3 = v1 + v2;
            var v4 = v2 - v1;

            var v5 = v4 + 7;
            var v6 = -v5;
*/

            var printer = new Printer();

            printer.Print("Print string");

            printer = new PrefixPrinter(">>>>>>>");

            printer.Print("Hello World!");

            printer = new DateTimeLogPrinter();

            printer.Print("test");

            Console.ReadLine();

        }
    }

    class Printer
    {
        public virtual void Print(string str)
        { Console.WriteLine(str); }
    }

    class PrefixPrinter : Printer
    {
        private string _Prefix;

        public PrefixPrinter(string Prefix) => _Prefix = Prefix;
        //public PrefixPrinter(string Prefix) { _Prefix = Prefix; }
        public override void Print(string str)
        {
            //Console.WriteLine("{0}{1}", _Prefix, str);
            base.Print($">>>>>>>>>>>{str}");
        }

    }

    class DateTimeLogPrinter : Printer
    {
        public override void Print(string str)
        {
            Console.Write(DateTime.Now);
            Console.Write(">>");
            base.Print(str);
        }
    }

    class FilePrinter : Printer
    {

        private string _FileName;
        public FilePrinter(string FileName) => _FileName = FileName;
        public override void Print(string str)
        {
            System.IO.File.AppendAllText(_FileName, str);
        }
    }

    class Gamer
    {
        private string _Name;
        private DateTime _DayOfBirth;
        public Gamer() { }
        public Gamer(string Name, DateTime DayOfBirth)
        {
            this._Name = Name;
            this._DayOfBirth = DayOfBirth;
        }

        /*public void SetName(string value) {
            _Name = value;
        }

        public string GetName() { return _Name; }
*/
        public string Name
        {
            get { return _Name ?? string.Empty; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                _Name = value;
            }
        }

        internal int GetNameLenght()
        {
            return Name.Length;
        }
        public void SayYouName()
        {
            Console.WriteLine($"My name is {_Name} - {_DayOfBirth:dd:MM:yyyy HH:mm:ss}");
        }
    }
}
