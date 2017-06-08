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
                    cursos.Add(new Cursos("Libre"));
                }
                
                while (horas != 0)//Se le iran restando hasta que llegue a 0 para saber que ya no hay mas posibles clases
                {
                    //(int ID, int nEstudiantes, String nombre, Aulas aula, int nClases,int semestre,Profes profe,int grupo)
                    if (horas == 2)//Si solo queda espacio para una clase, establece la cantidad de veces del curso a 1
                    {
                        cursos.Add(new Cursos(cont, rnd.Next(15, 31), "Curso" + cont, null, 1, rnd.Next(1, 9), null, rnd.Next(1, 10)));
                        horas -= 2;
                    }
                    else
                    {
                        vecesEnSemana = rnd.Next(1, 3);// Random de cantidad de veces que tendra lugar una clase durante la semana
                        Cursos cursoActual = new Cursos(cont, rnd.Next(15, 31), "Curso" + cont, null, vecesEnSemana, rnd.Next(1, 9), null, rnd.Next(1, 10));
                        cursos.Add(cursoActual);
                        
                        if (vecesEnSemana == 1)//Si es una vez resta 2 horas, sino resta 4 por q serian 2 veces en la semana
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
            Console.ReadKey();
        }
    }
}
