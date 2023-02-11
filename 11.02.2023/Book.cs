using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._02._2023
{
    internal class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Genre { get; private set; }
        private Book() { }
        public Book(string name, string author, string genre)
        {
            Name = name;
            Author = author;
            Genre = genre;
        }
    }
}
