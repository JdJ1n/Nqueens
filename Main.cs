//INF1008-TP1-Main.cs
//Jiadong Jin JINJ86100000

bool menu_continue = true;
while (menu_continue)
{
    Console.WriteLine("\r\nMenu");
    Console.WriteLine("Veuillez entrer un numéro pour sélectionner la fonction que vous voulez utiliser:");
    Console.WriteLine("(1) Générer un labyrinthe d'une taille spécifiée");
    Console.WriteLine("(2) Utiliser l'algorithme de Prim pour résoudre le labyrinthe.");
    Console.WriteLine("(3) Quitter l'application.");
    switch (Console.ReadKey().KeyChar)
    {
        case '1':
            Console.WriteLine("\r\nVeuillez entrer le nombre de colonnes du labyrinthe.:");
            if (!int.TryParse(Console.ReadLine(), out int y))
            {
                Console.WriteLine("Caractère non valide.");
                break;
            }
            Console.WriteLine("\r\nVeuillez entrer le nombre de lignes du labyrinthe.:");
            if (!int.TryParse(Console.ReadLine(), out int x))
            {
                Console.WriteLine("Caractère non valide.");
                break;
            }
            //Initialisation un compteur
            //pour compter le nombre d'opérations de base utilisées dans la génération des labyrinthes et des listes d'adjacence.
            //Générer un labyrinthe d'une taille donnée à partir du nombre de lignes et de colonnes saisies par l'utilisateur.
            Console.WriteLine("Le nombre d'opérations élémentaires (l'initialisation de la liste d'adjacence):");
            Console.WriteLine("Le nombre d'opérations élémentaires (la génération du labyrinthe):" + "\r\n");

            Console.WriteLine("Le nombre d'opérations élémentaires (l'affichage du labyrinthe):");

            Console.WriteLine("Nombre non valide.");
            break;
        case '2':
            if (true)
            {
                //Utilisation de l'algorithme prim pour résoudre des labyrinthes et afficher le nombre des opérations de base
                Console.WriteLine("\r\nL'arbre couvrant de poids minimal de ce labyrinthe est :");
                Console.WriteLine("\r\nLe nombre d'opérations élémentaires (l'affichage du labyrinthe):");
            }
            else
            {
                Console.WriteLine("\r\nLe labyrinthe n'est pas encore initialisé.");
            }
            break;
        case '3':
            menu_continue = false;
            break;
        default:
            Console.WriteLine("\r\n" + "Caractère non valide.\r\n");
            break;
    }
}


