namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<TEntity> : IAbstractTree<TEntity>
    {
        private Tree<TEntity> parent;
        private TEntity value;
        private readonly List<Tree<TEntity>> children;

        public Tree(TEntity value)
        {
            this.value = value;
            this.children = new List<Tree<TEntity>>();
        }

        public Tree(TEntity value, params Tree<TEntity>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(TEntity parentKey, Tree<TEntity> child)
        {
            var parentNode = this.FindNodeByKey(parentKey);

            bool isNull = parentNode == null;
            if (isNull)
            {
                throw new ArgumentNullException();
            }

            parentNode.children.Add(child);
        }

        public IEnumerable<TEntity> OrderBfs()
        {
            var result = new List<TEntity>();
            var queue = new Queue<Tree<TEntity>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var child in currentNode.children)
                {
                    queue.Enqueue(child);
                }

                result.Add(currentNode.value);
            }

            return result;
        }

        public IEnumerable<TEntity> OrderDfs()
        {
            var result = new Stack<TEntity>();
            var stack = new Stack<Tree<TEntity>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                foreach (var child in currentNode.children)
                {
                    stack.Push(child);
                }

                result.Push(currentNode.value);
            }

            return result;
        }

        public void RemoveNode(TEntity nodeKey)
        {
            Tree<TEntity> nodeToRemove = this.FindNodeByKey(nodeKey);

            bool isNull = nodeToRemove == null;
            if (isNull)
            {
                throw new ArgumentNullException();
            }

            Tree<TEntity> parent = nodeToRemove.parent;

            bool isRoot = parent == null;
            if (isRoot)
            {
                throw new ArgumentException();
            }

            parent.children.Remove(nodeToRemove);
        }

        public void Swap(TEntity firstKey, TEntity secondKey)
        {
            var firstNode = this.FindNodeByKey(firstKey);
            var secondNode = this.FindNodeByKey(secondKey);

            bool isNull = firstNode == null || secondNode == null;
            if (isNull)
            {
                throw new ArgumentNullException();
            }

            bool isRoot = firstNode.parent == null || secondNode.parent == null;
            if (isRoot)
            {
                throw new ArgumentException();
            }

            var firstNodeIndex = firstNode.parent.children.IndexOf(firstNode);
            var secondNodeIndex = secondNode.parent.children.IndexOf(secondNode);

            firstNode.parent.children.Remove(firstNode);
            secondNode.parent.children.Remove(secondNode);

            firstNode.parent.children.Insert(firstNodeIndex, secondNode);
            secondNode.parent.children.Insert(secondNodeIndex, firstNode);
        }

        private Tree<TEntity> FindNodeByKey(TEntity nodeKey)
        {
            Queue<Tree<TEntity>> queue = new Queue<Tree<TEntity>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                bool isEuqals = currentNode.value.Equals(nodeKey);
                if (isEuqals)
                {
                    return currentNode;
                }

                foreach (var child in currentNode.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
    }
}
