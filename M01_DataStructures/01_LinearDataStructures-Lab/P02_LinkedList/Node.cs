namespace P02_LinkedList
{
    public class Node<TEntity>
    {
        public Node(TEntity value)
        {
            this.Value = value;
        }

        public Node<TEntity> Next { get; set; }

        public Node<TEntity> Previous { get; set; }

        public TEntity Value { get; private set; }
    }
}
