using Xunit;
using Xunit.Abstractions;

namespace LinkedList.Tests
{
    public class LinkedListTests
    {
        private readonly ITestOutputHelper _output;
        
        public LinkedListTests(ITestOutputHelper output)
        {
            _output = output;
        }
        
        [Fact]
        public void Add_item_to_linked_list_tail()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            linkedList.AddTail(2);
            linkedList.AddTail("Third");
            linkedList.AddTail("4th");
            
            Assert.Equal("First", linkedList.Head.Data);
            Assert.Equal(2, linkedList.Head.Next.Data);
            Assert.Equal("4th", linkedList.Tail.Data);
            Assert.Null(linkedList.Tail.Next);
        }
        
        [Fact]
        public void Remove_item_from_linked_list_tail()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            linkedList.AddTail(2);
            linkedList.AddTail("Third");
            linkedList.RemoveTail();
            
            Assert.Equal("First", linkedList.Head.Data);
            Assert.Equal(2, linkedList.Tail.Data);
            Assert.Null(linkedList.Tail.Next);
        }
        
        [Fact]
        public void Add_item_to_linked_list_head()
        {
            var linkedList = new LinkedList();
            linkedList.AddHead("First");
            linkedList.AddHead(2);
            linkedList.AddHead("Third");
            linkedList.AddHead("4th");
            
            Assert.Equal("4th", linkedList.Head.Data);
            Assert.Equal("Third", linkedList.Head.Next.Data);
            Assert.Equal("First", linkedList.Tail.Data);
            Assert.Null(linkedList.Tail.Next);
        }
        
        [Fact]
        public void Remove_linked_list_head()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            linkedList.AddTail(2);
            linkedList.AddTail("Third");
            linkedList.AddTail("4th");
            linkedList.RemoveHead();
            
            Assert.Equal(2, linkedList.Head.Data);
            Assert.Equal("Third", linkedList.Head.Next.Data);
            Assert.Equal("4th", linkedList.Tail.Data);
            Assert.Null(linkedList.Tail.Next);
        }
    }
}