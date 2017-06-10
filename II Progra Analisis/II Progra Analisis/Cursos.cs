using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_Progra_Analisis
{
    class Cursos
    {
        public int ID { get; set; }
        public int nEstudiantes { get; set; }
        public String nombre { get; set; }
        public Aulas aula { get; set; }
        public int nClases { get; set; }
        public int semestre { get; set; }
        public Profes profe { get; set; }
        public int grupo { get; set; }
        public int nleccion { get; set; }

        public Cursos(int ID, int nEstudiantes, String nombre, Aulas aula, int nClases,int semestre,Profes profe,int grupo)
        {
            this.ID = ID;
            this.nEstudiantes = nEstudiantes;
            this.nombre = nombre;
            this.aula = aula;
            this.nClases = nClases;
            this.semestre = semestre;
            this.profe = profe;
            this.grupo = grupo;
        }
        public Cursos(int ID,String nombre)
        {
            this.ID = ID;
            this.nombre = nombre;
        }
    }
}
