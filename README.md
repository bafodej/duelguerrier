# Duel Guerrier

Application console C# simulant des combats entre différents types de guerriers.

## Description

Duel Guerrier est un jeu de combat au tour par tour où vous sélectionnez ou créez des personnages pour s'affronter dans l'arène. Chaque type de guerrier possède des caractéristiques uniques et des capacités spéciales.

## Types de Guerriers

- **Guerrier** : Combattant équilibré avec des attaques standards (1-6 dégâts par attaque)
- **Elfe** : Attaquant agile avec des dégâts élevés (4-8 par attaque) et résistance 50%
- **Nain** : Défenseur robuste avec armure lourde qui réduit les dégâts de 50%

## Fonctionnalités

- Sélection parmi 3 guerriers prédéfinis (Lancelot, Gimli, Legolas)
- Création personnalisée de guerriers avec statistiques au choix
- Système de combat au tour par tour avec dés aléatoires
- Interface console colorée utilisant Spectre.Console

## Structure du Projet

```
DuelGuerrier/
├── Models/              # Classes de personnages (Guerrier, Nain, Elfe)
├── Services/            # Logique métier (CharacterService, GameService)
├── UI/                  # Interface utilisateur (ConsoleUI)
└── Program.cs           # Point d'entrée de l'application
```

## Prérequis

- .NET 8.0 ou supérieur
- Package NuGet : Spectre.Console (v0.49.1)

## Installation

```bash
# Cloner le dépôt
git clone https://github.com/bafodej/duelguerrier.git
cd duelguerrier

# Restaurer les dépendances
dotnet restore

# Compiler le projet
dotnet build
```

## Utilisation

```bash
# Lancer l'application
dotnet run
```

Suivez ensuite les instructions à l'écran pour :
1. Sélectionner ou créer votre premier combattant
2. Sélectionner ou créer votre second combattant
3. Regarder le combat se dérouler tour par tour

## Exemple de Combat

```
Tour de combat !
Nom : Lancelot ; PV = 35 ; Nombres d'attaques = 3
Nom : Gimli ; PV = 40 ; Nombres d'attaques = 2

Lancelot attaque Gimli !
Lancelot inflige 12 de dégât !
Gimli a 34 PV restants.
```

## Licence

Projet éducatif - Libre d'utilisation
