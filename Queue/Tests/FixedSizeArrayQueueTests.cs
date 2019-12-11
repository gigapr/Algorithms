using System;
using Xunit;

namespace Queue.Tests
{
    public class FixedSizeArrayQueueTests
    {
        [Fact]
        public void Can_enqueue_data()
        {
            var linkedListQueue = new FixedSizeArrayQueue<int>(5);
            linkedListQueue.Enqueue(1);
            linkedListQueue.Enqueue(2);
            linkedListQueue.Enqueue(3);
            linkedListQueue.Enqueue(4);

            Assert.Equal(4, linkedListQueue.ElementsCount);
        }
        
        [Fact]
        public void Throws_when_enqueueing_too_many_elements()
        {
            var linkedListQueue = new FixedSizeArrayQueue<int>(5);
            linkedListQueue.Enqueue(1);
            linkedListQueue.Enqueue(2);
            linkedListQueue.Enqueue(3);
            linkedListQueue.Enqueue(4);
            linkedListQueue.Enqueue(5);
            
            Assert.Throws<Exception>(() => linkedListQueue.Enqueue(6));
        }
        
        [Fact]
        public void Can_dequeue_data()
        {
            var linkedListQueue = new FixedSizeArrayQueue<int>(5);
            linkedListQueue.Enqueue(1);
            linkedListQueue.Enqueue(2);
            linkedListQueue.Enqueue(3);
            linkedListQueue.Enqueue(4);
            
            var dequeued = linkedListQueue.Dequeue();
            Assert.Equal(1, dequeued);
            Assert.Equal(3, linkedListQueue.ElementsCount);
            
            dequeued = linkedListQueue.Dequeue();
            Assert.Equal(2, dequeued);
            Assert.Equal(2, linkedListQueue.ElementsCount);
        }
        
        [Fact]
        public void IsEmpty_is_true_when_there_are_no_elements()
        {
            var linkedListQueue = new FixedSizeArrayQueue<int>(5);
            
            Assert.True(linkedListQueue.IsEmpty);
        }
        
        [Fact]
        public void IsEmpty_is_false_when_there_are_elements()
        {
            var linkedListQueue = new FixedSizeArrayQueue<int>(5);
            linkedListQueue.Enqueue(1);
            
            Assert.False(linkedListQueue.IsEmpty);
        }
        
        [Fact]
        public void IsFull_is_true_when_the_elementscount_is_equal_the_queue_size()
        {
            var linkedListQueue = new FixedSizeArrayQueue<int>(5);
            linkedListQueue.Enqueue(1);
            linkedListQueue.Enqueue(2);
            linkedListQueue.Enqueue(3);
            linkedListQueue.Enqueue(4);
            linkedListQueue.Enqueue(5);
            
            Assert.True(linkedListQueue.IsFull);
        }
        
        [Fact]
        public void IsFull_is_false_when_the_elementscount_is_less_the_queue_size()
        {
            var linkedListQueue = new FixedSizeArrayQueue<int>(5);
            linkedListQueue.Enqueue(1);
            
            Assert.False(linkedListQueue.IsFull);
        }
        
        [Fact]
        public void Support_more_insertion_of_the_queue_size_if_the_elementscount_is_less_than_the_queue_size()
        {
            var linkedListQueue = new FixedSizeArrayQueue<int>(5);
            linkedListQueue.Enqueue(1);
            linkedListQueue.Enqueue(2);
            linkedListQueue.Enqueue(3);
            linkedListQueue.Enqueue(4);
            linkedListQueue.Enqueue(5);
            Assert.Equal(1, linkedListQueue.Dequeue());
            Assert.Equal(2, linkedListQueue.Dequeue());
            linkedListQueue.Enqueue(6);
            linkedListQueue.Enqueue(7);
            Assert.Equal(3, linkedListQueue.Dequeue());
            Assert.Equal(4, linkedListQueue.Dequeue());
            Assert.Equal(5, linkedListQueue.Dequeue());
            Assert.Equal(6, linkedListQueue.Dequeue());
            linkedListQueue.Enqueue(8);
            linkedListQueue.Enqueue(9);
            linkedListQueue.Enqueue(10);
            linkedListQueue.Enqueue(11);
            Assert.Equal(7, linkedListQueue.Dequeue());
            Assert.Equal(8, linkedListQueue.Dequeue());
            Assert.Equal(9, linkedListQueue.Dequeue());
            Assert.Equal(10, linkedListQueue.Dequeue());
            Assert.Equal(11, linkedListQueue.Dequeue());
            
            Assert.False(linkedListQueue.IsFull);
        }

        [Fact]
        public void Throws_an_exception_when_dequeuing_empty_queue()
        {
            var linkedListQueue = new FixedSizeArrayQueue<int>(5);

            Assert.Throws<Exception>(() => linkedListQueue.Dequeue());
        }
    }
}