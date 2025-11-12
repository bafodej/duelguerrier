using DuelGuerrier.Services;
using DuelGuerrier.UI;

namespace DuelGuerrier;

class Program
{
    static void Main(string[] args)
    {
        var consoleUI = new ConsoleUI();
        var characterService = new CharacterService();
        var gameService = new GameService();

        // Afficher l'écran d'accueil
        consoleUI.AfficherEcranAccueil();

        // Sélectionner ou créer les personnages
        var perso1 = characterService.SelectionnerOuCreerPersonnage("premier");
        var perso2 = characterService.SelectionnerOuCreerPersonnage("second");

        // Lancer le duel
        gameService.Duel(perso1, perso2);
    }
}
