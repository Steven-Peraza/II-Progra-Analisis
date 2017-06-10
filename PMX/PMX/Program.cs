using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMX
{
    class Program
    {
        static void Main(string[] args)
        {
            //lo que mide la memoria
            Stopwatch crono = new Stopwatch();
            Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();

            crono.Start();
            int[] p1 = new int[10];
            int[] p2 = new int[10];

            int[] p3 = { 2, 3, 0, 5, 4, 1, 6, 8, 9, 7};
            int[] p4 = { 7, 7, 1, 6, 3, 4, 9, 5, 8, 2 };


            //llenarArreglo(p1,p2);

            /*for (int i = 0; i < p1.Length; i++)
            {
                Console.Write(p3[i]+" ");
            }
            Console.WriteLine("");
            for (int i = 0; i < p2.Length; i++)
            {
                Console.Write(p4[i]+" ");
            }
            Console.WriteLine("");*/

            generachons(p3, p4, 0);
            //OJO CON ESTO///////////////////////
            long totalBytesOfMemoryUsed = currentProcess.WorkingSet64;
            /////////////////////////////////////
            crono.Stop();
            Console.WriteLine("Tiempo Transcurrido: "+ crono.Elapsed + " ms");
            Console.WriteLine("Cantidad de memoria utilizada: "+totalBytesOfMemoryUsed/1000000 + " MB");
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
                for (int j = punto1; j < punto2; j++)
                {
                    h1[j] = p1[j];
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
            /*Console.WriteLine("----------------------------");
            for (int n = 0; n < p1.Length; n++)
                {
                    Console.Write(h1[n] + " ");
                }
                Console.WriteLine("");
                /////*/
                for (int c = 0; c < y.Count; c++)
                {
                    hostia = Array.IndexOf(p2, y[c]);
                    //Console.WriteLine(hostia);
                    if(hostia == -1)
                    {
                    hostia = Array.IndexOf(p2, h1[0]);
                    //pequenya mutacion
                    h1[y[c]] = p2[x[c]];
                    //continue;
                    }

                    else if(h1[hostia] == 0)
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
            //Console.WriteLine("----------------------------");
            /*for (int i = 0; i < h1.Length; i++)
            {
                Console.Write(h1[i] + " ");
            }
            Console.WriteLine("");*/

            return h1;
        }

        private static void generachons(int[] j1, int[] j2, int veces)
        {
            int[] aux = new int[10];
            aux = j1;
            if (veces == 10)
            {
                Console.WriteLine("Fin de las generaciones");
                return;
            }

            else
            {
                j1 = PMX(j2, aux);
                j2 = PMX(aux, j2);
            }

            Console.WriteLine("Generacion: "+veces);
            for (int i = 0; i < j1.Length; i++)
            {
                Console.Write(j1[i] + " ");
            }
            Console.WriteLine("");

            for (int i = 0; i < j1.Length; i++)
            {
                Console.Write(j2[i] + " ");
            }
            Console.WriteLine("");
            veces++;
            generachons(j1, j2, veces);
        }
    }
}
