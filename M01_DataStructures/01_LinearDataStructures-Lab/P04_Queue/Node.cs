namespace P04_Queue
{
    public class Node<TEntity>
    {
        public Node(TEntity value)
        {
            this.Value = value;
        }

        public Node<TEntity> Next { get; set; }

        public TEntity Value { get; private set; }

    }
}
