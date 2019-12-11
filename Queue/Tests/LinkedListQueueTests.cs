using Xunit;

namespace Queue.Tests
{
    public class LinkedListQueueTests
    {
        [Fact]
        public void Can_enqueue_data()
        {
            var linkedListQueue = new LinkedListQueue<int>();
            linkedListQueue.Enqueue(1);
            linkedListQueue.Enqueue(2);
            linkedListQueue.Enqueue(3);
            linkedListQueue.Enqueue(4);

            Assert.Equal(4, linkedListQueue.Length);
            var head = linkedListQueue.Head;
            
            Assert.Equal(1, head.Data);
            Assert.Equal(2, head.Next.Data);
            Assert.Equal(3, head.Next.Next.Data);
            Assert.Equal(4, head.Next.Next.Next.Data);
        }
        
        [Fact]
        public void Can_dequeue_data()
        {
            var linkedListQueue = new LinkedListQueue<int>();
            linkedListQueue.Enqueue(1);
            linkedListQueue.Enqueue(2);
            linkedListQueue.Enqueue(3);
            linkedListQueue.Enqueue(4);
            
            var dequeued = linkedListQueue.Dequeue();
            Assert.Equal(1, dequeued.Data);
            Assert.Equal(3, linkedListQueue.Length);
            
            var head = linkedListQueue.Head;
            Assert.Equal(2, head.Data);
            Assert.Equal(3, head.Next.Data);
            Assert.Equal(4, head.Next.Next.Data);
        }
    }
}