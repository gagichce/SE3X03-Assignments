using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionA4
{
    class Program
    {
        const double h = 0.1d;
        const double start = 0;
        const double stop = 10.01;
        const double ystart = 1;

        static void Main(string[] args)
        {
            PrintValues();

            Console.ReadKey();
        }

        public static void PrintValues()
        {
            var yCurrent = ystart;
            var tCurrent = start;
            while(tCurrent < stop)
            {
                Console.WriteLine("t: {0:0.0}, y: {1}", tCurrent, yCurrent);

                yCurrent = Program.yNext(yCurrent, tCurrent);
                tCurrent += h;
            }
        }

        public static double yNext(double Yn, double Tn)
        {
            var k0 = Program.k0(Yn, Tn);
            var k1 = Program.k1(Yn, Tn, k0);
            var k2 = Program.k2(Yn, Tn, k1);
            var k3 = Program.k3(Yn, Tn, k2);

            return Yn + (k0 + 2 * k1 + 2 * k2 + k3) / 6;
        }

        public static double f(double Yn, double Tn)
        {
            return 3 * Yn - 4 * Math.Exp(-Tn);
        }

        public static double k0(double Yn, double Tn)
        {
            return h * f(Yn, Tn);
        }

        public static double k1(double Yn, double Tn, double k0)
        {
            return h * f(Yn + k0 / 2, Tn + h / 2);
        }

        public static double k2(double Yn, double Tn, double k1)
        {
            return h * f(Yn + k1 / 2, Tn + h / 2);
        }

        public static double k3(double Yn, double Tn, double k2)
        {
            return h * f(Yn + k2, Tn + h);
        }
    }
}
