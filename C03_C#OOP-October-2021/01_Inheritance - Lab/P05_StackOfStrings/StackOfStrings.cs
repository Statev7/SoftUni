namespace CustomStack
{
    using System.Collections.Generic;

    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(Stack<string> list)
        {
            while (list.Count != 0)
            {
                this.Push(list.Pop());
            }
        }
    }
}
