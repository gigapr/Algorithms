using System;

namespace LinkedList
{
    public class LinkedList
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }

        public void AddTail(object data)
        {
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
            Head = Head.Next;
        }
    }
}