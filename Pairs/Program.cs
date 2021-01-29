using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pairs
{
    class Program
    {
        static void Main(string[] args)
        {      
            Console.WriteLine("Ingrese los nombres del intercambio, separados por un espacio:\n");
            var personas = Console.ReadLine();
            string[] words = personas.Split(' ');
            int s = words.Count();
            string[,] salida = new string[s,2];
            Random random = new Random();
            int sorteo;
            Console.WriteLine("\n");
            List<Lista> lst = new List<Lista>();
            List<Intercambio> lstIntercambio = new List<Intercambio>();
            //Llenado de Listas
            foreach (var word in words)
            {
                var n = new Lista(word, false);
                lst.Add(n);
                var m = new Intercambio(word, null);
                lstIntercambio.Add(m);
            }

            //Sorteo
            foreach (var val in lstIntercambio)
            {
                do {
                    sorteo = random.Next(0, lstIntercambio.Count());

                    if (val.de != lst[sorteo].Nombre && lst[sorteo].Asignado == false)
                    {
                        val.para = lst[sorteo].Nombre;
                        lst[sorteo].Asignado = true;
                    }

                } while (val.para == null || val.de == lst[sorteo].Nombre && lst[sorteo].Asignado == true);
            }
                       
            //Lleno Array
            for (int i =0; i<lstIntercambio.Count;i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                        salida[i, j] = lstIntercambio[i].de;
                    else
                        salida[i, j] = lstIntercambio[i].para;
                }
            }

            //Resultados
            for (int i = 0; i < salida.Length/2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                        Console.Write(salida[i, j] + " -> ") ;
                    else
                        Console.WriteLine(salida[i, j]);
                }
            }

            Console.ReadLine();
        }
        public class Lista
        {
            public string Nombre;
            public bool Asignado;
            public Lista(string nombre, bool asignado)
            {
                Nombre = nombre;
                Asignado = asignado;
            }
        }
        public class Intercambio
        {
            public string de;
            public string para;
            public Intercambio(string de, string para)
            {
                this.de = de;
                this.para = para;
            }

          
        }
    }
}
