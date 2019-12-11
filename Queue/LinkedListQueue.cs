namespace Queue
{
    public class LinkedListQueueNode<T>
    {
        public T Data { get; }
        public LinkedListQueueNode<T> Next { get; set; }    
        
        public LinkedListQueueNode(T data)
        {
            Data = data;
        }
    }
    
    public class LinkedListQueue<T>
    {
        public LinkedListQueueNode<T> Head { get; private set; }
        public int Length { get; private set; }

        private LinkedListQueueNode<T> Tail { get; set; }

        public void Enqueue(T value)
        {
            var node = new LinkedListQueueNode<T>(value);
            
            Length++;
            
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
        }

        public LinkedListQueueNode<T> Dequeue()
        {
            Length--;
            var toReturn = Head;
            
            Head = toReturn.Next;
            
            return toReturn;
        }
    }
}