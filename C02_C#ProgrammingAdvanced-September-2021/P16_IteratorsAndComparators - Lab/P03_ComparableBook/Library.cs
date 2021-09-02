namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index = -1;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
            }

            public Book Current
            {
                get
                {
                    this.books.Sort();
                    return this.books[index];
                }
            }

            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                return ++index < books.Count;
            }

            public void Reset()
            {
                index = -1;
            }

            public void Dispose()
            {
            }
        }

        internal IEnumerable<object> Sort()
        {
            throw new NotImplementedException();
        }
    }
}
