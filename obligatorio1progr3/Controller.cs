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


        public bool CreateBook()
        {
            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Título:");
            string title = Console.ReadLine();

            Console.WriteLine("Autor:");
            string author = Console.ReadLine();

            Console.WriteLine("Género:");
            string genre = Console.ReadLine();

            Console.WriteLine("Año:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Sucursal:");
            string subsidiary = Console.ReadLine();

            Console.WriteLine("Estado:");
            string state = Console.ReadLine();

            Book abook = new Book(id, title, author, genre, year, subsidiary, state);
            UploadBook(abook);
            return true;
        }

        public bool UploadBook(Book pBook)
        {
            mListBooks.Add(pBook);
            return true;
        }

       
}
}
