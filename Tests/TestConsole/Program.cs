using System;
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
            var positions = new List<Vector2D>();
            for(var i = 0; i < 10; i++)
            {
                positions.Add(new Vector2D(10,10));
            }

            //positions[3].X = 7;

            Console.ReadLine();

        }
    }



}
