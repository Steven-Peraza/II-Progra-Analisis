﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_Progra_Analisis
{
    class Program
    {
        public static Cursos[] PMX(List<Cursos> c1, List<Cursos> c2)
        {
            Cursos[] p1 = new Cursos[c1.Count];
            Cursos[] p2 = new Cursos[c2.Count];
            Console.WriteLine(c1.Count);
            Console.WriteLine(c2.Count);
            for (int i = 0; i < c1.Count; i++)
            {
                p1[i] = c1[i];
                p2[i] = c2[i];
            }
            Cursos [] h1 = new Cursos[p1.Length];
            Random rnd = new Random();
            int punto1 = rnd.Next(0, p1.Length);
            int punto2 = rnd.Next(punto1 + 1, p2.Length);
            punto1 = (3);
            punto2 = (7);
            List<int> x = new List<int>();
            List<Cursos> y = new List<Cursos>();
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
                hostia = Array.IndexOf(p2, y[c]);
                //Console.WriteLine(hostia);
                if (hostia == -1)
                {
                    hostia = Array.IndexOf(p2, h1[0]);
                    //pequenya mutacion
                    h1[y[c].nleccion] = p2[x[c]];

                    //continue;
                }

                else if (h1[hostia] == null)
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
                if (h1[X] == null)
                {
                    h1[X] = p1[X];
                }
            }
            /*Console.WriteLine("----------------------------");
            for (int i = 0; i < h1.Length; i++)
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
            List<Cursos> cursos2;
            List<Horario> listaHorarios = new List<Horario>();
            List<Horario> listaHorarios2 = new List<Horario>();
            Horario horario;
            Horario horario2;
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
                cursos2 = new List<Cursos>();
                horario = new Horario();
                horario2 = new Horario();
                for (int i = 0; i < libres; i++)//Añade las libres a cursos
                {
                    cursos.Add(new Cursos(cont,"Libre"));
                    cursos2.Add(new Cursos(cont, "Libre"));
                    cont += 1;
                }
                
                while (horas != 0)//Se le iran restando hasta que llegue a 0 para saber que ya no hay mas posibles clases
                {
                    //(int ID, int nEstudiantes, String nombre, Aulas aula, int nClases,int semestre,Profes profe,int grupo)
                    if (horas == 2)//Si solo queda espacio para una clase, establece la cantidad de veces del curso a 1
                    {
                        cursos.Add(new Cursos(cont, rnd.Next(15, 31), "Curso" + cont2, null, 1, rnd.Next(1, 9), null, rnd.Next(1, 10)));
                        cursos2.Add(new Cursos(cont, rnd.Next(15, 31), "Curso" + cont2, null, 1, rnd.Next(1, 9), null, rnd.Next(1, 10)));
                        horas -= 2;
                    }
                    else
                    {
                        vecesEnSemana = rnd.Next(1, 3);// Random de cantidad de veces que tendra lugar una clase durante la semana
                        Cursos cursoActual = new Cursos(cont, rnd.Next(15, 31), "Curso" + cont2, null, vecesEnSemana, rnd.Next(1, 9), null, rnd.Next(1, 10));
                        Cursos cursoActual2 = new Cursos(cont, rnd.Next(15, 31), "Curso" + cont2, null, vecesEnSemana, rnd.Next(1, 9), null, rnd.Next(1, 10));
                        cursos.Add(cursoActual);
                        cursos2.Add(cursoActual2);

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

                horario2.cursos = cursos2;
                horario2.llenaLecciones();
                horario2.DesordenarLista();
                listaHorarios2.Add(horario2);

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
            }
            p1.cursos = l1;
            
            p1.llenaLecciones();
            p1.DesordenarLista();
            
            Console.WriteLine();
            
            listaHorariosPMX.Add(p1);
            for (int i = 0; i < listaHorarios[0].cursos.Count; i++)
            {
                l2.Add(listaHorarios2[0].cursos[i]);
            }
            p2.cursos = l2;
            p2.llenaLecciones();
            p2.DesordenarLista();
            p2.DesordenarLista();
            listaHorariosPMX.Add(p2);


            Console.WriteLine("-------------------------------------------Prueba PMX-------------------------------------");
            Cursos[] prueba = PMX(p1.lecciones,p2.lecciones);
            List<Cursos> c = new List<Cursos>();
            for (int i = 0; i < prueba.Length; i++)
            {
                c.Add(prueba[i]);
            }
            h1.cursos = p1.cursos;
            h1.lecciones = c;
            h1.llenaHorario();
            listaHorariosPMX.Add(h1);
            foreach (Horario h in listaHorariosPMX)
            {
                foreach (Cursos cur in h.lecciones)
                {
                    Console.Write(cur.ID+"-");
                }
                Console.WriteLine();
                Console.WriteLine("-------------------------PMX-------------------------");
            }
            Console.ReadKey();
        }
    }
}
