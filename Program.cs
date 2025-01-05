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

        Console.WriteLine("Que le combat commence !");
        Duel(perso1, perso2);
    }

   public static Guerrier SelectionnerOuCreerPersonnage(string ordre)
    {
        Console.Clear();
        Console.WriteLine($"/////////////////////////////////////////////////");
        Console.WriteLine($"Choisissez le {ordre} combattant ");
        Console.WriteLine("1. Lancelot (Guerrier, PV=35, Attaque=3)");
        Console.WriteLine("2. Gimli (Nain, PV=40, Attaque=2, Armure Lourde)");
        Console.WriteLine("3. Legolas (Elfe, PV=25, Attaque=5)");
        Console.WriteLine("4. Créer un nouveau personnage");
        Console.Write("    Votre choix : ");
        Console.WriteLine($"////////////////////////////////////////////////");


        int choix = int.Parse(Console.ReadLine());   
        Guerrier personnage;  

        switch (choix)                        // switch case pour la selection du type de personage
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
                personnage = new Nain("Gimli", 40, 2,false);                                    // Gestion de saisie utilisateur  
                break;
        }

        Console.WriteLine("Entrez le nom de votre personnage :");
        personnage.Nom = Console.ReadLine();
        Console.WriteLine("Entrez les points de vie :");
        personnage.PointDeVie = int.Parse(Console.ReadLine());
        Console.WriteLine("Entrez la force d'attaque :");
        personnage.NbAttaque = int.Parse(Console.ReadLine());

        return personnage;
    }
    static Guerrier CreerPersonnage()
    {
        Console.Clear();
        Console.WriteLine("Création d'un nouveau personnage :");

        Console.WriteLine("1. Guerrier");
        Console.WriteLine("2. Elfe");
        Console.WriteLine("3. Nain");
        Console.Write("Choisissez un type de personnage : ");
        int choixType = int.Parse(Console.ReadLine());

        Console.Write("Entrez le nom du personnage : ");
        string nom = Console.ReadLine();

        Console.Write("Entrez les points de vie : ");
        int pointsDeVie = int.Parse(Console.ReadLine());

        Console.Write("Entrez la force d'attaque : ");
        int nbAttaque = int.Parse(Console.ReadLine());

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
                Console.WriteLine("Choix invalide. Guerrier sélectionné par défaut.");
                personnage = new Guerrier(nom, pointsDeVie, nbAttaque);
                break;
        }

        Console.WriteLine($"le personage {nom} a était créé avec succès !");
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
        Console.WriteLine();

        Guerrier attaquant = random.Next(0, 2) == 0 ? perso1 : perso2;
        Guerrier defenseur = attaquant == perso1 ? perso2 : perso1;

        Console.WriteLine($"{attaquant.Nom} attaque {defenseur.Nom} !");
        attaquant.Attaquer(); // On exécute l'attaque mais on ne garde pas le résultat
        defenseur.SubirDegat(attaquant.NbAttaque); // On applique directement les dégâts

        Console.WriteLine($"{attaquant.Nom} inflige des dégâts !");
        Console.WriteLine($"{defenseur.Nom} a {defenseur.PointDeVie} PV restants.");

        if (defenseur.PointDeVie == 0)
        {
            Console.WriteLine($"{attaquant.Nom} remporte le duel !");
            break;
        }

        Console.WriteLine("Appuyez sur une touche pour continuer au prochain tour...");
        Console.ReadKey();
    }

    Console.WriteLine(perso1.PointDeVie > 0 ? $"{perso1.Nom} a gagné !" : $"{perso2.Nom} a gagné !");
}

    static void Attaquer(Guerrier attaquant, Guerrier defenseur)
    {
        Console.WriteLine($"{attaquant.Nom} attaque {defenseur.Nom} !");
        defenseur.PointDeVie -= attaquant.NbAttaque;
        if (defenseur.PointDeVie < 0) defenseur.PointDeVie = 0;
        Console.WriteLine($"{defenseur.Nom} a {defenseur.PointDeVie} points de vie restants.");
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Class guerrier :


namespace DuelGeurriers
{
    public class Guerrier
    {

        //attribut: 
        private string _nom;
        private int _pointDeVie;
        private int _nbAttaque;


        //accèsseurs

        public string Nom { get { return _nom; } set { _nom = value; } }
        public int PointDeVie { get { return _pointDeVie; } set { _pointDeVie = value; } }

        public int NbAttaque { get { return _nbAttaque; } set { _nbAttaque = value; } }



        //constructeur 

        public Guerrier(string nom, int pointDeVie, int nbAttaque)
        {
            _nom = nom;
            _pointDeVie = pointDeVie;
            _nbAttaque = nbAttaque;



        }
    

        //methodes

        public void AfficherInfos()
        {
            Console.WriteLine($"Nom : {Nom} ; Pv =({PointDeVie}) ; nombres d'attaques = {NbAttaque}");
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
            Console.WriteLine($"L'attaque occasionne  {degatSubit} degat");
            AfficherInfos();

        }

        public virtual void SubirDegat(int degatSubit)
        {


          
            PointDeVie = PointDeVie - degatSubit;
            Console.WriteLine($"L'attaque a occasionne - {degatSubit}  de degat il lui reste {PointDeVie}");
            AfficherInfos();

        }


    }
}



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

// Class Nain :


    internal class Nain : Guerrier
    {
        // attribut :
        private bool _armureLourde;


        // constructeur 
        public Nain (string nom, int pointDeVie, int nbAttaque, bool armureLourde): base(nom, pointDeVie, nbAttaque)
        {
            this._armureLourde = armureLourde;
        }

        // accésseur 
        public bool armureLourde { get { return _armureLourde; } set { _armureLourde = value; } }

        //methode 
        public override void  SubirDegat(int degatSubit)
        {
            Random deLancer = new Random();
            
            {
                
                PointDeVie = PointDeVie - (degatSubit/2);
                AfficherInfos();
            }

            
           }

    }
    




///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// Class Elfe : 



    internal class Elfe : Guerrier
    {
        public Elfe(string nom, int pointDeVie, int nbAttaque) : base(nom, pointDeVie, nbAttaque)
        {}

        public override int Attaquer()
        {
            Random deLancer = new Random();
            int degatSubit = 0;
            for (int i = 0; i < NbAttaque; i++)
            {
                degatSubit += deLancer.Next(4, 8); // Chaque dé inflige entre 4 et 7 dégâts minimum
            }
            return degatSubit;
            AfficherInfos();


        }
         public override void  SubirDegat(int degatSubit)
        {
            Random deLancer = new Random();
            
            {
                
                PointDeVie = PointDeVie - degatSubit/2;
                AfficherInfos();
            }

            
        }
    }
