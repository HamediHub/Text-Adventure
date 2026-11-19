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
            OutputHelper.PrintLineNoReadKey("Erstelle einen neuen Spieler.");
            
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
            newPlayer.Inventory.Add("taschenmesser");

            Console.Clear();
            OutputHelper.ColorPrint(newPlayer.Name, ConsoleColor.Blue);
            OutputHelper.PrintLineNoReadKey(" wurde erfolgreich erstellt.");
            OutputHelper.Print("Drücke eine beliebige Taste, um fortzufahren...");
            Console.ReadKey(true);

            return newPlayer;
        }

        public Player SelectPlayer()
        {
            OutputHelper.PrintLineNoReadKey("Wähle einen Spieler");
            List<Player> players = GetPlayers();

            int count = 0;
            foreach (Player player in players)
            {
                count++;
                OutputHelper.PrintLineNoReadKey(count + ": " + player.Name);
            }

            int input = InputHelper.GetIntInput(1, count);

            Player selectedPlayer = players[input - 1];

            Console.Clear();
            OutputHelper.ColorPrint(selectedPlayer.Name, ConsoleColor.Blue);
            OutputHelper.PrintLineNoReadKey(" wurde erfolgreich ausgewählt.");
            OutputHelper.Print("Drücke eine beliebige Taste, um fortzufahren...");
            Console.ReadKey(true);

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
            OutputHelper.Print("Drücke eine beliebige Taste, um fortzufahren...");
            Console.ReadKey(true);
        }

        public void DeletePlayer(int id)
        {
            List<Player> players = GetPlayers();
            if (players == null)
            {
                return;
            }

            if (players.Exists(p => p.Id == id))
            {
                players.RemoveAll(p => p.Id == id);
            }

            string json = JsonConvert.SerializeObject(players);

            string jsonPath = @"..\..\data\players.json";
            File.WriteAllText(jsonPath, json);
        }

    }
}
