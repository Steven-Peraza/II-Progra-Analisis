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
        public int horas { get; set; }
        public int semestre { get; set; }
        public Profes profe { get; set; }
        public int grupo { get; set; }

        public Cursos(int ID, String nombre)
        {
            this.ID = ID;
            this.nombre = nombre;
        }
    }
}
