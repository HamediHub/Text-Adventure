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
            String jsonPath = @"..\..\data\players.json";
            String json = File.ReadAllText(jsonPath);

            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(json);

            return players;
        }

        public Player CreateNewPlayer()
        {
            Console.WriteLine("Erstellen Sie einen neuen Spieler.");
            Console.WriteLine("Name:");

            Player newPlayer = new Player(Console.ReadLine());
            SavePlayer(newPlayer);

            return newPlayer;
        }

        public Player SelectPlayer()
        {
            // Spielerauswahl implementieren
            return null;
        }

        public void SavePlayer(Player player)
        {
            List<Player> players = GetPlayers();
            players.Add(player);

            String json = JsonConvert.SerializeObject(players);

            String jsonPath = @"..\..\data\players.json";
            File.WriteAllText(jsonPath, json);
        }

    }
}
