using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3
{
    public class Program
    {
        static void Main(string[] args)
        {

            bool switchLoop = true;
            while (switchLoop)
            {

                string initialWelcome = "Bienvenido. Seleccione una opción para comenzar: ";
                string initialOptions = "1: Usuarios | 2: Libros | 3: Sucursales | 4: Otros";
                string basicOptions = " | 0: Inicio | 9: Salir";
                Console.WriteLine(initialWelcome);
                Console.WriteLine(initialOptions + basicOptions);

                int initialValue = int.Parse(Console.ReadLine());

                switch (initialValue)
                {
                    case 0:
                        break;

                    case 1:
                        Console.WriteLine("Usuarios");
                        switchLoop = false;
                        break;

                    case 2:
                        Console.WriteLine("Libros");
                        Console.WriteLine("Seleccione una opción: ");
                        Console.WriteLine("1: Ver libros | 2: Alta libro" + basicOptions);
                        int optionValue = int.Parse(Console.ReadLine());

                        Controller aController = new Controller();

                        switch (optionValue)
                        {
                            case 0:
                                break;

                            case 1:
                                Console.WriteLine("Libros añadidos");
                                Console.WriteLine(aController.ListBooks().ToString());
                                switchLoop = false;
                                break;

                            case 2:
                                Console.WriteLine("Alta libro");
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

                                Books abook = new Books(id, title, author, genre, year, subsidiary, state);

                                aController.UploadBook(abook);
                                Console.WriteLine(aController.ListBooks().ToString());

                                switchLoop = false;
                                break;
                            case 9:
                                Console.WriteLine("Gracias por utilizar nuestro sistema :)");
                                switchLoop = false;
                                break;

                            default:
                                Console.WriteLine("Opción inválida");
                                break;
                        }
                        
                        break;

                    case 3:
                        Console.WriteLine("Sucursales");
                        switchLoop = false;
                        break;

                    case 4:
                        Console.WriteLine("Otros");
                        switchLoop = false;
                        break;

                    case 9:
                        Console.WriteLine("Gracias por utilizar nuestro sistema :)");
                        switchLoop = false;
                        break;

                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }

        }
    }
}
