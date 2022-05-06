namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<TEntity> : IAbstractTree<TEntity>
    {
        private readonly List<Tree<TEntity>> children;

        public Tree(TEntity key, params Tree<TEntity>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<TEntity>>();

            foreach (var child in children)
            {
                this.Parent = this;
                this.children.Add(child);
            }
        }

        public TEntity Key { get; private set; }

        public Tree<TEntity> Parent { get; private set; }

        public IReadOnlyCollection<Tree<TEntity>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<TEntity> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<TEntity> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return this.DfsTreeAsString(new StringBuilder(), this, 0);
        }

        public Tree<TEntity> GetDeepestLeftomostNode()
        {
            var leafs = this.GetLeafsTree().ToList();

            int maxDepth = 0;
            Tree<TEntity> deepestLeaf = null;

            foreach (var leaf in leafs)
            {
                int depth = 0;
                depth = GetDepth(leaf, depth);

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestLeaf = leaf;
                }
            }

            return deepestLeaf;
        }

        public List<TEntity> GetLeafKeys()
        {
            return this.Dfs(x => x.children.Count == 0);
        }

        public List<TEntity> GetMiddleKeys()
        {
            return this.Dfs(x => x.Parent != null && x.children.Count > 0);
        }

        public List<TEntity> GetLongestPath()
        {
            Stack<TEntity> result = new Stack<TEntity>();
            var deepestLeaf = this.GetDeepestLeftomostNode();

            while (deepestLeaf.Parent != null)
            {
                result.Push(deepestLeaf.Key);
                deepestLeaf = deepestLeaf.Parent;
            }

            //Add root
            result.Push(deepestLeaf.Key);

            return result.ToList();
        }

        public List<List<TEntity>> PathsWithGivenSum(int targetSum)
        {
            var result = FindPathsWithGivenSum(
                this, 
                new List<TEntity>(), 
                new List<List<TEntity>>(), 
                targetSum, 
                0);

            return result;
        }

        public List<Tree<TEntity>> SubTreesWithGivenSum(int sum)
        {
            var result = FindAllSubtreesWithGivenSum(sum);

            return result;
        }

        private string DfsTreeAsString(StringBuilder sb, Tree<TEntity> currentNode, int depth)
        {
            sb.AppendLine($"{new string(' ', depth)}{currentNode.Key}");

            foreach (var child in currentNode.children)
            {
                this.DfsTreeAsString(sb, child, depth + 2);
            }

            return sb.ToString().TrimEnd();
        }

        private List<TEntity> Dfs(Func<Tree<TEntity>, bool> predicate)
        {
            List<TEntity> result = new List<TEntity>();
            Queue<Tree<TEntity>> queue = new Queue<Tree<TEntity>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (predicate.Invoke(currentNode))
                {
                    result.Add(currentNode.Key);
                }

                foreach (var child in currentNode.children)
                {
                    queue.Enqueue(child);
                }
            }

            var orderedList = result.OrderBy(x => x).ToList();

            return result;
        }

        private Stack<Tree<TEntity>> GetLeafsTree()
        {
            Stack<Tree<TEntity>> result = new Stack<Tree<TEntity>>();
            Stack<Tree<TEntity>> queue = new Stack<Tree<TEntity>>();
            queue.Push(this);

            while (queue.Count > 0)
            {
                var currentNode = queue.Pop();

                if (currentNode.children.Count == 0)
                {
                    result.Push(currentNode);
                }

                foreach (var child in currentNode.children)
                {
                    queue.Push(child);
                }
            }

            return result;
        }

        private static int GetDepth(Tree<TEntity> leaf, int depth)
        {
            while (leaf.Parent != null)
            {
                leaf = leaf.Parent;
                depth++;
            }

            return depth;
        }

        private List<List<TEntity>> FindPathsWithGivenSum(
            Tree<TEntity> tree, 
            List<TEntity> path, 
            List<List<TEntity>> result,
            int targetSum, 
            int currentSum)
        {
            path.Add(tree.Key);
            currentSum += int.Parse(tree.Key.ToString());
            if (targetSum == currentSum)
            {
                result.Add(new List<TEntity>(path));
            }

            foreach (var child in tree.children)
            {
                FindPathsWithGivenSum(child, path, result, targetSum, currentSum);
            }

            path.Remove(tree.Key);
            currentSum -= int.Parse(tree.Key.ToString());

            return result;
        }

        private List<Tree<TEntity>> FindAllSubtreesWithGivenSum(int targerSum)
        {
            var path = new List<TEntity>() { this.Key };
            var result = new List<Tree<TEntity>>();

            var queue = new Queue<Tree<TEntity>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentSubTree = queue.Dequeue();
                var currentSum = int.Parse(currentSubTree.Key.ToString());

                foreach (var child in currentSubTree.children)
                {
                    queue.Enqueue(child);
                    path.Add(child.Key);
                    currentSum += int.Parse(child.Key.ToString());
                }

                if (targerSum == currentSum)
                {
                    result.Add(currentSubTree);
                }

                path.Clear();
            }

            return result;
        }
    }
}
