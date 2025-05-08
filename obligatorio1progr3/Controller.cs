using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using obligatorio1progr3.Domain;

namespace obligatorio1progr3
{
    public class Controller
    {
        #region books
        private static List<Book> mListBooks = new List<Book>();

        public List<Book> ListBooks()
        {
            Book lib = new Book(1, "La", "Canada", new Genre(1, "Terror"), 1999, "Mv", "Dis");
            mListBooks.Add(lib);
            return mListBooks;
        }

        public Book FindBook(int id)
        {
            foreach (Book book in mListBooks)
            {
                if (book.Id == id)
                    return book;
            }
            return null;
        }

        public bool CreateBook()
        {
            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            if (FindBook(id) != null)
            {
                return false;
            }

            Console.WriteLine("Título:");
            string title = Console.ReadLine();

            Console.WriteLine("Autor:");
            string author = Console.ReadLine();

            Console.WriteLine("Género:");
            foreach(Genre gen in mListGenres)
            {
                Console.WriteLine(gen.Id.ToString() + ". " + gen.Name);
            }
            Genre genre = FindGenre(int.Parse(Console.ReadLine()));

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

        public bool DeleteBook(int id)
        {
            foreach (Book book in mListBooks)
            {
                if (book.Id == id)
                {
                    mListBooks.Remove(book);
                    return true;
                }
            }
            return false;
        }

        public bool EditBook(int id)
        {
            foreach (Book book in mListBooks)
            {
                if (book.Id == id)
                {
                    Console.WriteLine("Título");
                    book.Title = Console.ReadLine();

                    Console.WriteLine("Autor:");
                    book.Author = Console.ReadLine();

                    Console.WriteLine("Género:");
                    foreach (Genre gen in mListGenres)
                    {
                        Console.WriteLine(gen.Id.ToString() + ". " + gen.Name);
                    }
                    book.Genre = FindGenre(int.Parse(Console.ReadLine()));

                    Console.WriteLine("Año");
                    book.Year = int.Parse(Console.ReadLine());

                    Console.WriteLine("Sucursal:");
                    book.Subsidiary = Console.ReadLine();

                    Console.WriteLine("Estado:");
                    book.State = Console.ReadLine();
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region genres
        private static List<Genre> mListGenres = new List<Genre>();

        public List<Genre> ListGenres()
        {
            Genre genre = new Genre(1, "Ficción");
            mListGenres.Add(genre);
            return mListGenres;
        }

        public Genre FindGenre(int id)
        {
            foreach (Genre genre in mListGenres)
            {
                if (genre.Id == id)
                    return genre;
            }
            return null;
        }

        public bool CreateGenre()
        {
            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            if (FindGenre(id) != null)
            {
                return false;
            }

            Console.WriteLine("Nombre: ");
            string name = Console.ReadLine();


            Genre genre = new Genre(id, name);
            UploadGenre(genre);
            return true;
        }

        public bool UploadGenre(Genre pGenre)
        {
            mListGenres.Add(pGenre);
            return true;
        }

        public bool DeleteGenre(int id)
        {
            foreach (Genre genre in mListGenres)
            {
                if (genre.Id == id)
                {
                    mListGenres.Remove(genre);
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region managers
        private static List<Manager> mListManagers = new List<Manager>();

        public List<Manager> ListManagers()
        {
            Manager manager = new Manager(1, "Juana Perez", 098282828);
            mListManagers.Add(manager);
            return mListManagers;
        }

        public Manager FindManager(int id)
        {
            foreach (Manager manager in mListManagers)
            {
                if (manager.Id == id)
                    return manager;
            }
            return null;
        }

        public bool CreateManager()
        {
            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            if (FindManager(id) != null)
            {
                return false;
            }

            Console.WriteLine("Nombre: ");
            string name = Console.ReadLine();

            Console.WriteLine("Teléfono: ");
            int phoneNumber = int.Parse(Console.ReadLine());

            Manager manager = new Manager(id, name, phoneNumber);
            UploadManager(manager);
            return true;
        }

        public bool UploadManager(Manager pManager)
        {
            mListManagers.Add(pManager);
            return true;
        }

        public bool DeleteManager(int id)
        {
            foreach (Manager manager in mListManagers)
            {
                if (manager.Id == id)
                {
                    mListManagers.Remove(manager);
                    return true;
                }
            }
            return false;
        }

        public bool EditManager(int id)
        {
            foreach(Manager manager in mListManagers)
            {
                if (manager.Id == id)
                {
                    Console.WriteLine("Ingrese nombre");
                    manager.Name = Console.ReadLine();
                    Console.WriteLine("Ingrese teléfono");
                    manager.PhoneNumber = int.Parse(Console.ReadLine());
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region subsidiaries
        private static List<Subsidiary> mListSubsidiaries = new List<Subsidiary>();

        public List<Subsidiary> ListSubsidiaries()
        {
            Subsidiary sub = new Subsidiary(1, "Las Piedras", "Canelones", "Calle bis 123 bis", 24123232, new Manager(122, "Roberto Lamas", 091919010));
            mListSubsidiaries.Add(sub);
            return mListSubsidiaries;
        }

        public Subsidiary FindSubsidiary(int id)
        {
            foreach (Subsidiary subsidiary in mListSubsidiaries)
            {
                if (subsidiary.Id == id)
                    return subsidiary;
            }
            return null;
        }

        public bool CreateSubsidiary()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());

            if (FindSubsidiary(id) != null)
            {
                return false;
            }

            Console.WriteLine("Nombre: ");
            string name = Console.ReadLine();

            Console.WriteLine("Ciudad: ");
            string city = Console.ReadLine();

            Console.WriteLine("Dirección: ");
            string address = Console.ReadLine();

            Console.WriteLine("Teléfono: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Encargado: ");
            foreach (Manager man in mListManagers)
            {
                Console.WriteLine(man.Id.ToString() + ". " + man.Name);
            }
            Manager manager = FindManager(int.Parse(Console.ReadLine()));

            Subsidiary asubsidiary = new Subsidiary(id, name, city, address, number, manager);
            UploadSubsidiary(asubsidiary);
            return true;
        }

        public bool UploadSubsidiary(Subsidiary pSubsidiary)
        {
            mListSubsidiaries.Add(pSubsidiary);
            return true;
        }

        public bool DeleteSubsidiary(int id)
        {
            foreach (Subsidiary subsidiary in mListSubsidiaries)
            {
                if (subsidiary.Id == id)
                {
                    mListSubsidiaries.Remove(subsidiary);
                    return true;
                }
            }
            return false;
        }

        public bool EditSubsidiary(int id)
        {
            foreach (Subsidiary subsidiary in mListSubsidiaries)
            {
                if (subsidiary.Id == id)
                {
                    Console.WriteLine("Nombre: ");
                    subsidiary.Name = Console.ReadLine();

                    Console.WriteLine("Ciudad: ");
                    subsidiary.City = Console.ReadLine();

                    Console.WriteLine("Dirección: ");
                    subsidiary.Address = Console.ReadLine();

                    Console.WriteLine("Teléfono: ");
                    subsidiary.Number = int.Parse(Console.ReadLine());

                    Console.WriteLine("Encargado: ");
                    foreach (Manager man in mListManagers)
                    {
                        Console.WriteLine(man.Id.ToString() + ". " + man.Name);
                    }
                    subsidiary.Manager = FindManager(int.Parse(Console.ReadLine()));
                }
            }
            return false;
        }
        #endregion
    }
}
