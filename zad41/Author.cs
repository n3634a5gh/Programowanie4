using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad41
{
    internal class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public List<Book> Books { get; set; }
        public Author()
        {
            Books = new List<Book>();
        }

    }
}
