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
            bool switchInLoop = true;
            string initialWelcome = "Bienvenido. Seleccione una opción para comenzar: ";
            string initialOptions = "1: Usuarios | 2: Libros | 3: Sucursales | 4: Otros | ";
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

            while (switchInLoop)
            {
                
                Console.WriteLine(initialWelcome);
                Console.WriteLine(initialOptions + basicOptions);

                int initialValue = int.Parse(Console.ReadLine());

                switch (initialValue)
                {
                    case 0:
                        break;

                    case 1:
                        Console.WriteLine("Usuarios");
                        Console.WriteLine(basicOptions);
                        int opt = int.Parse(Console.ReadLine());
                        Options(opt);
                        break;

                    case 2:
                        Console.WriteLine("Libros");
                        Console.WriteLine("Seleccione una opción: ");
                        Console.WriteLine("1: Ver libros | 2: Alta libro | " + basicOptions);
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
                                foreach (Book book in booksList)
                                {
                                    Console.WriteLine("'" + book.Title + "'. Autor: " + book.Author + ". Año: " + book.Year);
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
                            case 9:
                                Console.WriteLine("Gracias por utilizar nuestro sistema :)");
                                switchInLoop = false;
                                break;

                            default:
                                Console.WriteLine("Opción inválida");
                                break;
                        }
                        
                        break;

                    case 3:
                        Console.WriteLine("Sucursales");
                        Console.WriteLine(basicOptions);
                        opt = int.Parse(Console.ReadLine());
                        Options(opt);
                        break;

                    case 4:
                        Console.WriteLine("Otros");
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
            }

        }
    }
}
