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
        public List<Cursos> lecciones = new List<Cursos>();

        public void llenaHorario()//Pasa la lista de cursos a matriz referenciado a las horas y los dias
        {
            int cont = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 6; k++)
                {
                    //lecciones[cont].nleccion = cont + 1;
                    matriz[i,k] = lecciones[cont];
                    cont += 1;
                }  
            }
        }
        public void DesordenarLista()
        {
            List<Cursos> arr = lecciones;
            List<Cursos> arrDes = new List<Cursos>();

            Random randNum = new Random();
            while (arr.Count > 0)
            {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }
            lecciones = arrDes;
            llenaHorario();
        }
        public void llenaLecciones()
        {
            int cont = 1;
            Cursos cursoActual;
            Cursos cursoAux;
            
            for (int i = 0; i < cursos.Count; i++)
            {
                cursoActual = cursos[i];
                cursoAux = new Cursos(cursoActual.ID, cursoActual.nEstudiantes, cursoActual.nombre, null, cursoActual.nClases, cursoActual.semestre, null, cursoActual.grupo);
                cursoAux.nleccion = cont;
                lecciones.Add(cursoAux);
                cont += 1;
                if (cursoActual.nClases == 2)
                {
                    cursoAux = new Cursos(cursoActual.ID, cursoActual.nEstudiantes, cursoActual.nombre, null, cursoActual.nClases, cursoActual.semestre, null, cursoActual.grupo);
                    cursoAux.nleccion = cont;
                    lecciones.Add(cursoAux);
                    cont += 1;
                }
            }
            llenaHorario();
        }
    }
}
