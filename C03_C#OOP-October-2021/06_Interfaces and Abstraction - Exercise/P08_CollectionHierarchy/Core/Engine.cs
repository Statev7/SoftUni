namespace CollectionHierarchy.Core
{
    using System;

    using CollectionHierarchy.Collections;
    using CollectionHierarchy.Collections.Interfaces;

    public class Engine
    {
        public void Run()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var addCollection = new AddCollection();
            var AddRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            this.AddOutput(input, addCollection);
            this.AddOutput(input, AddRemoveCollection);
            this.AddOutput(input, myList);

            var itemsToRemove = int.Parse(Console.ReadLine());

            this.RemoveOutput(itemsToRemove, AddRemoveCollection);
            this.RemoveOutput(itemsToRemove, myList);
        }

        private void AddOutput(string[] input, IAdd collection)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var element = input[i];
                var index = collection.Add(element);
                Console.Write(index + " ");
            }

            Console.WriteLine();
        }

        private void RemoveOutput(int itemsToRemove, IRemove collection)
        {
            for (int i = 0; i < itemsToRemove; i++)
            {
                var element = collection.Remove();
                Console.Write(element + " ");
            }

            Console.WriteLine();
        }
    }
}
