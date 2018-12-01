using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplicationMatrix
{
    class Program
    {
        static string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static object locker = new object();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random rnd = new Random();
            Console.SetWindowSize(80, 40);
            for (int i = 0; i < 20; i++)
            {
                new Thread(Write).Start(true);
            }
            Console.ReadLine();
        }

        static void Write(object needSecond)
        {
            bool needS = (bool)needSecond;
            Random rnd = new Random((int)DateTime.Now.Ticks);
            
            int left = rnd.Next(0, 80);
            while (true)
            {
                Thread.Sleep(rnd.Next(20, 5000));
                for (int i = 0; i < 40; i++)
                {
                    lock (locker)
                    {
                        Console.CursorTop = 0;
                        Console.ForegroundColor = ConsoleColor.Black;
                        for (int j = 0; j < i; j++)
                        {
                            Console.CursorLeft = left;
                            Console.WriteLine("█");
                        }
                        if (needS && i < 35)
                        {
                            new Thread(Write).Start(false);
                            needS = false;
                        }
                        if (i < 34)
                        {
                            Console.CursorLeft = left;
                            Console.ForegroundColor = (ConsoleColor)rnd.Next(0, 15);
                            Console.WriteLine(str[rnd.Next(0, str.Length - 1)]);
                        }
                        if (i < 35)
                        {
                            Console.CursorLeft = left;
                            Console.ForegroundColor = (ConsoleColor)rnd.Next(0, 15);
                            Console.WriteLine(str[rnd.Next(0, str.Length - 1)]);
                        }
                        if (i < 36)
                        {
                            Console.CursorLeft = left;
                            Console.ForegroundColor = (ConsoleColor)rnd.Next(0, 15);
                            Console.WriteLine(str[rnd.Next(0, str.Length - 1)]);
                        }
                        Console.CursorTop = i;
                        Thread.Sleep(3);
                    }
                }
            }
        }

    }
}
