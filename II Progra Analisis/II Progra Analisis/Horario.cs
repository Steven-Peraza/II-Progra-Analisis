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
        //tamaño6 cursos por lashoras

        public void llenaHorario()
        {
            int cont = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 6; k++)
                {
                    Cursos cursoActual = cursos[cont];
                    matriz[i, k] = cursoActual;
                    if (cursos[cont].horas == 2)
                    {
                        Cursos cursoAux = new Cursos(cursoActual.ID, cursoActual.nEstudiantes, cursoActual.nombre, null, cursoActual.horas, cursoActual.semestre, null, cursoActual.grupo);
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
    }
}
