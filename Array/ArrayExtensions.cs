namespace Array
{
    public static class ArrayExtensions
    {
        public static void Reverse(this int[] theArray)
        {
            var theArrayLength = theArray.Length;
            var middle = theArrayLength / 2;
            
            for (var i = 0; i < middle; i++)
            {
                var current = theArray[i];
                var otherEnd = theArrayLength - i - 1;
                
                theArray[i] = theArray[otherEnd];
                theArray[otherEnd] = current;
            }
        }

        public static void Push(this int?[] theArray, int value)
        {
            var arrayLength = theArray.Length;
            var newArray = new int[arrayLength * 2];
            
            if (theArray[arrayLength - 1] != 0)
            {
                for (var i = 0; i < arrayLength; i++)
                {
                    newArray[i] = theArray[i];
                }

                newArray[arrayLength] = value;
                
                theArray = newArray;
            }
            else
            {
                theArray[theArray.Length] = value;
            }
        }
    }
}