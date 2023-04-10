//INF1008-TP2-Chessboard.cs
//Jiadong Jin JINJ86100000

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace INF1008_tp2
{
    public class Chessboard
    {
        private int N { get; set; }

        //private Node Root { get; set; }

        private bool[,] Board { get; set; }

        /* NegDiag est un tableau dont les indices indiquent (ligne - colonne + N - 1) et 
         * qui est utilisé pour vérifier si une reine peut être placée sur une diagonale négative ou non.*/
        private bool[] NegDiag { get; set; }

        /* PosDiag est un tableau dont les indices indiquent (ligne + colonne) et
         * qui est utilisé pour vérifier si une reine peut être placée sur la diagonale positive ou non.*/
        private bool[] PosDiag { get; set; }

        /* Column est un tableau dont les indices indiquent la colonne et
         * qui est utilisé pour vérifier si une reine peut être placée dans cette colonne ou non.*/
        private bool[] Column { get; set; }

        public Chessboard(int n)
        {
            this.N = n;
            this.Board = new bool[N, N];
            NegDiag = new bool[2 * N - 1];
            PosDiag = new bool[2 * N - 1];
            Column = new bool[N];
        }

        //Une fonction d'utilité récursive pour résoudre le problème de N Reines
        public void solveNReines(bool[,] board, int k, List<List<int>> allSteps)
        {
            //Sauvegarde de tous les progrès et étapes en cours
            List<int> currentStep = Enumerable.Range(0, N).Select(i => Enumerable.Range(0, N).Where(j => board[i, j]).DefaultIfEmpty(-1).First()).Where(x => x != -1).ToList();
            /*List<int> currentStep = new List<int>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j])
                    {
                        currentStep.Add(j);
                        break;
                    }
                }
            }*/
            allSteps.Add(currentStep);
            //Si toutes les reines sont placées, revener et continuer à chercher d'autres méthodes de placement.
            if (k >= N) return;
            for (int i = 0; i < N; i++)
            {
                // Vérifier que la position actuelle se trouve dans les colonnes des autres reines, ou sur leur diagonale positive ou négative.
                if ((NegDiag[i - k + N - 1] != true && PosDiag[i + k] != true) && Column[i] != true)
                {
                    //Placer cette reine dans le tableau board[i,k]
                    board[i, k] = true;
                    NegDiag[i - k + N - 1] = PosDiag[i + k] = Column[i] = true;
                    //retrouver pour placer le reste des reines
                    solveNReines(board, k + 1, allSteps);
                    //RETOUR ARRIÈRE
                    board[i, k] = false;
                    NegDiag[i - k + N - 1] = PosDiag[i + k] = Column[i] = false;
                }
            }
        }

        public List<List<int>> Resoudre()
        {
            bool[,] board = Board;
            List<List<int>> allSteps = new();
            solveNReines(board, 0, allSteps);
            return allSteps;
        }

        public void Afficher(List<int> result)
        {
            foreach (int i in result)
            {
                Console.WriteLine(" " + string.Join(" ", Enumerable.Range(0, result.Count).Select(j => j == i ? 'X' : '+')));
            }
            /*for (int i = 0; i < result.Count; i++) {
                for (int j = 0; j < result.Count; j++)
                {
                    char c = '0';
                    if (j == result[i]) {
                        c = 'X';
                    }
                    Console.Write(c+" ");
                }
                Console.WriteLine();
            }*/
        }
    }
}
