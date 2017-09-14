using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorizaConsola
{
    class Program
    {
        const double Pi = 3.1415;
        static void Main(string[] args)
        {
            double resu;
            int op = VisualizaMenu();
            while (op != 0)
            {
                switch (op)
                {
                    case 1:
                        resu = funcion1();
                        Visualizar(resu);
                        break;
                    case 2:
                        Console.Write("\nIntroduzca num1: ");
                        int num1 = Convert.ToInt32(Console.ReadLine());
                        resu = funcion2(num1);
                        Visualizar(resu);
                        break;
                    case 3:
                        resu = Operacion(2);
                        Visualizar(resu);
                        resu = Operacion(3);
                        Visualizar(resu);
                        resu = Operacion(4);
                        Visualizar(resu);
                        break;
                }
                op = VisualizaMenu();
            }
        }

        private static double Operacion(int num)
        {
            return (Pi * num - 1) / Pi;
        }

        private static int VisualizaMenu()
        {
            Console.Clear();
            Console.WriteLine("1.- Funcion1");
            Console.WriteLine("2.- Funcion2");
            Console.WriteLine("3.- Resultado");
            Console.WriteLine("0.- Salir");
            Console.Write("Opción: ");
            int op = Convert.ToInt32(Console.ReadLine());
            return op;
        }

        private static void Visualizar(double resu)
        {
            Console.WriteLine();
            Console.WriteLine("La visualización del resultado es");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Para ello tenemos que visualizar los valores");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Resu: {0}", resu);
            Console.ReadLine();
        }

        static double funcion1()
        {
            double resu = Pi + Pi;
            return (resu);
        }
        static int funcion2(int num1)
        {
            int aux = num1;
            if (aux < 8)
                for (int i = 0; i < 5; i++)
                    aux = aux - i;
            else
                aux = aux * 2;
            return (aux);
        }
    }
}