using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_Progra_Analisis
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Cursos> cursos = new List<Cursos>();
            List<Horario> listaHorarios = new List<Horario>();
            Cursos[,] matriz = new Cursos[5, 6];
            Horario horario = new Horario();

            int cont = 1;
            int vecesEnSemana;
            int semestre = 6;
            while(semestre != 0)
            {
                int horas = 60;
                int libres = rnd.Next(10, 15);
                horas -= (libres * 2);
                matriz = new Cursos[5, 6];
                cursos = new List<Cursos>();
                horario = new Horario();
                for (int i = 0; i < libres; i++)
                {
                    cursos.Add(new Cursos("Libre"));
                }
                
                while (horas != 0)
                {
                    if (horas == 2)
                    {
                        cursos.Add(new Cursos(cont, rnd.Next(15, 31), "Curso" + cont, null, 1, rnd.Next(1, 9), null, rnd.Next(1, 10)));
                        horas -= 2;
                    }
                    else
                    {
                        vecesEnSemana = rnd.Next(1, 3);
                        Cursos cursoActual = new Cursos(cont, rnd.Next(15, 31), "Curso" + cont, null, vecesEnSemana, rnd.Next(1, 9), null, rnd.Next(1, 10));
                        cursos.Add(cursoActual);
                        
                        if (vecesEnSemana == 1)
                            horas -= 2;
                        else
                        {
                            horas -= 4;
                        }
                            
                    }
                    cont += 1;
                }
                horario.cursos = cursos;
                horario.llenaHorario();
                listaHorarios.Add(horario);
                semestre -= 1;
            }
            
            
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
                        //Console.Write(a.ID + "---" + a.nEstudiantes + "---" + a.nombre + "---" + a.aula + "---" + a.horas + "---" + a.semestre + "---" + a.profe + "---" + a.grupo);
                        else
                            Console.Write("Libre"+ "\t");
                        }
                    hora += 2;
                    Console.WriteLine();
                }
                Console.WriteLine("-------------------------cambio semestre-------------------------");
            }
                
            
            
            cont = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 6; k++)
                {
                    horario.matriz[i,k] = cursos[cont];
                }
            }
            Console.ReadKey();
        }
    }
}
