using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace linearAlgebra
{
    class DoubleKeyDictionary
    {
        private List<Tuple<int, int, double>> list;

        public DoubleKeyDictionary()
        {
            list = new List<Tuple<int, int, double>>();
        }

        public void set(int first, int second, double third)
        {
            foreach (Tuple<int, int, double> x in list)
            {
                if(x.Item1 == first && x.Item2 == second)
                {
                    x.Item3 = third;
                    return;
                }
            }

            Tuple<int, int, double> tuple = new Tuple<int, int, double>();
            tuple.Item1 = first;
            tuple.Item2 = second;
            tuple.Item3 = third;
            list.Add(tuple);
        }

        public double? get(int first, int second)
        {
            double? found = null;
            foreach(Tuple<int, int, double> x in list)
            {
                if(x.Item1 == first && x.Item2 == second)
                {
                    found = x.Item3;
                }
            }

            return found;
        }
    }

    public class Tuple<T1, T2, T3>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public T3 Item3 { get; set; }
    }
}
