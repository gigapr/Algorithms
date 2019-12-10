using System;
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
        
        [Fact]
        public void Get_size()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            linkedList.AddHead(2);
            linkedList.AddTail("Third");
            linkedList.AddTail("4th");
            linkedList.RemoveHead();
            linkedList.RemoveTail();
            
            Assert.Equal(2, linkedList.Size);
        }
        
        
        [Fact]
        public void When_there_isnt_any_element_is_empty_is_true()
        {
            var linkedList = new LinkedList();
            
            Assert.True(linkedList.IsEmpty);
        }
        
        [Fact]
        public void When_there_are_elements_is_empty_is_false()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            
            Assert.False(linkedList.IsEmpty);
        }
        
        [Fact]
        public void When_getting_value_at_index_throws_if_out_of_bounds()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            linkedList.AddHead(2);
            
            Assert.Throws<IndexOutOfRangeException>(() => linkedList.ValueAt(5));
        }
        
        [Fact]
        public void Can_get_value_at_index()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            linkedList.AddHead(2);
            linkedList.AddTail("Third");
            linkedList.AddTail("4th");

            var value = linkedList.ValueAt(2);
            
            Assert.Equal("Third", value.Data);
        }
        
        [Fact]
        public void Can_insert_data_at_a_given_index()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            linkedList.AddHead(2);
            linkedList.AddTail("Third");
            linkedList.AddTail("4th");

            linkedList.InsertAt(2, "Due");

            var valueAtTwo = linkedList.ValueAt(2);
            Assert.Equal("Due", valueAtTwo.Data);
            Assert.Equal("Third", valueAtTwo.Next.Data);
        }
        
        [Fact]
        public void When_adding_value_at_index_throws_if_out_of_bounds()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            linkedList.AddHead(2);
            
            Assert.Throws<IndexOutOfRangeException>(() => linkedList.InsertAt(5, "5"));
        }
        
        [Fact]
        public void Can_remove_node_at_a_given_index()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            linkedList.AddHead(2);
            linkedList.AddTail("Third");
            linkedList.AddTail("4th");

            linkedList.RemoveAt(2);

            var valueAtTwo = linkedList.ValueAt(2);
            Assert.Equal("4th", valueAtTwo.Data);
        }
        
        [Fact]
        public void When_removing_node_at_index_throws_if_out_of_bounds()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            linkedList.AddHead(2);
            
            Assert.Throws<IndexOutOfRangeException>(() => linkedList.RemoveAt(5));
        }
        
        [Fact]
        public void Can_reverse_the_list()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail(1);
            linkedList.AddTail(2);
            linkedList.AddTail(3);
            linkedList.AddTail(4);
            linkedList.AddTail(5);

            linkedList.Reverse();

            Assert.Equal(5, linkedList.ValueAt(0).Data);
            Assert.Equal(4, linkedList.ValueAt(1).Data);
            Assert.Equal(3, linkedList.ValueAt(2).Data);
            Assert.Equal(2, linkedList.ValueAt(3).Data);
            Assert.Equal(1, linkedList.ValueAt(4).Data);
        }
    }
}