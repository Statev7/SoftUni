namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesByКeys;

        public TreeFactory()
        {
            this.nodesByКeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                int[] tokens = line.Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                int parent = tokens[0];
                int child = tokens[1];

                this.AddEdge(parent, child);
            }

            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!this.nodesByКeys.ContainsKey(key))
            {
                this.nodesByКeys.Add(key, new Tree<int>(key));
            }

            return this.nodesByКeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = this.CreateNodeByKey(parent);
            var childNode = this.CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        private Tree<int> GetRoot()
        {
            foreach (var kvp in this.nodesByКeys)
            {
                if (kvp.Value.Parent == null)
                {
                    return kvp.Value;
                }
            }

            return null;
        }
    }
}
