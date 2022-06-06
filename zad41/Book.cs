using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad41
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Year { get; set; }

        [ForeignKey("Author")]

        public int AuthorID;

        public Author Author { get; set; }
    }
}
