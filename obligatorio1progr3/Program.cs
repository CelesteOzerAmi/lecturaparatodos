using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using obligatorio1progr3.Domain;

namespace obligatorio1progr3
{
    public class Program
    {

        static void Main(string[] args)
        {
            #region switch basic options
            bool switchInLoop = true;
            string initialWelcome = "Bienvenido. Seleccione una opción para comenzar: ";
            string initialOptions = "1: Usuarios | 2: Libros | 3: Géneros | 4: Sucursales | 5: Encargados | 6: Clientes | 7: Préstamos | ";
            string basicOptions = "0: Inicio | 9: Salir";
            
            bool Options(int opt)
            {
                if(opt.GetType() != typeof(int))
                {
                    Console.WriteLine("Opción inválida");
                    switchInLoop = true;
                }
                if (opt == 9)
                {
                    Console.WriteLine("Gracias por utilizar nuestro sistema :)");
                    switchInLoop = false;
                }
                return switchInLoop;
            }
            #endregion

            #region main switch 
            while (switchInLoop)
            {
                
                Console.WriteLine(initialWelcome);
                Console.WriteLine(initialOptions + basicOptions);

                int initialValue = int.Parse(Console.ReadLine());

                switch (initialValue)
                {
                    case 0:
                        break;

                    #region users
                    case 1:
                        Console.WriteLine("Usuarios");
                        Console.WriteLine(basicOptions);
                        int opt = int.Parse(Console.ReadLine());
                        Options(opt);
                        break;
                    #endregion

                    #region books
                    case 2:
                        Console.WriteLine("Libros");
                        Console.WriteLine("Seleccione una opción: ");
                        Console.WriteLine("1: Ver libros | 2: Alta libro | 3: Eliminar libro | " + basicOptions);
                        int optionValue = int.Parse(Console.ReadLine());

                        Controller aController = new Controller();

                        switch (optionValue)
                        {
                            case 0:
                                break;

                            case 1:
                                Console.WriteLine("Libros añadidos");

                                List<Book> booksList = new List<Book>();
                                booksList = aController.ListBooks();
                                foreach (Book abook in booksList)
                                {
                                    Console.WriteLine("'" + abook.Title + "'. Autor: " + abook.Author + ". Año: " + abook.Year);
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 2:
                                Console.WriteLine("Alta libro");

                                if (aController.CreateBook())
                                {
                                    Console.WriteLine("Libro añadido con éxito");
                                }
                                else
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 3:
                                Console.WriteLine("Eliminar libro");

                                Console.WriteLine("Ingrese ID");
                                int id = int.Parse(Console.ReadLine());
                                Book book = aController.FindBook(id);
                                if (book != null)
                                {
                                    Console.WriteLine("'" + book.Title + "'. Autor: " + book.Author + ". Año: " + book.Year);
                                    Console.WriteLine("¿Eliminar libro?");
                                    Console.WriteLine("1. Confirmar | 2. Cancelar");
                                    int selectedOption = int.Parse(Console.ReadLine());
                                    if (selectedOption == 1)
                                    {
                                        if (aController.DeleteBook(id))
                                        {
                                            Console.WriteLine("Libro eliminado con éxito.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error. Intente nuevamente por favor.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Operación cancelada.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Libro no existe.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 9:
                                Console.WriteLine("Gracias por utilizar nuestro sistema :)");
                                switchInLoop = false;
                                break;

                            default:
                                Console.WriteLine("Opción inválida");
                                break;
                        }
                        break;
                    #endregion

                    #region genres
                    case 3:
                        Console.WriteLine("Géneros");
                        Console.WriteLine("Seleccione una opción: ");
                        Console.WriteLine("1: Ver géneros | 2: Alta género | 3: Eliminar género | " + basicOptions);
                        optionValue = int.Parse(Console.ReadLine());
                        Controller genresController = new Controller();


                        switch (optionValue)
                        {
                            case 0:
                                break;

                            case 1:
                                Console.WriteLine("Géneros añadidos");

                                List<Genre> genresList = new List<Genre>();
                                genresList = genresController.ListGenres();
                                foreach (Genre agenre in genresList)
                                {
                                    Console.WriteLine(agenre.Name);
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 2:
                                Console.WriteLine("Alta género");

                                if (genresController.CreateGenre())
                                {
                                    Console.WriteLine("Género añadido con éxito");
                                }
                                else
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 3:
                                Console.WriteLine("Eliminar género");

                                Console.WriteLine("Ingrese ID");
                                int id = int.Parse(Console.ReadLine());
                                Genre genre = genresController.FindGenre(id);
                                if (genre != null)
                                {
                                    Console.WriteLine(genre.Name);
                                    Console.WriteLine("¿Eliminar género?");
                                    Console.WriteLine("1. Confirmar | 2. Cancelar");
                                    int selectedOption = int.Parse(Console.ReadLine());
                                    if (selectedOption == 1)
                                    {
                                        if (genresController.DeleteGenre(id))
                                        {
                                            Console.WriteLine("Género eliminado con éxito.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error. Intente nuevamente por favor.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Operación cancelada.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Género no existe.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 9:
                                Console.WriteLine("Gracias por utilizar nuestro sistema :)");
                                switchInLoop = false;
                                break;

                            default:
                                Console.WriteLine("Opción inválida");
                                break;
                        }
                        break;
                    #endregion

                    #region subsidiaries
                    case 4:
                        Console.WriteLine("Sucursales");
                        Console.WriteLine("Seleccione una opción: ");
                        Console.WriteLine("1: Ver sucursales | 2: Alta sucursal | 3: Modificar sucursal | 4: Eliminar sucursal | " + basicOptions);
                        optionValue = int.Parse(Console.ReadLine());

                        Controller subController = new Controller();

                        switch (optionValue)
                        {
                            case 0:
                                break;

                            case 1:
                                Console.WriteLine("Sucursales registradas");

                                List<Subsidiary> subsidiariesList = new List<Subsidiary>();
                                subsidiariesList = subController.ListSubsidiaries();
                                foreach (Subsidiary asub in subsidiariesList)
                                {
                                    Console.WriteLine(asub.Id.ToString() + ". " + asub.Name + ". Dirección: " + asub.Address + ", " + asub.City
                                        + ". Teléfono: " + asub.Number.ToString() + ". Encargado: " + asub.Manager.Name);
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 2:
                                Console.WriteLine("Alta sucursal");

                                if (subController.CreateSubsidiary())
                                {
                                    Console.WriteLine("Sucursal añadida con éxito");
                                }
                                else
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 3:
                                Console.WriteLine("Eliminar sucursal");

                                Console.WriteLine("Ingrese ID");
                                int id = int.Parse(Console.ReadLine());
                                Subsidiary sub = subController.FindSubsidiary(id);
                                if (sub != null)
                                {
                                    Console.WriteLine("'" + sub.Name + ". Dirección: " + sub.Address + ", " + sub.City);
                                    Console.WriteLine("¿Eliminar sucursal?");
                                    Console.WriteLine("1. Confirmar | 2. Cancelar");
                                    int selectedOption = int.Parse(Console.ReadLine());
                                    if (selectedOption == 1)
                                    {
                                        if (subController.DeleteSubsidiary(id))
                                        {
                                            Console.WriteLine("Sucursal eliminada con éxito.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error. Intente nuevamente por favor.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Operación cancelada.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sucursal no existe.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 9:
                                Console.WriteLine("Gracias por utilizar nuestro sistema :)");
                                switchInLoop = false;
                                break;

                            default:
                                Console.WriteLine("Opción inválida");
                                break;
                        }
                        break;

                    #endregion

                    #region managers
                    case 5: 
                        Console.WriteLine("Encargados");
                        Console.WriteLine("Seleccione una opción: ");
                        Console.WriteLine("1: Ver encargados | 2: Alta encargado | 3: Modificar encargado | 4: Eliminar encargado | " + basicOptions);
                        optionValue = int.Parse(Console.ReadLine());
                        Controller managersController = new Controller();


                        switch (optionValue)
                        {
                            case 0:
                                break;

                            case 1:
                                Console.WriteLine("Encargados añadidos");

                                List<Manager> managersList = new List<Manager>();
                                managersList = managersController.ListManagers();
                                foreach (Manager amanager in managersList)
                                {
                                    Console.WriteLine(amanager.Id.ToString() + ". " + amanager.Name + ". " + amanager.PhoneNumber.ToString());
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 2:
                                Console.WriteLine("Alta encargado");

                                if (managersController.CreateManager())
                                {
                                    Console.WriteLine("Encargado añadido con éxito");
                                }
                                else
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 3:
                                Console.WriteLine("Modificar encargado");

                                Console.WriteLine("Ingrese ID");
                                int mid = int.Parse(Console.ReadLine());
                                if (managersController.EditManager(mid))
                                {
                                    Console.WriteLine("Encargado modificado con éxito");
                                }
                                else
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 4:
                                Console.WriteLine("Eliminar encargado");

                                Console.WriteLine("Ingrese ID");
                                int id = int.Parse(Console.ReadLine());
                                Manager manager = managersController.FindManager(id);
                                if (manager != null)
                                {
                                    Console.WriteLine(manager.Name);
                                    Console.WriteLine("¿Eliminar encargado?");
                                    Console.WriteLine("1. Confirmar | 2. Cancelar");
                                    int selectedOption = int.Parse(Console.ReadLine());
                                    if (selectedOption == 1)
                                    {
                                        if (managersController.DeleteManager(id))
                                        {
                                            Console.WriteLine("Encargado eliminado con éxito.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error. Intente nuevamente por favor.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Operación cancelada.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Encargado no existe.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 9:
                                Console.WriteLine("Gracias por utilizar nuestro sistema :)");
                                switchInLoop = false;
                                break;

                            default:
                                Console.WriteLine("Opción inválida");
                                break;
                        }
                        break;
                    #endregion

                    #region clients
                    case 6:
                        Console.WriteLine("Clientes");
                        Console.WriteLine(basicOptions);
                        opt = int.Parse(Console.ReadLine());
                        Options(opt);
                        break;
                    #endregion

                    #region rentals
                    case 7:
                        Console.WriteLine("Préstamos");
                        Console.WriteLine(basicOptions);
                        opt = int.Parse(Console.ReadLine());
                        Options(opt);
                        break;
                    #endregion

                    #region switch end
                    case 9:
                        Console.WriteLine("Gracias por utilizar nuestro sistema :)");
                        switchInLoop = false;
                        break;
                    #endregion

                    #region default
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                    #endregion
                }
                #endregion
            }
        }
    }
}
