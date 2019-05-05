
namespace RpsGame.Client.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpsGame.Core;
    using RpsGame.Core.Utils;
    using RpsGame.Core.Weapons;

    class Program
    {
        private static readonly Random random = new Random();

        private static Dictionary<string, BaseWeapon> availableWeapons;

        static void Main(string[] args)
        {
            availableWeapons = WeaponUtils.GetAvailableWeapons();
            RunWithConsoleInteraction();
        }

        private static void RunWithConsoleInteraction()
        {
            var option = string.Empty;
            while (string.IsNullOrWhiteSpace(option))
            {
                Console.Clear();
                Console.WriteLine("Welcome to the RPS GAME!!!!!\n");
                Console.WriteLine($"Choose an option:");
                Console.WriteLine("(1) - New single player match");
                Console.WriteLine("(9) - Quit");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        RunSinglePlayerMatch();
                        break;
                    case "9":
                        return;
                    default:
                        Console.Write($"\nInvalid option. ");
                        break;
                }

                option = string.Empty;
                Console.WriteLine("Press a key to continue.");
                Console.ReadLine();
            }
        }

        private static void RunSinglePlayerMatch()
        {
            var player1Name = GetPlayerName();
            var player1Weapon = availableWeapons.GetValueOrDefault(GetWeaponChoice());
            var player1 = new Player(player1Name, player1Weapon);

            var player2Name = "AI";
            var player2Weapon = availableWeapons.GetValueOrDefault(random.Next(1, 3).ToString());
            var player2 = new Player(player2Name, player2Weapon);

            var match = new Match(player1, player2);
            match.TryRun();

            Console.Write($"\n{player1.Name} ({player1.Weapon.Name}) Vs. {player2.Name} ({player2.Weapon.Name}). ");

            if (match.Result != MatchResult.OneWinner)
                Console.WriteLine($"It's a {match.Result}!!!\n\n");
            else
                Console.WriteLine(match.WinnerId == player1.Id ? "You won!!!\n\n" : "You lost. Try again.\n\n");
        }

        private static string GetPlayerName()
        {
            Console.Clear();
            Console.WriteLine("What's your player name?");
            var inputName = Console.ReadLine();
            return string.IsNullOrWhiteSpace(inputName) ? "Player1" : inputName;
        }

        private static string GetWeaponChoice()
        {
            var playerChoice = string.Empty;
            while (string.IsNullOrWhiteSpace(playerChoice))
            {
                Console.Clear();
                Console.WriteLine($"Choose your hand:");
                availableWeapons.ToList().ForEach(w => Console.WriteLine($"({w.Key}) - {w.Value.Name}"));
                playerChoice = Console.ReadLine();

                if (availableWeapons.ContainsKey(playerChoice))
                    return playerChoice;

                playerChoice = string.Empty;
                Console.WriteLine($"\nInvalid option. Press a key to continue.");
                Console.ReadLine();
            }
            return playerChoice;
        }
    }
}
