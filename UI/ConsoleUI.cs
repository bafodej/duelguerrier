using Spectre.Console;

namespace DuelGuerrier.UI;

public class ConsoleUI
{
    public void AfficherEcranAccueil()
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
    }
}
