namespace P03_ImplemantationLinkedList
{
    public class ListNote<T>
    {
        public ListNote(T element)
        {
            this.Value = element;
        }

        public T Value { get; set; }

        public ListNote<T> NextNode { get; set; }

        public ListNote<T>  PreviosNode { get; set; }
    }
}
