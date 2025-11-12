using DuelGuerrier.Models;

namespace DuelGuerrier.Services;

public class GameService
{
    public void Duel(Guerrier perso1, Guerrier perso2)
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
