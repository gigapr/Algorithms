using Xunit;

namespace Array.Tests
{
    public class ArrayTests
    {
        [Fact]
        public void Can_reverse()
        {
            var array = new[] {1, 2, 3, 4, 5 };
            
            array.Reverse();
            
            Assert.Equal(new []{ 5, 4, 3, 2, 1}, array);
        }
        
        [Fact]
        public void Can_extend_array()
        {
            var array = new int[5] {1, 2, 3, 4, 5 };
            
            array.Push(6);
            
            Assert.Equal(6, array[6]);
        }
    }
}