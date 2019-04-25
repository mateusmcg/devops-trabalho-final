using System.Collections.Generic;
using CaixeiroViajante.Model;
using System.Linq;
using System;
using System.Diagnostics;

namespace CaixeiroViajante
{
    public class Util
    {
        public static List<Rota> GetListaRotas()
        {
            return new List<Rota>
            {
                new Rota { CidadeDe = 'A', CidadePara = 'B', Custo = 185 },
                new Rota { CidadeDe = 'A', CidadePara = 'C', Custo = 119 },
                new Rota { CidadeDe = 'A', CidadePara = 'D', Custo = 152 },
                new Rota { CidadeDe = 'A', CidadePara = 'E', Custo = 133 },
                new Rota { CidadeDe = 'B', CidadePara = 'A', Custo = 185 },
                new Rota { CidadeDe = 'B', CidadePara = 'C', Custo = 121 },
                new Rota { CidadeDe = 'B', CidadePara = 'D', Custo = 150 },
                new Rota { CidadeDe = 'B', CidadePara = 'E', Custo = 200 },
                new Rota { CidadeDe = 'C', CidadePara = 'A', Custo = 119 },
                new Rota { CidadeDe = 'C', CidadePara = 'B', Custo = 121 },
                new Rota { CidadeDe = 'C', CidadePara = 'D', Custo = 174 },
                new Rota { CidadeDe = 'C', CidadePara = 'E', Custo = 120 },
                new Rota { CidadeDe = 'D', CidadePara = 'A', Custo = 152 },
                new Rota { CidadeDe = 'D', CidadePara = 'B', Custo = 150 },
                new Rota { CidadeDe = 'D', CidadePara = 'C', Custo = 174 },
                new Rota { CidadeDe = 'D', CidadePara = 'E', Custo = 199 },
                new Rota { CidadeDe = 'E', CidadePara = 'A', Custo = 133 },
                new Rota { CidadeDe = 'E', CidadePara = 'B', Custo = 200 },
                new Rota { CidadeDe = 'E', CidadePara = 'C', Custo = 120 },
                new Rota { CidadeDe = 'E', CidadePara = 'D', Custo = 199 }
            };
        }

        public static int GetCustoRota(int cidadeDe, int cidadePara)
        {
            return Util.GetListaRotas().Single(rota => rota.CidadeDe == MapCidadeToChar(cidadeDe) && rota.CidadePara == MapCidadeToChar(cidadePara)).Custo;
        }

        public static char MapCidadeToChar(int cidade)
        {
            if (cidade == 0) return 'A';
            if (cidade == 1) return 'B';
            if (cidade == 2) return 'C';
            if (cidade == 3) return 'D';
            if (cidade == 4) return 'E';

            throw new Exception("Só são suportadas 5 cidades nesse exemplo");
        }

        public static void ImprimeMelhorCaminho(int custo, Rota[] melhorRota)
        {
            int i; /* indexa o vetor que contem a rota */
            Console.WriteLine("\n\nCUSTO MINIMO PARA A VIAGEM DO CAIXEIRO: " + custo);
            Console.WriteLine("\n\nMELHOR CAMINHO PARA A VIAGEM DO CAIXEIRO:");
            Console.WriteLine("\n\n              DE               PARA             CUSTO ");
            for (i = 0; i < melhorRota.Length; i++)
            {
                Console.Write("              " + Util.MapCidadeToChar(melhorRota[i].CidadeDe) + "                  " + Util.MapCidadeToChar(melhorRota[i].CidadePara) + "                " + melhorRota[i].Custo + "\n");
            }
            Console.WriteLine("\n");
        }

        public static void ImprimeTempo(Stopwatch tempo)
        {
            Console.WriteLine("TEMPO DE EXECUÇÂO: ");
            Console.WriteLine(tempo.Elapsed.Hours + " horas " + tempo.Elapsed.Minutes + " minutos " + tempo.Elapsed.Seconds + " segundos " + tempo.Elapsed.Milliseconds + " milisegundos");
        }

        public static void ImprimeGrafo(int numCidades, Grafo grafo)
        {
            Console.Write("\nCidades e custos:\n   ");
            for (int i = 0; i < numCidades; i++)
            {
                Console.Write(Util.MapCidadeToChar(i) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < numCidades; i++)
            {
                Console.Write(Util.MapCidadeToChar(i) + " ");
                for (int j = 0; j < numCidades; j++)
                {
                    Console.Write(" " + grafo.Matriz[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}