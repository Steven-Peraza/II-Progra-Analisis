using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_Progra_Analisis
{
    class Program
    {
        public static Tuple<int[], int[]> CruceSimple(int[] p1, int[] p2)
        {

            Tuple<int[], int[]> hijos = C1P(p1, p2);

            Console.WriteLine("Hijo 1 : ");
            for (int i = 0; i < p1.Length; i++)
            {
                Console.Write(hijos.Item1[i] + " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Hijo 2 : ");
            for (int i = 0; i < p2.Length; i++)
            {
                Console.Write(hijos.Item2[i] + " ");
            }

            return hijos;

        }

        //Funcion que cruza en un solo punto a dos listas de enteros
        static Tuple<int[], int[]> C1P(int[] pa1, int[] ma1)
        {
            //se crea el random para determinar un punto aleatorio de cruce
            Random rnd = new Random();
            int puntoCX = rnd.Next(0, 9);
            Console.WriteLine("Punto de cruce: " + puntoCX);
            //se crean dos hijos del mismo tamanyo de los padres
            int[] h1 = new int[pa1.Length];
            int[] h2 = new int[ma1.Length];

            //ciclo que cruza ambos padres para obtener a los hijos correspondientes.
            for (int i = 0; i < h1.Length; i++)
            {
                //si ya se paso al punto de cruce, entonces se mezclan los padres en los hijos
                if (i > puntoCX)
                {
                    h1[i] = ma1[i];
                    h2[i] = pa1[i];
                }
                //sino, solo se copian directamente al hijo
                else
                {
                    h1[i] = pa1[i];
                    h2[i] = ma1[i];
                }
            }
            //se crea una tupla para retornar ambos hijos ya cruzados
            Tuple<int[], int[]> hijos = new Tuple<int[], int[]>(h1, h2);
            return hijos;
        }
    
        // funcion que cruza dos padres utilizando el algoritmo PMX
    private static int[] PMX2(int[] p1, int[] p2)
        {
            //se crea el random para determinar los puntos aleatorios de cruce
            Random rnd = new Random();
            int punto1 = rnd.Next(0, p1.Length);
            int punto2 = rnd.Next(punto1 + 1, p1.Length);
            //porcentaje de aparicion de mutacion
            int porcenMut = rnd.Next(1, 100);
            //se crea la estructura del hijo
            int[] h1 = new int[p1.Length];
            //Listas que ayudan al mapeo de elementos
            List<int> x = new List<int>();
            List<int> y = new List<int>();
            //enteros que sirven para tomar indices y auxiliares
            int index, aux, hostia;
            //se copia el segmento determinado aleatoriamente del primer padre al hijo
            for (int j = punto1; j < punto2; j++)
            {
                h1[j] = p1[j];
            }
            //se buscan los elementos repetidos para mapearlos dentro de las listas auxiliares "x" y "y"
            for (int v = punto1; v < punto2; v++)
            {
                //array index of busca en el hijo (h1) el elemento de padre 2, si no lo encuentra retorna un -1, y se introduce en las listas auxiliares
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

            //se realiza el cruce basandose en los elementos mapeados
            for (int c = 0; c < y.Count; c++)
            {
                //se buscan los elementos mapreados en padre 2
                hostia = Array.IndexOf(p2, y[c]);
                //si el porcentaje de mutacion es un numero de 5 o menor, (5 %) entonces se muta esa posicion con otro elemento ya mapeado
                //para evitar que se pierdan o inserten datos
                if (porcenMut <= 50)
                {
                    //pequenya mutacion
                    Console.WriteLine("Mutando el curso {0} en la posicion {1}", h1[y[c]],hostia);
                    h1[y[c]] = p2[x[c]];
                    Console.WriteLine("A: {0} en la misma posicion", p2[x[c]]);
                }
                //en caso de que no haya mutacion, se mapea normalmente donde haya campo en el hijo (si hay 0)
                if (h1[hostia] == 0)
                    h1[hostia] = p2[x[c]];
                //si no hay 0, entonces esta ocupada esa posicion, entonces, se mapea el elemento en esa posicion y se realiza el cruce
                else
                {
                    hostia = Array.IndexOf(p2, h1[hostia]);
                    h1[hostia] = p2[x[c]];
                }
            }

            //luego se termina de copiar el padre en el hijo donde existan espacios vacios
            for (int X = 0; X < h1.Length; X++)
            {
                if (h1[X] == 0)
                {
                    h1[X] = p1[X];
                }
            }
            //Console.WriteLine("----------------------------");
            /*for (int i = 0; i < h1.Length; i++)
            {
                Console.Write(h1[i] + " ");
            }
            Console.WriteLine("");*/
            //se retorna el hijo cruzado
            return h1;
        }

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
                listaProfes.Add(new Profes(i + 1, "Profe" + ((i + 1)), (rnd.Next(1, 8)) * 2));
            }

            //---------------------------------------------Construye el horario--------------------------------------------------------------
            int cont = 1;
            int cont2 = 1;
            int vecesEnSemana;
            int semestre = 6;
            while (semestre != 0)//Crea horarios la cantidad de semestres establecida
            {
                int horas = 60;// Cantidad de horas de posibles clases incluidads las libres
                int libres = rnd.Next(10, 15);//Un random de la cantidad de libres que tendra el horario
                horas -= (libres * 2);//Se multiplica *2 debido a que cada clase son 2 horas
                cursos = new List<Cursos>();
                horario = new Horario();
                for (int i = 0; i < libres; i++)//Añade las libres a cursos
                {
                    cursos.Add(new Cursos(cont, "Libre"));
                    cont += 1;
                }

                while (horas != 0)//Se le iran restando hasta que llegue a 0 para saber que ya no hay mas posibles clases
                {
                    //(int ID, int nEstudiantes, String nombre, Aulas aula, int nClases,int semestre,Profes profe,int grupo)
                    if (horas == 2)//Si solo queda espacio para una clase, establece la cantidad de veces del curso a 1
                    {
                        cursos.Add(new Cursos(cont, rnd.Next(15, 31), "Curso" + cont2, null, 1, rnd.Next(1, 9), null, rnd.Next(1, 10)));
                        horas -= 2;
                    }
                    else
                    {
                        vecesEnSemana = rnd.Next(1, 3);// Random de cantidad de veces que tendra lugar una clase durante la semana
                        Cursos cursoActual = new Cursos(cont, rnd.Next(15, 31), "Curso" + cont2, null, vecesEnSemana, rnd.Next(1, 9), null, rnd.Next(1, 10));
                        cursos.Add(cursoActual);

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

                semestre -= 1;
            }

            //---------------------------------------------Imprime los horarios--------------------------------------------------------------
            foreach (Horario h in listaHorarios)
            {
                int hora = 7;
                Console.WriteLine("\t" + "Lunes" + "\t" + "Martes" + "\t" + "Mierco" + "\t" + "Jueves" + "\t" + "Viernes");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write(hora + ":00" + "\t");
                    for (int k = 0; k < 5; k++)
                    {
                        Cursos a = h.matriz[k, i];
                        if (a.nombre != "Libre")
                            Console.Write(a.nombre + "\t");
                        else
                            Console.Write("Libre" + "\t");
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
            Horario h2 = new Horario();
            List<Cursos> l1 = new List<Cursos>();
            List<Cursos> l2 = new List<Cursos>();

            List<Horario> listaHorariosPMX = new List<Horario>();
            for (int i = 0; i < listaHorarios[0].cursos.Count; i++)
            {
                l1.Add(listaHorarios[0].cursos[i]);
                l2.Add(listaHorarios[0].cursos[i]);
                h1.cursos.Add(listaHorarios[0].cursos[i]);
                h2.cursos.Add(listaHorarios[0].cursos[i]);
            }

            p1.cursos = l1;
            p1.llenaLecciones();
            p1.DesordenarLista();

            Console.WriteLine();

            listaHorariosPMX.Add(p1);

            p2.cursos = l2;
            p2.llenaLecciones();
            p2.DesordenarLista();
            p2.DesordenarLista();
            listaHorariosPMX.Add(p2);

            int[] pruebaP1 = new int[p1.lecciones.Count];
            int[] pruebaP2 = new int[p1.lecciones.Count];
            for (int i = 0; i < p1.lecciones.Count; i++)
            {
                pruebaP1[i] = p1.lecciones[i].nleccion;
                pruebaP2[i] = p2.lecciones[i].nleccion;
            }

            Console.WriteLine("-------------------------------------------Prueba PMX-------------------------------------");

            int[] pruebaPMX = PMX2(pruebaP1, pruebaP2);
            int[] pruebaPMX2 = PMX2(pruebaP2, pruebaP1);
            for (int i = 0; i < pruebaPMX.Length; i++)
            {
                foreach (Cursos c in listaHorarios[0].lecciones)
                {
                    if (c.nleccion == pruebaPMX[i])
                        h1.lecciones.Add(c);
                }
            }
            for (int i = 0; i < pruebaPMX2.Length; i++)
            {
                foreach (Cursos c in listaHorarios[0].lecciones)
                {
                    if (c.nleccion == pruebaPMX2[i])
                        h2.lecciones.Add(c);
                }
            }
            Console.WriteLine(h1.lecciones.Count);
            //h1.llenaHorario();
            listaHorariosPMX.Add(h1);
            listaHorariosPMX.Add(h2);
            /*for (int i = 0; i < prueba1.Length; i++)
            {
                Console.Write(prueba1[i]+"-");
            }
            Console.WriteLine();
            for (int i = 0; i < prueba2.Length; i++)
            {
                Console.Write(prueba2[i] + "-");
            }
            Console.WriteLine();
            for (int i = 0; i < prueba.Length; i++)
            {
                Console.Write(prueba[i] + "-");
            }
            Console.WriteLine();
            */

            foreach (Horario h in listaHorariosPMX)
            {
                foreach (Cursos cur in h.lecciones)
                {
                    Console.Write(cur.nleccion + "-");
                }
                Console.WriteLine();
                Console.WriteLine("-------------------------PMX-------------------------");
            }
           // Console.WriteLine("-------------------------------------------Prueba Simple-------------------------------------");

            /*Tuple<int[],int[]> pruebaSimple = CruceSimple(pruebaP1, pruebaP2);
            for (int i = 0; i < pruebaSimple.Item1.Length; i++)
            {
                foreach (Cursos c in listaHorarios[0].lecciones)
                {
                    if (c.nleccion == pruebaPMX[i])
                        h1.lecciones.Add(c);
                }
            }
            for (int i = 0; i < pruebaSimple.Item2.Length; i++)
            {
                foreach (Cursos c in listaHorarios[0].lecciones)
                {
                    if (c.nleccion == pruebaPMX2[i])
                        h2.lecciones.Add(c);
                }
            }*/

            Tuple<Horario, Horario> nuevaGen = fitnessAux(p1, p2, h1, h2);

            int hora1 = 7;
            Console.WriteLine("-----------------------Hijo1-----------------");
            Console.WriteLine("\t" + "Lunes" + "\t" + "Martes" + "\t" + "Mierco" + "\t" + "Jueves" + "\t" + "Viernes");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(hora1 + ":00" + "\t");
                Console.Write(nuevaGen.Item1.lecciones[i].nombre + "\t" + nuevaGen.Item1.lecciones[i+6].nombre + "\t"+ nuevaGen.Item1.lecciones[i+12].nombre + "\t"+nuevaGen.Item1.lecciones[i+18].nombre + "\t"+ nuevaGen.Item1.lecciones[i+24].nombre + "\t");

                hora1 += 2;
                Console.WriteLine();
            }

            hora1 = 7;
            Console.WriteLine("-----------------------Hijo2-----------------");
            Console.WriteLine("\t" + "Lunes" + "\t" + "Martes" + "\t" + "Mierco" + "\t" + "Jueves" + "\t" + "Viernes");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(hora1 + ":00" + "\t");
                Console.Write(nuevaGen.Item2.lecciones[i].nombre + "\t" + nuevaGen.Item2.lecciones[i + 6].nombre + "\t" + nuevaGen.Item2.lecciones[i + 12].nombre + "\t" + nuevaGen.Item2.lecciones[i + 18].nombre + "\t" + nuevaGen.Item2.lecciones[i + 24].nombre + "\t");

                hora1 += 2;
                Console.WriteLine();
            }

            Console.WriteLine();
            
            Console.ReadKey();
        }

        //funcion que toma un horario y calcula el fitness del mismo con los estandares perfectos
        public static double Fitness(Horario hijo1)
        {
            Console.WriteLine("------------------------------------------");
            //lista de elementos con fitness perfecto, para comparar
            double[] perfectHit = { 1.6, 1.5, 1.33333333333333333333, 1 };
            double fit = 0;
            //datos que sirven para dividir la lista de cursos (horario) en dias separados con fitness diferentes...
            double ultimaHora = 0, primeraHora = 0, cursos = 0, hora = 7, dia = 0, hitCombo = 0;
            //ciclo que toma todo el horario y lo recorre para aplicar la funcion fitness cada 6 elementos
            for (int i = 0; i < hijo1.lecciones.Count; i++)
            {
                //si el horario en esa hora no esta libre y ya hay hora de inicio de clases
                if ((hijo1.lecciones[i].nombre != "Libre") && (primeraHora != 0) && (dia < 7))
                {
                    //la ulitma hora se toma
                    ultimaHora = hora;
                    //se aumenta la cantidad de cursos del dia
                    cursos++;
                }
                ////si el horario en esa hora no esta libre y todavia no hay hora de inicio de clases
                else if ((hijo1.lecciones[i].nombre != "Libre") && (primeraHora == 0) && (dia < 7))
                {
                    //la primera hora es tomada
                    primeraHora = hora;
                    cursos++;
                }
                //se aumenta la hora en 2 (2 horas por curso)
                hora += 2;
                //si se llego a 6 espacios de horario, entonces se ha cubierto un dia de la semana
                if (dia == 6)
                {
                    Console.WriteLine("Fit del dia: "+ (ultimaHora - primeraHora) / cursos);
                    //se calcula el fitness de cada dia mediante la formula y se compara con los fitness perfectos
                    if (perfectHit.Contains((ultimaHora - primeraHora) / cursos))
                    {
                        //si son iguales, se aumenta el "hit combo", o sea la cantidad de dias con horario perfecto
                        hitCombo++;
                        Console.WriteLine("It has been a lovely day... XD");
                    }
                    fit += (ultimaHora - primeraHora) / cursos;
                    Console.WriteLine("Fit acumulado: "+fit);
                    //se vuelven las variables a sus estados originales para el siguiente dia
                    cursos = 0;
                    dia = 0;
                    hora = 7;
                    primeraHora = 0;
                    ultimaHora = 0;
                }
                dia++;
            }
            //si los cinco dias han tenido un horario perfecto, entonces este es el objetivo conseguido!!
            if(hitCombo == 5)
            {
                Console.WriteLine("Horario Perfecto!!!!");
            }
            //Console.WriteLine("Total Fit: "+fit);
            Console.WriteLine("-------------------------");
            //se retorna el valor de fitness obtenido a la semana
            return fit;
        }

        //funcion auxiliar que recibe y envia los parametros necesarios para que la funcion fitness funciones adecuadamente
        //recibe los dos padres y los dos hijos cruzados
        public static Tuple<Horario, Horario> fitnessAux(Horario z1, Horario z2,Horario z3, Horario z4)
        {
            //se le saca el fitness a cada elemento (horario)
            double fitP1 = Fitness(z1);
            double fitP2 = Fitness(z2);
            double fitH1 = Fitness(z3);
            double fitH2 = Fitness(z4);
            //lista auxiliar para guardar los mejores horarios 
            List<Horario> bestH = new List<Horario>();
            //Horario best2 = new Horario();

            Console.WriteLine("Fit del padre 1: " + fitP1);
            Console.WriteLine("Fit del padre 2: " + fitP2);
            Console.WriteLine("Fit del hijo 1: "+ fitH1);
            Console.WriteLine("Fit del hijo 2: "+ fitH2);
            //asinaciones para evitar problemas en ciertos casos
            if (fitH1 < 0)
                fitH1 = 5;
            if (fitH2 < 0)
                fitH2 = 5;
            if (fitP1 < 0)
                fitP1 = 5;
            if (fitP2 < 0)
                fitP2 = 5;

            //comparaciones entre todos los fitness para averiguar si los hijos o los padres, o una mezcla de ambos son los mejores horarios
            if ((fitP1 >= fitH1) && (fitP2 >= fitH1) && (fitP1 >= fitH2) && (fitP2 >= fitH2))
            {
                bestH.Add(z3);
                bestH.Add(z4);
            }
            else if ((fitP1 >= fitH1) && (fitP2 >= fitH1) && (fitP1 < fitH2) && (fitP2 >= fitH2))
            {
                bestH.Add(z3);
                bestH.Add(z1);
            }

            else if ((fitP1 >= fitH1) && (fitP2 >= fitH1) && (fitP1 >= fitH2) && (fitP2 < fitH2))
            {
                bestH.Add(z3);
                bestH.Add(z2);
            }
            else if ((fitP1 < fitH1) && (fitP2 >= fitH1) && (fitP1 >= fitH2) && (fitP2 >= fitH2))
            {
                bestH.Add(z4);
                bestH.Add(z1);
            }
            else if ((fitP1 >= fitH1) && (fitP2 < fitH1) && (fitP1 >= fitH2) && (fitP2 >= fitH2))
            {
                bestH.Add(z4);
                bestH.Add(z2);
            }
            else
            {
                bestH.Add(z1);
                bestH.Add(z2);
            }

            //se crea una tupla para retornar los dos hijos mas prometedores, los demas son descartados.
            Tuple<Horario, Horario> bestGen = new Tuple<Horario, Horario>(bestH[0], bestH[1]);
            return bestGen;
        }
    }
}
