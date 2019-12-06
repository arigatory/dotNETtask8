using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotNETtask8
{
    class Inverser
    {
        public delegate double RealFunc(double x);

        public Action<double> PrecisionTracker ;

        public double Inverse(double a, double b, RealFunc f, double y, double epsilon)
        {
            double x = (b - a) / 2 + a;
            double fValue = f(x);
            while (Math.Abs(fValue-y)>epsilon)
            {
                
                if (fValue>y)
                {
                    b = x;
                    x = (b - a) / 2 + a;
                    fValue = f(x);
                }

                if (fValue < y)
                {
                    a = x;
                    x = (b - a) / 2 + a;
                    fValue = f(x);
                }
                Thread.Sleep(400);
                PrecisionTracker?.Invoke(Math.Abs(fValue - y));

                //Console.WriteLine($"a={a}; b={b}; x ={x}; f(x)={fValue}; y={y}");
            }
            return x;
        }
    }
}
