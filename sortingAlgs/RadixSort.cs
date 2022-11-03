namespace MyDataStructures
{
    static class RadixSort
    {
        private static int GetDigit(int num, int digitId)
        {
            if(digitId < 0)
                throw new ArgumentException("No such thing as negative digit index");

            return Math.Abs(num) / (int)Math.Pow(10, digitId * 1.0) % 10;
        } 
        
        private static int DigitCount(int num)
        {
            if(num == 0) return 1;
            return (int)Math.Log10(Math.Abs(num) * 1.0) + 1;
        }

        private static int MostDigits(int[] arr)
        {
            int max = 0;
            foreach (var num in arr)
            {
                if(DigitCount(num) > max)
                {
                    max = DigitCount(num);
                }
            }

            return max;
        }
        
        private static DynArray<int>[] InitializeBuckets()
        {
            var buckets = new DynArray<int>[10];
            for (int i = 0; i < 10; i++)
            {
                buckets[i] = new DynArray<int>();
            }
            return buckets;
        }

        public static int[] Sort(int[] array)
        {
            if(array == null)
                throw new ArgumentNullException();
            
            var maxDigits = MostDigits(array);

            for (int i = 0; i < maxDigits; i++)
            {
                var buckets = InitializeBuckets();
                foreach (var num in array)
                {
                    var digit = GetDigit(num, i);
                    buckets[digit].Add(num);
                }

                array = new int[]{};
                foreach (var bucket in buckets)
                {
                    array = array.Concat(bucket.ToArray()!).ToArray();                    
                }
            }

            return array;
        }
    }
}