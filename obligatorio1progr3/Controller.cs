using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using obligatorio1progr3.Domain;
using obligatorio1progr3.Persistence;

namespace obligatorio1progr3
{
    public class Controller
    {

        #region clients
        private static List<Client> mListClients = new List<Client>();

        public List<Client> ListClients()
        {
            List<Client> clients = new List<Client>();
            foreach (Senior s in PSenior.Listar()) {
                clients.Add(new Client(s.Id, s.Name, s.Mail, s.PhoneNumber, s.Subsidiary, "Senior"));
            }
            foreach (Child c in PChild.listar())
            {
                clients.Add(new Client(c.Id, c.Name, c.Mail, c.PhoneNumber, c.Subsidiary, "Child"));
            }
            foreach (Adult a in PAdult.listar())
            {
                clients.Add(new Client(a.Id, a.Name, a.Mail, a.PhoneNumber, a.Subsidiary, "Adult"));
            }
            return clients;
        }

        public Client FindClient(int id)
        {
            Client client = null;
            if (PSenior.Conseguir(id) != null)
            {
                Senior s = PSenior.Conseguir(id);
                client = new Client(s.Id, s.Name, s.Mail, s.PhoneNumber, s.Subsidiary, "Senior");
            }
            
            if (PChild.conseguir(id) != null)
            {
                Child c = PChild.conseguir(id);
                client = new Client(c.Id, c.Name, c.Mail, c.PhoneNumber, c.Subsidiary, "Child");
            }
            
            if (PAdult.conseguir(id) != null)
            {
                Adult a = PAdult.conseguir(id);
                client = new Client(a.Id, a.Name, a.Mail, a.PhoneNumber, a.Subsidiary, "Adult");
            }
            
            return client;
        }

        public Adult FindAdult(int id)
        {
            return PAdult.conseguir(id);
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
            foreach (Subsidiary sub in PSubsidiary.ListSubsidiaries())
            {
                Console.WriteLine($"Id: {sub.Id}, Nombre: {sub.Name}, Dir: {sub.Address}.");
            }
            Subsidiary s = FindSubsidiary(int.Parse(Console.ReadLine()));

            Console.WriteLine("¿Requiere autorización de adulto?");
            Console.WriteLine("1: Sí | 2: No");
            if (Console.ReadLine() == "1")
            {
                PChild.alta(new Child(id, name, mail, phoneNumber, s, true));
                Console.WriteLine("Registro exitoso.");
                return true;
            }
            else
            {
                Console.WriteLine("¿Registra promoción por jubilado?");
                Console.WriteLine("1: Sí | 2: No");
                if (Console.ReadLine() == "1")
                {
                    PSenior.Alta(new Senior(id, name, mail, phoneNumber, s, true));
                    Console.WriteLine("Registro exitoso.");
                    return true;
                }
                else
                {
                    PAdult.alta(new Adult(id, name, mail, phoneNumber, s));
                    return true;
                }
            }
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
                if (Console.ReadLine() == "1")
                {
                    DetermineClientDeletion(cli.Id);
                }
                Console.WriteLine("Operación cancelada.");
                return false;
            }
            Console.WriteLine("Usuario no existe");
            return false;
        }
        #endregion

        #region books

        public List<Book> ListBooks()
        {
            return PBook.ListBooks();
        }

        public bool CreateBook()
        {
            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            if (PBook.GetBook(id) != null)
            {
                Console.WriteLine("Libro ya existe");
                return false;
            }

            Console.WriteLine("Título:");
            string title = Console.ReadLine();

            Console.WriteLine("Autor:");
            string author = Console.ReadLine();

            Console.WriteLine("Género:");
            foreach (Genre gen in PGenre.ListGenres())
            {
                Console.WriteLine($"{gen.Id}, {gen.Name}.");
            }
            Genre genre = FindGenre(int.Parse(Console.ReadLine()));

            Console.WriteLine("Año:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Sucursal:");
            foreach (Subsidiary s in PSubsidiary.ListSubsidiaries())
            {
                Console.WriteLine($"{s.Id}, {s.Name}.");
            }
            Subsidiary subsidiary = FindSubsidiary(int.Parse(Console.ReadLine()));

            Console.WriteLine("Estado:");
            Console.WriteLine("1: Disponible | 2: No disponible.");
            bool available = false;
            if (int.Parse(Console.ReadLine()) == 1)
            {
                available = true;
            }
           
            if(PBook.Upload(new Book(id, title, author, genre, year, subsidiary, available)))
            {
                Console.WriteLine("Libro añadido con éxito");
                return true;
            }

            Console.WriteLine("Error al registrar libro");
            return false;
            
        }

        public bool DeleteBook()
        {
            Console.WriteLine("Ingrese ID");
            Book boo = PBook.GetBook(int.Parse(Console.ReadLine()));

            if (boo != null)
            {
                Console.WriteLine($"Id: {boo.Id}, '{boo.Title}', {boo.Author}, {boo.Year}.");
                Console.WriteLine("¿Eliminar libro?");
                Console.WriteLine("1. Confirmar | 2. Cancelar");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    if (PBook.Delete(boo.Id))
                    {
                        Console.WriteLine("Libro eliminado");
                        return true;
                    }
                    Console.WriteLine("Error al eliminar");
                    return false;
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
            Book book = PBook.GetBook(id);
            if (book != null)
            {
                Console.WriteLine("Título");
                book.Title = Console.ReadLine();

                Console.WriteLine("Autor:");
                book.Author = Console.ReadLine();

                Console.WriteLine("Género:");
                foreach (Genre g in PGenre.ListGenres())
                {
                    Console.WriteLine($"{g.Id}, {g.Name}.");
                }
                book.Genre = FindGenre(int.Parse(Console.ReadLine()));

                Console.WriteLine("Año");
                book.Year = int.Parse(Console.ReadLine());

                foreach (Subsidiary s in PSubsidiary.ListSubsidiaries())
                {
                    Console.WriteLine($"{s.Id}, {s.Name}.");
                }
                book.Subsidiary = FindSubsidiary(int.Parse(Console.ReadLine()));

                Console.WriteLine("Estado:");
                Console.WriteLine("1: Disponible | 2: No disponible.");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    book.Available = true;
                }
                else
                {
                    book.Available = false;
                }
                if (PBook.Update(book))
                {
                    Console.WriteLine("Libro modificado con exito.");
                    return true;
                }
                Console.WriteLine("Error al modificar libro");
                return false;
            }
            else
            {
                Console.WriteLine("Libro no encontrado");
                return false;
            }
        }


        #endregion

        #region genres
        public List<Genre> ListGenres()
        {
            return PGenre.ListGenres();
        }

        public Genre FindGenre(int id)
        {
            foreach (Genre genre in ListGenres())
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

            PGenre.Upload(new Genre(id, name));
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
                    if (PGenre.Delete(g.Id))
                    {
                        Console.WriteLine("Género eliminado con éxito.");
                        return true;
                    }
                }
                Console.WriteLine("Operación cancelada.");
                return false;
            }
            Console.WriteLine("Género no existe.");
            return false;
        }

        #endregion

        #region managers
        public List<Manager> ListManagers()
        {
            return PManager.listar();
        }

        public Manager FindManager(int id)
        {
            return PManager.conseguir(id);
        }

        public bool CreateManager()
        {
            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            if (FindManager(id) != null)
            {
                return false; //excelente este código
            }

            Console.WriteLine("Nombre: ");
            string name = Console.ReadLine();

            Console.WriteLine("Teléfono: ");
            int phoneNumber = int.Parse(Console.ReadLine());

            Manager newManager = new Manager(id, name, phoneNumber);

            PManager.alta(newManager);
            Console.WriteLine("Encargado añadido con éxito");
            return true;
        }

        public bool DeleteManager()
        {
            Console.WriteLine("Ingrese ID");
            Manager m = FindManager(int.Parse(Console.ReadLine()));

            if (m != null)
            {
                PManager.baja(m.Id);
                return true;
            }
            Console.WriteLine("Encargado no existe");
            return false;
        }

        public bool EditManager(int id)
        {
            Manager manager = FindManager(id);
            if (manager != null)
            {
                Console.WriteLine("Ingrese nombre");
                manager.Name = Console.ReadLine();
                Console.WriteLine("Ingrese teléfono");
                manager.PhoneNumber = int.Parse(Console.ReadLine());
                PManager.modificar(manager);
                return true;
            }
            return false;
        }

        #endregion

        #region subsidiaries

        public List<Subsidiary> ListSubsidiaries()
        {
            return PSubsidiary.ListSubsidiaries();
        }

        public Subsidiary FindSubsidiary(int id)
        {
            foreach (Subsidiary s in PSubsidiary.ListSubsidiaries())
            {
                if (s.Id == id)
                    return s;
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
            foreach (Manager man in PManager.listar())
            {
                Console.WriteLine(man.Id.ToString() + ". " + man.Name);
            }
            Manager manager = FindManager(int.Parse(Console.ReadLine()));
            if (PSubsidiary.Upload(new Subsidiary(id, name, city, address, number, manager)))
            {
                Console.WriteLine("Sucursal añadida con éxito.");
                return true;
            }
            Console.WriteLine("Error al registrar sucursal");
            return false;
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
                    if (PSubsidiary.Delete(su.Id))
                    {
                        Console.WriteLine("Sucursal eliminada");
                        return true;
                    }
                }
                Console.WriteLine("Operación cancelada");
                return false;
            }
            Console.WriteLine("Sucursal no existe");
            return false;
        }

        public bool EditSubsidiary()
        {
            Console.WriteLine("Ingrese id");
            int id = int.Parse(Console.ReadLine());
            foreach (Subsidiary s in ListSubsidiaries())
            {
                if (s.Id == id)
                {
                    Console.WriteLine("Nombre: ");
                    s.Name = Console.ReadLine();

                    Console.WriteLine("Ciudad: ");
                    s.City = Console.ReadLine();

                    Console.WriteLine("Dirección: ");
                    s.Address = Console.ReadLine();

                    Console.WriteLine("Teléfono: ");
                    s.Number = int.Parse(Console.ReadLine());

                    Console.WriteLine("Encargado: ");
                    foreach (Manager man in PManager.listar())
                    {
                        Console.WriteLine(man.Id.ToString() + ". " + man.Name);
                    }
                    s.Manager = FindManager(int.Parse(Console.ReadLine()));
                    if (PSubsidiary.Update(s))
                    {
                        Console.WriteLine("Sucusal modificada con éxito");
                    }
                }
            }
            Console.WriteLine("Sucursal no existe");
            return false;
        }
        #endregion

        #region utilities
        public void DetermineClientDeletion(int id)
        {
            if (PSenior.Conseguir(id) != null)
            {
                PSenior.Baja(id);
            }

            if (PChild.conseguir(id) != null)
            {
                PChild.baja(id);
            }

            if (PAdult.conseguir(id) != null)
            {
                PAdult.baja(id);
            }
        }
        #endregion
    }
}
