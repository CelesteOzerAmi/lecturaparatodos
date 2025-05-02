using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3
{
    public class Controller
    {
        private static List<Book> mListBooks = new List<Book>();

        public List<Book> ListBooks()
        {
            Book lib = new Book(1, "La", "Canada", "Seca", 1999, "Mv", "Dis");
            mListBooks.Add(lib);
            return mListBooks;
        }

        public bool UploadBook(Book pBook)
        {
            mListBooks.Add(pBook);
            return true;
        }

       
}
}
