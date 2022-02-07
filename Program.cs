using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ejercicioBaraja
{
    class Program
    {
        

        class Baraja
        {
            private List<Carta> cartas = new List<Carta>(48);

            public Baraja ()
            {
                for (int i = 0; i < 48; i++) { this.cartas.Add(new Carta()); }
            }

            public int getNCartas() { return this.cartas.Count(); }
            public string robaCarta()
            {
                this.cartas.RemoveAt(0);
                return this.cartas[0].getFigura();
            }
            public void cogeCarta (int id) { 
                if (id <= getNCartas() && id >= 0)
                {
                    this.cartas.RemoveAt(id);
                }
            }
            public void cogeCartaAlAzar()
            {
                var rand = new Random();

                this.cartas.RemoveAt(rand.Next(0, getNCartas()));
            }
            public void escribeBaraja()
            {
                for (int i = 0; i < getNCartas(); i++) {
                    Console.WriteLine("\n" + i + " -> " + this.cartas[i].getFigura());
                }
            }
            public void barajar()
            {
                for (int i = 0; i < 1000; i++)
                {
                    int aleatorio = new Random().Next(this.cartas.Count());
                    int aleatorio2 = new Random().Next(this.cartas.Count());

                    Console.WriteLine(aleatorio.ToString() + " " + aleatorio2.ToString());
                    Console.ReadKey();
                    Console.WriteLine("\n");

                    Carta aux = this.cartas[aleatorio];
                    this.cartas[aleatorio] = this.cartas[aleatorio2];
                    this.cartas[aleatorio2] = aux;
                }
            }
        }
        class Carta
        {
            private string figura;
            private string[] figurasDis = { "Trebol", "Pica", "Diamante", "Corazon", "Rey", "Dama", "Joker" };
            

            public Carta ()
            {
                Random rand = new Random();
                this.figura = figurasDis[new Random().Next(0, 6)];
            }

            public string getFigura () { return this.figura; }
            public void setFigura (string figura) { this.figura = figura; }
        }

        public static void pintarMenu()
        {
            Console.WriteLine("\n1-Numero de Cartas");
            Console.WriteLine("2-Roba Carta");
            Console.WriteLine("3-Coge Carta");
            Console.WriteLine("4-Coge Carta Al Azar");
            Console.WriteLine("5-Escribe Baraja");
            Console.WriteLine("6-Barajar");
            Console.WriteLine("7-Salir");
            Console.Write("\nOpcion >>> ");
        }

        static void Main(string[] args)
        {
            Baraja miBaraja = new Baraja();

            miBaraja.escribeBaraja();
            miBaraja.barajar();
            miBaraja.escribeBaraja();
            
            Console.ReadKey();
        }

        
    }
}
