// INF1008-TP2-Main.cs
// Jiadong Jin JINJ86100000

// Programme C# pour résoudre le problème de la reine N en utilisant le backtracking
using INF1008_tp2;

bool menu_continue = true;
while (menu_continue)
{
    Console.WriteLine("\r\nMenu");

    Console.WriteLine("Veuillez entrer le N (N reines sur un plateau de jeu N*N) :");
    if (!int.TryParse(Console.ReadLine(), out int n))
    {
        Console.WriteLine("Caractère non valide.");
    }
    else
    {
        Chessboard cb = new Chessboard(n);
        List<List<int>> sol = cb.Resoudre();
        if (sol.Max(x => x.Count) < n)
        {
            Console.WriteLine("Aucune solution dans ce cas.");
        }
        else
        {
            Console.WriteLine("La solution au problème des n-reines dans ce cas a été générée.");
            bool board_continue = true;
            while (board_continue)
            {
                Console.WriteLine("\r\nVeuillez entrer un numéro pour sélectionner la fonction que vous voulez utiliser:");
                Console.WriteLine("(1) Une solution possible pour une taille de plateau donnée avec nombre de tuples k-prometteurs");
                Console.WriteLine("(2) Toutes les solutions possibles pour une taille de plateau avec nombre de tuples k-prometteurs.");
                Console.WriteLine("(3) Le nombre de tuples k-prometteurs total pour explorer toute l’espace de recherche.");
                Console.WriteLine("(4) Entrer un nouveau N.");
                Console.WriteLine("(5) Quitter.");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.WriteLine();
                        List<int> first = sol.First(x => x.Count == n);
                        Console.WriteLine("Le nombre de tuples k-prometteurs de la première solution :" + sol.IndexOf(first));
                        Console.WriteLine("[" + string.Join(",", first.Select(x => x + 1)) + "]");
                        cb.Afficher(first);
                        break;
                    case '2':
                        Console.WriteLine();
                        int kcounter = 0;
                        foreach (List<int> solution in sol)
                        {
                            kcounter++;
                            if (solution.Count == n)
                            {
                                Console.WriteLine("Le nombre de tuples k-prometteurs de la solution :" + kcounter);
                                Console.WriteLine("[" + string.Join(",", solution.Select(x => x + 1)) + "]");
                                cb.Afficher(solution);
                                kcounter = 0;
                            }
                        }
                        break;
                    case '3':
                        Console.WriteLine();
                        Console.WriteLine("Le nombre de tuples k-prometteurs total :" + sol.Count);
                        break;
                    case '4':
                        board_continue = false;
                        break;
                    case '5':
                        board_continue = false;
                        menu_continue = false;
                        break;
                    default:
                        Console.WriteLine("\r\n" + "Caractère non valide.\r\n");
                        break;
                }
            }

        }

    }

}


