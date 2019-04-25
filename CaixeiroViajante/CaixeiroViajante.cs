using System;
using CaixeiroViajante.Model;

namespace CaixeiroViajante
{
    public class CaixeiroViajante
    {
        /// <summary>
        /// Verifica se a permutação passada como parâmetro tem custo melhor que o custo
        /// já obtido. Caso positivo, então monta a rota correspondnete à permutação como
        /// sendo a melhor rota (e armazena no vetor melhorRota, retornando tambem o custo 
        /// total da melhor rota 
        /// </summary>
        /// <param name="grafo"></param>
        /// <param name="melhorRota"></param>
        /// <param name="melhorCusto"></param>
        /// <param name="permutacao"></param>
        public void melhorCaminho(Grafo grafo, Rota[] melhorRota, ref int melhorCusto, int[] permutacao)
        {
            int j, k;                     /* contadores: auxiliam a montagem das rotas */
            int cid1, cid2;             /* cidades da melhor rota */
            int custo;                 /* custo total da melhor rota */
            int[] proxDaRota;        /* vetor que armazena a sequencia de cidades que estao
				                           em uma rota, tal que um indice indica uma cidade e
				                           o conteudo deste indice, a proxima cidade da rota */

            proxDaRota = new int[melhorRota.Length];
            cid1 = 0;
            cid2 = permutacao[1];
            custo = grafo.Matriz[cid1, cid2];

            proxDaRota[cid1] = cid2;

            for (j = 2; j < melhorRota.Length; j++)
            {
                cid1 = cid2;
                cid2 = permutacao[j];
                custo += grafo.Matriz[cid1, cid2];  /* calcula o custo parcial da rota */
                proxDaRota[cid1] = cid2;      /* armazena a rota fornecida pela permutacao */
            }

            proxDaRota[cid2] = 0;           /* completa o ciclo da viagem */
            custo += grafo.Matriz[cid2, 0];  /* custo total desta rota */

            if (custo < melhorCusto)    /* procura pelo melhor (menor) custo */
            {
                melhorCusto = custo;
                cid2 = 0;
                for (k = 0; k < melhorRota.Length; k++) /* guarda a melhor rota */
                {
                    cid1 = cid2;
                    cid2 = proxDaRota[cid1];
                    melhorRota[k].CidadeDe = cid1;
                    melhorRota[k].CidadePara = cid2;
                    melhorRota[k].Custo = grafo.Matriz[cid1, cid2];
                }
            }
        }

        /// <summary>
        /// Gera os possiveis caminhos entre a cidade zero e as outras (N-1) envolvidas
        /// na busca, armazenando-os no vetor permutacao, um por vez, e a cada permutacao
        /// gerada, chama a funcao melhorCaminho que escolhe o caminho (a permutacao) de menor custo.
        /// 
        /// CÓDIGO ADAPTADO DE "Algorithms in C" (Robert Sedgewick), página 624.
        /// </summary>
        /// <param name="permutacao"></param>
        /// <param name="grafo"></param>
        /// <param name="melhorRota"></param>
        /// <param name="melhorCusto"></param>
        /// <param name="controle"></param>
        /// <param name="k"></param>
        public void permuta(int[] permutacao, Grafo grafo, Rota[] melhorRota, ref int melhorCusto, int controle, int k)
        {
            int i;
            permutacao[k] = ++controle;
            if (controle == (melhorRota.Length - 1)) /* se gerou um caminho então verifica se ele é melhor */
                melhorCaminho(grafo, melhorRota, ref melhorCusto, permutacao);
            else
                for (i = 1; i < melhorRota.Length; i++)
                    if (permutacao[i] == 0)
                        permuta(permutacao, grafo, melhorRota, ref melhorCusto, controle, i);
            controle--;
            permutacao[k] = 0;
        }

        //------------------------------------------------------------------------------

        /// <summary>
        /// Gera os pesos dos arcos do grafo randomicamente e preenche
        /// a matriz grafo->M, que e indexada pelos nomes dos vertices (cidades)
        /// </summary>
        /// <param name="grafo"></param>
        /// <param name="numCidades"></param>
        public void montaGrafo(out Grafo grafo, int numCidades)
        {
            grafo = new Grafo();
            grafo.Matriz = new int[numCidades, numCidades];

            for (int i = 0; i < numCidades; i++)
            {
                for (int j = 0; j < numCidades; j++)
                {
                    if (i < j)
                        grafo.Matriz[i, j] = Util.GetCustoRota(i, j);
                    else
                        if (i == j)
                        grafo.Matriz[i, j] = 0;
                    else
                        grafo.Matriz[i, j] = grafo.Matriz[j, i];
                }
            }

            Util.ImprimeGrafo(numCidades, grafo);
        }

        /// <summary>
        /// Gera os possiveis caminhos entre a cidade zero e todas as outras envolvidas
        /// na rota da viagem do caixeiro e escolhe a melhor rota entre todas.
        /// </summary>
        /// <param name="permutacao"></param>
        /// <param name="grafo"></param>
        /// <param name="melhorRota"></param>
        /// <param name="melhorCusto"></param>
        public void geraEscolheCaminhos(ref int[] permutacao, Grafo grafo, Rota[] melhorRota, out int melhorCusto)
        {
            int controle = -1;
            melhorCusto = int.MaxValue;

            for (int i = 0; i < melhorRota.Length; i++)
            {
                melhorRota[i] = new Rota();
            }

            permuta(permutacao, grafo, melhorRota, ref melhorCusto, controle, 1);
        }
    }
}