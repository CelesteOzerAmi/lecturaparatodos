using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using obligatorio1progr3.Domain;

namespace obligatorio1progr3
{
    public class Controller
    {
        #region clients
        private static List<Client> mListClients = new List<Client>();

        public List<Client> ListClients()
        {
            Subsidiary ss = FindSubsidiary(1);
            Client cli = new Adult(2, "Jorge", "jorge@mail", 098, ss);
            Client clie = new Child(3, "antonio", "antoni@o", 018, ss, true);
            mListClients.Add(cli);
            mListClients.Add(clie);
            return mListClients;
        }

        public Client FindClient(int id)
        {
            foreach (Client client in mListClients)
            {
                if (client.Id == id)
                {
                    return client;
                }
            }
            return null;
        }

        public bool CreateClient()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());

            if (FindClient(id) != null)
            {
                return false;
            }

            Console.WriteLine("Nombre completo: ");
            string name = Console.ReadLine();

            Console.WriteLine("Correo electrónico: ");
            string mail = Console.ReadLine();

            Console.WriteLine("Teléfono:");
            int phoneNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Sucursal: ");
            foreach(Subsidiary sub in mListSubsidiaries)
            {
                Console.WriteLine($"Id: {sub.Id}, Nombre: {sub.Name}, Dir: {sub.Address}.");
            }
            Subsidiary s = FindSubsidiary(int.Parse(Console.ReadLine()));

            Console.WriteLine("¿Requiere autorización de adulto?");
            Console.WriteLine("1: Sí | 2: No");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                UploadClient(new Child(id, name, mail, phoneNumber, s, false));
                Console.WriteLine("Registro exitoso.");
                return true;
            }
            else
            {
                Console.WriteLine("¿Registra promoción por jubilado?");
                Console.WriteLine("1: Sí | 2: No");
                if(int.Parse(Console.ReadLine()) == 1)
                {
                    UploadClient(new Senior(id, name, mail, phoneNumber, s, true));
                    Console.WriteLine("Registro exitoso.");
                    return true;
                }
                else
                {
                    if(UploadClient(new Adult(id, name, mail, phoneNumber, s)))
                    {
                        Console.WriteLine("Registro exitoso.");
                        return true; 
                    }
                    else
                    {
                        Console.WriteLine("error al registrar, intente nuevamente.");
                        return false;
                    }
                }
            }
        }

        public bool UploadClient(Client c)
        {
            mListClients.Add(c);
            return true;
        }

        public bool DeleteClient()
        {
            Console.WriteLine("Ingrese ID");
            Client cli = FindClient(int.Parse(Console.ReadLine()));

            if (cli != null)
            {
                Console.WriteLine($"Id: {cli.Id}, {cli.Name}, {cli.PhoneNumber}");
                Console.WriteLine("¿Eliminar usuario?");
                Console.WriteLine("1. Confirmar | 2. Cancelar");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    foreach (Client c in mListClients)
                    {
                        if (c.Id == cli.Id)
                        {
                            mListClients.Remove(c);
                            Console.WriteLine("Usuario eliminado con exito.");
                            return true;
                        }
                    }
                }
                Console.WriteLine("Operación cancelada.");
                return false;
            }           
            Console.WriteLine("Usuario no existe");
            return false; 
        }
        #endregion

        #region books
        private static List<Book> mListBooks = new List<Book>();

        public List<Book> ListBooks()
        {
            Subsidiary s1 = new Subsidiary(12, "Tranqueras", "Tacuarembo", "Calle número 1", 43512323, FindManager(1));
            Book lib = new Book(1, "La cañada seca", "Horacio Quiroga", new Genre(1, "Terror"), 1999, s1, "Disponible");
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
                Console.WriteLine("Libro ya existe");
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
            foreach (Subsidiary s in mListSubsidiaries)
            {
                Console.WriteLine(s.Id.ToString() + ". " + s.Name);
            }
            Subsidiary subsidiary = FindSubsidiary(int.Parse(Console.ReadLine()));

            Console.WriteLine("Estado:");
            Console.WriteLine("1: Disponible | 2: No disponible.");
            string state;
            if(int.Parse(Console.ReadLine()) == 1)
            {
                state = "Disponible";
            }
            else
            {
                state = "No disponible";
            }

            mListBooks.Add(new Book(id, title, author, genre, year, subsidiary, state));
            Console.WriteLine("Libro añadido con éxito");
            return true;
        }

        public bool DeleteBook()
        {
            Console.WriteLine("Ingrese ID");
            Book boo = FindBook(int.Parse(Console.ReadLine()));

            if (boo != null)
            {
                Console.WriteLine($"Id: {boo.Id}, '{boo.Title}', {boo.Author}, {boo.Year}.");
                Console.WriteLine("¿Eliminar libro?");
                Console.WriteLine("1. Confirmar | 2. Cancelar");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    foreach (Book b in mListBooks)
                    {
                        if (b.Id == boo.Id)
                        {
                            mListBooks.Remove(b);
                            Console.WriteLine("Libro eliminado");
                            return true;
                        }
                    }
                }
                Console.WriteLine("Operación cancelada");
                return false;
            }
            Console.WriteLine("Libro no existe");
            return false;
        }

        public bool EditBook()
        {
            Console.WriteLine("Ingrese id");
            int id = int.Parse(Console.ReadLine()); 

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

                    foreach (Subsidiary s in mListSubsidiaries)
                    {
                        Console.WriteLine(s.Id.ToString() + ". " + s.Name);
                    }
                    book.Subsidiary = FindSubsidiary(int.Parse(Console.ReadLine()));

                    Console.WriteLine("Estado:");
                    Console.WriteLine("1: Disponible | 2: No disponible.");
                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        book.State = "Disponible";
                    }
                    else
                    {
                        book.State = "No disponible";
                    }
                    Console.WriteLine("Libro modificado con exito.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Libro no encontrado");
                    return false;
                }
            }
            Console.WriteLine("Error. Intente nuevamente.");
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

            mListGenres.Add(new Genre(id, name));
            Console.WriteLine("Género añadido con éxito");
            return true;
        }

        public bool DeleteGenre()
        {
            Console.WriteLine("Ingrese ID");
            Genre g = FindGenre(int.Parse(Console.ReadLine()));

            if (g != null)
            {
                Console.WriteLine($"Id: {g.Id}, {g.Name}.");
                Console.WriteLine("¿Eliminar género?");
                Console.WriteLine("1. Confirmar | 2. Cancelar");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    foreach (Genre gn in mListGenres)
                    {
                        if (gn.Id == g.Id)
                        {
                            mListGenres.Remove(gn);
                            Console.WriteLine("Género eliminado");
                            return true;
                        }
                    }
                }
                Console.WriteLine("Operación cancelada");
                return false;
            }
            Console.WriteLine("Género no existe");
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

            mListManagers.Add(new Manager(id, name, phoneNumber));
            Console.WriteLine("Encargado añadido con éxito");
            return true;
        }

        public bool DeleteManager()
        {
            Console.WriteLine("Ingrese ID");
            Manager m = FindManager(int.Parse(Console.ReadLine()));

            if (m != null)
            {
                Console.WriteLine($"Id: {m.Id}, {m.Name}.");
                Console.WriteLine("¿Eliminar encargado?");
                Console.WriteLine("1. Confirmar | 2. Cancelar");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    foreach (Manager ma in mListManagers)
                    {
                        if (ma.Id == m.Id)
                        {
                            mListManagers.Remove(ma);
                            Console.WriteLine("Encargado eliminado");
                            return true;
                        }
                    }
                }
                Console.WriteLine("Operación cancelada");
                return false;
            }
            Console.WriteLine("Encargado no existe");
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
            mListSubsidiaries.Add(new Subsidiary(id, name, city, address, number, manager));
            Console.WriteLine("Sucursal añadida con éxito.");
            return true;
        }

        public bool DeleteSubsidiary()
        {
            Console.WriteLine("Ingrese ID");
            Subsidiary su = FindSubsidiary(int.Parse(Console.ReadLine()));

            if (su != null)
            {
                Console.WriteLine($"Id: {su.Id}, {su.Name}. Dirección: {su.Address}, {su.City}.");
                Console.WriteLine("¿Eliminar sucursal?");
                Console.WriteLine("1. Confirmar | 2. Cancelar");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    foreach (Subsidiary s in mListSubsidiaries)
                    {
                        if (s.Id == su.Id)
                        {
                            mListSubsidiaries.Remove(s);
                            Console.WriteLine("Sucursal eliminada");
                            return true;
                        }
                    }
                }
                Console.WriteLine("Operación cancelada");
                return false;
            }
            Console.WriteLine("Sucursal no existe");
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
