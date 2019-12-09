using System;
using Xunit;

namespace LinkedList
{
    public class LinkedListTests
    {
        [Fact]
        public void Add_item_to_linked_list_tail()
        {
            var linkedList = new LinkedList();
            linkedList.AddTail("First");
            linkedList.AddTail(2);
            linkedList.AddTail("Third");
            linkedList.AddTail("4th");
            
            linkedList.Print();
            
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
            
            linkedList.Print();
            
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
            
            linkedList.Print();
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
            
            linkedList.Print();
            Assert.Equal(2, linkedList.Head.Data);
            Assert.Equal("Third", linkedList.Head.Next.Data);
            Assert.Equal("4th", linkedList.Tail.Data);
            Assert.Null(linkedList.Tail.Next);
        }
    }

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
                var next = Head;
                while (next != null)
                {
                    if (next.Next == null)
                    {
                        next.Next = node;
                        Tail = node;
                        break;
                    }
                    next = next.Next;
                }
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

        public void Print()
        {
            var current = Head;
            
            while (current != null)
            {
                Console.WriteLine(current.Data);
                
                current = current.Next;
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
            var headNext = Head.Next;
            Head = headNext;
        }
    }

    public class Node
    {
        public Node(object data)
        {
            Data = data;
        }

        public object Data { get; }
        public Node Next { get; set; }
        
        protected bool Equals(Node other)
        {
            return Equals(Data, other.Data);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            return (Data != null ? Data.GetHashCode() : 0);
        }
    }
}