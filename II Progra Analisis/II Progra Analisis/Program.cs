using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_Progra_Analisis
{
    class Program
    {
        public static int asignacionesSimple;
        public static int comparacionesSimple;
        public static int asignacionesPMX;
        public static int comparacionesPMX;
        public static int asignacionesFitness;
        public static int comparacionesFitness;
        static Random rnd = new Random();
        public static Tuple<int[], int[]> CruceSimple(int[] p1, int[] p2)
        {
            
            Tuple<int[], int[]> hijos = C1P(p1, p2);
            asignacionesSimple += 1;
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
            asignacionesSimple += 1;
            return hijos;

        }

        static Tuple<int[], int[]> C1P(int[] pa1, int[] ma1)
        {
            
            int puntoCX = rnd.Next(0, 9);
            Console.WriteLine("Punto de cruce: " + puntoCX);
            int[] h1 = new int[pa1.Length];
            int[] h2 = new int[ma1.Length];
            asignacionesSimple += 4;
            for (int i = 0; i < h1.Length; i++)
            {
                comparacionesSimple += 2;
                if (i > puntoCX)
                {
                    h1[i] = ma1[i];
                    h2[i] = pa1[i];
                    asignacionesSimple += 2;
                }
                else
                {
                    h1[i] = pa1[i];
                    h2[i] = ma1[i];
                    asignacionesSimple += 2;
                }
            }
            asignacionesSimple += 2;
            Tuple<int[], int[]> hijos = new Tuple<int[], int[]>(h1, h2);
            return hijos;
        }
    
    private static int[] PMX2(int[] p1, int[] p2)
        {
            int punto1 = rnd.Next(0, p1.Length);
            int punto2 = rnd.Next(punto1 + 1, p1.Length);
            int[] h1 = new int[p1.Length];
            //punto1 = 3;
            //punto2 = 6;
            List<int> x = new List<int>();
            List<int> y = new List<int>();
            asignacionesPMX += 2;
            int index, aux, hostia;
            asignacionesPMX += 1;
            for (int j = punto1; j < punto2; j++)
            {
                h1[j] = p1[j];
                asignacionesPMX += 2;
                comparacionesPMX += 1;
            }
            asignacionesPMX += 1;
            for (int v = punto1; v < punto2; v++)
            {
                index = Array.IndexOf(h1, p2[v]);
                aux = Array.IndexOf(p2, p2[v]);
                asignacionesPMX += 1;
                if (index == -1)
                {
                    asignacionesPMX += 2;
                    x.Add(aux);
                    y.Add(h1[v]);
                }
                comparacionesPMX += 1;
                asignacionesPMX += 1;
            }/////
             /*Console.WriteLine("----------------------------");
             for (int n = 0; n < p1.Length; n++)
                 {
                     Console.Write(h1[n] + " ");
                 }
                 Console.WriteLine("");
                 /////*/
            asignacionesPMX += 1;
            for (int c = 0; c < y.Count; c++)
            {
                //Console.WriteLine(hostia);
                hostia = Array.IndexOf(p2, y[c]);
                asignacionesPMX += 1;
                //Console.WriteLine(hostia);
                comparacionesPMX += 1;
                if (hostia == -1)
                {
                    hostia = Array.IndexOf(p2, h1[0]);
                    //pequenya mutacion
                    h1[y[c]] = p2[x[c]];
                    //continue;
                    asignacionesPMX += 2;
                }

                else if (h1[hostia] == 0)
                {
                    comparacionesPMX += 1;
                    h1[hostia] = p2[x[c]];
                    asignacionesPMX += 1;
                }
                    
                
                else
                {
                    comparacionesPMX += 1;
                    //z.Add(h1[hostia]);
                    hostia = Array.IndexOf(p2, h1[hostia]);
                    h1[hostia] = p2[x[c]];
                    asignacionesPMX += 2;
                }
            }
            asignacionesPMX += 1;
            for (int X = 0; X < h1.Length; X++)
            {
                comparacionesPMX += 1;
                if (h1[X] == 0)
                {
                    h1[X] = p1[X];
                    asignacionesPMX += 1;
                }
                asignacionesPMX += 1;
                comparacionesPMX += 1;
            }
            //Console.WriteLine("----------------------------");
            /*for (int i = 0; i < h1.Length; i++)
            {
                Console.Write(h1[i] + " ");
            }
            Console.WriteLine("");*/
            asignacionesPMX += 1;
            return h1;
        }

        static void Main(string[] args)
        {
            Stopwatch crono = new Stopwatch();
            Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            long totalBytesOfMemoryUsed;
            Random rnd = new Random();
            List<Cursos> cursos;
            List<Horario> listaHorarios = new List<Horario>();
            Horario horario;
            List<Profes> listaProfes = new List<Profes>();

            //---------------------------------------------Crea los profesores---------------------------------------------------------------
            for (int i = 0; i < 20; i++)
            {
                listaProfes.Add(new Profes(i + 1, "Profe" + ((i + 1)), (rnd.Next(1, 8)) * 2));
            }

            //---------------------------------------------Construye el horario--------------------------------------------------------------
            int cont = 1;
            int cont2 = 1;
            int vecesEnSemana;
            int semestre = 6;
            while (semestre != 0)//Crea horarios la cantidad de semestres establecida
            {
                int horas = 60;// Cantidad de horas de posibles clases incluidads las libres
                int libres = rnd.Next(10, 15);//Un random de la cantidad de libres que tendra el horario
                horas -= (libres * 2);//Se multiplica *2 debido a que cada clase son 2 horas
                cursos = new List<Cursos>();
                horario = new Horario();
                for (int i = 0; i < libres; i++)//Añade las libres a cursos
                {
                    cursos.Add(new Cursos(cont, "Libre"));
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
                Console.WriteLine("\t" + "Lunes" + "\t" + "Martes" + "\t" + "Mierco" + "\t" + "Jueves" + "\t" + "Viernes");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write(hora + ":00" + "\t");
                    for (int k = 0; k < 5; k++)
                    {
                        Cursos a = h.matriz[k, i];
                        if (a.nombre != "Libre")
                            Console.Write(a.nombre + "\t");
                        else
                            Console.Write("Libre" + "\t");
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
            Horario h2 = new Horario();
            Horario h3 = new Horario();
            Horario h4 = new Horario();
            List<Cursos> l1 = new List<Cursos>();
            List<Cursos> l2 = new List<Cursos>();

            List<Horario> listaHorariosPMX = new List<Horario>();
            List<Horario> listaHorariosSimple = new List<Horario>();
            for (int i = 0; i < listaHorarios[0].cursos.Count; i++)
            {
                l1.Add(listaHorarios[0].cursos[i]);
                l2.Add(listaHorarios[0].cursos[i]);
                h1.cursos.Add(listaHorarios[0].cursos[i]);
                h2.cursos.Add(listaHorarios[0].cursos[i]);
                h3.cursos.Add(listaHorarios[0].cursos[i]);
                h4.cursos.Add(listaHorarios[0].cursos[i]);
            }

            p1.cursos = l1;
            p1.llenaLecciones();
            p1.DesordenarLista();

            Console.WriteLine();

            listaHorariosPMX.Add(p1);
            listaHorariosSimple.Add(p1);

            p2.cursos = l2;
            p2.llenaLecciones();
            p2.DesordenarLista();
            p2.DesordenarLista();
            listaHorariosPMX.Add(p2);
            listaHorariosSimple.Add(p2);

            int[] pruebaP1 = new int[p1.lecciones.Count];
            int[] pruebaP2 = new int[p1.lecciones.Count];
            for (int i = 0; i < p1.lecciones.Count; i++)
            {
                pruebaP1[i] = p1.lecciones[i].nleccion;
                pruebaP2[i] = p2.lecciones[i].nleccion;
            }

            Console.WriteLine("-------------------------------------------Prueba PMX-------------------------------------");
            crono.Start();
            int[] pruebaPMX = PMX2(pruebaP1, pruebaP2);
            int[] pruebaPMX2 = PMX2(pruebaP2, pruebaP1);
            for (int i = 0; i < pruebaPMX.Length; i++)
            {
                foreach (Cursos c in listaHorarios[0].lecciones)
                {
                    if (c.nleccion == pruebaPMX[i])
                        h1.lecciones.Add(c);
                }
            }
            for (int i = 0; i < pruebaPMX2.Length; i++)
            {
                foreach (Cursos c in listaHorarios[0].lecciones)
                {
                    if (c.nleccion == pruebaPMX2[i])
                        h2.lecciones.Add(c);
                }
            }
            Console.WriteLine(h1.lecciones.Count);
            //h1.llenaHorario();
            listaHorariosPMX.Add(h1);
            listaHorariosPMX.Add(h2);
            
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



            Tuple<Horario, Horario> nuevaGenPMX = fitnessAux(p1, p2, h1, h2);
            nuevaGenPMX.Item1.llenaHorario();
            nuevaGenPMX.Item2.llenaHorario();


            //OJO CON ESTO///////////////////////
            totalBytesOfMemoryUsed = currentProcess.WorkingSet64;
            /////////////////////////////////////
            crono.Stop();
            foreach (Horario h in listaHorariosPMX)
            {
                foreach (Cursos cur in h.lecciones)
                {
                    Console.Write(cur.nleccion + "-");
                }
                Console.WriteLine();
                Console.WriteLine("-------------------------PMX-------------------------");
            }
            Console.WriteLine("Tiempo Transcurrido: " + crono.Elapsed + " ms");
            Console.WriteLine("Cantidad de memoria utilizada: " + totalBytesOfMemoryUsed / 1000000 + " MB");
            Console.ReadKey();
            Console.WriteLine(" ");
            int horaa = 7;
            Console.WriteLine("\t" + "Lunes" + "\t" + "Martes" + "\t" + "Mierco" + "\t" + "Jueves" + "\t" + "Viernes");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(horaa + ":00" + "\t");
                for (int k = 0; k < 5; k++)
                {
                    Cursos a = nuevaGenPMX.Item1.matriz[k, i];
                    Console.Write(a.nombre + a.nleccion + "\t");
                }
                horaa += 2;
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------cambio semestre-------------------------");
            horaa = 7;
            Console.WriteLine("\t" + "Lunes" + "\t" + "Martes" + "\t" + "Mierco" + "\t" + "Jueves" + "\t" + "Viernes");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(horaa + ":00" + "\t");
                for (int k = 0; k < 5; k++)
                {
                    Cursos a = nuevaGenPMX.Item2.matriz[k, i];
                    Console.Write(a.nombre + a.nleccion + "\t");
                }
                horaa += 2;
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------cambio semestre-------------------------");

            Console.WriteLine();

            Console.ReadKey();
            // Console.WriteLine("-------------------------------------------Prueba Simple-------------------------------------");
            crono.Start();
            Tuple<int[], int[]> pruebaSimple = CruceSimple(pruebaP1, pruebaP2);
            for (int i = 0; i < pruebaSimple.Item1.Length; i++)
            {
                foreach (Cursos c in listaHorarios[0].lecciones)
                {
                    if (c.nleccion == pruebaPMX[i])
                        h3.lecciones.Add(c);
                }
            }
            for (int i = 0; i < pruebaSimple.Item2.Length; i++)
            {
                foreach (Cursos c in listaHorarios[0].lecciones)
                {
                    if (c.nleccion == pruebaPMX2[i])
                        h4.lecciones.Add(c);
                }
            }
            listaHorariosSimple.Add(h3);
            listaHorariosSimple.Add(h4);

            Tuple<Horario, Horario> nuevaGenSimple = fitnessAux(p1, p2, h1, h2);
            nuevaGenSimple.Item1.llenaHorario();
            nuevaGenSimple.Item2.llenaHorario();

            //OJO CON ESTO///////////////////////
            totalBytesOfMemoryUsed = currentProcess.WorkingSet64;
            /////////////////////////////////////
            crono.Stop();
            Console.WriteLine("Tiempo Transcurrido: " + crono.Elapsed + " ms");
            Console.WriteLine("Cantidad de memoria utilizada: " + totalBytesOfMemoryUsed / 1000000 + " MB");
            Console.ReadKey();
            Console.WriteLine(" ");

            horaa = 7;
            Console.WriteLine("\t" + "Lunes" + "\t" + "Martes" + "\t" + "Mierco" + "\t" + "Jueves" + "\t" + "Viernes");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(horaa + ":00" + "\t");
                for (int k = 0; k < 5; k++)
                {
                    Cursos a = nuevaGenSimple.Item1.matriz[k, i];
                    Console.Write(a.nombre + a.nleccion + "\t");
                }
                horaa += 2;
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------cambio semestre-------------------------");
            horaa = 7;
            Console.WriteLine("\t" + "Lunes" + "\t" + "Martes" + "\t" + "Mierco" + "\t" + "Jueves" + "\t" + "Viernes");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(horaa + ":00" + "\t");
                for (int k = 0; k < 5; k++)
                {
                    Cursos a = nuevaGenSimple.Item2.matriz[k, i];
                    Console.Write(a.nombre + a.nleccion + "\t");
                }
                horaa += 2;
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------cambio semestre-------------------------");

            Console.WriteLine();

            Console.ReadKey();



        }

        public static double Fitness(Horario hijo1)
        {
            Console.WriteLine("------------------------------------------");
            double[] perfectHit = { 1.6, 1.5, 1.33333333333333333333, 1 };
            double fit = 0;
            double ultimaHora = 0, primeraHora = 0, cursos = 0, hora = 7, dia = 0, hitCombo = 0;
            asignacionesFitness += 9;
            for (int i = 0; i < hijo1.lecciones.Count; i++)
            {
                //Console.WriteLine("hora: " + hora);
                comparacionesFitness += 2;
                if ((hijo1.lecciones[i].nombre != "Libre") && (primeraHora != 0) && (dia < 7))
                {
                    ultimaHora = hora;
                    cursos++;
                    asignacionesFitness += 2;
                }
                else if ((hijo1.lecciones[i].nombre != "Libre") && (primeraHora == 0) && (dia < 7))
                {
                    primeraHora = hora;
                    cursos++;
                    asignacionesFitness += 2;
                }
                comparacionesFitness += 2;
                hora += 2;
                asignacionesFitness += 1;
                comparacionesFitness += 1;
                if (dia == 6)
                {
                    Console.WriteLine("Fit del dia: "+ (ultimaHora - primeraHora) / cursos);
                    comparacionesFitness += 4;
                    if (perfectHit.Contains((ultimaHora - primeraHora) / cursos))
                    {
                        hitCombo++;
                        Console.WriteLine("It has been a lovely day... XD");
                        asignacionesFitness += 1;
                    }
                    fit += (ultimaHora - primeraHora) / cursos;
                    asignacionesFitness += 1;
                    Console.WriteLine("Fit acumulado: "+fit);
                    cursos = 0;
                    dia = 0;
                    hora = 7;
                    primeraHora = 0;
                    ultimaHora = 0;
                    asignacionesFitness += 5;
                }
                dia++;
                asignacionesFitness += 2;
                comparacionesPMX += 1;
                asignacionesFitness += 3;
            }
            if(hitCombo == 5)
            {
                Console.WriteLine("Horario Perfecto, la PTM!!!!");
            }
            //Console.WriteLine("Total Fit: "+fit);
            Console.WriteLine("-------------------------");
            asignacionesFitness += 1;
            return fit;
        }

        public static Tuple<Horario, Horario> fitnessAux(Horario z1, Horario z2,Horario z3, Horario z4)
        {
            double fitP1 = Fitness(z1);
            double fitP2 = Fitness(z2);
            double fitH1 = Fitness(z3);
            double fitH2 = Fitness(z4);
            

            List<Horario> bestH = new List<Horario>();
            //Horario best2 = new Horario();
            asignacionesFitness += 5;

            Console.WriteLine("Fit del padre 1: " + fitP1);
            Console.WriteLine("Fit del padre 2: " + fitP2);
            Console.WriteLine("Fit del hijo 1: "+ fitH1);
            Console.WriteLine("Fit del hijo 2: "+ fitH2);

            if (fitH1 < 0)
                fitH1 = 5;
            if (fitH2 < 0)
                fitH2 = 5;
            if (fitP1 < 0)
                fitP1 = 5;
            if (fitP2 < 0)
                fitP2 = 5;
            asignacionesFitness = +4;
            comparacionesFitness += 4;

            if ((fitP1 >= fitH1) && (fitP2 >= fitH1) && (fitP1 >= fitH2) && (fitP2 >= fitH2))
            {
                bestH.Add(z3);
                bestH.Add(z4);
                comparacionesFitness += 4;
                asignacionesFitness += 2;
            }
            else if ((fitP1 >= fitH1) && (fitP2 >= fitH1) && (fitP1 < fitH2) && (fitP2 >= fitH2))
            {
                bestH.Add(z1);
                bestH.Add(z3);
                comparacionesFitness += 8;
                asignacionesFitness += 2;
            }

            else if ((fitP1 >= fitH1) && (fitP2 >= fitH1) && (fitP1 >= fitH2) && (fitP2 < fitH2))
            {
                bestH.Add(z2);
                bestH.Add(z3);
                comparacionesFitness += 12;
                asignacionesFitness += 2;
            }
            else if ((fitP1 < fitH1) && (fitP2 >= fitH1) && (fitP1 >= fitH2) && (fitP2 >= fitH2))
            {
                bestH.Add(z1);
                bestH.Add(z4);
                comparacionesFitness += 16;
                asignacionesFitness += 2;
            }
            else if ((fitP1 >= fitH1) && (fitP2 < fitH1) && (fitP1 >= fitH2) && (fitP2 >= fitH2))
            {
                bestH.Add(z2);
                bestH.Add(z4);
                comparacionesFitness += 20;
                asignacionesFitness += 2;
            }
            else
            {
                bestH.Add(z1);
                bestH.Add(z2);
                comparacionesFitness += 24;
                asignacionesFitness += 2;
            }


            Tuple<Horario, Horario> bestGen = new Tuple<Horario, Horario>(bestH[0], bestH[1]);
            return bestGen;
        }
    }
}
