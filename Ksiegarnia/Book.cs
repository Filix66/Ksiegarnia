using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    public class Book
    {
        public string bookName { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public int bookId { get; set; }

        public override string ToString()
        {
            return "bookId: " + bookId + " bookName: " + bookName + " author: " + author + " description: " + description;
        }
    }
}
