using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            string initialOptions = "1: Usuarios | 2: Libros | 3: Géneros | 4: Sucursales | 5: Encargados | 6: Préstamos | ";
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
                int opt;

                switch (initialValue)
                {
                    case 0:
                        break;

                    #region users
                    case 1:
                        Console.WriteLine("Usuarios");

                        Controller clientController = new Controller();
                        Console.WriteLine("Seleccione una opción: ");
                        Console.WriteLine("1: Ver usuarios | 2: Alta usuario | 3: Eliminar usuario | " + basicOptions);
                        int optionValue = int.Parse(Console.ReadLine());

                        switch (optionValue)
                        {
                            case 0:
                                break;

                            case 1:
                                Console.WriteLine("Usuarios añadidos");

                                foreach (Client aclient in clientController.ListClients())
                                {
                                    Console.WriteLine($"Usuario {aclient.Id}: {aclient.Name}, {aclient.PhoneNumber}. Registrado en {aclient.Subsidiary.Name}");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 2:
                                Console.WriteLine("Alta usuario");

                                if (!clientController.CreateClient())
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 3:
                                Console.WriteLine("Eliminar usuario");

                                clientController.DeleteClient();
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

                    #region books
                    case 2:
                        Console.WriteLine("Libros");
                        Console.WriteLine("Seleccione una opción: ");
                        Console.WriteLine("1: Ver libros | 2: Alta libro | 3: Modificar libro | 4: Eliminar libro " + basicOptions);
                        optionValue = int.Parse(Console.ReadLine());

                        Controller aController = new Controller();

                        switch (optionValue)
                        {
                            case 0:
                                break;

                            case 1:
                                Console.WriteLine("Libros añadidos");

                                foreach (Book abook in aController.ListBooks())
                                {
                                    Console.WriteLine($"{abook.Id}. '{abook.Title}', {abook.Author}. {abook.Year}. Estado: {abook.State}. Sucursal: {abook.Subsidiary.Name}");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 2:
                                Console.WriteLine("Alta libro");

                                if (!aController.CreateBook())
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 3:
                                Console.WriteLine("Modificar libro");

                                aController.EditBook();
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 4:
                                Console.WriteLine("Eliminar libro");

                                aController.DeleteBook();
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

                                if (!genresController.CreateGenre())
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 3:
                                Console.WriteLine("Eliminar género");

                                genresController.DeleteGenre();
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

                                foreach (Subsidiary asub in subController.ListSubsidiaries())
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

                                if (!subController.CreateSubsidiary())
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 3:
                                Console.WriteLine("Eliminar sucursal");

                                subController.DeleteSubsidiary();
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

                                foreach (Manager amanager in managersController.ListManagers())
                                {
                                    Console.WriteLine(amanager.Id.ToString() + ". " + amanager.Name + ". " + amanager.PhoneNumber.ToString());
                                }
                                Console.WriteLine(basicOptions);
                                opt = int.Parse(Console.ReadLine());
                                Options(opt);
                                break;

                            case 2:
                                Console.WriteLine("Alta encargado");

                                if (!managersController.CreateManager())
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

                                managersController.DeleteManager();
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

                    #region rentals
                    case 6:
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
