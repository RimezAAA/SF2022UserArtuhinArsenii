﻿using SF2022UserArtuhinArsenii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeSpan[] startTimes = new TimeSpan[]
            {
                new TimeSpan(10,0,0),
                new TimeSpan(11,0,0),
                new TimeSpan(15,0,0),
                new TimeSpan(15,30,0),
                new TimeSpan(16,50,0)
            };
            int[] durations = new int[]
            {
                60,
                30,
                10,
                10,
                40
            };
            Calculations calculations = new Calculations(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0), 30);
            foreach (var item in calculations.AvailablePeriods())
            {
                Console.WriteLine(item);
            }

            //TimeSpan[] startTimes = new TimeSpan[]
            //{
            //    new TimeSpan(9,0,0),
            //    new TimeSpan(12,0,0),
            //    new TimeSpan(13,0,0),
            //};
            //int[] durations = new int[]
            //{
            //    10,
            //    50,
            //    30,
            //};
            //TimeSpan beginWorkingTime = new TimeSpan(9, 0, 0);
            //TimeSpan endWorkingTime = new TimeSpan(16, 0, 0);
            //int consultationTime = 50;

            //Calculations calculations = new Calculations(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            //foreach (var item in calculations.AvailablePeriods())
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
