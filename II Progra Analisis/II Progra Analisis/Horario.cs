using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_Progra_Analisis
{
    class Horario
    {
        public Cursos[,] matriz = new Cursos[5,6];//Matriz dia x hora
        public List<Cursos> cursos = new List<Cursos>();

        public void llenaHorario()//Pasa la lista de cursos a matriz referenciado a las horas y los dias
        {
            cursos = DesordenarLista(cursos);
            int cont = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 6; k++)
                {
                    Cursos cursoActual = cursos[cont];
                    matriz[i, k] = cursoActual;
                    if (cursos[cont].nClases == 2)
                    {
                        Cursos cursoAux = new Cursos(cursoActual.ID, cursoActual.nEstudiantes, cursoActual.nombre, null, cursoActual.nClases, cursoActual.semestre, null, cursoActual.grupo);
                        k += 1;
                        if (k == 6)
                        {
                            k = 0;
                            i += 1;
                            if (i == 5)
                            {
                                return;
                            }
                        }
                        matriz[i, k] = cursoAux;
                    }
                    cont += 1;

                }
            }
        }
        public List<Cursos> DesordenarLista(List<Cursos> input)
        {
            List<Cursos> arr = input;
            List<Cursos> arrDes = new List<Cursos>();

            Random randNum = new Random();
            while (arr.Count > 0)
            {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }
            return arrDes;
        }
    }
}
