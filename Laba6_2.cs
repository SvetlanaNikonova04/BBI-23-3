using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6_2
{
    using System;

    class Struct1
    {
        private string _famile;
        private double[] _x;
        public double _sred { get; private set; }

        public Struct1(string famile1, double[] x1)
        {
            _sred = 0;
            _famile = famile1;
            _x = x1;

            for (int i = 0; i < 4; i++)
            {
                _sred += _x[i];
            }

            _sred /= 4;
        }

        public void Print()
        {
            Console.WriteLine($"{_famile} {_sred}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Struct1[] cl = new Struct1[3]
            {
            new Struct1("Иванов", new double[] { 3.0, 5.0, 2.0, 3.0 }),
            new Struct1("Петров", new double[] { 5.0, 4.0, 5.0, 3.0 }),
            new Struct1("Сидоров", new double[] { 5.0, 4.0, 5.0, 5.0 })
            };

            PrintStructArray(cl);

            SortAndPrintByAverage(cl);

            Console.WriteLine();

            PrintStructArray(cl);
        }

        static void PrintStructArray(Struct1[] array)
        {
            foreach (var item in array)
            {
                item.Print();
            }
        }

        static void SortAndPrintByAverage(Struct1[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                double amax = array[i]._sred;
                int imax = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j]._sred > amax)
                    {
                        amax = array[j]._sred;
                        imax = j;
                    }
                }

                Struct1 temp = array[imax];
                array[imax] = array[i];
                array[i] = temp;
            }

            PrintStructArray(array);
        }
    }

}
