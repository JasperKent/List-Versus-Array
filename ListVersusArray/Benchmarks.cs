using BenchmarkDotNet.Attributes;

namespace ListVersusArray
{
    public class Benchmarks
    {
        private List<int> list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private int[] array =  { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        //[Benchmark(Baseline = true)]
        //public void Array()
        //{
        //    for (int i = 0; i < 10; ++i)
        //        array[i]++;
        //}

        //[Benchmark]
        //public void List()
        //{
        //    for (int i = 0; i < 10; ++i)
        //        list[i]++;
        //}

        public Benchmarks()
        {
            list = new List<int>();
            array = new int[10000];

            for (int i = 0; i < 10000; ++i)
            {
                list.Add(i);
                array[i] = i;
            }
        }

        [Benchmark(Baseline = true)]
        public int Array()
        {
            return array.Sum();
        }

        [Benchmark]
        public int List()
        {
            return list.Sum();
        }

        [Benchmark]
        public int ToArray()
        {
            return list.ToArray().Sum();
        }
    }
}
