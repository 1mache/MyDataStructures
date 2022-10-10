namespace MyDataStructures
{
    static class QuickSort
    {
        private static int PivotHelper<T>(T[] array, int start, int end) where T: IComparable
        {
            var pivot = array[start];
            int swapId = start;

            for (int i = start+1; i < end+1; i++)
            {
                //if the element is smaller than the pivot we move it
                //to id after the previous smaller element.

                //that way we will have a sequence of elements that are
                //smaller than our pivot at the beginning of the
                //array right after the pivot itself
    
                if(pivot.CompareTo(array[i]) != -1)
                {
                    swapId++;
                    var temp = array[swapId];
                    array[swapId] = array[i];
                    array[i] = temp;
                }
            }
            //swaps the last element of the less sequence with the 
            //first element of the array which is the pivot.
            array[start] = array[swapId];
            array[swapId] = pivot;

            return swapId;
        }
        public static void Sort<T>(T[] array) where T: IComparable
        {
            //internal function is needed only so the main fuction
            //can have only one argument which is the array that needs sorting.

            //this is not possible with default arguments as (in .NET 6.0)
            //you cant have an argument default to a property of another argument
            //object which is needed here with the array length 
            T[] internalSort(T[] array, int left, int right)
            {
                if(left < right)
                {
                    var pivotId = PivotHelper(array, left, right);
                    //left
                    internalSort(array, left, pivotId-1);
                    //right
                    internalSort(array, pivotId +1, right);
                }

                return array;
            }

            internalSort(array, 0, array.Length -1);
        }
    }
}