using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Workers
{
    class Program
    {
        static void Main(string[] args)
        {
            Workers.ArrayWorkers = new BaseWorker[30];
            for(var i = 0; i < Workers.ArrayWorkers.Length; i++)
            {
                var rnd = new Random();
                BaseWorker worker;
                Thread.Sleep(30);
                var rndResult = rnd.Next(0, 2);
                switch (rndResult)
                {
                    case 0:
                        worker = new FixedPayWorker($"Работник {i}", 20000);
                        break;
                    case 1:
                        worker = new HourlyPayWorker($"Работник {i}", 150 + rnd.Next(1,5));
                        break;
                    default:
                        worker = new FixedPayWorker($"Работник {i}", 20000);
                        break;
                }
                Workers.ArrayWorkers[i] = worker;
            }

            //использовал интерфейс Icomparer, так как не удалось в сортировке использовать метод WhatSalary
            Array.Sort(Workers.ArrayWorkers, new WorkerComparer());

            Console.WriteLine(Workers.ToString());
            Console.ReadLine();
        }
    }
}
