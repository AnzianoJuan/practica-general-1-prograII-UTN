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
        static void Main(string[] args)
        {


            int opcion = 0;
            const int cantidadTotalDeTrabajadores = 2;


            string[] nombres = new string[cantidadTotalDeTrabajadores];
            long[] cuils = new long[cantidadTotalDeTrabajadores];
            DateTime[] nacimientos = new DateTime[cantidadTotalDeTrabajadores];
            float[] sueldoMensuales = new float[cantidadTotalDeTrabajadores];
            int[] puestos = new int[cantidadTotalDeTrabajadores];

            while(opcion != 5)
            {
                opcion = Menu(opcion);

                if(opcion == 1)
                {
                    CargaDeEmpleados(nombres, cuils, nacimientos, sueldoMensuales, puestos);
                }else if(opcion == 2)
                {
                    listadoDeobreros(nombres, cuils, nacimientos, sueldoMensuales, puestos);
                }else if(opcion == 3)
                {
                    listadoDeAdministrartivos(nombres, cuils, nacimientos, sueldoMensuales, puestos);
                }else if(opcion == 4)
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

            int edad;

            for(int i = 0; i < 2; i++)
            {
                if (obreros[i] == 1)
                {
                    edad = DateTime.Now.Year - fechas[i].Year;

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

            for (int i = 0; i < 2; i++)
            {
                if (admins[i] == 2)
                {
                    edad = DateTime.Now.Year - fechas[i].Year;

                    Console.WriteLine($"Nombre completo: {nombres[i]} - CUIL: {cuil[i]} - Edad: {edad} – Sueldo: $ {sueldos[i]}");
                }
            }

            Console.WriteLine();



        }

        static float sueldosTotales(float[] sueldos) 
        {
            float total = 0;

            for(int i = 0; i < 2; i++)
            {
                total += sueldos[i];
            }

            return total;
        
        }




        static void CargaDeEmpleados(string[] nombreCompleto , long[] cuil, DateTime[] fechaNacimiento, float[] sueldoMensual, int[] puesto) 
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


            for(int i = 0; i < 2; i++)
            {
                Console.WriteLine();

                Console.WriteLine($"TRABAJADOR NRO :{posicionDeTrabajador}");
                posicionDeTrabajador++;

                Console.Write("INGRESE NOMBRE : ");
                cadena = Console.ReadLine();

                nombreCompleto[i] = cadena;

                Console.Write("INGRESE CUIL : ");
                cadena = Console.ReadLine();
                while (!long.TryParse(cadena,out cuilDePersona) || cuilDePersona > 9223372036854775807 || cuilDePersona < -9223372036854775808) 
                { 
                    Console.Write("ingresa nuevamente con el dato correcto : ");
                    cadena = Console.ReadLine();
                }

                cuil[i] = cuilDePersona;

                Console.Write("INGRESE FECHA DE NACIMIENTO : (xx/xx/xxxx) o con espacios xx xx xxxx : ");
                cadena = Console.ReadLine();

                while(!DateTime.TryParse(cadena,out nacimientoPorPersona) || nacimientoPorPersona.Year > 9999 || nacimientoPorPersona.Month > 12 || nacimientoPorPersona.Day > 31)
                {
                    Console.Write("ingresa nuevamente con el formato correcto : ");
                    cadena = Console.ReadLine();
                }

                fechaNacimiento[i] = nacimientoPorPersona;


                Console.Write("INGRESE SUELDO : ");
                cadena = Console.ReadLine();

                while(!float.TryParse(cadena,out sueldo))
                {
                    Console.Write("ingresa el formato del sueldo correctamente : ");
                    cadena = Console.ReadLine();
                }

                sueldoMensual[i] = sueldo; 

                Console.Write("INGRESA PUESTO 1 = OBRERO | 2 = ADMINISTRADOR  : ");
                cadena = Console.ReadLine();
                while(!int.TryParse(cadena, out puestoLaboral) || puestoLaboral < 1 || puestoLaboral > 2)
                {
                    Console.Write("INGRESA PUESTO CORRECTAMENTE !!! 1 = OBRERO | 2 = ADMINISTRADOR  :");
                    cadena = Console.ReadLine();
                }

                puesto[i] = puestoLaboral;

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


    }
}
