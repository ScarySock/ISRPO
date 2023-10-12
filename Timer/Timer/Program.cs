using System;

namespace ConsoleApp1
{
    class Timer
    {
        private System.Diagnostics.Stopwatch t;
        private bool started;
        public void Start()
        {
            t = new System.Diagnostics.Stopwatch();
            t.Start();
            started = true;
        }
        public double Stop()
        {
            if (started)
            {
                t.Stop();
                started = false;
                return t.ElapsedMilliseconds;
            }
            return Double.NaN;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer();
            Console.WriteLine("Сейчас запустим таймер и паузу в 1 сек.");
            t.Start();
            System.Threading.Thread.Sleep(1000);
            double time = t.Stop();
            Console.WriteLine("Измеренное время = " + time + " мс");
        }
    }
}
