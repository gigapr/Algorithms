namespace LinkedList
{
    public class Node
    {
        public object Data { get; }
        public Node Next { get; set; }
        
        public Node(object data)
        {
            Data = data;
        }
        
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