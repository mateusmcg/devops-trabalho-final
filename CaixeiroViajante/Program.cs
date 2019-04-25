using System;
using System.Diagnostics;
using CaixeiroViajante.Model;

namespace CaixeiroViajante
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] permutacao;     /* vetor com uma possivel rota de viagem */
            Rota[] melhorRota;    /* contera' a melhor rota da viagem */
            int numCidades,      /* numero de vertices (cidades) do grafo */
                    melhorCusto;     /* custo da viagem pelo grafo (pelas cidades) */

            CaixeiroViajante caixeiro = new CaixeiroViajante();
            Grafo grafo;

            numCidades = 5;
            caixeiro.montaGrafo(out grafo, numCidades);

            permutacao = new int[numCidades];
            melhorRota = new Rota[numCidades];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();//Inicia a contagem do tempo
            caixeiro.geraEscolheCaminhos(ref permutacao, grafo, melhorRota, out melhorCusto);
            stopwatch.Stop();//Encerra a contagem do tempo
            Util.ImprimeMelhorCaminho(melhorCusto, melhorRota);
            Util.ImprimeTempo(stopwatch);

            Console.ReadKey(true);
        }
    }
}
