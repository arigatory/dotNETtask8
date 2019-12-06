using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotNETtask8
{
    class Program
    {
        static private double epsilon = 1e-4;

        static void Main(string[] args)
        {
            Inverser inverser = new Inverser();
            inverser.PrecisionTracker += ShowProgress;
            Console.WriteLine("Находим значения х, при которых: \n");

            Console.WriteLine($"1.  0.5 = sin(x) на отрезке [0.1, 1.3]");
            Console.WriteLine($" Ответ: x = {inverser.Inverse(0.1, 1.3, delegate(double x){ return Math.Sin(x);}, 0.5, epsilon)}\n");
            
            
            Console.WriteLine($"2.  8 = x^2 + sin(x-2) на отрезке [2.5, 3.5]");
            Console.WriteLine($" Ответ: x = {inverser.Inverse(2.5, 3.5, x => x * x + Math.Sin(x - 2), 8, epsilon)}\n");

            Inverser.RealFunc myFunction = Sigmoida;
            Console.WriteLine($"3.  0.5 = Сигмоида(x) на отрезке [-4, 5]");
            Console.WriteLine($" Ответ: x = {inverser.Inverse(-4, 5, myFunction, 0.5, epsilon)}\n");
            
            Console.ReadLine();
        }

        static void ShowProgress(double current)
        {
            if (current > epsilon)
                Console.Write(
                    $"\r{Math.Log10(current) / Math.Log10(epsilon) * 100:0.}% (текущая точность: 10^{Math.Log10(current):0.})");
            else
                Console.WriteLine($"\r {100}% (текущая точность: 10^{Math.Log10(current):0.})");
        }

        static double Sigmoida(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }

}
