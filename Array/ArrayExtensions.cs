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
    }
}