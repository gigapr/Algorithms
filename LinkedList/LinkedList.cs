using System;

namespace LinkedList
{
    public class LinkedList
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public int Size { get; private set; }

        public bool IsEmpty => Head == null;

        public void AddTail(object data)
        {
            Size++;
            var node = new Node(data);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                if (Head.Next == null)
                {
                    Head.Next = node;
                }
                else
                {
                    Tail.Next = node;
                }
                Tail = node;
               
//                var next = Head;
//                while (next != null)
//                {
//                    if (next.Next == null)
//                    {
//                        next.Next = node;
//                        Tail = node;
//                        break;
//                    }
//                    next = next.Next;
//                }
            }
        }
        
        public void AddHead(object data)
        {
            Size++;
            var node = new Node(data);
            var currentHead = Head;

            if (currentHead == null)
            {
                Head = node;
            }
            else
            {
                node.Next = currentHead;
                Head = node;
            }

            if (Tail == null)
            {
                Tail = node;
            }
        }

        public void RemoveTail()
        {
            Size--;
            var current = Head;
            while (!current.Next.Equals(Tail))
            {
                current = current.Next;
            }

            current.Next = null;
            Tail = current;
        }

        public void RemoveHead()
        {
            Size--;
            Head = Head.Next;
        }

        public Node ValueAt(int index)
        {
            var count = 0;
            var current = Head;
            while (count <= index)
            {
                if (count == index)
                {
                    return current;
                }

                current = current.Next;
                if (current == null)
                {
                    throw new IndexOutOfRangeException($"Unable to get element at {index}. Linked list length is {count}");
                }
                count++;
            }
            
            throw new IndexOutOfRangeException();
        }

        public void InsertAt(int index, string data)
        {
            var count = 0;
            var current = Head;
            var previous = index - 1;
            var node = new Node(data);
            
            while (count <= index)
            {
                if (count == previous)
                {
                    node.Next = current.Next;
                    current.Next = node;
                    break;
                }

                current = current.Next;
                if (current == null)
                {
                    throw new IndexOutOfRangeException($"Unable to insert element at {index}. Linked list length is {count}");
                }
                count++;
            }
        }

        public void RemoveAt(int index)
        {
            var count = 0;
            var current = Head;
            var previous = index - 1;
            
            while (count <= index)
            {
                if (count == previous)
                {
                    var toBeRemoved = current.Next;
                    current.Next = toBeRemoved.Next;
                    break;
                }

                current = current.Next;
                if (current == null)
                {
                    throw new IndexOutOfRangeException($"Unable to insert element at {index}. Linked list length is {count}");
                }
                count++;
            }
        }

        public void Reverse()
        {
            Node previous = null;
            var current = Head;

            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            Head = previous;
        }
    }
}