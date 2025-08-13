using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        const int cantidadTotalDeTrabajadores = 60;
        static int contadorDeTrabadores = 0;

        static void Main(string[] args)
        {


            int opcion = 0;

            string[] nombres = new string[cantidadTotalDeTrabajadores];
            long[] cuils = new long[cantidadTotalDeTrabajadores];
            DateTime[] nacimientos = new DateTime[cantidadTotalDeTrabajadores];
            float[] sueldoMensuales = new float[cantidadTotalDeTrabajadores];
            int[] puestos = new int[cantidadTotalDeTrabajadores];

            while (opcion != 5)
            {
                opcion = Menu(opcion);

                if (opcion == 1)
                {
                    CargaDeEmpleados(nombres, cuils, nacimientos, sueldoMensuales, puestos);
                }
                else if (opcion == 2)
                {
                    listadoDeobreros(nombres, cuils, nacimientos, sueldoMensuales, puestos);
                }
                else if (opcion == 3)
                {
                    listadoDeAdministrartivos(nombres, cuils, nacimientos, sueldoMensuales, puestos);
                }
                else if (opcion == 4)
                {
                    Console.WriteLine();

                    float totalidad = sueldosTotales(sueldoMensuales);
                    Console.WriteLine($"LOS SUELDOS TOTALES SON DE : $ {totalidad}");
                }


            }

            Console.WriteLine("saliste del programa...");

        }

        static void listadoDeobreros(string[] nombres, long[] cuil, DateTime[] fechas, float[] sueldos, int[] obreros)
        {
            Console.WriteLine();

            Console.WriteLine("LISTADO DE OBREROS :");

            int edad = 0;

            for (int i = 0; i < cantidadTotalDeTrabajadores; i++)
            {
                if (obreros[i] == 1)
                {
                    if (fechas[i].Month < DateTime.Now.Month || (fechas[i].Month == DateTime.Now.Month && fechas[i].Day <= DateTime.Now.Day))
                    {
                        edad = DateTime.Now.Year - fechas[i].Year;
                    }else
                    {
                        edad = DateTime.Now.Year - fechas[i].Year - 1;
                    }

                    Console.WriteLine($"Nombre completo: {nombres[i]} - CUIL: {cuil[i]} - Edad: {edad} – Sueldo: $ {sueldos[i]}");
                }
            }

            Console.WriteLine();



        }

        static void listadoDeAdministrartivos(string[] nombres, long[] cuil, DateTime[] fechas, float[] sueldos, int[] admins)
        {
            Console.WriteLine();

            Console.WriteLine("LISTADO DE ADMINISTRATIVOS :");

            int edad;

            for (int i = 0; i < cantidadTotalDeTrabajadores; i++)
            {
                if (admins[i] == 2)
                {
                    if (fechas[i].Month < DateTime.Now.Month || (fechas[i].Month == DateTime.Now.Month && fechas[i].Day <= DateTime.Now.Day))
                    {
                        edad = DateTime.Now.Year - fechas[i].Year;
                    }
                    else
                    {
                        edad = DateTime.Now.Year - fechas[i].Year - 1;
                    }


                    Console.WriteLine($"Nombre completo: {nombres[i]} - CUIL: {cuil[i]} - Edad: {edad} – Sueldo: $ {sueldos[i]}");
                }
            }

            Console.WriteLine();



        }

        static float sueldosTotales(float[] sueldos)
        {
            float total = 0;

            for (int i = 0; i < cantidadTotalDeTrabajadores; i++)
            {
                total += sueldos[i];
            }

            return total;

        }




        static void CargaDeEmpleados(string[] nombreCompleto, long[] cuil, DateTime[] fechaNacimiento, float[] sueldoMensual, int[] puesto)
        {

            //            Para la carga de empleados se debe pedir por teclado el nombre completo, cuil, fecha de
            //            nacimiento, sueldo mensual y puesto que debe ser 1 para Obrero o 2 para Administrativo(validar
            //            el ingreso). La cantidad de empleados a cargar no puede superar la cantidad de 60.

            Console.WriteLine();

            string cadena;
            long cuilDePersona;
            DateTime nacimientoPorPersona;
            float sueldo;
            int puestoLaboral;
            int posicionDeTrabajador = 1;
            Console.WriteLine("------ INGRESO AL APARTADO PARA INGRESAR EMPLEADOS -----");

            Console.WriteLine();
            int i = 0;
            string continuacion = "S";
            string continua;

            while (contadorDeTrabadores < cantidadTotalDeTrabajadores && continuacion.ToUpper() == "S")
            {

                Console.WriteLine();

                Console.WriteLine($"TRABAJADOR NRO :{contadorDeTrabadores + 1}");
                posicionDeTrabajador++;

                Console.Write("INGRESE NOMBRE : ");
                cadena = Console.ReadLine();

                nombreCompleto[contadorDeTrabadores] = cadena;

                Console.Write("INGRESE CUIL : ");
                cadena = Console.ReadLine();

                TryParses(cadena, out cuilDePersona);

                cuil[contadorDeTrabadores] = cuilDePersona;

                Console.Write("INGRESE FECHA DE NACIMIENTO : (xx/xx/xxxx) o con espacios xx xx xxxx : ");
                cadena = Console.ReadLine();

                TryParses(cadena, out nacimientoPorPersona);

                fechaNacimiento[contadorDeTrabadores] = nacimientoPorPersona;

                Console.Write("INGRESE SUELDO : ");
                cadena = Console.ReadLine();

                TryParses(cadena, out sueldo);   

                sueldoMensual[contadorDeTrabadores] = sueldo;

                Console.Write("INGRESA PUESTO 1 = OBRERO | 2 = ADMINISTRADOR  : ");
                cadena = Console.ReadLine();

                TryParses(cadena, out puestoLaboral);

                puesto[contadorDeTrabadores] = puestoLaboral;

                Console.WriteLine("CARGADO CORRECTAMENTE...");

                Console.Write("DESEA SEGUIR CARGANDO (S/N) : ");
                continua = Console.ReadLine();

                continuacion = validacion(continua);

                contadorDeTrabadores++;
            }

        }

        static int Menu(int opcion)
        {
            string cadena;

            Console.WriteLine();

            Console.WriteLine("1.Cargar datos empleados");
            Console.WriteLine("2.Listado de Obreros");
            Console.WriteLine("3.Listado de Administrativos");
            Console.WriteLine("4.Total de sueldos");
            Console.WriteLine("5.Salir");
            Console.Write("OPCION : ");
            cadena = Console.ReadLine();

            while(!int.TryParse(cadena , out opcion) || opcion < 1 || opcion > 5) 
            {
                Console.Write("INGRESA NUEVAMENTE : ");
                cadena = Console.ReadLine();
            }

            return opcion;


        }

        static void TryParses(string cadena,out long cuil)
        {
            while (!long.TryParse(cadena, out cuil) || cuil > 9223372036854775807 || cuil < -9223372036854775808)
            {
                Console.Write("ingresa nuevamente con el dato correcto : ");
                cadena = Console.ReadLine();
            }
        }

        static void TryParses(string cadena, out DateTime fechaNac)
        {
            while (!DateTime.TryParse(cadena, out fechaNac) || fechaNac.Year > 9999 || fechaNac.Month > 12 || fechaNac.Day > 31)
            {
                Console.Write("ingresa nuevamente con el formato correcto : ");
                cadena = Console.ReadLine();
            }
        }

        static void TryParses(string cadena,out float sueldo)
        {
            while (!float.TryParse(cadena, out sueldo))
            {
                Console.Write("ingresa el formato del sueldo correctamente : ");
                cadena = Console.ReadLine();
            }
        }

        static void TryParses(string cadena, out int puestoLaboral)
        {
            while (!int.TryParse(cadena, out puestoLaboral) || puestoLaboral < 1 || puestoLaboral > 2)
            {
                Console.Write("INGRESA PUESTO CORRECTAMENTE !!! 1 = OBRERO | 2 = ADMINISTRADOR  :");
                cadena = Console.ReadLine();
            }
        }

        static string validacion(string continua)
        {
            while (continua.ToUpper() != "S" && continua.ToUpper() != "N")
            {
                Console.Write("INGRESE CORRECTAMENTE : ");
                continua = Console.ReadLine();
            }

            return continua;



        }


    }
}
