using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            /* ----------------
             * Progrma:  Biblioteca
             * 1. Alta de libros: preguntar al usuario> NOMBRE del libro, AUTOR, ISBN, EDITORAL, AÑO de publicación, LUGAR de publicación, GENERO y Numero de paginas  [8]
             * 2. Busqueda de libro: preguntar al usuario> NOMBRE del libro 
             *    En caso de SI encontrar el libro DESPLEGAR INFORMACION. SINO  DESPLEGAR MENSAJE  "Libro no encontrado"
             * 3. Mostrar todos los libros. DESPLEGAR LA INFORMACION DE TODOS LOS LIBROS ALMACENADOS.
             * ----------------
             * REQUISITOS: Todos los libros se deben almacenar en un mismo archivo de texto.*/

            byte control = 0;

            string libro;
            string ruta = @"C:\Users\david\Documents\IntProg\A1_P2 - Biblioteca\DB\libros.txt";


            do
            {

                Console.WriteLine("    ------------- BIBLIOTECA -------------");
                Console.WriteLine(" Ingrese la opción que desea realizar: ");
                Console.WriteLine("   1. Agregar libro");
                Console.WriteLine("   2. Buscar libro");
                Console.WriteLine("   3. Consultar colección de libros " + '\n' );
                Console.Write("     >  ");

                byte opcion = byte.Parse(Console.ReadLine());


                switch (opcion)
                {
                    case 1:
                        {

                            Console.Clear();
                            Console.WriteLine("    ----------- AGREGAR LIBRO -----------" + '\n');
                            
                                Console.WriteLine("    Porfavor ingrese: ");
                                Console.Write("   > NOMBRE: ");
                                libro = Console.ReadLine();
                                Console.Write("   > AUTOR: ");
                                libro = libro + "," + Console.ReadLine();
                                Console.Write("   > ISBN: ");
                                libro = libro + "," + Console.ReadLine();
                                Console.Write("   > EDITORIAL: ");
                                libro = libro + "," + Console.ReadLine();
                                Console.Write("   > AÑO DE PUBLICACIÓN: ");
                                libro = libro + "," + Console.ReadLine();
                                Console.Write("   > LUGAR DE PUBLICACIÓN: ");
                                libro = libro + "," + Console.ReadLine();
                                Console.Write("   > GENERO: ");
                                libro = libro + "," + Console.ReadLine();
                                Console.Write("   > NÚMERO DE PÁGINAS: ");
                                libro = libro + "," + Console.ReadLine() ;

                                Console.WriteLine(libro);
                            

                            StreamWriter escritura = File.AppendText(ruta);
                            escritura.WriteLine(libro);
                            escritura.Close();

                            Console.WriteLine( '\n' + "Los valores ingresados se han almacenado corretamente");


                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("----------- BUSCAR LIBRO -----------" + '\n');

                            StreamReader lectura = File.OpenText(ruta);
                            String consulta = lectura.ReadToEnd();
                            lectura.Close();

                            string[] librero = consulta.Split('\n'); // recordar no puedo imprimir asi como asi los datos de un string tenemos que pasarlos por un for


                            Console.Write("    Porfavor ingrese el nombre del libro: ");
                            string nombre = Console.ReadLine();

                            for ( int x=0 ; x < librero.Length - 1 ; x++)
                            {

                                string[] lib = librero[x].Split(',');

                                if (lib[0].Trim().Equals(nombre))
                                {
                                    Console.WriteLine("Se encontro el valor" + '\n');


                                    Console.WriteLine("   > NOMBRE: " + lib[0]);
                                    Console.WriteLine("   > AUTOR: " + lib[1]);
                                    Console.WriteLine("   > ISBN: " + lib[2]);
                                    Console.WriteLine("   > EDITORIAL: " + lib[3]);
                                    Console.WriteLine("   > AÑO DE PUBLICACIÓN: " + lib[4]);
                                    Console.WriteLine("   > LUGAR DE PUBLICACIÓN: " + lib[5]);
                                    Console.WriteLine("   > GENERO: " + lib[6]);
                                    Console.WriteLine("   > NÚMERO DE PÁGINAS: " + lib[7] + '\n');

                                }
                                else
                                {
                                    
                                }
                            }

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("----------- LIBROS ALMACENADOS -----------" + '\n');

                            StreamReader lectura = File.OpenText(ruta);
                            String consulta = lectura.ReadToEnd();
                            lectura.Close();

                            string[] librero = consulta.Split('\n'); // recordar no puedo imprimir asi como asi los datos de un string


                            for ( int x=0 ; x < librero.Length - 1 ; x++)
                            {
                                    string[] lib = librero[x].Split(','); 

                                    Console.WriteLine("   > NOMBRE: " + lib[0]);
                                    Console.WriteLine("   > AUTOR: " + lib[1]);
                                    Console.WriteLine("   > ISBN: " + lib[2]);
                                    Console.WriteLine("   > EDITORIAL: " + lib[3]);
                                    Console.WriteLine("   > AÑO DE PUBLICACIÓN: " + lib[4]);
                                    Console.WriteLine("   > LUGAR DE PUBLICACIÓN: " + lib[5]);
                                    Console.WriteLine("   > GENERO: " + lib[6]);
                                    Console.WriteLine("   > NÚMERO DE PÁGINAS: " + lib[7] + '\n');

                            }
                        
                            break;
                        }
                    default:
                        {
                            Console.Write("   > la opción ingresada no es valida");
                            break;
                        }
                }


                    Console.WriteLine( '\n' + "Ingrese 0 para salir de la aplicación o Ingrese 1 para mostrar nuevamente el menu");
                    control = byte.Parse(Console.ReadLine());
                    Console.Clear();


            } while (control != 0);

        }
    }
}
