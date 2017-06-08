using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMX
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] p1 = new int[10];
            int[] p2 = new int[10];

            int[] p3 = { 2, 3, 0, 5,4,1,6,8,9,7};
            int[] p4 = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };


            //llenarArreglo(p1,p2);

            for (int i = 0; i < p1.Length; i++)
            {
                Console.Write(p3[i]+" ");
            }
            Console.WriteLine("");
            for (int i = 0; i < p2.Length; i++)
            {
                Console.Write(p4[i]+" ");
            }
            Console.WriteLine("");



            Console.ReadKey();
        }

        private static void llenarArreglo(int[] lista1, int[] lista2)
        {
            //hay un problema aqui, ambas listas tienen el mismo tamanyo pero no los mismos elementos, entonces al buscar mas adelante se cae... XD
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                //lista1[i] = rnd.Next(1,10);
                lista1[i] = i;
            }
            for (int i = 0; i < 10; i++)
            {
                //lista2[i] = rnd.Next(1, 10);
            }
        }

        private static int[] PMX(int[] p1, int[] p2)
        {
            Random rnd = new Random();
            int punto1 = rnd.Next(0, p1.Length);
            int punto2 = rnd.Next(punto1+1,p1.Length);
            int[] h1 = new int[10];
            List<int> x = new List<int>();
            List<int> y = new List<int>();
            int index,aux,hostia;

            /*for (int i = 0; i < 10; i++)
            {*/
                for (int j = punto1; j < punto2; j++)
                {
                    h1[j] = p1[j];
                    //h2[j] = p2[j];
                }
                for (int v = punto1; v < punto2; v++)
                {
                    index = Array.IndexOf(h1,p2[v]);
                    aux = Array.IndexOf(p2, p2[v]);
                    if (index == -1)
                    {
                        x.Add(aux);
                        y.Add(h1[v]);
                    }
                }/////
                for (int n = 0; n < p1.Length; n++)
                {
                    Console.Write(h1[n] + " ");
                }
                Console.WriteLine("");
                /////
                for (int c = 0; c < y.Count; c++)
                {
                    hostia = Array.IndexOf(p2, y[c]);
                    if(h1[hostia] == 0)
                        h1[hostia] = p2[x[c]];
                    else
                    {
                        //z.Add(h1[hostia]);
                        hostia = Array.IndexOf(p2, h1[hostia]);
                        h1[hostia] = p2[x[c]];
                    }
                }
                for (int X = 0; X < h1.Length; X++)
                {
                    if (h1[X] == 0)
                    {
                        h1[X] = p1[X];
                    }
                }
            //}

            for (int i = 0; i < p1.Length; i++)
            {
                Console.Write(h1[i] + " ");
            }
            Console.WriteLine("");
            /*for (int i = 0; i < h1.Length; i++)
            {
                Console.Write(h1[i] + " ");
            }
            Console.WriteLine("");*/
            return h1;
        }
    }
}
