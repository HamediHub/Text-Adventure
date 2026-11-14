using CreateYourOwnAdventure.helper;
using CreateYourOwnAdventure.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CreateYourOwnAdventure.service
{
    internal class PlayerService
    {

        public List<Player> GetPlayers()
        {
            string jsonPath = @"..\..\data\players.json";
            string json = File.ReadAllText(jsonPath);

            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(json);

            return players;
        }

        public Player CreateNewPlayer()
        {
            OutputHelper.PrintLineNoReadKey("Erstellen Sie einen neuen Spieler.");
            OutputHelper.Print("Name: ");

            string playerName = InputHelper.GetNameInput();

            List<Player> players = GetPlayers();

            int newUniqueId = 1;
            if (players != null)
            {
                while (players.Exists(p => p.Id == newUniqueId))
                {
                    newUniqueId++;
                }
            }
            
            Player newPlayer = new Player(playerName, newUniqueId);

            Console.Clear();
            OutputHelper.ColorPrint(newPlayer.Name, ConsoleColor.Blue);
            OutputHelper.PrintLineNoReadKey(" wurde erfolgreich erstellt.");
            OutputHelper.PrintLine("Drücken Sie eine beliebige Taste, um fortzufahren...");

            return newPlayer;
        }

        public Player SelectPlayer()
        {
            OutputHelper.PrintLineNoReadKey("Wählen Sie einen Spieler");
            List<Player> players = GetPlayers();

            int count = 0;
            foreach (Player player in players)
            {
                count++;
                OutputHelper.PrintLineNoReadKey(count + ": " + player.Name + " (" + player.CurrentNode + ")");
            }

            int input = InputHelper.GetIntInput(1, count);

            Player selectedPlayer = players[input - 1];

            Console.Clear();
            OutputHelper.ColorPrint(selectedPlayer.Name, ConsoleColor.Blue);
            OutputHelper.PrintLineNoReadKey(" wurde erfolgreich ausgewählt.");
            OutputHelper.PrintLine("Drücken Sie eine beliebige Taste, um fortzufahren...");

            return selectedPlayer;
        }

        public void SavePlayer(Player player)
        {

            List<Player> players = GetPlayers();
            if (players == null)
            {
                players = new List<Player>();
            }

            if (players.Exists(p => p.Id == player.Id))
            {
                players.RemoveAll(p => p.Id == player.Id);
            }
            players.Add(player);

            string json = JsonConvert.SerializeObject(players);

            string jsonPath = @"..\..\data\players.json";
            File.WriteAllText(jsonPath, json);

            Console.Clear();
            OutputHelper.ColorPrint(player.Name, ConsoleColor.Blue);
            OutputHelper.PrintLineNoReadKey(" wurde erfolgreich gespeichert.");
            OutputHelper.PrintLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
        }

    }
}
