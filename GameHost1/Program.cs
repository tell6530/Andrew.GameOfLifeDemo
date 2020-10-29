﻿using System;
using System.Threading;

namespace GameHost1
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunGameOfLife();
        }

        private static void RunGameOfLife()
        {
            var map = new Map(50, 20);

            // TODO: 模擬時間經過取代 gen 迴圈?
            // var timeMachine = new TimeMachine();
            // var now = timeMachine.Now;
            // timeMachine.PassTime(new TimeSpan(0, 0, 1));

            for (int gen = 0; gen < 5000; gen++)
            {
                int live_count = 0;

                Thread.Sleep(200);
                Console.SetCursorPosition(0, 0);

                for (int y = 0; y < map.ColumnNum; y++)
                {
                    for (int x = 0; x < map.RowNum; x++)
                    {
                        var c = map.Cells[x, y];
                        live_count += (c.IsAlive ? 1 : 0);
                        Console.Write(c.IsAlive ? '★' : '☆');
                    }
                    Console.WriteLine();
                }

                map.GetNextGen();
                Console.WriteLine($"total lives: {live_count}, round: {gen} / 5000...");
            }
        }
    }
}
