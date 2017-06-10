using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_Progra_Analisis
{
    class Program
    {
        public static Tuple<int[], int[]> CruceSimple(int[] p1, int[] p2)
        {

            Tuple<int[], int[]> hijos = C1P(p1, p2);

            Console.WriteLine("Hijo 1 : ");
            for (int i = 0; i < p1.Length; i++)
            {
                Console.Write(hijos.Item1[i] + " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Hijo 2 : ");
            for (int i = 0; i < p2.Length; i++)
            {
                Console.Write(hijos.Item2[i] + " ");
            }

            return hijos;

        }

        static Tuple<int[], int[]> C1P(int[] pa1, int[] ma1)
        {
            Random rnd = new Random();
            int puntoCX = rnd.Next(0, 9);
            Console.WriteLine("Punto de cruce: " + puntoCX);
            int[] h1 = new int[pa1.Length];
            int[] h2 = new int[ma1.Length];


            for (int i = 0; i < h1.Length; i++)
            {
                if (i > puntoCX)
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
    
    private static int[] PMX2(int[] p1, int[] p2)
        {
            Random rnd = new Random();
            int punto1 = rnd.Next(0, p1.Length);
            int punto2 = rnd.Next(punto1 + 1, p1.Length);
            int[] h1 = new int[p1.Length];
            punto1 = 3;
            punto2 = 6;
            List<int> x = new List<int>();
            List<int> y = new List<int>();
            int index, aux, hostia;
            for (int j = punto1; j < punto2; j++)
            {
                h1[j] = p1[j];
            }
            for (int v = punto1; v < punto2; v++)
            {
                index = Array.IndexOf(h1, p2[v]);
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
                //Console.WriteLine(hostia);
                hostia = Array.IndexOf(p2, y[c]);
                //Console.WriteLine(hostia);
                if (hostia == -1)
                {
                    hostia = Array.IndexOf(p2, h1[0]);
                    //pequenya mutacion
                    h1[y[c]] = p2[x[c]];
                    //continue;
                }

                if (h1[hostia] == 0)
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
        
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Cursos> cursos;
            List<Horario> listaHorarios = new List<Horario>();
            Horario horario;
            List<Profes> listaProfes = new List<Profes>();

            //---------------------------------------------Crea los profesores---------------------------------------------------------------
            for (int i = 0; i < 20; i++)
            {
                listaProfes.Add(new Profes(i + 1, "Profe" + ((i + 1)), (rnd.Next(1, 8))*2));
            }

            //---------------------------------------------Construye el horario--------------------------------------------------------------
            int cont = 1;
            int cont2 = 1;
            int vecesEnSemana;
            int semestre = 6;
            while(semestre != 0)//Crea horarios la cantidad de semestres establecida
            {
                int horas = 60;// Cantidad de horas de posibles clases incluidads las libres
                int libres = rnd.Next(10, 15);//Un random de la cantidad de libres que tendra el horario
                horas -= (libres * 2);//Se multiplica *2 debido a que cada clase son 2 horas
                cursos = new List<Cursos>();
                horario = new Horario();
                for (int i = 0; i < libres; i++)//Añade las libres a cursos
                {
                    cursos.Add(new Cursos(cont,"Libre"));
                    cont += 1;
                }
                
                while (horas != 0)//Se le iran restando hasta que llegue a 0 para saber que ya no hay mas posibles clases
                {
                    //(int ID, int nEstudiantes, String nombre, Aulas aula, int nClases,int semestre,Profes profe,int grupo)
                    if (horas == 2)//Si solo queda espacio para una clase, establece la cantidad de veces del curso a 1
                    {
                        cursos.Add(new Cursos(cont, rnd.Next(15, 31), "Curso" + cont2, null, 1, rnd.Next(1, 9), null, rnd.Next(1, 10)));
                        horas -= 2;
                    }
                    else
                    {
                        vecesEnSemana = rnd.Next(1, 3);// Random de cantidad de veces que tendra lugar una clase durante la semana
                        Cursos cursoActual = new Cursos(cont, rnd.Next(15, 31), "Curso" + cont2, null, vecesEnSemana, rnd.Next(1, 9), null, rnd.Next(1, 10));
                        cursos.Add(cursoActual);

                        if (vecesEnSemana == 1)//Si es una vez resta 2 horas, sino resta 4 por q serian 2 veces en la semana
                            horas -= 2;
                        else
                        {
                            horas -= 4;
                        }
                    }
                    cont += 1;
                    cont2 += 1;
                }
                horario.cursos = cursos;
                horario.llenaLecciones();
                horario.DesordenarLista();
                listaHorarios.Add(horario);

                semestre -= 1;
            }

            //---------------------------------------------Imprime los horarios--------------------------------------------------------------
            foreach (Horario h in listaHorarios)
            {
            int hora = 7;
            Console.WriteLine("\t"+"Lunes"+ "\t"+ "Martes"+ "\t"+"Mierco"+ "\t"+"Jueves"+ "\t"+"Viernes");
                for (int i = 0; i < 6; i++)
                {    
                Console.Write(hora+":00"+ "\t");
                    for (int k = 0; k < 5; k++)
                    {
                    Cursos a = h.matriz[k, i];
                    if (a.nombre != "Libre")
                        Console.Write(a.nombre+"\t");
                    else
                        Console.Write("Libre"+ "\t");
                    }
                    hora += 2;
                    Console.WriteLine();
                }
                Console.WriteLine("-------------------------cambio semestre-------------------------");
            }

            //---------------------------------------------asdasdasdasdasdasdasdasd--------------------------------------------------------------
            Horario p1 = new Horario();
            Horario p2 = new Horario();
            Horario h1 = new Horario();
            List<Cursos> l1 = new List<Cursos>();
            List<Cursos> l2 = new List<Cursos>();
            
            List<Horario> listaHorariosPMX = new List<Horario>();
            for (int i = 0; i < listaHorarios[0].cursos.Count; i++)
            {
                l1.Add(listaHorarios[0].cursos[i]);
                l2.Add(listaHorarios[0].cursos[i]);
                h1.cursos.Add(listaHorarios[0].cursos[i]);
            }

            p1.cursos = l1;
            p1.llenaLecciones();
            p1.DesordenarLista();
            
            Console.WriteLine();
            
            listaHorariosPMX.Add(p1);

            p2.cursos = l2;
            p2.llenaLecciones();
            p2.DesordenarLista();
            p2.DesordenarLista();
            listaHorariosPMX.Add(p2);

            int []pruebaP1 = new int [p1.lecciones.Count];
            int[] pruebaP2 = new int[p1.lecciones.Count];
            for (int i = 0; i < p1.lecciones.Count; i++)
            {
                pruebaP1[i] = p1.lecciones[i].nleccion;
                pruebaP2[i] = p2.lecciones[i].nleccion;
            }
            
            Console.WriteLine("-------------------------------------------Prueba PMX-------------------------------------");
            
            int[] pruebaPMX = PMX2(pruebaP1,pruebaP2);
            for (int i = 0; i < pruebaPMX.Length; i++)
            {
                foreach (Cursos c in listaHorarios[0].lecciones)
                {
                    if (c.nleccion == pruebaPMX[i])
                        h1.lecciones.Add(c);
                }
            }
            Console.WriteLine(h1.lecciones.Count);
            //h1.llenaHorario();
            listaHorariosPMX.Add(h1);
            /*for (int i = 0; i < prueba1.Length; i++)
            {
                Console.Write(prueba1[i]+"-");
            }
            Console.WriteLine();
            for (int i = 0; i < prueba2.Length; i++)
            {
                Console.Write(prueba2[i] + "-");
            }
            Console.WriteLine();
            for (int i = 0; i < prueba.Length; i++)
            {
                Console.Write(prueba[i] + "-");
            }
            Console.WriteLine();
            */

            foreach (Horario h in listaHorariosPMX)
            {
                foreach (Cursos cur in h.lecciones)
                {
                    Console.Write(cur.nleccion+"-");
                }
                Console.WriteLine();
                Console.WriteLine("-------------------------cambio semestre-------------------------");
            }
            Console.WriteLine("-------------------------------------------Prueba Simple-------------------------------------");
            Tuple<int[],int[]> pruebaSimple = CruceSimple(pruebaP1, pruebaP2);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
