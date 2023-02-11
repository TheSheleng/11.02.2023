using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._02._2023
{
    internal class BookShelf
    {
        public enum Sorts
        {
            BookName,
            Author,
            Genre,
        }
        public SortedDictionary<string, Book> Books { get; private set; } = new SortedDictionary<string, Book>();
        public int Count { get => Books.Count; }
        public Book this[int index] { get => Books.ElementAt(index).Value; }
        Sorts sorttype;
        public Sorts SortType
        { 
            get => sorttype; 
            set 
            {
                sorttype = value;
                SortedDictionary<string, Book> bTemp = new SortedDictionary<string, Book>();
                foreach (var book in Books)
                {
                    switch (sorttype)
                    {
                        case Sorts.BookName: bTemp.Add(book.Value.Name, book.Value); break;
                        case Sorts.Author: bTemp.Add(book.Value.Author, book.Value); break;
                        case Sorts.Genre: bTemp.Add(book.Value.Name, book.Value); break;
                    }
                }
                Books = bTemp;
            }
        }
        private BookShelf() { }
        public BookShelf(Sorts SortType) => this.SortType = SortType;
        public void NewBook(Book book) 
        {
            switch (SortType) 
            {
                case Sorts.BookName: Books.Add(book.Name, book); break;
                case Sorts.Author: Books.Add(book.Author, book); break;
                case Sorts.Genre: Books.Add(book.Name, book); break;
            }
        }
        public void RemBook(int index) => Books.Remove(Books.ElementAt(index).Key);
        public static implicit operator string[](BookShelf bs)
        {
            string[] res = new string[bs.Count];
            for (int i = 0; i < bs.Count; i++)
            {
                res[i] = bs[i].Name;
            }
            return res;
        }
    }
}
