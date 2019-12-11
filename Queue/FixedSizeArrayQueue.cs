using System;

namespace Queue
{
    public class FixedSizeArrayQueue<T> where T : struct
    {
        public int ElementsCount { get; private set; }
        public bool IsEmpty => ElementsCount == 0;
        public bool IsFull=> ElementsCount == _buffer;
        
        private readonly T?[] _queue;
        private int _writePosition;
        private int _readPosition;
        private readonly int _buffer;

        public FixedSizeArrayQueue(int buffer)
        {
            _buffer = buffer;
            _queue = new T?[buffer];
        }

        public void Enqueue(T data)
        {
            if (IsFull)
            {
                throw new Exception($"Trying to insert too many elements. Queue size is {_buffer}");
            }
            
            if (_queue.Length > _writePosition)
            {
                _queue[_writePosition] = data;
            }
            else
            {
                _writePosition = 0;
                _queue[_writePosition] = data;
            }
            _writePosition++;
            ElementsCount++;
        }

        public T Dequeue()
        {
            if (ElementsCount == 0)
            {
                throw new Exception("Unable to dequeue an empty queue");
            }
            T data;
                
            ElementsCount--;
            
            if (_queue.Length > _readPosition)
            {
                data = _queue[_readPosition].Value;
                _queue[_readPosition] = null;
               
            }
            else
            {
                _readPosition = 0;
                data = _queue[_readPosition].Value;
                _queue[_readPosition] = null;
            }
            _readPosition++;
                
            return data;
        }
    }
}