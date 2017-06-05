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
            List<Cursos> cursos = new List<Cursos>();
            List<Horario> listaHorarios = new List<Horario>();
            Horario horario = new Horario();            

            for (int i = 0; i < 30; i++)
            {
                cursos.Add(new Cursos(i,"Curso"+i));
            }
            int cont = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 6; k++)
                {
                    horario.matriz.SetValue((i,k));
                }
            }

        }
    }
}
