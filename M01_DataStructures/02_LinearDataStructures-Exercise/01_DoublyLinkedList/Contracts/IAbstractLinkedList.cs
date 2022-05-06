namespace _01_DoublyLinkedList.Contracts
{
    using System.Collections.Generic;

    public interface IAbstractLinkedList<TEntity> : IEnumerable<TEntity>
    {
        int Count { get; }

        void AddFirst(TEntity item);

        TEntity RemoveFirst();

        TEntity GetFirst();

        void AddLast(TEntity item);

        TEntity RemoveLast();

        TEntity GetLast();
    }
}
