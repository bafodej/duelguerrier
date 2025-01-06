using DuelGeurriers;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // Créer un panneau
        var panel = new Panel("Bienvenue dans l'arène des guerriers!")
        {
            Header = new PanelHeader("[bold green]Arène des Guerriers[/]"),
            Border = BoxBorder.Heavy,
            Padding = new Padding(2, 2, 2, 2)
        };

        // Afficher le panneau dans la console
        AnsiConsole.Write(panel);

        // Afficher un tableau pour la suite
        var table = new Table();
        table.AddColumn("[yellow]Nom du Guerrier[/]");
        table.AddColumn("[blue]Points de Vie[/]");
        table.AddColumn("[green]Attaque[/]");
        table.AddRow("Lancelot", "35", "10");
        table.AddRow("Gimli", "40", "8");
        table.AddRow("Legolas", "25", "12");

        AnsiConsole.WriteLine(); // Ligne vide
        AnsiConsole.Write(table);

        Console.WriteLine("Appuyez sur une touche pour continuer...");
        Console.ReadKey();
        Console.Clear();

        Guerrier perso1 = SelectionnerOuCreerPersonnage("premier");
        Guerrier perso2 = SelectionnerOuCreerPersonnage("second");

        Duel(perso1, perso2);
    }

    public static Guerrier SelectionnerOuCreerPersonnage(string ordre)
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

    public static Guerrier CreerPersonnage()
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
        string nom = Console.ReadLine();

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

    public static void Duel(Guerrier perso1, Guerrier perso2)
    {
        Random random = new Random();

        while (perso1.PointDeVie > 0 && perso2.PointDeVie > 0)
        {
            Console.Clear();
            Console.WriteLine("Tour de combat !");
            perso1.AfficherInfos();
            perso2.AfficherInfos();

            Guerrier attaquant = random.Next(0, 2) == 0 ? perso1 : perso2;
            Guerrier defenseur = attaquant == perso1 ? perso2 : perso1;

            Console.WriteLine($"{attaquant.Nom} attaque {defenseur.Nom} !");
            int degatSubit = attaquant.Attaquer();
            defenseur.SubirDegat(degatSubit);

            Console.WriteLine($"{attaquant.Nom} inflige {degatSubit} de dégât !");
            Console.WriteLine($"{defenseur.Nom} a {defenseur.PointDeVie} PV restants.");

            if (defenseur.PointDeVie <= 0)
            {
                defenseur.PointDeVie = 0;
                Console.WriteLine($"{attaquant.Nom} remporte le duel !");
                break;
            }

            Console.WriteLine("Appuyez sur une touche pour continuer au prochain tour...");
            Console.ReadKey();
        }

        Console.WriteLine(perso1.PointDeVie > 0 ? $"{perso1.Nom} a gagné !" : $"{perso2.Nom} a gagné !");
    }
}

namespace DuelGeurriers
{
    public class Guerrier
    {
        protected string _nom;
        protected int _pointDeVie;
        protected int _nbAttaque;

        public string Nom { get { return _nom; } set { _nom = value; } }
        public int PointDeVie { get { return _pointDeVie; } set { _pointDeVie = value; } }
        public int NbAttaque { get { return _nbAttaque; } set { _nbAttaque = value; } }

        public Guerrier(string nom, int pointDeVie, int nbAttaque)
        {
            _nom = nom;
            _pointDeVie = pointDeVie;
            _nbAttaque = nbAttaque;
        }

        public void AfficherInfos()
        {
            Console.WriteLine($"Nom : {Nom} ; PV = {PointDeVie} ; Nombres d'attaques = {NbAttaque}");
        }

        public virtual int Attaquer()
        {
            Random deLancer = new Random();
            int degatSubit = 0;
            for (int i = 0; i < NbAttaque; i++)
            {
                degatSubit += deLancer.Next(1, 7);
            }
            return degatSubit;
        }

        public virtual void SubirDegat(int degatSubit)
        {
            PointDeVie -= degatSubit;
            if (PointDeVie < 0) PointDeVie = 0;
        }
    }

    public class Nain : Guerrier
    {
        private bool _armureLourde;

        public bool armureLourde { get { return _armureLourde; } set { _armureLourde = value; } }

        public Nain(string nom, int pointDeVie, int nbAttaque, bool armureLourde) : base(nom, pointDeVie, nbAttaque)
        {
            _armureLourde = armureLourde;
        }

        public override void SubirDegat(int degatSubit)
        {
            PointDeVie -= degatSubit / 2;
            if (PointDeVie < 0) PointDeVie = 0;
        }
    }

    public class Elfe : Guerrier
    {
        public Elfe(string nom, int pointDeVie, int nbAttaque) : base(nom, pointDeVie, nbAttaque) { }

        public override int Attaquer()
        {
            Random deLancer = new Random();
            int degatSubit = 0;
            for (int i = 0; i < NbAttaque; i++)
            {
                degatSubit += deLancer.Next(4, 9);
            }
            return degatSubit;
        }

        public override void SubirDegat(int degatSubit)
        {
            PointDeVie -= degatSubit / 2;
            if (PointDeVie < 0) PointDeVie = 0;
        }
    }
}

