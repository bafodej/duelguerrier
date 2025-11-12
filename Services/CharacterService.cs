using DuelGuerrier.Models;

namespace DuelGuerrier.Services;

public class CharacterService
{
    public Guerrier SelectionnerOuCreerPersonnage(string ordre)
    {
        Console.Clear();
        Console.WriteLine($"/////////////////////////////////////////////////");
        Console.WriteLine($"Choisissez le {ordre} combattant : ");
        Console.WriteLine("1. Lancelot (Guerrier, PV=35, Attaque=3)");
        Console.WriteLine("2. Gimli (Nain, PV=40, Attaque=2, Armure Lourde)");
        Console.WriteLine("3. Legolas (Elfe, PV=25, Attaque=5)");
        Console.WriteLine("4. Créer un nouveau personnage");
        Console.Write("    Votre choix : ");

        int choix;
        while (!int.TryParse(Console.ReadLine(), out choix) || choix < 1 || choix > 4)
        {
            Console.WriteLine("Veuillez entrer un choix valide (1-4) :");
        }

        Guerrier personnage;
        switch (choix)
        {
            case 1:
                personnage = new Guerrier("Lancelot", 35, 3);
                break;
            case 2:
                personnage = new Nain("Gimli", 40, 2, true);
                break;
            case 3:
                personnage = new Elfe("Legolas", 25, 5);
                break;
            case 4:
                personnage = CreerPersonnage();
                break;
            default:
                Console.WriteLine("Choix invalide. Guerrier par défaut sélectionné.");
                personnage = new Guerrier("Lancelot", 35, 3);
                break;
        }

        return personnage;
    }

    public Guerrier CreerPersonnage()
    {
        Console.Clear();
        Console.WriteLine("Création d'un nouveau personnage :");

        Console.WriteLine("1. Guerrier");
        Console.WriteLine("2. Elfe");
        Console.WriteLine("3. Nain");
        Console.Write("Choisissez un type de personnage : ");

        int choixType;
        while (!int.TryParse(Console.ReadLine(), out choixType) || choixType < 1 || choixType > 3)
        {
            Console.WriteLine("Veuillez entrer un choix valide (1-3) :");
        }

        Console.Write("Entrez le nom du personnage : ");
        string nom = Console.ReadLine() ?? "Guerrier";

        int pointsDeVie;
        Console.Write("Entrez les points de vie : ");
        while (!int.TryParse(Console.ReadLine(), out pointsDeVie) || pointsDeVie <= 0)
        {
            Console.WriteLine("Veuillez entrer un nombre valide pour les points de vie :");
        }

        int nbAttaque;
        Console.Write("Entrez la force d'attaque : ");
        while (!int.TryParse(Console.ReadLine(), out nbAttaque) || nbAttaque <= 0)
        {
            Console.WriteLine("Veuillez entrer un nombre valide pour la force d'attaque :");
        }

        Guerrier personnage;
        switch (choixType)
        {
            case 1:
                personnage = new Guerrier(nom, pointsDeVie, nbAttaque);
                break;
            case 2:
                personnage = new Elfe(nom, pointsDeVie, nbAttaque);
                break;
            case 3:
                personnage = new Nain(nom, pointsDeVie, nbAttaque, false);
                break;
            default:
                personnage = new Guerrier(nom, pointsDeVie, nbAttaque);
                break;
        }

        Console.WriteLine($"Le personnage {nom} a été créé avec succès !");
        Console.WriteLine("Appuyez sur une touche pour continuer...");
        Console.ReadKey();
        return personnage;
    }
}
