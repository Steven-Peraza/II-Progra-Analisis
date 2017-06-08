using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_Progra_Analisis
{
    class Profes
    {
        public int ID { get; set; }
        public String nombre { get; set; }
        public int horas { get; set; }
        public int maxHoras = 22;
        public List<Cursos> cursosImpartidos { get; set; }
    }
}
