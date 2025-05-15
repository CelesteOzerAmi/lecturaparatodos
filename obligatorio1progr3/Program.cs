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
            
            bool Options()
                
            {
                Console.WriteLine(basicOptions);
                int opt = int.Parse(Console.ReadLine());
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
                                    Console.WriteLine($"Usuario {aclient.Id}: {aclient.Name}, {aclient.PhoneNumber}. Registrado en {aclient.Subsidiary.Name}. Tipo de usuario {aclient.Type}");
                                }                                
                                Options();
                                break;

                            case 2:
                                Console.WriteLine("Alta usuario");

                                if (!clientController.CreateClient())
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Options();
                                break;

                            case 3:
                                Console.WriteLine("Eliminar usuario");

                                clientController.DeleteClient();
                                Options();
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
                                Options();
                                break;

                            case 2:
                                Console.WriteLine("Alta libro");

                                if (!aController.CreateBook())
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Options();
                                break;

                            case 3:
                                Console.WriteLine("Modificar libro");

                                aController.EditBook();
                                Options();
                                break;

                            case 4:
                                Console.WriteLine("Eliminar libro");

                                aController.DeleteBook();
                                Options();
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

                                foreach (Genre g in genresController.ListGenres())
                                {
                                    Console.WriteLine($"{g.Id}: {g.Name}.");
                                }
                                Options();
                                break;

                            case 2:
                                Console.WriteLine("Alta género");

                                if (!genresController.CreateGenre())
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Options();
                                break;

                            case 3:
                                Console.WriteLine("Eliminar género");

                                genresController.DeleteGenre();
                                Options();
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
                                Options();
                                break;

                            case 2:
                                Console.WriteLine("Alta sucursal");

                                if (!subController.CreateSubsidiary())
                                {
                                    Console.WriteLine("Error. Intente nuevamente por favor.");
                                }
                                Options();
                                break;

                            case 3:
                                Console.WriteLine("Modificar sucursal");

                                subController.EditSubsidiary();
                                Options();
                                break;
                            case 4:
                                Console.WriteLine("Eliminar sucursal");

                                subController.DeleteSubsidiary();
                                Options();
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

                                foreach (Manager m in managersController.ListManagers())
                                {
                                    Console.WriteLine($"{m.Id}: {m.Name}, {m.PhoneNumber}");
                                }
                                Options();
                                break;

                            case 2:
                                Console.WriteLine("Alta encargado");

                                managersController.CreateManager();
                                Options();
                                break;

                            case 3:
                                Console.WriteLine("Modificar encargado");
                                Console.WriteLine("Ingrese ID");
                                managersController.EditManager(int.Parse(Console.ReadLine()));
                                Options();
                                break;

                            case 4:
                                Console.WriteLine("Eliminar encargado");

                                managersController.DeleteManager();
                                Options();
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
                        Controller rentController = new Controller();
                        Console.WriteLine("Seleccione una opción: ");
                        Console.WriteLine("1: Ver préstamos | 2: Alta préstamo | 3: Modificar préstamo | 4: Eliminar préstamo | " + basicOptions);
                        optionValue = int.Parse(Console.ReadLine());

                        switch (optionValue)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.WriteLine("Ver préstamos");
                                Options();
                                break;
                            case 2:
                                Console.WriteLine("Alta préstamo");
                                Options();
                                break;
                            case 3:
                                Console.WriteLine("Modificar préstamo");
                                Options();
                                break;
                            case 4:
                                Console.WriteLine("Eliminar préstamo");
                                Options();
                                break;
                        }
                        Options();
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
