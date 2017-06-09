using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cruce1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] P1 = new int[10];
            int[] P2 = new int[10];

            int[] p3 = { 2, 3, 0, 5, 4, 1, 6, 8, 9, 7 };
            int[] p4 = { 7, 7, 1, 6, 3, 4, 9, 5, 8, 2 };

            Tuple<int[], int[]> hijos = C1P(p3, p4);

            Console.WriteLine("Hijo 1 : ");
            for (int i = 0; i < P1.Length; i++)
            {
                Console.Write(hijos.Item1[i]+ " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Hijo 2 : ");
            for (int i = 0; i < P2.Length; i++)
            {
                Console.Write(hijos.Item2[i] + " ");
            }

            Console.ReadKey();

        }

        static Tuple<int[],int[]> C1P(int[]pa1, int[]ma1)
        {
            Random rnd = new Random();
            int puntoCX = rnd.Next(0, 9);
            Console.WriteLine("Punto de cruce: "+ puntoCX);
            int[] h1 = new int[10];
            int[] h2 = new int[10];
            

            for (int i = 0; i < h1.Length; i++)
            {
                if(i > puntoCX)
                {
                    h1[i] = ma1[i];
                    h2[i] = pa1[i];
                }
                else
                {
                    h1[i] = pa1[i];
                    h2[i] = ma1[i];
                }
            }
            Tuple<int[], int[]> hijos = new Tuple<int[], int[]>(h1, h2);
            return hijos;
        }
    }
}
