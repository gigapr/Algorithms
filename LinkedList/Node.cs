namespace LinkedList
{
    public class Node<T>
    {
        public object Data { get; }
        public Node<T> Next { get; set; }
        
        public Node(T data)
        {
            Data = data;
        }
        
        protected bool Equals(Node<T> other)
        {
            return Equals(Data, other.Data);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Node<T>) obj);
        }

        public override int GetHashCode()
        {
            return (Data != null ? Data.GetHashCode() : 0);
        }
    }
}