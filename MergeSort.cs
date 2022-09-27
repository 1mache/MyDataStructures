namespace MyDataStructures
{
    static class MergeSort
    {
        private static T[] Merge<T>(T[] arr1, T[] arr2) where T: IComparable<T>
        {
            int len1 = arr1.Length, len2 = arr2.Length;

            if(len1 == 0) return arr2;
            if(len2 == 0) return arr1;

            var result = new T[arr1.Length + arr2.Length];

            int count1 = 0, count2 = 0, countRes = 0;
            //while the result array isnt filled up
            while(countRes < result.Length)
            {
                //if we`re done with the first array:
                //reached the end of first array
                if(count1 == len1) 
                {
                    //take the remaining elements of second array
                    result[countRes] = arr2[count2];
                    count2 ++;
                    countRes++;
                    continue;
                }
                //if second array reached the end first
                if(count2 == len2) 
                {
                    //take the remaining elements of first array
                    result[countRes] = arr1[count1];
                    count1 ++;
                    countRes++;
                    continue;
                }

                if(arr1[count1].CompareTo(arr2[count2]) == -1)
                {
                    result[countRes] = arr1[count1];
                    count1 ++;
                }
                else
                {
                    result[countRes] = arr2[count2];
                    count2 ++;
                }

                countRes++;
            }
            
            return result;
        }
        
        public static T[] Sort<T>(T[] array) where T: IComparable<T>
        {
            if(array is null)
            {
                throw new ArgumentNullException();
            }

            if(array.Length == 0 || array.Length == 1)
            {
                return array;
            }
            
            T[] half1 = new T[array.Length/2];
            T[] half2 = new T[array.Length - half1.Length];
            Array.Copy(array, 0, half1, 0, half1.Length);
            Array.Copy(array, array.Length/2, half2, 0, half2.Length);
            return Merge(Sort(half1), Sort(half2));
        }
    }
}