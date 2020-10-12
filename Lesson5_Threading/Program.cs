using System;
using System.Diagnostics;
using System.Threading;

namespace Lesson5_Threading
{
    class Program
    {

        static void Main(string[] args)
        {
            long sum1 = 0;
            object sum2 = 0;
            object sum3 = 0;
            object sum4 = 0;
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();

            int n = 1_000_000_003;

            stopwatch1.Start();
            summ(0, n, ref sum1);
            stopwatch1.Stop();

            Console.WriteLine($"Время подсчета суммы {n} = {sum1} чисел без потоков: " + stopwatch1.Elapsed); 

            //делим на три потока
            var thread1 = new calcSumInThread(0, n / 3, ref sum2);
            var thread2 = new calcSumInThread(n / 3 + 1, 2 * n / 3 + 1, ref sum3);
            var thread3 = new calcSumInThread(2 * n / 3 + 2, n, ref sum4);

            stopwatch2.Start();
            //стартуем потоки
            thread1.Start();
            thread2.Start();
            thread3.Start();
            //ждем завершения всех трех потоков
            thread1._thread.Join();
            thread2._thread.Join();
            thread3._thread.Join();
            stopwatch2.Stop();

            var sum5 = (int)sum2 + (int)sum3 + (int)sum4;

            Console.WriteLine($"Время подсчета суммы {n} = {sum5} чисел в 3 потока: " + stopwatch2.Elapsed);


            Console.ReadLine();

        }

        static void summ(int from, int to, ref long sum)
        {
            long res = 0;
            for (int i = from; i <= to; i++)
            {
                res += i;
            }

            sum = res;
        }
    }

    class calcSumInThread
    {
        private readonly int _from, _to;
        private long _res;
        object _sum;
        //пришлось нарушить инкапсуляцию для синхронизации мейна с этим потоком
        public Thread _thread;

        public void Start()
        {
            _thread.Start(_sum);
        }
        public calcSumInThread(int from, int to, ref object sum)
        {
            _from = from;
            _to = to;
            _thread = new Thread(SumMethod);
            _sum = sum;
        }

        private void SumMethod(object sum)
        {
            _res = 0;
            for (int i = _from; i <= _to; i++)
            {
                _res += i;
            }
            sum = _res;

        }
    }
}
